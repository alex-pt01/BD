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
    public partial class FormHorario : Form
    {
        private int currentHorario;
        private int currentAluno;
        private string current_id_horario;
        private int currentProfessor;
        private int currentTurma;
        private int currentUC;

        private int currentHorario2;        //teste
        private int currentProfessor2;
        private int currentAluno2;

        public FormHorario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void FormHorario_Load(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC SAA.IDS_HORARIOS", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listHorarios.Items.Clear();

            while (reader.Read())
            {

                Horario H = new Horario();
                H.ID_Horario = reader["ID_Horario"].ToString();

                listHorarios.Items.Add(H);
            }
            BDconnection.getConnection().Close();

            currentHorario = currentHorario2;
        }

        private void listaAlunos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.ALUNOS_DO_HORARIO @ID_Horario";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

            SqlDataReader reader = cmd.ExecuteReader();
            listaUsers.Items.Clear();

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

                listaUsers.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = currentAluno2;

            ShowAluno();
        }

        private void listaProfessor()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.PROFESSOR_DO_HORARIO @ID_Horario";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

            SqlDataReader reader = cmd.ExecuteReader();
            listaUsers.Items.Clear();

            while (reader.Read())
            {

                Professor prof = new Professor();
                prof.Nome = reader["Nome_Prof"].ToString();
                prof.TNMEC = (int)reader["TMEC"];
                prof.Email = reader["Email"].ToString();
                prof.numGabinete = (int)reader["Num_Gabinete"];
                prof.ID_Horario = (int)reader["ID_Horario"];
                prof.ID_Dep = (int)reader["ID_Dep"];

                listaUsers.Items.Add(prof);
            }
            BDconnection.getConnection().Close();

            currentProfessor = 0;
            ShowProfessor();
        }

        private void listaTurma()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.TURMAS_DO_HORARIO @ID_Horario";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

            SqlDataReader reader = cmd.ExecuteReader();
            listaUsers.Items.Clear();

            while (reader.Read())
            {

                Turma turma = new Turma();
                turma.ID_turma = (int)reader["ID_Turma"];
                turma.TNMEC = (int)reader["TNEMC"];
                turma.ID_Horario = (int)reader["ID_Horario"];
                turma.AnoLectivo = (int)reader["AnoLectivo"];

                listaUsers.Items.Add(turma);
            }
            BDconnection.getConnection().Close();

            currentTurma = 0;
            ShowTurma();
        }

        private void listaUC()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.UCS_DO_HORARIO @ID_Horario";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

            SqlDataReader reader = cmd.ExecuteReader();
            listaUsers.Items.Clear();

            while (reader.Read())
            {
                UC uc = new UC();
                uc.ID_UC = (int)reader["ID_UC"];
                uc.anoFormacao = reader["AnoFormacao"].ToString();
                uc.ID_Horario = (int)reader["ID_Horario"];
                uc.ID_Aval = (int)reader["ID_Aval"];

                listaUsers.Items.Add(uc);
            }
            BDconnection.getConnection().Close();

            currentUC = 0;
            ShowUC();
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

        private void listHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHorarios.Enabled = true;
            if (listHorarios.SelectedIndex >= 0)
            {
                currentHorario = listHorarios.SelectedIndex;
                current_id_horario = listHorarios.Items[currentHorario].ToString();

                if ((String)comboBoxHorarios.SelectedItem == "Aluno")
                {
                    listaAlunos();
                }
                if ((String)comboBoxHorarios.SelectedItem == "Professor")
                {
                    listaProfessor();
                }
                if ((String)comboBoxHorarios.SelectedItem == "Turma")
                {
                    listaTurma();
                }
                if ((String)comboBoxHorarios.SelectedItem == "UC")
                {
                    listaUC();
                }
            }
        }

        //lista box de users
        private void listBoxAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaUsers.SelectedIndex >= 0)
            {
                if ((String)comboBoxHorarios.SelectedItem == "Aluno")
                {
                    currentAluno = listaUsers.SelectedIndex;
                    ShowAluno();
                }
                if ((String)comboBoxHorarios.SelectedItem == "Professor")
                {
                    currentProfessor = listaUsers.SelectedIndex;
                    ShowProfessor();
                }
                if ((String)comboBoxHorarios.SelectedItem == "Turma")
                {
                    currentTurma = listaUsers.SelectedIndex;
                    ShowTurma();
                }
                if ((String)comboBoxHorarios.SelectedItem == "UC")
                {
                    currentUC = listaUsers.SelectedIndex;
                    ShowUC();
                }
            }
        }

        private void comboBoxHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaUsers.Visible = true;
            labelnmec2.Visible = true;
            labelnome2.Visible = true;

            clearFields();
            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {
                listaAlunos();
            }
            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {
                listaProfessor();
            }

            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                listaTurma();
            }

            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                listaUC();
            }
        }

        public void ShowAluno()
        {
            labelNMEC_TUTOR.Text = "NMEC Tutor";
            labelIdade.Text = "Idade";
            labelCurso.Text = "Curso";
            labelNMEC.Text = "NMEC";
            labelEmail.Text = "Email";
            labelnmec2.Text = "NMEC";
            labelnome2.Text = "Nome";
            regimeEstudoAluno.Visible = true;
            idBibliotecaAluno.Visible = true;
            labelRegime.Visible = true;
            labelHorario.Visible = true;
            labelBiblio.Visible = true;
            //passAluno.Visible = true;
            idHorarioAluno.Visible = true;
            nomeAluno.Visible = true;
            idCursoAluno.Visible = true;
            labelNome.Visible = true;
            labelCurso.Visible = true;

            if (listaUsers.Items.Count == 0 | currentAluno < 0)
                return;

            Aluno aluno = new Aluno();
            aluno = (Aluno)listaUsers.Items[currentAluno];
            nomeAluno.Text = aluno.Nome.ToString();
            nmecAluno.Text = aluno.NMEC;
            emailAluno.Text = aluno.Email;
            regimeEstudoAluno.Text = aluno.RegimeEstudo;
            idHorarioAluno.Text = aluno.ID_Horario;
            idBibliotecaAluno.Text = aluno.ID_Biblioteca;
            idCursoAluno.Text = aluno.ID_Curso;
            nmecTutorAluno.Text = aluno.NMEC_Tutor;
            idadeAluno.Text = aluno.Idade;
        }

        public void ShowProfessor()
        {

            labelNMEC_TUTOR.Text = "Departamento";
            labelIdade.Text = "Gabinete";
            labelCurso.Text = "Horario";
            labelNMEC.Text = "TNMEC";
            labelEmail.Text = "Email";
            labelnmec2.Text = "TNMEC";
            labelnome2.Text = "Nome";
            regimeEstudoAluno.Visible = false;
            idBibliotecaAluno.Visible = false;
            labelRegime.Visible = false;
            labelHorario.Visible = false;
            labelBiblio.Visible = false;
            //passAluno.Visible = false;
            idHorarioAluno.Visible = false;
            nomeAluno.Visible = true;
            idCursoAluno.Visible = true;
            labelNome.Visible = true;
            labelCurso.Visible = true;
            //nmecAluno.ReadOnly = true;

            //idCursoAluno.Text = current_id_horario;

            if (listaUsers.Items.Count == 0 | currentProfessor < 0)
                return;

            Professor prof = new Professor();
            prof = (Professor)listaUsers.Items[currentProfessor];
            nomeAluno.Text = prof.Nome.ToString();
            nmecAluno.Text = prof.TNMEC.ToString();
            emailAluno.Text = prof.Email;
            idadeAluno.Text = prof.numGabinete.ToString();
            nmecTutorAluno.Text = prof.ID_Dep.ToString();
            idCursoAluno.Text = prof.ID_Horario.ToString();
        }

        private void ShowTurma()
        {
            labelNome.Visible = false;
            nomeAluno.Visible = false;
            labelEmail.Text = "Ano Letivo";
            labelIdade.Text = "TNMEC";
            labelCurso.Visible = false;
            idCursoAluno.Visible = false;
            labelnmec2.Text = "ID";
            labelnome2.Text = "Ano Letivo";
            labelNMEC_TUTOR.Text = "ID_Horario";
            labelNMEC.Text = "Turma";
            regimeEstudoAluno.Visible = false;
            idBibliotecaAluno.Visible = false;
            labelRegime.Visible = false;
            labelHorario.Visible = false;
            labelBiblio.Visible = false;
            //passAluno.Visible = false;
            idHorarioAluno.Visible = false;

            if (listaUsers.Items.Count == 0 | currentTurma < 0)
                return;

            Turma turma = new Turma();
            turma = (Turma)listaUsers.Items[currentTurma];
            nmecAluno.Text = turma.ID_turma.ToString();
            emailAluno.Text = turma.AnoLectivo.ToString();
            idadeAluno.Text = turma.TNMEC.ToString();
            nmecTutorAluno.Text = turma.ID_Horario.ToString();

        }

        private void ShowUC()
        {
            labelNome.Visible = false;
            nomeAluno.Visible = false;
            labelEmail.Text = "Ano Formacao";
            labelIdade.Text = "Avaliacao";
            labelCurso.Visible = false;
            idCursoAluno.Visible = false;
            labelnmec2.Text = "ID";
            labelnome2.Text = "Ano Formacao";
            labelNMEC_TUTOR.Text = "ID_Horario";
            labelNMEC.Text = "UC";
            regimeEstudoAluno.Visible = false;
            idBibliotecaAluno.Visible = false;
            labelRegime.Visible = false;
            labelHorario.Visible = false;
            labelBiblio.Visible = false;
            //passAluno.Visible = false;
            idHorarioAluno.Visible = false;

            if (listaUsers.Items.Count == 0 | currentUC < 0)
                return;


            UC uc = new UC();
            uc = (UC)listaUsers.Items[currentUC];
            nmecAluno.Text = uc.ID_UC.ToString();
            emailAluno.Text = uc.anoFormacao.ToString();
            idadeAluno.Text = uc.ID_Aval.ToString();
            nmecTutorAluno.Text = uc.ID_Horario.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {
                confirmBtn.Visible = true;
                cancelarBtn.Visible = true;
                adicionarBtn.Visible = false;
                updateBtn.Visible = false;
                eliminarBtn.Visible = false;
                confirmBtn2.Visible = false;
                limparBtn.Visible = true;


                nomeAluno.ReadOnly = false;
                emailAluno.ReadOnly = false;
                nmecTutorAluno.ReadOnly = false;
                idadeAluno.ReadOnly = false;
                idCursoAluno.ReadOnly = false;
                idBibliotecaAluno.ReadOnly = false;
                idHorarioAluno.ReadOnly = true;
                //passAluno.ReadOnly = false;

                regimeEstudoAluno.Enabled = true;
                idHorarioAluno.Text = current_id_horario;
            }

            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {
                confirmBtn.Visible = true;
                cancelarBtn.Visible = true;
                adicionarBtn.Visible = false;
                updateBtn.Visible = false;
                eliminarBtn.Visible = false;
                confirmBtn2.Visible = false;
                limparBtn.Visible = true;


                idCursoAluno.Text = current_id_horario;
                nmecAluno.ReadOnly = true;
                idCursoAluno.ReadOnly = true;
                nmecTutorAluno.ReadOnly = false;

                nomeAluno.ReadOnly = false;
                emailAluno.ReadOnly = false;
                idadeAluno.ReadOnly = false;
                idBibliotecaAluno.ReadOnly = false;
                idHorarioAluno.ReadOnly = true;

                regimeEstudoAluno.Enabled = true;
            }

            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                confirmBtn.Visible = true;
                cancelarBtn.Visible = true;
                adicionarBtn.Visible = false;
                updateBtn.Visible = false;
                eliminarBtn.Visible = false;
                confirmBtn2.Visible = false;
                limparBtn.Visible = true;


                nomeAluno.ReadOnly = false;
                emailAluno.ReadOnly = false;
                nmecTutorAluno.ReadOnly = true;
                idadeAluno.ReadOnly = false;
                idCursoAluno.ReadOnly = false;
                idBibliotecaAluno.ReadOnly = false;
                idHorarioAluno.ReadOnly = true;
                //passAluno.ReadOnly = false;

                regimeEstudoAluno.Enabled = true;
                //idHorarioAluno.Text = current_id_horario;
            }

            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                confirmBtn.Visible = true;
                cancelarBtn.Visible = true;
                adicionarBtn.Visible = false;
                updateBtn.Visible = false;
                eliminarBtn.Visible = false;
                confirmBtn2.Visible = false;
                limparBtn.Visible = true;


                nomeAluno.ReadOnly = false;
                emailAluno.ReadOnly = false;
                nmecTutorAluno.ReadOnly = false;
                idadeAluno.ReadOnly = false;
                idCursoAluno.ReadOnly = false;
                idBibliotecaAluno.ReadOnly = false;
                idHorarioAluno.ReadOnly = true;
                //passAluno.ReadOnly = false;

                regimeEstudoAluno.Enabled = true;
                idHorarioAluno.Text = current_id_horario;
            }

        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {

            confirmBtn.Visible = false;
            confirmBtn2.Visible = false;
            adicionarBtn.Visible = true;
            updateBtn.Visible = true;
            eliminarBtn.Visible = true;
            cancelarBtn.Visible = false;
            limparBtn.Visible = false;

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
            //passAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;


            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {
                ShowAluno();
            }
            else if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {
                ShowProfessor();
            }
            else if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                ShowTurma();
            }
            else if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                ShowUC();
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {

                if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(nmecAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(regimeEstudoAluno.Text) || String.IsNullOrEmpty(idHorarioAluno.Text)) //|| String.IsNullOrEmpty(passAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        cmd.CommandText = "EXEC SAA.updateAluno @Nome, @NMEC, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@Nome", nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@NMEC", Int32.Parse(nmecAluno.Text));
                        cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@RegimeEstudo", (String)regimeEstudoAluno.SelectedItem);
                        cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(current_id_horario));
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
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }

                    currentAluno2 = currentAluno;
                    currentHorario2 = currentHorario;

                    FormHorario_Load(sender, e);
                    listaAlunos();
                    ShowAluno();

                    currentAluno = currentAluno2;
                    currentHorario = currentHorario2;

                }
            }

            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {

                if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(nmecTutorAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        labelNMEC_TUTOR.Text = "Departamento";
                        labelIdade.Text = "Gabinete";
                        labelCurso.Text = "Horario";
                        idCursoAluno.Text = current_id_horario;
                        cmd.CommandText = "SAA.update_Prof @Nome_Prof, @Num_Gabinete, @Email, @TMEC, @ID_DEP, @ID_Horario";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@Nome_Prof", nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@TMEC", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@ID_DEP", Int32.Parse(nmecTutorAluno.Text));
                        cmd.Parameters.AddWithValue("@Num_Gabinete", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }

                    
                    currentAluno2 = currentAluno;
                    currentHorario2 = currentHorario;

                    FormHorario_Load(sender, e);
                    listaProfessor();
                    ShowProfessor();

                    currentAluno = currentAluno2;
                    currentHorario = currentHorario2;
                    
                }
            }
            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                if (String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(nmecTutorAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        nmecTutorAluno.Text = current_id_horario;
                        cmd.CommandText = "EXEC SAA.updateTurma @idTurma,  @tnmec, @id_Horario, @anoLectivo ";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@idTurma", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@anoLectivo", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@id_Horario", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@tnmec", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaTurma();
                ShowTurma();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;

            }

            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                DateTime temp;
                if (String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || !DateTime.TryParse(emailAluno.Text, out temp))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos corretamente \n Ano Formacao é do tipo dd/mm/yyyy");
                }
                else
                {
                    try
                    {
                        nmecTutorAluno.Text = current_id_horario;
                        cmd.CommandText = "EXEC SAA.updateUC @ID_UC, @anoForm, @id_hor, @id_aval";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@ID_UC", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@anoForm", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@id_hor", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@id_aval", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaUC();
                ShowUC();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;

            }

            confirmBtn.Visible = false;
            confirmBtn2.Visible = false;
            cancelarBtn.Visible = false;
            adicionarBtn.Visible = true;
            updateBtn.Visible = true;
            eliminarBtn.Visible = true;
            limparBtn.Visible = false;

            nomeAluno.ReadOnly = true;
            emailAluno.ReadOnly = true;
            nmecTutorAluno.ReadOnly = true;
            idadeAluno.ReadOnly = true;
            idCursoAluno.ReadOnly = true;
            idBibliotecaAluno.ReadOnly = true;
            idHorarioAluno.ReadOnly = true;
            //passAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            confirmBtn.Visible = false;
            cancelarBtn.Visible = true;
            adicionarBtn.Visible = false;
            updateBtn.Visible = false;
            eliminarBtn.Visible = false;
            confirmBtn2.Visible = true;
            limparBtn.Visible = true;

            nomeAluno.ReadOnly = false;
            emailAluno.ReadOnly = false;
            //nmecAluno.ReadOnly = true;
            nmecTutorAluno.ReadOnly = false;
            idadeAluno.ReadOnly = false;
            idCursoAluno.ReadOnly = false;
            idBibliotecaAluno.ReadOnly = false;
            idHorarioAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = true;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }
            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {
                idHorarioAluno.Text = current_id_horario;
                nmecAluno.ReadOnly = true;
                idHorarioAluno.ReadOnly = true;
            }

            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {
                idCursoAluno.Text = current_id_horario;
                nmecAluno.ReadOnly = true;
                idCursoAluno.ReadOnly = true;
            }

            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                nmecTutorAluno.Text = current_id_horario;
                nmecTutorAluno.ReadOnly = true;
            }

            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                nmecTutorAluno.Text = current_id_horario;
                nmecTutorAluno.ReadOnly = true;
            }

            //idHorarioAluno.Text = current_id_horario;
        }

        private void confirmBtn2_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {

                if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(regimeEstudoAluno.Text) || String.IsNullOrEmpty(idHorarioAluno.Text)) //|| String.IsNullOrEmpty(passAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        cmd.CommandText = "EXEC SAA.addAluno @Nome, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@Nome", nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@RegimeEstudo", regimeEstudoAluno.SelectedItem);
                        cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(current_id_horario));       //Int32.Parse(idHorarioAluno.Text));
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
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentProfessor2 = currentProfessor;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaAlunos();
                ShowAluno();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;
            }

            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {
                if (String.IsNullOrEmpty(nomeAluno.Text) || String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(idCursoAluno.Text) || String.IsNullOrEmpty(nmecTutorAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        idCursoAluno.Text = current_id_horario;
                        cmd.CommandText = "EXEC SAA.addProf @Nome_Prof, @TMEC, @Email, @Num_Gabinete, @ID_DEP, @ID_Horario";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@Nome_Prof", nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@TMEC", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@Email", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@ID_DEP", Int32.Parse(nmecTutorAluno.Text));
                        cmd.Parameters.AddWithValue("@Num_Gabinete", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaProfessor();
                ShowProfessor();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;

            }
            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {
                if (String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || String.IsNullOrEmpty(nmecTutorAluno.Text))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos");
                }
                else
                {
                    try
                    {
                        nmecTutorAluno.Text = current_id_horario;
                        cmd.CommandText = "EXEC SAA.addTurma @ID, @TNMEC,  @ID_Horario, @AnoLetivo";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@ID", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@AnoLetivo", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@ID_Horario", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@TNMEC", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaTurma();
                ShowTurma();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;

            }

            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                DateTime temp;
                if ( String.IsNullOrEmpty(idadeAluno.Text) || String.IsNullOrEmpty(emailAluno.Text) || !DateTime.TryParse(emailAluno.Text, out temp))
                {
                    MessageBox.Show("Todos os campos devem estar preenchidos corretamente \n Ano Formacao é do tipo dd/mm/yyyy");
                }
                else
                {
                    try
                    {
                        nmecTutorAluno.Text = current_id_horario;
                        cmd.CommandText = "EXEC SAA.addUC @ID_UC, @anoForm, @id_horario, @id_aval";
                        cmd.Parameters.Clear();
                        MessageBox.Show(nomeAluno.Text);
                        cmd.Parameters.AddWithValue("@ID_UC", nmecAluno.Text);
                        cmd.Parameters.AddWithValue("@anoForm", emailAluno.Text);
                        cmd.Parameters.AddWithValue("@id_horario", Int32.Parse(current_id_horario));
                        cmd.Parameters.AddWithValue("@id_aval", Int32.Parse(idadeAluno.Text));

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaUC();
                ShowUC();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;

            }

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
            //passAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;
        }

        private void limparBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    if (ctrl != idHorarioAluno)
                    {
                        ctrl.Text = String.Empty;
                    }
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                if (!BDconnection.verifySGBDConnection())
                    return;

            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

            if (obj.ToString().Equals("Yes"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = BDconnection.getConnection();

                    cmd.CommandText = "EXEC SAA.deleteHorario @ID_Horario";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

                    cmd.ExecuteNonQuery();
                    BDconnection.getConnection().Close();
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }

                foreach (Control ctrl in Controls)
                {
                    if (ctrl is TextBoxBase)
                    {
                        ctrl.Text = String.Empty;
                    }
                }

                comboBoxHorarios.SelectedItem = null;
                listaUsers.Items.Clear();
                FormHorario_Load(sender, e);

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
                //passAluno.ReadOnly = true;

                regimeEstudoAluno.Enabled = false;
            }
        }

        private void adicionarHorarioBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.addHorario";
                cmd.Parameters.Clear();

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();
            }
            catch (SqlException ex)
            {
                DisplaySqlErrors(ex);
            }

            FormHorario_Load(sender, e);
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
            //passAluno.ReadOnly = true;

            regimeEstudoAluno.Enabled = false;
        }

        private static void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                //MessageBox.Show("Index #" + i + "\n" +
                //    "Error: " + exception.Errors[i].ToString() + "\n");
                MessageBox.Show("ERRO SQL");
            }
            Console.ReadLine();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHorario2 fhor2 = new FormHorario2();
            fhor2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            FormHorario2 fhor2 = new FormHorario2();
            fhor2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
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

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            if ((String)comboBoxHorarios.SelectedItem == "Aluno")
            {

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

                    FormHorario_Load(sender, e);
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
                    clearFields();
                    listaAlunos();
                }
            }
            if ((String)comboBoxHorarios.SelectedItem == "Professor")
            {

                Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

                if (obj.ToString().Equals("Yes"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = BDconnection.getConnection();

                    cmd.CommandText = "EXEC SAA.del_Professor @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", nmecAluno.Text);

                    cmd.ExecuteNonQuery();
                    BDconnection.getConnection().Close();

                    FormHorario_Load(sender, e);

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
                    clearFields();
                    listaProfessor();
                    ShowProfessor();
                }
            }
            if ((String)comboBoxHorarios.SelectedItem == "Turma")
            {

                Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

                if (obj.ToString().Equals("Yes"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = BDconnection.getConnection();

                    cmd.CommandText = "EXEC SAA.del_Turma @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", nmecAluno.Text);

                    cmd.ExecuteNonQuery();
                    BDconnection.getConnection().Close();

                    FormHorario_Load(sender, e);

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
                    clearFields();
                    listaTurma();
                    ShowTurma();
                }
            }
            if ((String)comboBoxHorarios.SelectedItem == "UC")
            {
                Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

                if (obj.ToString().Equals("Yes"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = BDconnection.getConnection();

                    try
                    {
                        cmd.CommandText = "EXEC SAA.delUC @ID_UC";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ID_UC", nmecAluno.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(nomeAluno.Text + " Eliminado com sucesso.");
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                }

                currentAluno2 = currentAluno;
                currentHorario2 = currentHorario;

                FormHorario_Load(sender, e);
                listaUC();
                ShowUC();

                currentAluno = currentAluno2;
                currentHorario = currentHorario2;
            }
        }

        private void clearFields()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
            }
        }
    }
}
