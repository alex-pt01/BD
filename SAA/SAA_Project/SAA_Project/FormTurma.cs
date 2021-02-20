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
   
    public partial class FormTurma : Form
    {
     
        private int currentTurma;
        private int currentAnos;
        public FormTurma()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            buttonOkUp.Visible = false;
            buttonAddOK.Visible = false;
            comboBoxHor.Visible = false;
            comboBoxProf.Visible = false;

            button5.Visible = false;


            //loadTurmas(); //comboBoxT
            FormTurmas_Load();
            loadHoraios();
            loadTnmec();
            Turma.Visible = false;




        }

        //Form LOAD dados TURMA
        private void FormTurmas_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            
            SqlCommand cmd = new SqlCommand("EXEC SAA.data_TURMA", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
               
                Turma A = new Turma();
                A.ID_turma = (int)reader["ID_turma"];
                A.ID_Horario = (int)reader["ID_Horario"];
                A.AnoLectivo = (int)reader["AnoLectivo"];
                A.TNMEC = (int)reader["TNEMC"];
                


               
     
                listBox1.Items.Add(A);
            }
            BDconnection.getConnection().Close();
            currentTurma = 0;
            ShowTurma();
        }


        //atribui à ListBox e a todas as textBoxes
        public void ShowTurma()
        {
            if (listBox1.Items.Count == 0 | currentTurma < 0)
                return;
            Turma p = new Turma();
            p = (Turma)listBox1.Items[currentTurma];
            textBox1.Text = p.ID_turma.ToString();
            textBox2.Text = p.ID_Horario.ToString();
            textBox3.Text = p.TNMEC.ToString();
            textBox4.Text = p.AnoLectivo.ToString();


        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                //professor selecionado
                currentTurma = listBox1.SelectedIndex;
                ShowTurma();
            }

        }

        

        //--------------------------------------------------------------------------------------------
        //ELIMINAR TURMA
        private void button2_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);
         
            if (obj.ToString().Equals("Yes"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.del_Turma @ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", Int32.Parse(textBox1.Text));

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();

                FormTurmas_Load();
            }
        }

        //ADICIONAR TURMA
        private void button1_Click(object sender, EventArgs e)
        {
            buttonAddOK.Visible = true;
            comboBoxHor.Visible = true;
            comboBoxProf.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            buttonOkUp.Visible = false;
            button5.Visible = true;


        }
        //ao carregar no butao chama o adicionarTurma();
        private void buttonAddOK_Click(object sender, EventArgs e)
        {
            adicionarTurma();

        }
        //ADICIONAR TURMA
        private void adicionarTurma()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();
          
           
          
            if ( String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty((String)comboBoxHor.SelectedItem) || String.IsNullOrEmpty((String)comboBoxProf.SelectedItem) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }
            
            cmd.CommandText = "EXEC SAA.addTurma @id, @tnmec, @idHorario,@anoLect";
            cmd.Parameters.Clear();
           
            cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@tnmec", Int32.Parse((String)comboBoxProf.SelectedItem));
            cmd.Parameters.AddWithValue("@idHorario", Int32.Parse((String)comboBoxHor.SelectedItem));
            cmd.Parameters.AddWithValue("@anoLect", Int32.Parse(textBox4.Text));
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Turma ID deve ser único!");
            }
            finally
            {
                BDconnection.getConnection().Close();
            }


            FormTurmas_Load();

            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            buttonOkUp.Visible = false;
            buttonAddOK.Visible = false;

            comboBoxHor.Visible = false;
            comboBoxProf.Visible = false;
            button5.Visible = false;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxHor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void loadHoraios()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.IDsHoraios", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxHor.Items.Add(reader["ID_Horario"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void loadTnmec()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.Tnmecs", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxProf.Items.Add(reader["TMEC"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //UPDATE TURMA
        private void button3_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;

            comboBoxHor.Visible = false;
            buttonOkUp.Visible = true;

            comboBoxProf.Visible = true;
            comboBoxProf.Left += 110;
            Turma.Visible = true;





        }

        private void buttonOkUp_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();



            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }

            cmd.CommandText = "EXEC SAA.updateTurma @id, @tnmec, @idHorario,@anoLect";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@tnmec", Int32.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@idHorario", Int32.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@anoLect", Int32.Parse(textBox4.Text));

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados editados com sucesso!");
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                BDconnection.getConnection().Close();
            }


            FormTurmas_Load();

            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            buttonOkUp.Visible = false;
            buttonAddOK.Visible = false;

            comboBoxHor.Visible = false;
            comboBoxProf.Visible = false;
            
            button5.Visible = false;


            comboBoxProf.Visible = false;
            comboBoxProf.Left -= 110;
            Turma.Visible = false;



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
     

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormTurma1 menu = new FormTurma1();
            menu.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAnos_TextChanged(object sender, EventArgs e)
        {
            FormAnos_Turmas_Load();

        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
       
       

        private void FormAnos_Turmas_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
       

            int number;
            bool success = Int32.TryParse(textBoxAnos.Text, out number);
            if (success)
            {
                SqlCommand cmd = new SqlCommand("select * from SAA.ALUNOS_TURMA_DE_HA_X_ANOS (" + number + ") ", BDconnection.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                listBox2.Items.Clear();
                while (reader.Read())
                {

                anosTurma B = new anosTurma();

                B.ID_turma = (int)reader["ID_turma"];
                B.NNMEC = (int)reader["NMEC"];
                B.nome = reader["Nome"].ToString();
                B.Email = reader["Email"].ToString();
                B.resEstudo = reader["RegimeEstudo"].ToString();
                B.idade = (int)reader["Idade"];
                B.anoLect = (int)reader["AnoLectivo"];

                listBox2.Items.Add(B);
                }
            }
            else
                return;
            BDconnection.getConnection().Close();
            currentAnos = 0;
            ShowTurma_Anos();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentAnos = listBox1.SelectedIndex;
                ShowTurma_Anos();
            }

        }


        public void ShowTurma_Anos()
        {
            if (listBox2.Items.Count == 0 | currentAnos < 0)
                return;
            anosTurma p = new anosTurma();

            p = (anosTurma)listBox2.Items[currentAnos];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTurma fT = new FormTurma();
            fT.ShowDialog();
        }

        private void Turma_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
