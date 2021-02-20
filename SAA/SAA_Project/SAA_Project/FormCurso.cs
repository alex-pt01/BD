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
    public partial class FormCurso : Form
    {
        private int currentCurso;
        private int ucs_Curso;

        public FormCurso()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            buttonOkAdd.Visible = false;
            buttonOkEdit.Visible = false;
            buttonCanc.Visible = false;
            button2.Visible = true;
            comboBox1.Visible = false;
            FormCurso_Load();
            loadDep();
            loadIDUcs();
        }

        
      //listBox e textBoxes

        private void FormCurso_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand("EXEC SAA.loadCurso", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {

                Curso A = new Curso();
                A.idCurso = (int)reader["ID_Curso"];
                A.idDep = (int)reader["ID_Dep"];
                A.nome_Curso = reader["Nome_Curso"].ToString();
                

                listBox1.Items.Add(A);
            }
            BDconnection.getConnection().Close();
            currentCurso = 0;
            ShowCurso();
        }

        public void ShowCurso()
        {
            if (listBox1.Items.Count == 0 | currentCurso < 0)
                return;
            Curso p = new Curso();
            p = (Curso)listBox1.Items[currentCurso];
            textBox1.Text = p.nome_Curso.ToString();
            textBox2.Text = p.idCurso.ToString();
            textBox3.Text = p.idDep.ToString();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                //professor selecionado
                currentCurso = listBox1.SelectedIndex;
                ShowCurso();
            }

        }

        //DELETE CURSO

        //ELIMINAR TURMA
        private void button1_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);
           
            if (obj.ToString().Equals("Yes"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.delCurso @ID_Curso";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Curso", Int32.Parse(textBox2.Text));

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();

                FormCurso_Load();
            }
        }

        //ADICIONAR CURSO

        private void adicionarCurso()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();



            if ( String.IsNullOrEmpty((String)comboBox1.SelectedItem) ||  String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) )
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }

            cmd.CommandText = "EXEC SAA.addCurso @nomeCurso, @id_curso, @id_dep ";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@nomeCurso", textBox1.Text);
            cmd.Parameters.AddWithValue("@id_curso", Int32.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@id_dep", Int32.Parse((String)comboBox1.SelectedItem));
            

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Curso ID deve ser único!");
            }
            finally
            {
                BDconnection.getConnection().Close();
            }

            FormCurso_Load();
            button1.Visible = true;
            button2.Visible = true;
            buttonOkAdd.Visible = false;
            textBox3.Visible = true;
            buttonCanc.Visible = false;
            button3.Visible = true;

        }

        private void loadDep()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.loadDepID", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["ID_Dep"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonCanc.Visible = true;
            buttonOkAdd.Visible = true;
            comboBox1.Visible = true;
         
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            textBox3.Visible = false;


        }

        private void buttonOkAdd_Click(object sender, EventArgs e)
        {
            adicionarCurso();

          
        }

        //UPDATE CURSO
        private void button3_Click(object sender, EventArgs e)
        {
            buttonCanc.Visible = true;

            buttonOkEdit.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            comboBox1.Visible = true;
            textBox3.Visible = false;
          


        }
        public void editCurso()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();



            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty((String)comboBox1.SelectedItem))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }

            cmd.CommandText = "EXEC SAA.updateCurso @nomeCurso, @id_curso, @id_dep ";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@nomeCurso", textBox1.Text);
            cmd.Parameters.AddWithValue("@id_curso", Int32.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@id_dep", Int32.Parse((String)comboBox1.SelectedItem));


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BDconnection.getConnection().Close();
            }



            FormCurso_Load();
            buttonOkEdit.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            comboBox1.Visible = false;
            buttonCanc.Visible = false;
            textBox3.Visible = true;

        }


        private void buttonOkEdit_Click(object sender, EventArgs e)
        {
            editCurso();
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        // para o 
        public void loadIDUcs() //meter no construtor
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.loadUcs", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["ID_UC"].ToString());
            }
            BDconnection.getConnection().Close();

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            showUCs_Cursos();

        }

        public void showUCs_Cursos()
        {
            if (!BDconnection.verifySGBDConnection())
            return;

            String depSelected = (String)comboBox2.SelectedItem;
            SqlCommand cmd = new SqlCommand("select * from SAA.UC_DO_CURSO_X (" + Int32.Parse(depSelected) + ") ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {
                uc_Curso B = new uc_Curso();

                B.idUC = (int)reader["ID_UC"];
                B.anoForm = reader["AnoFormacao"].ToString();
                B.nomeCurso = reader["Nome_Curso"].ToString();
          
                listBox2.Items.Add(B);
            }
      
            BDconnection.getConnection().Close();
            ucs_Curso = 0;
            ShowUcs_Curso();
        }



        public void ShowUcs_Curso()
        {
            if (listBox2.Items.Count == 0 | ucs_Curso < 0)
                return;
            uc_Curso p = new uc_Curso();
            p = (uc_Curso)listBox2.Items[ucs_Curso];

        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>






        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Menu_Click(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }

        }

        private void buttonCanc_Click(object sender, EventArgs e)
        {
            FormCurso_Load();
            buttonOkEdit.Visible = false;
            buttonOkAdd.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            comboBox1.Visible = false;
            textBox3.Visible = true;
            buttonCanc.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormCurso_Load(object sender, EventArgs e)
        {

        }
    }
}
