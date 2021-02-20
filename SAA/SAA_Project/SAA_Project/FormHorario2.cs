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
    public partial class FormHorario2 : Form
    {
        private int currentHorario;
        private string current_id_horario;
        private int currentAluno;


        public FormHorario2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHorario fhor = new FormHorario();
            fhor.Show();
        }

        private void FormHorario2_Load(object sender, EventArgs e)
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

            currentHorario = 0;
        }

        private void listaUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaAlunos.SelectedIndex >= 0)
            {
                currentAluno = listaAlunos.SelectedIndex;
                ShowDados();
            }
        }

        private void listHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listHorarios.SelectedIndex >= 0)
            {
                currentHorario = listHorarios.SelectedIndex;
                current_id_horario = listHorarios.Items[currentHorario].ToString();

                listaAlunos.Visible = true;
                labelnmec2.Visible = true;
                labelnome2.Visible = true;

                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "Select * from SAA.DADOS_HOR_X2 (@ID_Horario)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Horario", current_id_horario);

                SqlDataReader reader = cmd.ExecuteReader();
                listaAlunos.Items.Clear();

                while (reader.Read())
                {
                    HorAlunoProf aluProf = new HorAlunoProf();
                    aluProf.Nome = reader["Nome"].ToString();
                    aluProf.NMEC = reader["NMEC"].ToString();
                    aluProf.Email = reader["Email_Aluno"].ToString();
                    aluProf.ID_Horario = reader["ID_Horario"].ToString();
                    aluProf.NMEC_Tutor = reader["NMEC_Tutor"].ToString();
                    aluProf.RegimeEstudo = reader["RegimeEstudo"].ToString();
                    aluProf.ID_Biblioteca = reader["ID_Biblioteca"].ToString();
                    aluProf.ID_Curso = reader["ID_Curso"].ToString();
                    aluProf.Idade = reader["Idade"].ToString();

                    aluProf.NomeProf = reader["Nome_Prof"].ToString();
                    aluProf.EmailProf = reader["Email_Prof"].ToString();
                    aluProf.TNMEC = reader["TMEC"].ToString();
                    aluProf.numGabinete = (int)reader["Num_Gabinete"];
                    aluProf.ID_Dep = (int)reader["ID_Dep"];

                    listaAlunos.Items.Add(aluProf);
                }

                BDconnection.getConnection().Close();

                currentAluno = 0;
                ShowDados();
            }
        }

        public void ShowDados()
        {
            if (listaAlunos.Items.Count == 0 | currentAluno < 0)
                return;

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
            passAluno.Visible = true;
            idHorarioAluno.Visible = true;
            nomeAluno.Visible = true;
            idCursoAluno.Visible = true;
            labelNome.Visible = true;
            labelCurso.Visible = true;

            HorAlunoProf aluProf = new HorAlunoProf();
            aluProf = (HorAlunoProf)listaAlunos.Items[currentAluno];
            nomeAluno.Text = aluProf.Nome.ToString();
            nmecAluno.Text = aluProf.NMEC;
            emailAluno.Text = aluProf.Email;
            regimeEstudoAluno.Text = aluProf.RegimeEstudo;
            idHorarioAluno.Text = aluProf.ID_Horario;
            idBibliotecaAluno.Text = aluProf.ID_Biblioteca;
            idCursoAluno.Text = aluProf.ID_Curso;
            nmecTutorAluno.Text = aluProf.NMEC_Tutor;
            idadeAluno.Text = aluProf.Idade;

            //professor
            nomeProf.Text = aluProf.NomeProf.ToString();
            tnmecProf.Text = aluProf.TNMEC.ToString();
            emailProf.Text = aluProf.EmailProf.ToString();
            gabineteProf.Text = aluProf.numGabinete.ToString();
            depProf.Text = aluProf.ID_Dep.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHorario fhor = new FormHorario();
            fhor.Show();
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
