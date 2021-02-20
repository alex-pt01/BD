using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAA_Project
{
    public partial class FormHomePage : Form
    {
        public FormHomePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormHomePage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonUC_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUC fUC = new FormUC();
            fUC.ShowDialog();
            

        }

        private void horario_Click(object sender, EventArgs e)
        {

        }

        private void turmas_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAluno fUC = new FormAluno();
            fUC.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfessor prof = new FormProfessor();
            prof.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTurma turma = new FormTurma();
            turma.ShowDialog();

        }

        private void Curso_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCurso curso = new FormCurso();
            curso.ShowDialog();

        }

        private void UC_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUC uc = new FormUC();
            uc.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistos fRegistos = new FormRegistos();
            fRegistos.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormAluno fAluno = new FormAluno();
            fAluno.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormHorario fHorario = new FormHorario();
            fHorario.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormHorario fHorario = new FormHorario();
            fHorario.ShowDialog();
        }
    }
}
