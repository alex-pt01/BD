using System;
using System.Collections;
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
    public partial class FormTurma1 : Form
    {

        private int currentT;
        private int currentA;
        private int curreteSala;

        public FormTurma1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadTurmas();
            tipoSala();  //tipoSala
        }

        // para a comboBoxTurmas
        private void loadTurmas()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.IDsTurmas", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxT.Items.Add(reader["ID_Turma"].ToString());
            }
            BDconnection.getConnection().Close();
        }


    
        private void FormAlun_Turmas_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBoxT.Items.Count == 0)
                return;
            String turmaSelected = (String)comboBoxT.SelectedItem;
            //MessageBox.Show(depSelected);  //TROCAR AQU!!!
            SqlCommand cmd = new SqlCommand("select * from SAA.ALUNOS_TURMA_Y (" + Int32.Parse(turmaSelected) + ") ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();
            while (reader.Read())
            {

                relAlunosTurma B = new relAlunosTurma();

                B.ID_turma = (int)reader["ID_turma"];
                B.TNMEC = (int)reader["NMEC"];
                B.Idade = (int)reader["Idade"];
                B.nome_Prof = reader["Nome"].ToString();
                B.Email = reader["Email"].ToString();
                B.RegEstudo = reader["RegimeEstudo"].ToString();

                listBox2.Items.Add(B);
            }
            BDconnection.getConnection().Close();
            currentT = 0;
            ShowTurma_Prof();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                //professor selecionado
                currentT = listBox2.SelectedIndex;
                ShowTurma_Prof();
            }
        }

        public void ShowTurma_Prof()
        {
            if (listBox2.Items.Count == 0 | currentT < 0)
                return;
            relAlunosTurma p = new relAlunosTurma();
          
            p = (relAlunosTurma)listBox2.Items[currentT];
        }

        private void comboBoxT_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FormAlun_Turmas_Load();
            FormProf_Turmas_Load();

        }

       
        /////////////////////////////////////////////

    


        private void FormProf_Turmas_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBoxT.Items.Count == 0)
                return;
            String turmaSelected = (String)comboBoxT.SelectedItem;
            //MessageBox.Show(depSelected);  //TROCAR AQU!!!
            SqlCommand cmd = new SqlCommand("select * from SAA.PROFESSORES_TURMA_Y (" + Int32.Parse(turmaSelected) + ") ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {

                turmaAluno B = new turmaAluno();

                B.ID_turma = (int)reader["ID_turma"];
                B.TNMEC = (int)reader["TNEMC"];
                B.nome_Prof = reader["Nome_Prof"].ToString();
                B.numGab = (int)reader["Num_Gabinete"];
                B.Email = reader["Email"].ToString();

                listBox1.Items.Add(B);
            }
            BDconnection.getConnection().Close();
            currentA = 0;
            ShowTurma_Prof();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                //professor selecionado
                currentA = listBox1.SelectedIndex;
                ShowTurma_Professor();
            }

        }
        public void ShowTurma_Professor()
        {
            if (listBox1.Items.Count == 0 | currentT < 0)
                return;
            turmaAluno p = new turmaAluno();

            p = (turmaAluno)listBox1.Items[currentA];
        }


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        private void tipoSala()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.tipoSala1", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxTSala.Items.Add(reader["tipoSala"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void comboBoxTSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormtipoSala_Load();

        }

     

        private void FormtipoSala_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBoxTSala.Items.Count == 0)
                return;
            String turmaSelected = (String)comboBoxTSala.SelectedItem;
            SqlCommand cmd = new SqlCommand("select * from SAA.Alunos_Turmas_Do_TipoSala ('" + turmaSelected + "') ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox3.Items.Clear();
            while (reader.Read())
            {

                tipoSala B = new tipoSala();

                B.ID_Sala = (int)reader["ID_Sala"];
                B.AnoLectivo = (int)reader["AnoLectivo"];
                B.ID_Turma = (int)reader["ID_Turma"];
                B.TipoSala = reader["tipoSala"].ToString();
                B.limiAlunos = (int)reader["Limite_Alunos"];
                B.ID_Dep = (int)reader["ID_Dep"];

                listBox3.Items.Add(B);
            }
            BDconnection.getConnection().Close();
            curreteSala = 0;
            ShowTurma_Prof();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                curreteSala = listBox3.SelectedIndex;
                ShowAlunos_tipoSala();
            }

        }

        public void ShowAlunos_tipoSala()
        {
            if (listBox3.Items.Count == 0 | curreteSala < 0)
                return;
            tipoSala p = new tipoSala();

            p = (tipoSala)listBox3.Items[curreteSala];
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

        private void button4_Click(object sender, EventArgs e)
        {
           
                this.Close();
                FormTurma menu = new FormTurma();
                menu.Show();
            }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
