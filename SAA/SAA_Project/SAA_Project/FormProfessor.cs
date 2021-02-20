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

using System.Collections;
/*
 * 
 * Ao adicionar -> PROCEDURE i23nProfessor; que n aparece 
 */
namespace SAA_Project
{
    public partial class FormProfessor : Form
    {
        private int currentProf;
        private int currentProfTurma;
        //construtor onde td é inicializado
        public FormProfessor()
        {
            InitializeComponent();
           
            this.StartPosition = FormStartPosition.CenterScreen;
            FormProf_Load();
            //TurmaProf_Load();
            label14.Visible = false;


            button2.Visible = false;
            cancelar.Visible = false;

            loadSelectDepartamentos();
            loadDepID();
            loadHorario();
            TurmaProf_Load();
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            buttonokEdit.Visible = false;
           // loadTotalTurmas_Prof();

        }


        // COMBOBOX
        //carregar departamentos
        private void loadDepID()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("select ID_DEP from SAA.DEPARTAMENTO order by ID_DEP", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["ID_DEP"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //comboBox dos Departamentos que chama a function loadSelectDepartamentos() 
        //precisa de ser carregada no construtor
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //COMBOBOX 
        private void loadHorario()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.showHorario", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader["ID_Horario"].ToString());
            }
            BDconnection.getConnection().Close();
        }

       
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //LOAD_LISTBOX dos professores
        private void FormProf_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.PROFESSOR", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {

                Professor A = new Professor();
                A.Nome = reader["Nome_Prof"].ToString();
                A.TNMEC = (int)reader["TMEC"];
                A.Email = reader["Email"].ToString();
                A.numGabinete = (int)reader["Num_Gabinete"];
                A.ID_Dep = (int)reader["ID_DEP"];
                A.ID_Horario = (int)reader["ID_Horario"];

