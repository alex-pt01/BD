using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SAA_Project
{
    public partial class FormMenu : Form
    {
        private SqlConnection cn;
        private int currentTable;

        public FormMenu()
        {
            InitializeComponent();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMenu_Load_1(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'SAA'", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listTables.Items.Clear();

            while (reader.Read())
            {

                Table T = new Table();
                T.TABLE_NAME = reader["TABLE_NAME"].ToString();
                

                listTables.Items.Add(T);
            }
            cn.Close();

            currentTable = 0;
            ShowTable();

        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p3g6; uid = p3g6; password = 552748589@Bd");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTables.SelectedIndex >= 0)
            {
                currentTable = listTables.SelectedIndex;
                ShowTable();
            }
        }

        public void ShowTable()
        {
            if (listTables.Items.Count == 0 | currentTable < 0)
                return;
            Table table = new Table();
            table = (Table)listTables.Items[currentTable];
            textBox1.Text = table.TABLE_NAME;

        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAluno fAluno = new FormAluno();
            fAluno.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            switch (textBox1.Text)
            {
                case "ALUNO":
                    this.Hide();
                    FormAluno fAluno = new FormAluno();
                    fAluno.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Erro");
                    break;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHomePage homeP = new FormHomePage();


            homeP.ShowDialog();
            this.Close();
        }
    }
}
