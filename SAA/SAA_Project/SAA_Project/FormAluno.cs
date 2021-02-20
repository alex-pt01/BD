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
using System.Data.SqlClient;

namespace SAA_Project
{
    public partial class FormAluno : Form
    {
        private int currentAluno;
        private int currentAluno2;

        public FormAluno()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.Aluno", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listAluno.Items.Clear();

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

                listAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

        }

        private void listAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAluno.SelectedIndex >= 0)
            {
                currentAluno = listAluno.SelectedIndex;
                ShowAluno();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void voltarAoMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu fMenu = new FormMenu();
            fMenu.ShowDialog();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            confirmBtn.Visible = true;
            cancelarBtn.Visible = true;
            adicionarBtn.Visible = false;
            updateBtn.Visible = false;
            confirmBtn2.Visible = false;
            limparBtn.Visible = true;
            eliminarBtn.Visible = false;



            nomeAluno.ReadOnly = false;
            emailAluno.ReadOnly = false;
            nmecTutorAluno.ReadOnly = false;
            idadeAluno.ReadOnly = false;
            idCursoAluno.ReadOnly = false;
            idBibliotecaAluno.ReadOnly = false;
            idHorarioAluno.ReadOnly = false;

            regimeEstudoAluno.Enabled = true;
        }

        private void confirmButon_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;
            Aluno aluno = new Aluno();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(nmecAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(regimeEstudoAluno.Text) || String.IsNullOrEmpty(idHorarioAluno.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");
            }
            else
            {
                try
                {
                    cmd.CommandText = "EXEC SAA.updateAluno @Nome, @NMEC, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Nome", nomeAluno.Text);
                    cmd.Parameters.AddWithValue("@NMEC", Int32.Parse(nmecAluno.Text));
                    cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                    cmd.Parameters.AddWithValue("@RegimeEstudo", (String)regimeEstudoAluno.SelectedItem);
                    cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(idHorarioAluno.Text));
                    cmd.Parameters.AddWithValue("@ID_Biblioteca", Int32.Parse(idBibliotecaAluno.Text));
                    if (!String.IsNullOrEmpty(nmecTutorAluno.Text))
                    {
                        cmd.Parameters.AddWithValue("@NMEC_TUTOR", Int32.Parse(nmecTutorAluno.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NMEC_TUTOR", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@Idade", Int32.Parse(idadeAluno.Text));
                    cmd.Parameters.AddWithValue("@ID_Curso", Int32.Parse(idCursoAluno.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aluno '" + nomeAluno.Text + "' Atualizado Com Sucesso!");
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }
            }

            FormAluno_Load(sender, e);
            ShowAluno();

            confirmBtn.Visible = false;
            confirmBtn2.Visible = false;
            cancelarBtn.Visible = false;
            adicionarBtn.Visible = true;
            updateBtn.Visible = true;
            limparBtn.Visible = false;
            eliminarBtn.Visible = true;


            nomeAluno.ReadOnly = true;
            emailAluno.ReadOnly = true;
            nmecTutorAluno.ReadOnly = true;
            idadeAluno.ReadOnly = true;
            idCursoAluno.ReadOnly = true;
            idBibliotecaAluno.ReadOnly = true;
            idHorarioAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            confirmBtn.Visible = false;
            confirmBtn2.Visible = false;
            adicionarBtn.Visible = true;
            updateBtn.Visible = true;
            cancelarBtn.Visible = false;
            limparBtn.Visible = false;
            eliminarBtn.Visible = true;


            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }

            nomeAluno.ReadOnly = true;
            nmecAluno.ReadOnly = true;
            emailAluno.ReadOnly = true;
            nmecTutorAluno.ReadOnly = true;
            idadeAluno.ReadOnly = true;
            idCursoAluno.ReadOnly = true;
            idBibliotecaAluno.ReadOnly = true;
            idHorarioAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;
        }

        private void confirmBtn2_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;
            Aluno aluno = new Aluno();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(regimeEstudoAluno.Text) || String.IsNullOrEmpty(idHorarioAluno.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");
            }
            else
            {
                try
                {
                    cmd.CommandText = "EXEC SAA.addAluno @Nome, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Nome", nomeAluno.Text);
                    cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                    cmd.Parameters.AddWithValue("@RegimeEstudo", regimeEstudoAluno.SelectedItem);
                    cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(idHorarioAluno.Text));
                    cmd.Parameters.AddWithValue("@ID_Biblioteca", Int32.Parse(idBibliotecaAluno.Text));
                    if (!String.IsNullOrEmpty(nmecTutorAluno.Text))
                    {
                        cmd.Parameters.AddWithValue("@NMEC_TUTOR", Int32.Parse(nmecTutorAluno.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NMEC_TUTOR", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@Idade", Int32.Parse(idadeAluno.Text));
                    cmd.Parameters.AddWithValue("@ID_Curso", Int32.Parse(idCursoAluno.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aluno '" + nomeAluno.Text + "' Adicionado Com Sucesso!");
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }

                FormAluno_Load(sender, e);
                ShowAluno();

                confirmBtn.Visible = false;
                confirmBtn2.Visible = false;
                cancelarBtn.Visible = false;
                adicionarBtn.Visible = true;
                updateBtn.Visible = true;
                limparBtn.Visible = false;
                eliminarBtn.Visible = true;


                nomeAluno.ReadOnly = true;
                emailAluno.ReadOnly = true;
                nmecAluno.ReadOnly = true;
                nmecTutorAluno.ReadOnly = true;
                idadeAluno.ReadOnly = true;
                idCursoAluno.ReadOnly = true;
                idBibliotecaAluno.ReadOnly = true;
                idHorarioAluno.ReadOnly = true;

                regimeEstudoAluno.Enabled = false;
            }
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            confirmBtn.Visible = false;
            cancelarBtn.Visible = true;
            adicionarBtn.Visible = false;
            updateBtn.Visible = false;
            confirmBtn2.Visible = true;
            limparBtn.Visible = true;
            eliminarBtn.Visible = false;


            nomeAluno.ReadOnly = false;
            emailAluno.ReadOnly = false;
            nmecAluno.ReadOnly = true;
            nmecTutorAluno.ReadOnly = false;
            idadeAluno.ReadOnly = false;
            idCursoAluno.ReadOnly = false;
            idBibliotecaAluno.ReadOnly = false;
            idHorarioAluno.ReadOnly = false;

            regimeEstudoAluno.Enabled = true;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }
        }



        public void ShowAluno()
        {
            if (listAluno.Items.Count == 0 | currentAluno < 0)
                return;
            Aluno aluno = new Aluno();
            aluno = (Aluno)listAluno.Items[currentAluno];
            nomeAluno.Text = aluno.Nome.ToString();
            nmecAluno.Text = aluno.NMEC;
            emailAluno.Text = aluno.Email;
            regimeEstudoAluno.Text = aluno.RegimeEstudo;
            idHorarioAluno.Text = aluno.ID_Horario;
            idBibliotecaAluno.Text = aluno.ID_Biblioteca;
            idCursoAluno.Text = aluno.ID_Curso;
            nmecTutorAluno.Text = aluno.NMEC_Tutor;
            idadeAluno.Text = aluno.Idade;

            n_Alunos.Text = listAluno.Items.Count.ToString();
        }




        private void label13_Click(object sender, EventArgs e)
        {

        }



        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void eliminarBtn_Click_1(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

            if (obj.ToString().Equals("Yes"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.del_Aluno @NMEC";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NMEC", nmecAluno.Text);

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();

                MessageBox.Show("Aluno '" + nomeAluno.Text + "' Eliminado Com Sucesso!");

                FormAluno_Load(sender, e);
                ShowAluno();

                confirmBtn.Visible = false;
                confirmBtn2.Visible = false;
                cancelarBtn.Visible = false;
                adicionarBtn.Visible = true;
                updateBtn.Visible = true;
                limparBtn.Visible = false;
                eliminarBtn.Visible = true;

                nomeAluno.ReadOnly = true;
                emailAluno.ReadOnly = true;
                nmecAluno.ReadOnly = true;
                nmecTutorAluno.ReadOnly = true;
                idadeAluno.ReadOnly = true;
                idCursoAluno.ReadOnly = true;
                idBibliotecaAluno.ReadOnly = true;
                idHorarioAluno.ReadOnly = true;

                regimeEstudoAluno.Enabled = false;
            }
        }

        private static void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                //MessageBox.Show("Index #" + i + "\n" +
                //   "Error: " + exception.Errors[i].ToString() + "\n");
                MessageBox.Show("ERRO SQL");
            }
            Console.ReadLine();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPerfilAluno fperfil = new FormPerfilAluno();
            fperfil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