                //String prof = reader["Nome_Prof"].ToString() + "  " + reader["TMEC"];
                listBox1.Items.Add(A);
            }
            BDconnection.getConnection().Close();
            currentProf = 0;
            ShowProf();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listBox1.SelectedIndex >= 0)
            {
                //professor selecionado
                currentProf = listBox1.SelectedIndex;
                ShowProf();
            } 

        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>
        
        //ATRIBUICAO TEXTBOXES turma do prof
       

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox2.SelectedIndex >= 0)
            {
                //professor selecionado
                currentProfTurma = listBox2.SelectedIndex;
                ShowTurma_Prof();
            }
        }

        //ATRIBUICAO TEXTBOXES
        public void ShowProf()
        {
            if (listBox1.Items.Count == 0 | currentProf < 0)
                return;
            Professor p = new Professor();
            p = (Professor)listBox1.Items[currentProf];
            textBox1.Text = p.Nome.ToString();
            textBox3.Text = p.numGabinete.ToString();
            textBox4.Text = p.TNMEC.ToString();
            textBox2.Text = p.Email.ToString();
            textBox6.Text = p.ID_Dep.ToString();
            textBox7.Text = p.ID_Horario.ToString();
           // textBox6.Text = p.ID_Dep.ToString();
            
        }
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        

        //UPDATE prof na BD
        private void button2_Click(object sender, EventArgs e)
        {
            buttonokEdit.Visible = true;
            comboBox3.Visible = true;
            comboBox2.Visible = true;
            textBox6.Visible = false;
            textBox7.Visible = false;
            Adicionar.Visible = false;
            Eliminar.Visible = false;
            Update.Visible = false;
            cancelar.Visible = true;




        }

        public void okEdit()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            Professor aluno = new Professor();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty((String)comboBox2.SelectedItem) || String.IsNullOrEmpty((String)comboBox3.SelectedItem) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");

            }
            else
            {
                cmd.CommandText = "EXEC SAA.update_Prof @nome, @numGab, @Email,@tmec,@id_dep,@id_horaio";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@numGab", Int32.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                cmd.Parameters.AddWithValue("@tmec", Int32.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@id_dep", Int32.Parse((String)comboBox2.SelectedItem));
                cmd.Parameters.AddWithValue("@id_horaio", Int32.Parse((String)comboBox3.SelectedItem));

                cmd.ExecuteNonQuery();
            }

            FormProf_Load();
            ShowProf();
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            textBox6.Visible = true;
            textBox7.Visible = true;
            buttonokEdit.Visible = false;

            Adicionar.Visible = true;
            Eliminar.Visible = true;
            Update.Visible = true;
            cancelar.Visible = true;



        }
        private void buttonokEdit_Click(object sender, EventArgs e)
        {
            okEdit();
        }



        //COMBOBOX
        //carregar departamentos
        private void loadSelectDepartamentos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("select Nome_Dep from SAA.DEPARTAMENTO group by Nome_Dep", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Nome_Dep"].ToString());
            }
            BDconnection.getConnection().Close();
        }


        //comboBox dos Departamentos que chama a function loadSelectDepartamentos() 
        //precisa de ser carregada no construtor
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadSelectDepartamentos(); //pq já chama no construtor
            loadTotalDepSelected();
        }
       

        //TOTAL_PROFESSORES_DEP_X
        private void loadTotalDepSelected()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBox1.Items.Count == 0)
                return;
            String depSelected = (String)comboBox1.SelectedItem;

            SqlCommand cmd = new SqlCommand("select * from SAA.TOTAL_PROFESSORES_DEP_Y ('" + depSelected + "') ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              
                textBoxTotalprofs.Text = reader["TOTAL_PROF_DEP"].ToString();

            }
            BDconnection.getConnection().Close();

        }

        //ELIMINAR professor
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);
            Professor p = new Professor();
            if (obj.ToString().Equals("Yes"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.del_Professor @ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", Int32.Parse(textBox4.Text));

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();

                FormProf_Load();
            }
            cancelar.Visible = false;
        }

      

        //ADICIONAR PROFESSOR
        private void Adicionar_Click(object sender, EventArgs e)
        {
            clearFields();

            button2.Visible = true ;
            Adicionar.Visible = false;
            Eliminar.Visible = false;
            Update.Visible = false;
            cancelar.Visible = true;
            label14.Visible = true;
            comboBox3.Visible = true;
            comboBox2.Visible = true;
            textBox6.Visible = false;
            textBox7.Visible = false;


            textBox4.ReadOnly = true; //tnmec read only



        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            label14.Visible = false ;
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            textBox6.Visible = true;
            textBox7.Visible = true;

            loadAdicionar();

        }

        private void loadAdicionar()
        {
            
            if (!BDconnection.verifySGBDConnection())
                return;

           
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();
            //  Professor p = new Professor();

            if (String.IsNullOrEmpty((String)comboBox2.SelectedItem) || String.IsNullOrEmpty((String)comboBox2.SelectedItem) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos");

            }

           // MessageBox.Show(textBox1.Text + "  aqui  " + Int32.Parse(textBox3.Text));
            // esta a ir buscar...
            cmd.CommandText = "EXEC SAA.addProf @nome, @numGab, @Email, @tmec, @id_dep, @id_horaio";
            cmd.Parameters.Clear();
           // MessageBox.Show(textBox1.Text);
            cmd.Parameters.AddWithValue("@nome", textBox1.Text);
            cmd.Parameters.AddWithValue("@numGab", Int32.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Email", textBox2.Text);
            cmd.Parameters.AddWithValue("@tmec", Int32.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@id_dep", Int32.Parse((String)comboBox2.SelectedItem));
            cmd.Parameters.AddWithValue("@id_horaio", Int32.Parse((String)comboBox3.SelectedItem));

            MessageBox.Show(textBox1.Text + textBox2.Text + Int32.Parse(textBox4.Text));
            try
            {
               cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("NMEC, Número de Gabinete e mail devem ser únicos!");

            }
            finally
            {
                BDconnection.getConnection().Close();
            }

            button2.Visible = false;
            Adicionar.Visible = true;
            Eliminar.Visible = true;
            Update.Visible = true;
            cancelar.Visible = false;
            FormProf_Load();
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>


        private void CleantextBox()
        {
            textBox1.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox2.Text = " ";
            comboBox2.SelectedItem = " ";
            comboBox2.SelectedItem = " ";


        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

      



        
        //LOAD_COMBOBOX com as turmas de cada professor
        //mete na combobox4 os ids dos stores
        private void TurmaProf_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("select distinct TNEMC from SAA.TURMA order by TNEMC", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["TNEMC"].ToString());
            }
            BDconnection.getConnection().Close();

        
        }
        //Mete na textBox o numero total de turmas
        private void loadTotalTurmas_Prof()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBox4.Items.Count == 0)
                return;

            String depSelected = (String)comboBox4.SelectedItem;
            SqlCommand cmd = new SqlCommand("EXEC SAA.totalTurmasProf " + Int32.Parse(depSelected) + " ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                textBox5.Text = reader["total_prof_turma"].ToString();

            }
            BDconnection.getConnection().Close();

        }
        //ao selecionar as opcoes quero q faça isto
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTotalTurmas_Prof();
            FormProf_Turmas_Load();

        }

        //Load turmas para a list box2 das turmas dos professores
        private void FormProf_Turmas_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            String depSelected = (String)comboBox4.SelectedItem;
            //MessageBox.Show(depSelected);
            SqlCommand cmd = new SqlCommand("select * from SAA.TurmasCadaStor (" + Int32.Parse(depSelected) + ") ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {

                Turma A = new Turma();

                A.ID_turma = (int)reader["ID_turma"];
                A.AnoLectivo = (int)reader["AnoLectivo"];

                listBox2.Items.Add(A);
            }
            BDconnection.getConnection().Close();
            currentProfTurma = 0;
            ShowTurma_Prof();
        }



        public void ShowTurma_Prof()
        {
            if (listBox2.Items.Count == 0 | currentProfTurma < 0)
                return;
            Turma p = new Turma();
            p = (Turma)listBox2.Items[currentProfTurma];

        }





        private void loadTurma()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            if (comboBox1.Items.Count == 0)
                return;
            String depSelected = (String)comboBox1.SelectedItem;

            SqlCommand cmd = new SqlCommand("select * from SAA.TOTAL_PROFESSORES_DEP_Y ('" + depSelected + "') ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                textBoxTotalprofs.Text = reader["TOTAL_PROF_DEP"].ToString();

            }
            BDconnection.getConnection().Close();

        }
        private void textBoxTotalprofs_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Object obj = MessageBox.Show("Quer ir para o menu principal? ", " ", MessageBoxButtons.YesNo);
            if (obj.ToString().Equals("Yes"))
            {
                this.Close();
                FormHomePage menu = new FormHomePage();
                menu.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CleantextBox();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormProfessor p = new FormProfessor();
            p.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void FormProfessor_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


















