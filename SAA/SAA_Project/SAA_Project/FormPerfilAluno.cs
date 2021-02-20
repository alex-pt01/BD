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
    public partial class FormPerfilAluno : Form
    {

        private int currentAluno;
        private int ucs;

        public FormPerfilAluno()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            N_TURMAS();
            Nome_Cursos();
            Nome_Dep();
            N_BIBLIOS();
        }

        private void FormPerfilAluno_Load(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.Aluno", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBoxAluno.Items.Clear();

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

                listBoxAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();
        }

        private void listBoxAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAluno.SelectedIndex >= 0)
            {
                currentAluno = listBoxAluno.SelectedIndex;

                clearFields();
                ShowAluno();
                ListaUCs();
            }
        }

        private void ListaUCs()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.UCS_DO_ALUNO ( @NMEC ) ", BDconnection.getConnection());
            cmd.Parameters.AddWithValue("@NMEC", nmecAluno.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            listUCs.Items.Clear();

            while (reader.Read())
            {
                ucs = (int)reader["ID_UC"];
                listUCs.Items.Add(ucs);
            }
            BDconnection.getConnection().Close();
            n_ucs.Text = listUCs.Items.Count.ToString();
        }

        //add nome dos departamentos à combo box
        private void Nome_Dep()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("SELECT Nome_Dep FROM SAA.DEPARTAMENTO", BDconnection.getConnection()); 
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxDep.Items.Add(reader["Nome_Dep"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //mostrar alunos de um departamento
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
            listBoxAluno.Items.Clear();

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

                listBoxAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxCurso.Text = "";
            comboBoxTurma.Text = "";
            comboBoxBiblio.Text = "";

        }

        //add nome dos cursos a combobox
        private void Nome_Cursos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.NOME_CURSOS", BDconnection.getConnection());      //TODO:
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCurso.Items.Add(reader["Nome_Curso"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //filtra por nome de curso
        private void comboBoxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.ALUNOS_DO_CURSO @NOME_CURSO";                           //TODO:
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NOME_CURSO", (String)comboBoxCurso.SelectedItem);


            SqlDataReader reader = cmd.ExecuteReader();
            listBoxAluno.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listBoxAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxDep.Text = "";
            comboBoxTurma.Text = "";
            comboBoxBiblio.Text = "";

        }

        //Mudamos uc fazemos a media
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_uc_aluno.Text = "";
            media_aluno.Text = "";
            falta_justificada.Text = "";
            faltas_injustificada.Text = "";

            string current_uc = listUCs.GetItemText(listUCs.SelectedItem);
            id_uc_aluno.Text = current_uc;
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.MediaAlunos @NMEC, @ID_UC";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NMEC", nmecAluno.Text);
            cmd.Parameters.AddWithValue("@ID_UC", id_uc_aluno.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                media_aluno.Text = reader["Media"].ToString();
            }
            BDconnection.getConnection().Close();


            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = BDconnection.getConnection();

            cmd2.CommandText = "EXEC SAA.num_falta_justificadas @NMEC, @ID_UC";
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@NMEC", nmecAluno.Text);
            cmd2.Parameters.AddWithValue("@ID_UC", id_uc_aluno.Text);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                falta_justificada.Text = reader2["num_faltas"].ToString();
            }
            BDconnection.getConnection().Close();


            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = BDconnection.getConnection();

            cmd3.CommandText = "EXEC SAA.num_falta_injustificadas @NMEC, @ID_UC";
            cmd3.Parameters.Clear();
            cmd3.Parameters.AddWithValue("@NMEC", nmecAluno.Text);
            cmd3.Parameters.AddWithValue("@ID_UC", id_uc_aluno.Text);

            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                faltas_injustificada.Text = reader3["num_faltas"].ToString();
            }
            BDconnection.getConnection().Close();

        }

        //add n_turmas a combobox
        private void N_TURMAS()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.N_TURMAS", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxTurma.Items.Add(reader["ID_TURMA"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //filtra por turmas
        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.ALUNOS_DA_TURMA @ID_Turma";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Turma", Int32.Parse((String)comboBoxTurma.SelectedItem));


            SqlDataReader reader = cmd.ExecuteReader();
            listBoxAluno.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listBoxAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxCurso.Text = "";
            comboBoxDep.Text = "";
            comboBoxBiblio.Text = "";
        }

        //filtrar pela biblio
        private void comboBoxBiblio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

            cmd.CommandText = "EXEC SAA.ALUNOS_DA_BIBLIO @ID_BIBLIO";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_BIBLIO", Int32.Parse((String)comboBoxBiblio.SelectedItem));


            SqlDataReader reader = cmd.ExecuteReader();
            listBoxAluno.Items.Clear();

            while (reader.Read())
            {

                Aluno A = new Aluno();
                A.Nome = reader["Nome"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC = reader["NMEC"].ToString();
                A.Email = reader["Email"].ToString();
                A.RegimeEstudo = reader["RegimeEstudo"].ToString();
                A.ID_Horario = reader["ID_Horario"].ToString();
                A.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                A.ID_Curso = reader["ID_Curso"].ToString();
                A.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                A.Idade = reader["Idade"].ToString();

                listBoxAluno.Items.Add(A);
            }
            BDconnection.getConnection().Close();

            currentAluno = 0;
            ShowAluno();

            comboBoxCurso.Text = "";
            comboBoxDep.Text = "";
            comboBoxTurma.Text = "";

        }

        //add n_biblios à combobox
        private void N_BIBLIOS()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.N_BIBLIOS", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxBiblio.Items.Add(reader["ID_Biblioteca"].ToString());
            }
            BDconnection.getConnection().Close();
        }



        public void ShowAluno()
        {
            if (listBoxAluno.Items.Count == 0 | currentAluno < 0)
                return;
            Aluno aluno = new Aluno();
            aluno = (Aluno)listBoxAluno.Items[currentAluno];
            nomeAluno.Text = aluno.Nome.ToString();
            nmecAluno.Text = aluno.NMEC;
            emailAluno.Text = aluno.Email;
            idCursoAluno.Text = aluno.ID_Curso;

            n_Alunos.Text = listBoxAluno.Items.Count.ToString();
        }


        //botao menu
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

        //outros
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
        private void PreviousPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormAluno faluno = new FormAluno();
            faluno.Show();
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void regimeEstudoAluno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void idCursoAluno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void filtros_btn_Click(object sender, EventArgs e)
        {
            comboBoxDep.Visible = true;
            label14.Visible = true;
            comboBoxCurso.Visible = true;
            label13.Visible = true;
            comboBoxBiblio.Visible = true;
            label15.Visible = true;
            comboBoxTurma.Visible = true;
            label10.Visible = true;

            hideBtn.Visible = true;
            filtros_btn.Visible = false;
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            comboBoxDep.Visible = false;
            label14.Visible = false;
            comboBoxCurso.Visible = false;
            label13.Visible = false;
            comboBoxBiblio.Visible = false;
            label15.Visible = false;
            comboBoxTurma.Visible = false;
            label10.Visible = false;

            hideBtn.Visible = false;
            filtros_btn.Visible = true;
            FormPerfilAluno_Load(sender, e);
        }
    }
}
