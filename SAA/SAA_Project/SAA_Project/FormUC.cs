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
    public partial class FormUC : Form
    {

        private int currentUC;
        private String msgRegistos;
        private int tipoF;


        public FormUC()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormUCs_Load();

            comboBox3.Visible = true;
            showCursos();
            showIDAval();
            showIDhorario();

           
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = false;
            buttonOk_Editar.Visible = false;
            showTipoFaltas();

            label21.Visible = false;
            comboBox3.Visible = false;
           

            buttonOK_ADD.Visible = false;
            Cancelar.Visible = false;

        }

        //LOAD UC
        private void FormUCs_Load()
        {
            if (!BDconnection.verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand("EXEC SAA.loadUC", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {

                UC A = new UC();
                A.ID_UC = (int)reader["ID_UC"];
                A.ID_Horario = (int)reader["ID_Horario"];
                A.ID_Aval = (int)reader["ID_Aval"];
                A.anoFormacao = reader["AnoFormacao"].ToString() ;





                listBox1.Items.Add(A);
            }
            BDconnection.getConnection().Close();
            currentUC = 0;
            ShowUC();
        }

        public void ShowUC()
        {
            if (listBox1.Items.Count == 0 | currentUC < 0)
                return;
            UC p = new UC();
            p = (UC)listBox1.Items[currentUC];
            textBox1.Text = p.ID_UC.ToString();
            textBox2.Text = p.anoFormacao.ToString();
            textBox3.Text = p.ID_Horario.ToString();
            textBox4.Text = p.ID_Aval.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentUC = listBox1.SelectedIndex;
                ShowUC();
            }

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        //ELIMINAR UC
        private void button2_Click_1(object sender, EventArgs e)
        {
           
            if (!BDconnection.verifySGBDConnection())
                return;
            Object obj = MessageBox.Show("Tem a certeza que pretende eliminar?", "", MessageBoxButtons.YesNo);

            if (obj.ToString().Equals("Yes"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.delUC @ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", Int32.Parse(textBox1.Text));

                cmd.ExecuteNonQuery();
                BDconnection.getConnection().Close();

                FormUCs_Load();
             
            }

        }

        //ADICIONAR UC
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            showIDhorario();
        }
        private void showIDhorario()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.loadIDHorario", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["ID_Horario"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //showIDAval();

        }

        private void showIDAval()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.loadIDAval", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["ID_Aval"].ToString());
            }
            BDconnection.getConnection().Close();
        }

        //butao add
        private void button1_Click_2(object sender, EventArgs e)
        {
            label21.Visible = true;
            comboBox3.Visible = true;

            Cancelar.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;

            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            buttonOK_ADD.Visible = true;
            textBox2.Visible = false;
            button3.Visible = false;
        }
        private void buttonOK_ADD_Click(object sender, EventArgs e)
        {
            adicionarUC();
            adicionarCursoDaUC(0);


        }

        private void adicionarUC()
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

    


            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty((String)comboBox1.SelectedItem) || String.IsNullOrEmpty((String)comboBox2.SelectedItem) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }

            cmd.CommandText = "EXEC SAA.addUC @idUC, @anoForm, @Id_Hora,@id_aval";
            cmd.Parameters.Clear();

 

            cmd.Parameters.AddWithValue("@idUC", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@anoForm", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Id_Hora", Int32.Parse((String)comboBox1.SelectedItem));
            cmd.Parameters.AddWithValue("@id_aval", Int32.Parse((String)comboBox2.SelectedItem));

           
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("UC ID deve ser único!" + " " +textBox1.Text+ " " + (String)comboBox1.SelectedItem + " " + (String)comboBox2.SelectedItem  +" " + this.dateTimePicker1.Text);
            }
            finally
            {
              
                BDconnection.getConnection().Close();
            }

           
            FormUCs_Load();

           
            comboBox1.Visible = false;
            comboBox2.Visible = false;

            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;
            button1.Visible = true;

            buttonOK_ADD.Visible = false;
            dateTimePicker1.Visible = false;

            textBox2.Visible = true;
            button3.Visible = true;
            Cancelar.Visible = false;

            label21.Visible = false;
            comboBox3.Visible = false;


        }

        //UPDATE UC
        private void button3_Click(object sender, EventArgs e)
        {

            label21.Visible = true;
            comboBox3.Visible = true;


            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = true;

            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
           
            button2.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            Cancelar.Visible = true;

            buttonOk_Editar.Visible = true;
         

        }

        private void adicionarCursoDaUC(int id_add_up)
        {

            label21.Visible = true;
            comboBox3.Visible = true;

            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();

           



            if ( String.IsNullOrEmpty((String)comboBox3.SelectedItem) )
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }


            if (id_add_up == 0)
            {
                cmd.CommandText = "EXEC SAA.addUC_and_Curso @ID_UC, @ID_Curso";
                cmd.Parameters.Clear();


            }
            else
            {
                cmd.CommandText = "EXEC SAA.updateUC_and_Curso @ID_UC, @ID_Curso";
                cmd.Parameters.Clear();
            }



            char[] separator = {' '};
            String idCurso;
            String s = (String)comboBox3.SelectedItem;
            idCurso = s.Split(separator)[1].Trim();
            

            cmd.Parameters.AddWithValue("@ID_UC", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@ID_Curso", Int32.Parse(idCurso));
            cmd.ExecuteNonQuery();
            BDconnection.getConnection().Close();
            


            FormUCs_Load();


            comboBox1.Visible = false;
            comboBox2.Visible = false;

            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;
            button1.Visible = true;

            buttonOK_ADD.Visible = false;
            dateTimePicker1.Visible = false;

            textBox2.Visible = true;
            button3.Visible = true;
            Cancelar.Visible = false;

            label21.Visible = false;
            comboBox3.Visible = false;


        }
        private void buttonOk_Editar_Click(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDconnection.getConnection();


            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Todos os campos devem estar preenchidos!");

            }

            cmd.CommandText = "EXEC SAA.updateUC @idUC, @anoForm, @Id_Hora,@id_aval";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@idUC", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@anoForm", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Id_Hora", Int32.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@id_aval", Int32.Parse(textBox4.Text));

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


            FormUCs_Load();

            
            dateTimePicker1.Visible = false;

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;

            button2.Visible = true;
            button1.Visible = true;
            button3.Visible = true;

            buttonOk_Editar.Visible = false;
            Cancelar.Visible = false;

            label21.Visible = false;
            comboBox3.Visible = false;


            adicionarCursoDaUC(1);
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormUC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHomePage home_Page = new FormHomePage();
            home_Page.ShowDialog();

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUC c = new FormUC();
            c.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            registosTotais();

        }

        //UC ...
        private void registosTotais()
        {
            if (!BDconnection.verifySGBDConnection())
                return;


            int number;
            bool success = Int32.TryParse(textBox5.Text, out number);
            if (success)
            {
                SqlCommand cmd = new SqlCommand("EXEC SAA.TotalRegistos_UC "+ number , BDconnection.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox6.Text = reader["RegistosTotais"].ToString();
                }
 
            }
            else
                return;
            BDconnection.getConnection().Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCurso1 x = new FormCurso1();
            x.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void showTipoFaltas()
        {
            if (!BDconnection.verifySGBDConnection())
                return;



            SqlCommand cmd = new SqlCommand("EXEC  SAA.tipo_faltas_alunos_cada_uc ", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {

                ucFaltas B = new ucFaltas();

                B.ID_UC = (int)reader["ID_UC"];
                B.Email = reader["Email"].ToString();
                B.NMEC = (int)reader["NMEC"];
                B.nomeAluno = reader["Nome"].ToString();
                B.tipo_Falta = reader["Tipo_Falta"].ToString();
               

                listBox2.Items.Add(B);
            }

            BDconnection.getConnection().Close();
            tipoF = 0;
            tfalta();
        }

        public void tfalta()
        {
            if (listBox2.Items.Count == 0 | tipoF < 0)
                return;
            ucFaltas p = new ucFaltas();
            p = (ucFaltas)listBox2.Items[tipoF];

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void showCursos()
        {
            if (!BDconnection.verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("EXEC SAA.showCurso", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add("ID " + reader["ID_Curso"].ToString() + " - " + reader["Nome_Curso"].ToString());
            }
            BDconnection.getConnection().Close();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
