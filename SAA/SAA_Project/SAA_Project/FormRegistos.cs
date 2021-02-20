using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAA_Project
{
    public partial class FormRegistos : Form
    {
        private int currentAluno;
        private int currentRegisto;
        private int nota_ver = 0;

        public FormRegistos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void FormRegistos_Load(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.Aluno", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listAlunos.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listAlunos.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();
        }
        public void ShowAluno()
        {
            if (listAlunos.Items.Count == 0 | currentAluno < 0)
                return;
            Aluno aluno = new Aluno();
            aluno = (Aluno)listAlunos.Items[currentAluno];
            nomeAluno.Text = aluno.Nome;
            nmecAluno.Text = aluno.NMEC;
            emailAluno.Text = aluno.Email;
            idHorarioAluno.Text = aluno.ID_Horario;
            idCursoAluno.Text = aluno.ID_Curso;

            n_Alunos.Text = listAlunos.Items.Count.ToString();
        }

        private void listAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAlunos.SelectedIndex >= 0)
            {
                currentAluno = listAlunos.SelectedIndex;

                id_uc_nota.Visible = false;
                NMEC_nota.Visible = false;
                nota_Nota.Visible = false;
                labelnmecadd.Visible = false;
                labelucadd.Visible = false;
                labelnotaadd.Visible = false;
                //id_aval_nota.Visible = false;
                //labelid_aval.Visible = false;
                confirmBtn.Visible = false;
                notaBtn.Visible = true;


                ShowAluno();
                ListarRegistos();
                ListarFN();         

                int n_registos = listRegistos.Items.Count;
                Console.WriteLine(n_registos);
                if (n_registos == 0)
                {
                    eliminarBtn.Visible = false;
                    updateBtn.Visible = false;

                    id_registo.Text = "";
                    nmecRegisto.Text = "";
                    id_uc_Registo.Text = "";
                    id_Aval_Registo.Text = "";
                    id_nota.Text = "";
                    notaBox.Text = "";
                    id_falta.Text = "";
                    comboBoxtipoFalta.SelectedIndex = -1;
                }
                else
                {
                    eliminarBtn.Visible = true;
                    updateBtn.Visible = true;
                }
            }
        }

        private void ListarRegistos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "SELECT * FROM SAA.REGISTOS_DO_NMEC ( @NMEC )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NMEC", nmecAluno.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            listRegistos.Items.Clear();

            while (reader.Read())
            {

                Registo R = new Registo();
                R.ID_Registo = reader["ID_Registo"].ToString();
                R.NMEC = reader["NMEC"].ToString();
                R.ID_UC = reader["ID_UC"].ToString();
                R.ID_Aval = reader["ID_Aval"].ToString();

                listRegistos.Items.Add(R);
            }
            BDconnection.getConnection().Close();

            currentRegisto = 0;
            ShowRegisto();
        }

        private void ShowRegisto()
        {
            if (listRegistos.Items.Count == 0 | currentRegisto < 0)
                return;
            Registo R = new Registo();
            R = (Registo)listRegistos.Items[currentRegisto];
            id_registo.Text = R.ID_Registo.ToString();
            nmecRegisto.Text = R.NMEC;
            id_uc_Registo.Text = R.ID_UC;
            id_Aval_Registo.Text = R.ID_Aval;

        }

        private void ListarFN()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.INFO_REGISTO @ID_Registo";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Registo", id_registo.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Falta_Nota FN = new Falta_Nota();
                Registo R = new Registo();
                try
                {
                    R.ID_Registo = reader["ID_Registo"].ToString();
                    R.ID_Nota = reader["ID_Nota"].ToString();
                    R.Nota = reader["Nota"].ToString();
                    R.NMEC = reader["NMEC"].ToString();
                    R.ID_UC = reader["ID_UC"].ToString();
                    R.ID_Aval = reader["ID_Aval"].ToString();

                    id_nota.Text = R.ID_Nota;
                    notaBox.Text = R.Nota;
                    nmecRegisto.Text = R.NMEC;
                    id_uc_Registo.Text = R.ID_UC;
                    id_Aval_Registo.Text = R.ID_Aval;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Nao e nota");
                }

                try
                {
                    R.ID_Registo = reader["ID_Registo"].ToString();
                    R.NMEC = reader["NMEC"].ToString();
                    R.ID_UC = reader["ID_UC"].ToString();
                    R.ID_Aval = reader["ID_Aval"].ToString();
                    R.ID_Falta = reader["ID_Falta"].ToString();
                    R.tipoFalta = reader["tipo_Falta"].ToString();

                    id_falta.Text = R.ID_Falta;
                    nmecRegisto.Text = R.NMEC;
                    id_uc_Registo.Text = R.ID_UC;
                    id_Aval_Registo.Text = R.ID_Aval;
                    comboBoxtipoFalta.Text = R.tipoFalta;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nao e falta");
                }

            }

            BDconnection.getConnection().Close();

            currentRegisto = 0;
            //ShowFN();
        }


        private void listRegistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRegistos.SelectedIndex >= 0)
            {
                currentRegisto = listRegistos.SelectedIndex;

                comboBoxtipoFalta.Enabled = false;
                nota_Nota.ReadOnly = true;

                clearFields();
                ShowRegisto();
                ListarFN();
                ShowAluno();
            }
        }

        private void confirmBtn2_Click(object sender, EventArgs e)
        {
            id_uc_nota.Visible = true;
            NMEC_nota.Visible = true;
            nota_Nota.Visible = true;
            labelnmecadd.Visible = true;
            labelucadd.Visible = true;
            labelnotaadd.Visible = true;
            //id_aval_nota.Visible = true;
            //labelid_aval.Visible = true;
            confirmBtn.Visible = true;
            notaBtn.Visible = false;

            //id_aval_nota.ReadOnly = false;
            id_uc_nota.ReadOnly = false;
            nota_Nota.ReadOnly = false;
            NMEC_nota.Text = nmecAluno.Text;

            cancel_nota.Visible = true;
        }

        private void notaBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty(NMEC_nota.Text) || String.IsNullOrEmpty(id_uc_nota.Text) || String.IsNullOrEmpty(nota_Nota.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");
            }
            else
            {
                try
                {
                    cmd.CommandText = "EXEC SAA.addNota @NMEC, @ID_UC, @ID_AVAL, @Nota";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NMEC", NMEC_nota.Text);
                    cmd.Parameters.AddWithValue("@ID_UC", id_uc_nota.Text);
                    cmd.Parameters.AddWithValue("@ID_AVAL", id_uc_nota.Text); //id_aval_nota.Text); //TODO: MUDAR PARA UC
                    cmd.Parameters.AddWithValue("@Nota", nota_Nota.Text);

                    cmd.ExecuteNonQuery();
                    string output = String.Format("Nota: {0} adicionada ao NMEC: {1}", nota_Nota.Text, NMEC_nota.Text);
                    MessageBox.Show(output);
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }
                catch
                {
                    MessageBox.Show("Ditite os campos corretamente");
                }


                id_uc_nota.Visible = false;
                NMEC_nota.Visible = false;
                nota_Nota.Visible = false;
                labelnmecadd.Visible = false;
                labelucadd.Visible = false;
                labelnotaadd.Visible = false;
                //id_aval_nota.Visible = false;
                //labelid_aval.Visible = false;
                confirmBtn.Visible = false;
                notaBtn.Visible = true;

                //id_aval_nota.ReadOnly = true;
                id_uc_nota.ReadOnly = true;
                nota_Nota.ReadOnly = true;
                cancel_nota.Visible = false;
                ShowRegisto();
                ListarRegistos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nmecfalta.Text = nmecAluno.Text;

            ucfalta.Visible = true;
            nmecfalta.Visible = true;
            tipoFaltaCombo.Visible = true;
            labelnmecfalta.Visible = true;
            labelucfalta.Visible = true;
            labeltipofalta.Visible = true;

            confirmFaltaBtn.Visible = true;
            faltaBtn.Visible = false;

            ucfalta.ReadOnly = false;
            cancel_falta.Visible = true;
        }

        private static void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                MessageBox.Show("ERRO SQL");
            }
            Console.ReadLine();
        }

        private void filtros_btn_Click(object sender, EventArgs e)
        {
            labelDepf.Visible = true;
            comboBoxDep.Visible = true;
            labelcursof.Visible = true;
            comboBoxCurso.Visible = true;
            labelturmaf.Visible = true;
            comboBoxTurma.Visible = true;
            hideBtn.Visible = true;
            filtros_btn.Visible = false;

            Nome_Dep();
            Nome_Cursos();
            N_TURMAS();
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            labelDepf.Visible = false;
            comboBoxDep.Visible = false;
            labelcursof.Visible = false;
            comboBoxCurso.Visible = false;
            labelturmaf.Visible = false;
            comboBoxTurma.Visible = false;
            hideBtn.Visible = false;
            filtros_btn.Visible = true;
        }

        //add nome dos departamentos à combo box
        private void Nome_Dep()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            //SqlCommand cmd = new SqlCommand("EXEC SAA.NOME_DEPARTAMENTOS", BDconnection.getConnection());       //TODO:
            SqlCommand cmd = new SqlCommand("SELECT Nome_Dep FROM SAA.DEPARTAMENTO", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxDep.Items.Add(reader["Nome_Dep"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void clearFields()
        {
            comboBoxtipoFalta.SelectedItem = null;
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }
        }

        private void confirmFaltaBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty(nmecfalta.Text) || String.IsNullOrEmpty(ucfalta.Text) || tipoFaltaCombo.SelectedItem == null)
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");
            }
            else
            {
                try
                {
                    cmd.CommandText = "EXEC SAA.addFalta @NMEC, @ID_UC, @ID_AVAL, @TipoFalta";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NMEC", nmecAluno.Text);
                    cmd.Parameters.AddWithValue("@ID_UC", ucfalta.Text);
                    cmd.Parameters.AddWithValue("@ID_AVAL", ucfalta.Text); //idavalfalta.Text);
                    cmd.Parameters.AddWithValue("@TipoFalta", tipoFaltaCombo.SelectedItem);

                    cmd.ExecuteNonQuery();
                    string output = String.Format("Falta: {0} adicionada ao NMEC: {1}", tipoFaltaCombo.SelectedItem, nmecAluno.Text);
                    MessageBox.Show(output);
                }

                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }
                catch
                {
                    MessageBox.Show("Ditite os campos corretamente");
                }

                ucfalta.Visible = false;
                nmecfalta.Visible = false;
                tipoFaltaCombo.Visible = false;
                //idavalfalta.Visible = false;
                labelnmecfalta.Visible = false;
                labelucfalta.Visible = false;
                labeltipofalta.Visible = false;
                //labelidaval.Visible = false;

                confirmFaltaBtn.Visible = false;
                faltaBtn.Visible = true;

                ucfalta.ReadOnly = true;
                //idavalfalta.ReadOnly = true;

                ShowRegisto();
                ListarRegistos();
                cancel_falta.Visible = false;
            }
        }

        private void comboBoxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "SELECT * FROM SAA.ALUNO_DE_DEPARTAMENTO ( @Nome_Dep )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome_Dep", (String)comboBoxDep.SelectedItem);


            SqlDataReader reader = cmd.ExecuteReader();
            listAlunos.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();

                listAlunos.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxCurso.Text = "";
            comboBoxTurma.Text = "";
        }

        private void comboBoxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "SELECT * FROM SAA.ALUNOS_DO_CURSO_UDF ( @NOME_CURSO )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NOME_CURSO", (String)comboBoxCurso.SelectedItem);


            SqlDataReader reader = cmd.ExecuteReader();
            listAlunos.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listAlunos.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();
            comboBoxDep.Text = "";
            comboBoxTurma.Text = "";
        }

        //add nome dos cursos a combobox
        private void Nome_Cursos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.NOME_CURSOS", BDconnection.getConnection());                  //TODO:
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCurso.Items.Add(reader["Nome_Curso"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "SELECT * FROM SAA.ALUNOS_DA_TURMA_UDF ( @ID_Turma )";                             //TODO:--
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Turma", Int32.Parse((String)comboBoxTurma.SelectedItem));


            SqlDataReader reader = cmd.ExecuteReader();
            listAlunos.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listAlunos.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxCurso.Text = "";
            comboBoxDep.Text = "";
        }
        //add n_turmas a combobox
        private void N_TURMAS()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            //SqlCommand cmd = new SqlCommand("EXEC SAA.N_TURMAS", BDconnection.getConnection());             //TODO:
            SqlCommand cmd = new SqlCommand("SELECT ID_TURMA FROM SAA.TURMA", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxTurma.Items.Add(reader["ID_TURMA"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;

            if (String.IsNullOrEmpty(id_registo.Text))
            {
                MessageBox.Show("Selecione um Registo para Apagar");
            }
            else
            {
                Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

                if (obj.ToString().Equals("Yes"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = BDconnection.getConnection();

                    cmd.CommandText = "EXEC SAA.delRegisto @ID_Registo";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID_Registo", id_registo.Text);

                    cmd.ExecuteNonQuery();
                    BDconnection.getConnection().Close();

                    string output = String.Format("Registo:{0} Eliminado", id_registo.Text);
                    MessageBox.Show(output);

                    ListarRegistos();
                    ListarFN();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancelarBtn.Visible = true;
            eliminarBtn.Visible = false;
            confirmUpdateBtn.Visible = true;
            updateBtn.Visible = false;

            id_uc_Registo.ReadOnly = false;
            //id_Aval_Registo.ReadOnly = false;

            if (String.IsNullOrEmpty(id_falta.Text))
            {
                notaBox.ReadOnly = false;
            }
            if (String.IsNullOrEmpty(id_nota.Text))
            {
                comboBoxtipoFalta.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBoxtipoFalta.Enabled = false;
            notaBox.ReadOnly = true;
            confirmUpdateBtn.Visible = false;
            cancelarBtn.Visible = false;
            eliminarBtn.Visible = true;
            confirmUpdateBtn.Visible = false;
            updateBtn.Visible = true;

            id_uc_Registo.ReadOnly = true;
            //id_Aval_Registo.ReadOnly = true;
        }

        private void confirmUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;

            Registo R = new Registo();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            if (String.IsNullOrEmpty(id_falta.Text))
            {
                if (String.IsNullOrEmpty(id_uc_Registo.Text) || String.IsNullOrEmpty(notaBox.Text))         //id_aval????
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        cmd.CommandText = "EXEC SAA.updateNota @ID_Nota, @Nota, @ID_Registo, @ID_UC, @ID_Aval ";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ID_Nota", Int32.Parse(id_nota.Text));
                        cmd.Parameters.AddWithValue("@Nota", Decimal.Parse(notaBox.Text));
                        cmd.Parameters.AddWithValue("@ID_Registo", Int32.Parse(id_registo.Text));
                        cmd.Parameters.AddWithValue("@ID_UC", Int32.Parse(id_uc_Registo.Text));
                        cmd.Parameters.AddWithValue("@ID_Aval", Int32.Parse(id_uc_Registo.Text)); //Int32.Parse(id_Aval_Registo.Text));

                        cmd.ExecuteNonQuery();
                        string output = String.Format("Nota:{0} Atualizada", id_nota.Text);
                        MessageBox.Show(output);
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                    catch
                    {
                        MessageBox.Show("Ditite os campos corretamente");
                    }
                }
            }
            if (String.IsNullOrEmpty(id_nota.Text))
            {
                if (String.IsNullOrEmpty(id_uc_Registo.Text) || String.IsNullOrEmpty(comboBoxtipoFalta.Text))         //id_aval????
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        cmd.CommandText = "EXEC SAA.updateFalta @ID_FALTA, @TipoFalta, @ID_Registo, @ID_UC, @ID_Aval ";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ID_FALTA", Int32.Parse(id_falta.Text));
                        cmd.Parameters.AddWithValue("@TipoFalta", comboBoxtipoFalta.SelectedItem);
                        cmd.Parameters.AddWithValue("@ID_Registo", Int32.Parse(id_registo.Text));
                        cmd.Parameters.AddWithValue("@ID_UC", Int32.Parse(id_uc_Registo.Text));
                        cmd.Parameters.AddWithValue("@ID_Aval", Int32.Parse(id_uc_Registo.Text)); //Int32.Parse(id_Aval_Registo.Text));

                        cmd.ExecuteNonQuery();
                        string output = String.Format("Falta:{0} Atualizada", id_falta.Text);
                        MessageBox.Show(output);
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                    catch
                    {
                        MessageBox.Show("Ditite os campos corretamente");
                    }
                }
            }

            comboBoxtipoFalta.Enabled = false;
            notaBox.ReadOnly = true;
            confirmUpdateBtn.Visible = false;
            cancelarBtn.Visible = false;
            eliminarBtn.Visible = true;
            confirmUpdateBtn.Visible = false;
            updateBtn.Visible = true;
            id_uc_Registo.ReadOnly = true;
            //id_Aval_Registo.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }
        }

        private void comboBoxtipoFalta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormRegistos2 fRegistos2 = new FormRegistos2();
            fRegistos2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            id_uc_nota.Visible = false;
            NMEC_nota.Visible = false;
            nota_Nota.Visible = false;
            labelnmecadd.Visible = false;
            labelucadd.Visible = false;
            labelnotaadd.Visible = false;

            confirmBtn.Visible = false;
            notaBtn.Visible = true;

            //id_uc_nota.ReadOnly = true;
           // nota_Nota.ReadOnly = true;
            //NMEC_nota.Text = nmecAluno.Text;

            cancel_nota.Visible = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            ucfalta.Visible = false;
            nmecfalta.Visible = false;
            tipoFaltaCombo.Visible = false;
            labelnmecfalta.Visible = false;
            labelucfalta.Visible = false;
            labeltipofalta.Visible = false;

            confirmFaltaBtn.Visible = false;
            faltaBtn.Visible = true;

            ucfalta.ReadOnly = true;
            cancel_falta.Visible = false;
        }
    }

}
