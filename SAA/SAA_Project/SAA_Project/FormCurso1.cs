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
   
    public partial class FormCurso1 : Form
    {
        private int anoUC;
        private int regAlunosUc;
        public FormCurso1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            showUC_Curso();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void showUC_Curso()
        {
            if (!BDconnection.verifySGBDConnection())
                return;


           
            SqlCommand cmd = new SqlCommand("EXEC oldest_UC ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {

                anoUC B = new anoUC();

                B.ano = (int)reader["Duracao_UC"];
                B.nomeCurso = reader["Nome_Curso"].ToString();
                B.idCurso = (int)reader["ID_UC"];

                listBox1.Items.Add(B);
            }

            BDconnection.getConnection().Close();
            anoUC = 0;
            anoUCs();
        }

        public void anoUCs()
        {
            if (listBox1.Items.Count == 0 | anoUC < 0)
                return;
            anoUC p = new anoUC();
            p = (anoUC)listBox1.Items[anoUC];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUC c = new FormUC();
            c.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            registosAlunosEntreAnos();
        }

        private void registosAlunosEntreAnos()
        {
           
          
            int idUC;
            int yearStart;
            int yearEnd;

            bool flag = false;
            if (Int32.TryParse(textBox1.Text, out idUC))
                flag = true;
            
            if (Int32.TryParse(textBox2.Text, out yearStart))
                flag = true;

            if (Int32.TryParse(textBox3.Text, out yearEnd))
                flag = true;

            if (flag)
            {
                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand("select * from SAA.REGISTOS_ALUNOS_UC_Y_BETWEENYEARS( " + idUC +","+ yearStart+","+ yearEnd+")", BDconnection.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                listBox2.Items.Clear();

                while (reader.Read())
                {

                    registosAlunosUcs B = new registosAlunosUcs();

                    B.NMEC = (int)reader["NMEC"];
                    B.ID_UC = (int)reader["ID_UC"];
                    B.ID_Curso = (int)reader["ID_Curso"];
                    B.ID_Reg = (int)reader["ID_Registo"];
                    B.Email = reader["Email"].ToString();
                    B.RegismeEst = reader["RegimeEstudo"].ToString();
                    B.NomeAlu = reader["Nome"].ToString();

                    listBox2.Items.Add(B);
                }

                BDconnection.getConnection().Close();
                regAlunosUc = 0;
            }
            else
                MessageBox.Show("Campos Inválidos. Deve colocar o ID da UC, o ano de começo e o ano térmico para obter os resultados corretos");

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                regAlunosUc = listBox2.SelectedIndex;
                ShowReg_Alunos();
            }
        }

        public void ShowReg_Alunos()
        {
            if (listBox2.Items.Count == 0 | regAlunosUc < 0)
                return;
            registosAlunosUcs p = new registosAlunosUcs();

            p = (registosAlunosUcs)listBox2.Items[regAlunosUc];
        }

        private void FormCurso1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
