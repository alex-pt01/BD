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
    public partial class FormRegistos2 : Form
    {
        private int currentUC;

        public FormRegistos2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void FormRegistos2_Load(object sender, EventArgs e)
        {
            if (!BDconnection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAA.UC", BDconnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            listBoxUCs.Items.Clear();

            while (reader.Read())
            {
                UC uc = new UC();
                uc.ID_UC = (int)reader["ID_UC"];
                uc.ID_Horario = (int)reader["ID_Horario"];
                uc.ID_Aval = (int)reader["ID_Aval"];
                uc.anoFormacao = reader["AnoFormacao"].ToString();

                listBoxUCs.Items.Add(uc);
            }
            BDconnection.getConnection().Close();

            currentUC = 0;
            ShowUC();
        }

        public void ShowUC()
        {
            if (listBoxUCs.Items.Count == 0 | currentUC < 0)
                return;
            UC uc = new UC();
            uc = (UC)listBoxUCs.Items[currentUC];
            id_uc.Text = uc.ID_UC.ToString();
        }

        private void listBoxUCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUCs.SelectedIndex >= 0)
            {
                clearFields();
                currentUC = listBoxUCs.SelectedIndex;
                ShowUC();

                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BDconnection.getConnection();

                cmd.CommandText = "EXEC SAA.faltas_da_uc @ID_UC";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_UC", id_uc.Text);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    num_faltas.Text = reader["N_Faltas"].ToString();
                }
                BDconnection.getConnection().Close();


                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = BDconnection.getConnection();

                cmd2.CommandText = "EXEC SAA.mediaNotas_ucs @ID_UC";
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@ID_UC", id_uc.Text);


                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    nota_media.Text = reader2["Media_nota"].ToString();
                }
                BDconnection.getConnection().Close();


                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = BDconnection.getConnection();

                cmd3.CommandText = "EXEC SAA.num_falta_justificadas_uc @ID_UC";
                cmd3.Parameters.Clear();
                cmd3.Parameters.AddWithValue("@ID_UC", id_uc.Text);


                SqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    faltas_justificadas.Text = reader3["num_faltas"].ToString();
                }
                BDconnection.getConnection().Close();


                if (!BDconnection.verifySGBDConnection())
                    return;

                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = BDconnection.getConnection();

                cmd4.CommandText = "EXEC SAA.num_falta_injustificadas_uc @ID_UC";
                cmd4.Parameters.Clear();
                cmd4.Parameters.AddWithValue("@ID_UC", id_uc.Text);


                SqlDataReader reader4 = cmd4.ExecuteReader();

                while (reader4.Read())
                {
                    faltas_injustificadas.Text = reader4["num_faltas"].ToString();
                }
                BDconnection.getConnection().Close();

                if (String.IsNullOrEmpty(faltas_justificadas.Text))
                    faltas_justificadas.Text = "0";
                if (String.IsNullOrEmpty(faltas_injustificadas.Text))
                    faltas_injustificadas.Text = "0";
                if (String.IsNullOrEmpty(num_faltas.Text))
                    num_faltas.Text = "0";
                if (String.IsNullOrEmpty(nota_media.Text))
                    nota_media.Text = "-";
            }
        }











        private void NextPage_Click(object sender, EventArgs e)
        {
            this.Close();
            FormRegistos fRegistos = new FormRegistos();
            fRegistos.Show();
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

        private void Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
