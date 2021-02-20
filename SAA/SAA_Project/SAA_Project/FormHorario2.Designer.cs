namespace SAA_Project
{
    partial class FormHorario2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHorario2));
            this.labelBiblio = new System.Windows.Forms.Label();
            this.regimeEstudoAluno = new System.Windows.Forms.ComboBox();
            this.passAluno = new System.Windows.Forms.TextBox();
            this.labelCurso = new System.Windows.Forms.Label();
            this.labelIdade = new System.Windows.Forms.Label();
            this.labelHorario = new System.Windows.Forms.Label();
            this.labelNMEC = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelNMEC_TUTOR = new System.Windows.Forms.Label();
            this.labelRegime = new System.Windows.Forms.Label();
            this.idadeAluno = new System.Windows.Forms.TextBox();
            this.nmecTutorAluno = new System.Windows.Forms.TextBox();
            this.idCursoAluno = new System.Windows.Forms.TextBox();
            this.idBibliotecaAluno = new System.Windows.Forms.TextBox();
            this.idHorarioAluno = new System.Windows.Forms.TextBox();
            this.nmecAluno = new System.Windows.Forms.TextBox();
            this.emailAluno = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.nomeAluno = new System.Windows.Forms.TextBox();
            this.listHorarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gabineteProf = new System.Windows.Forms.TextBox();
            this.depProf = new System.Windows.Forms.TextBox();
            this.tnmecProf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nomeProf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.emailProf = new System.Windows.Forms.TextBox();
            this.listaAlunos = new System.Windows.Forms.ListBox();
            this.labelnome2 = new System.Windows.Forms.Label();
            this.labelnmec2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBiblio
            // 
            this.labelBiblio.AutoSize = true;
            this.labelBiblio.Location = new System.Drawing.Point(429, 224);
            this.labelBiblio.Name = "labelBiblio";
            this.labelBiblio.Size = new System.Drawing.Size(53, 13);
            this.labelBiblio.TabIndex = 156;
            this.labelBiblio.Text = "Biblioteca";
            // 
            // regimeEstudoAluno
            // 
            this.regimeEstudoAluno.Enabled = false;
            this.regimeEstudoAluno.FormattingEnabled = true;
            this.regimeEstudoAluno.Items.AddRange(new object[] {
            "Estudante",
            "TrabalhadorEstudante",
            "EstudanteInternacional",
            "Erasmus"});
            this.regimeEstudoAluno.Location = new System.Drawing.Point(247, 282);
            this.regimeEstudoAluno.Name = "regimeEstudoAluno";
            this.regimeEstudoAluno.Size = new System.Drawing.Size(155, 21);
            this.regimeEstudoAluno.TabIndex = 155;
            // 
            // passAluno
            // 
            this.passAluno.Location = new System.Drawing.Point(435, 282);
            this.passAluno.Name = "passAluno";
            this.passAluno.ReadOnly = true;
            this.passAluno.Size = new System.Drawing.Size(47, 20);
            this.passAluno.TabIndex = 152;
            // 
            // labelCurso
            // 
            this.labelCurso.AutoSize = true;
            this.labelCurso.Location = new System.Drawing.Point(243, 224);
            this.labelCurso.Name = "labelCurso";
            this.labelCurso.Size = new System.Drawing.Size(34, 13);
            this.labelCurso.TabIndex = 147;
            this.labelCurso.Text = "Curso";
            // 
            // labelIdade
            // 
            this.labelIdade.AutoSize = true;
            this.labelIdade.Location = new System.Drawing.Point(429, 144);
            this.labelIdade.Name = "labelIdade";
            this.labelIdade.Size = new System.Drawing.Size(34, 13);
            this.labelIdade.TabIndex = 146;
            this.labelIdade.Text = "Idade";
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Location = new System.Drawing.Point(335, 222);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(41, 13);
            this.labelHorario.TabIndex = 145;
            this.labelHorario.Text = "Horario";
            // 
            // labelNMEC
            // 
            this.labelNMEC.AutoSize = true;
            this.labelNMEC.Location = new System.Drawing.Point(244, 144);
            this.labelNMEC.Name = "labelNMEC";
            this.labelNMEC.Size = new System.Drawing.Size(38, 13);
            this.labelNMEC.TabIndex = 144;
            this.labelNMEC.Text = "NMEC";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(244, 183);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 143;
            this.labelEmail.Text = "Email";
            // 
            // labelNMEC_TUTOR
            // 
            this.labelNMEC_TUTOR.AutoSize = true;
            this.labelNMEC_TUTOR.Location = new System.Drawing.Point(336, 144);
            this.labelNMEC_TUTOR.Name = "labelNMEC_TUTOR";
            this.labelNMEC_TUTOR.Size = new System.Drawing.Size(66, 13);
            this.labelNMEC_TUTOR.TabIndex = 142;
            this.labelNMEC_TUTOR.Text = "NMEC Tutor";
            // 
            // labelRegime
            // 
            this.labelRegime.AutoSize = true;
            this.labelRegime.Location = new System.Drawing.Point(244, 266);
            this.labelRegime.Name = "labelRegime";
            this.labelRegime.Size = new System.Drawing.Size(79, 13);
            this.labelRegime.TabIndex = 141;
            this.labelRegime.Text = "Regime Estudo";
            // 
            // idadeAluno
            // 
            this.idadeAluno.Location = new System.Drawing.Point(432, 160);
            this.idadeAluno.Name = "idadeAluno";
            this.idadeAluno.ReadOnly = true;
            this.idadeAluno.Size = new System.Drawing.Size(75, 20);
            this.idadeAluno.TabIndex = 140;
            // 
            // nmecTutorAluno
            // 
            this.nmecTutorAluno.Location = new System.Drawing.Point(339, 160);
            this.nmecTutorAluno.Name = "nmecTutorAluno";
            this.nmecTutorAluno.ReadOnly = true;
            this.nmecTutorAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecTutorAluno.TabIndex = 139;
            // 
            // idCursoAluno
            // 
            this.idCursoAluno.Location = new System.Drawing.Point(246, 240);
            this.idCursoAluno.Name = "idCursoAluno";
            this.idCursoAluno.ReadOnly = true;
            this.idCursoAluno.Size = new System.Drawing.Size(77, 20);
            this.idCursoAluno.TabIndex = 138;
            // 
            // idBibliotecaAluno
            // 
            this.idBibliotecaAluno.Location = new System.Drawing.Point(432, 240);
            this.idBibliotecaAluno.Name = "idBibliotecaAluno";
            this.idBibliotecaAluno.ReadOnly = true;
            this.idBibliotecaAluno.Size = new System.Drawing.Size(75, 20);
            this.idBibliotecaAluno.TabIndex = 137;
            // 
            // idHorarioAluno
            // 
            this.idHorarioAluno.Location = new System.Drawing.Point(339, 240);
            this.idHorarioAluno.Name = "idHorarioAluno";
            this.idHorarioAluno.ReadOnly = true;
            this.idHorarioAluno.Size = new System.Drawing.Size(76, 20);
            this.idHorarioAluno.TabIndex = 136;
            // 
            // nmecAluno
            // 
            this.nmecAluno.Location = new System.Drawing.Point(247, 160);
            this.nmecAluno.Name = "nmecAluno";
            this.nmecAluno.ReadOnly = true;
            this.nmecAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecAluno.TabIndex = 135;
            // 
            // emailAluno
            // 
            this.emailAluno.Location = new System.Drawing.Point(247, 199);
            this.emailAluno.Name = "emailAluno";
            this.emailAluno.ReadOnly = true;
            this.emailAluno.Size = new System.Drawing.Size(260, 20);
            this.emailAluno.TabIndex = 134;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(244, 99);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(47, 17);
            this.labelNome.TabIndex = 133;
            this.labelNome.Text = "Nome";
            // 
            // nomeAluno
            // 
            this.nomeAluno.Location = new System.Drawing.Point(247, 119);
            this.nomeAluno.Name = "nomeAluno";
            this.nomeAluno.ReadOnly = true;
            this.nomeAluno.Size = new System.Drawing.Size(260, 20);
            this.nomeAluno.TabIndex = 132;
            // 
            // listHorarios
            // 
            this.listHorarios.FormattingEnabled = true;
            this.listHorarios.Location = new System.Drawing.Point(21, 79);
            this.listHorarios.Name = "listHorarios";
            this.listHorarios.Size = new System.Drawing.Size(42, 264);
            this.listHorarios.TabIndex = 158;
            this.listHorarios.SelectedIndexChanged += new System.EventHandler(this.listHorarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 159;
            this.label1.Text = "Horarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 160;
            this.label2.Text = "Aluno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(545, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 161;
            this.label3.Text = "Professor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 168;
            this.label5.Text = "TNMEC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(624, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 167;
            this.label6.Text = "Departamento";
            // 
            // gabineteProf
            // 
            this.gabineteProf.Location = new System.Drawing.Point(716, 160);
            this.gabineteProf.Name = "gabineteProf";
            this.gabineteProf.ReadOnly = true;
            this.gabineteProf.Size = new System.Drawing.Size(66, 20);
            this.gabineteProf.TabIndex = 166;
            // 
            // depProf
            // 
            this.depProf.Location = new System.Drawing.Point(627, 160);
            this.depProf.Name = "depProf";
            this.depProf.ReadOnly = true;
            this.depProf.Size = new System.Drawing.Size(71, 20);
            this.depProf.TabIndex = 165;
            // 
            // tnmecProf
            // 
            this.tnmecProf.Location = new System.Drawing.Point(549, 160);
            this.tnmecProf.Name = "tnmecProf";
            this.tnmecProf.ReadOnly = true;
            this.tnmecProf.Size = new System.Drawing.Size(59, 20);
            this.tnmecProf.TabIndex = 164;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(546, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 163;
            this.label7.Text = "Nome";
            // 
            // nomeProf
            // 
            this.nomeProf.Location = new System.Drawing.Point(549, 119);
            this.nomeProf.Name = "nomeProf";
            this.nomeProf.ReadOnly = true;
            this.nomeProf.Size = new System.Drawing.Size(233, 20);
            this.nomeProf.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(713, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 169;
            this.label4.Text = "Gabinete";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 171;
            this.label8.Text = "Email";
            // 
            // emailProf
            // 
            this.emailProf.Location = new System.Drawing.Point(549, 199);
            this.emailProf.Name = "emailProf";
            this.emailProf.ReadOnly = true;
            this.emailProf.Size = new System.Drawing.Size(233, 20);
            this.emailProf.TabIndex = 170;
            // 
            // listaAlunos
            // 
            this.listaAlunos.FormattingEnabled = true;
            this.listaAlunos.Location = new System.Drawing.Point(69, 78);
            this.listaAlunos.Name = "listaAlunos";
            this.listaAlunos.Size = new System.Drawing.Size(142, 264);
            this.listaAlunos.TabIndex = 172;
            this.listaAlunos.Visible = false;
            this.listaAlunos.SelectedIndexChanged += new System.EventHandler(this.listaUsers_SelectedIndexChanged);
            // 
            // labelnome2
            // 
            this.labelnome2.AutoSize = true;
            this.labelnome2.Font = new System.Drawing.Font("Arial", 7F);
            this.labelnome2.Location = new System.Drawing.Point(124, 62);
            this.labelnome2.Name = "labelnome2";
            this.labelnome2.Size = new System.Drawing.Size(35, 13);
            this.labelnome2.TabIndex = 174;
            this.labelnome2.Text = "Nome";
            this.labelnome2.Visible = false;
            // 
            // labelnmec2
            // 
            this.labelnmec2.AutoSize = true;
            this.labelnmec2.Font = new System.Drawing.Font("Arial", 7F);
            this.labelnmec2.Location = new System.Drawing.Point(70, 62);
            this.labelnmec2.Name = "labelnmec2";
            this.labelnmec2.Size = new System.Drawing.Size(37, 13);
            this.labelnmec2.TabIndex = 173;
            this.labelnmec2.Text = "NMEC";
            this.labelnmec2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(716, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 30);
            this.button1.TabIndex = 175;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(669, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 176;
            this.button2.Text = "Menu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.Transparent;
            this.Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Login.BackgroundImage")));
            this.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Login.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Login.Location = new System.Drawing.Point(750, 7);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(43, 33);
            this.Login.TabIndex = 177;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // FormHorario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelnome2);
            this.Controls.Add(this.labelnmec2);
            this.Controls.Add(this.listaAlunos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emailProf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gabineteProf);
            this.Controls.Add(this.depProf);
            this.Controls.Add(this.tnmecProf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nomeProf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listHorarios);
            this.Controls.Add(this.labelBiblio);
            this.Controls.Add(this.regimeEstudoAluno);
            this.Controls.Add(this.passAluno);
            this.Controls.Add(this.labelCurso);
            this.Controls.Add(this.labelIdade);
            this.Controls.Add(this.labelHorario);
            this.Controls.Add(this.labelNMEC);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelNMEC_TUTOR);
            this.Controls.Add(this.labelRegime);
            this.Controls.Add(this.idadeAluno);
            this.Controls.Add(this.nmecTutorAluno);
            this.Controls.Add(this.idCursoAluno);
            this.Controls.Add(this.idBibliotecaAluno);
            this.Controls.Add(this.idHorarioAluno);
            this.Controls.Add(this.nmecAluno);
            this.Controls.Add(this.emailAluno);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.nomeAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHorario2";
            this.Text = "FormHorario2";
            this.Load += new System.EventHandler(this.FormHorario2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelBiblio;
        private System.Windows.Forms.ComboBox regimeEstudoAluno;
        private System.Windows.Forms.TextBox passAluno;
        private System.Windows.Forms.Label labelCurso;
        private System.Windows.Forms.Label labelIdade;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.Label labelNMEC;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelNMEC_TUTOR;
        private System.Windows.Forms.Label labelRegime;
        private System.Windows.Forms.TextBox idadeAluno;
        private System.Windows.Forms.TextBox nmecTutorAluno;
        private System.Windows.Forms.TextBox idCursoAluno;
        private System.Windows.Forms.TextBox idBibliotecaAluno;
        private System.Windows.Forms.TextBox idHorarioAluno;
        private System.Windows.Forms.TextBox nmecAluno;
        private System.Windows.Forms.TextBox emailAluno;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox nomeAluno;
        private System.Windows.Forms.ListBox listHorarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox gabineteProf;
        private System.Windows.Forms.TextBox depProf;
        private System.Windows.Forms.TextBox tnmecProf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nomeProf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailProf;
        private System.Windows.Forms.ListBox listaAlunos;
        private System.Windows.Forms.Label labelnome2;
        private System.Windows.Forms.Label labelnmec2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Login;
    }
}