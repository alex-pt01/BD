namespace SAA_Project
{
    partial class FormAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAluno));
            this.nomeAluno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listAluno = new System.Windows.Forms.ListBox();
            this.emailAluno = new System.Windows.Forms.TextBox();
            this.nmecAluno = new System.Windows.Forms.TextBox();
            this.idHorarioAluno = new System.Windows.Forms.TextBox();
            this.idBibliotecaAluno = new System.Windows.Forms.TextBox();
            this.idCursoAluno = new System.Windows.Forms.TextBox();
            this.nmecTutorAluno = new System.Windows.Forms.TextBox();
            this.idadeAluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelProf = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.adicionarBtn = new System.Windows.Forms.Button();
            this.limparBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.confirmBtn2 = new System.Windows.Forms.Button();
            this.regimeEstudoAluno = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.NextPage = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.n_Alunos = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nomeAluno
            // 
            this.nomeAluno.Location = new System.Drawing.Point(344, 108);
            this.nomeAluno.Name = "nomeAluno";
            this.nomeAluno.ReadOnly = true;
            this.nomeAluno.Size = new System.Drawing.Size(260, 20);
            this.nomeAluno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // listAluno
            // 
            this.listAluno.FormattingEnabled = true;
            this.listAluno.Location = new System.Drawing.Point(32, 61);
            this.listAluno.Name = "listAluno";
            this.listAluno.Size = new System.Drawing.Size(245, 342);
            this.listAluno.TabIndex = 3;
            this.listAluno.SelectedIndexChanged += new System.EventHandler(this.listAluno_SelectedIndexChanged);
            // 
            // emailAluno
            // 
            this.emailAluno.Location = new System.Drawing.Point(344, 188);
            this.emailAluno.Name = "emailAluno";
            this.emailAluno.ReadOnly = true;
            this.emailAluno.Size = new System.Drawing.Size(260, 20);
            this.emailAluno.TabIndex = 4;
            // 
            // nmecAluno
            // 
            this.nmecAluno.Location = new System.Drawing.Point(344, 149);
            this.nmecAluno.Name = "nmecAluno";
            this.nmecAluno.ReadOnly = true;
            this.nmecAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecAluno.TabIndex = 6;
            // 
            // idHorarioAluno
            // 
            this.idHorarioAluno.Location = new System.Drawing.Point(426, 270);
            this.idHorarioAluno.Name = "idHorarioAluno";
            this.idHorarioAluno.ReadOnly = true;
            this.idHorarioAluno.Size = new System.Drawing.Size(63, 20);
            this.idHorarioAluno.TabIndex = 7;
            // 
            // idBibliotecaAluno
            // 
            this.idBibliotecaAluno.Location = new System.Drawing.Point(517, 229);
            this.idBibliotecaAluno.Name = "idBibliotecaAluno";
            this.idBibliotecaAluno.ReadOnly = true;
            this.idBibliotecaAluno.Size = new System.Drawing.Size(87, 20);
            this.idBibliotecaAluno.TabIndex = 8;
            // 
            // idCursoAluno
            // 
            this.idCursoAluno.Location = new System.Drawing.Point(344, 270);
            this.idCursoAluno.Name = "idCursoAluno";
            this.idCursoAluno.ReadOnly = true;
            this.idCursoAluno.Size = new System.Drawing.Size(63, 20);
            this.idCursoAluno.TabIndex = 10;
            // 
            // nmecTutorAluno
            // 
            this.nmecTutorAluno.Location = new System.Drawing.Point(436, 149);
            this.nmecTutorAluno.Name = "nmecTutorAluno";
            this.nmecTutorAluno.ReadOnly = true;
            this.nmecTutorAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecTutorAluno.TabIndex = 11;
            // 
            // idadeAluno
            // 
            this.idadeAluno.Location = new System.Drawing.Point(529, 149);
            this.idadeAluno.Name = "idadeAluno";
            this.idadeAluno.ReadOnly = true;
            this.idadeAluno.Size = new System.Drawing.Size(75, 20);
            this.idadeAluno.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Regime Estudo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "NMEC Tutor";
            // 
            // labelProf
            // 
            this.labelProf.AutoSize = true;
            this.labelProf.Font = new System.Drawing.Font("Arial", 14F);
            this.labelProf.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelProf.Location = new System.Drawing.Point(28, 24);
            this.labelProf.Name = "labelProf";
            this.labelProf.Size = new System.Drawing.Size(133, 22);
            this.labelProf.TabIndex = 15;
            this.labelProf.Text = "Perfil do Aluno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "NMEC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Horario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Idade";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(341, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "Curso";
            // 
            // adicionarBtn
            // 
            this.adicionarBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.adicionarBtn.Location = new System.Drawing.Point(344, 307);
            this.adicionarBtn.Name = "adicionarBtn";
            this.adicionarBtn.Size = new System.Drawing.Size(76, 28);
            this.adicionarBtn.TabIndex = 86;
            this.adicionarBtn.Text = "Adicionar";
            this.adicionarBtn.UseVisualStyleBackColor = true;
            this.adicionarBtn.Click += new System.EventHandler(this.adicionarBtn_Click);
            // 
            // limparBtn
            // 
            this.limparBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.limparBtn.Location = new System.Drawing.Point(517, 264);
            this.limparBtn.Name = "limparBtn";
            this.limparBtn.Size = new System.Drawing.Size(87, 28);
            this.limparBtn.TabIndex = 87;
            this.limparBtn.Text = "Limpar";
            this.limparBtn.UseVisualStyleBackColor = true;
            this.limparBtn.Visible = false;
            this.limparBtn.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.updateBtn.Location = new System.Drawing.Point(435, 307);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(76, 28);
            this.updateBtn.TabIndex = 88;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.Update_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.cancelarBtn.Location = new System.Drawing.Point(524, 307);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(80, 28);
            this.cancelarBtn.TabIndex = 89;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Visible = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.confirmBtn.Location = new System.Drawing.Point(344, 307);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(95, 28);
            this.confirmBtn.TabIndex = 91;
            this.confirmBtn.Text = "Confirmar";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Visible = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmButon_Click);
            // 
            // confirmBtn2
            // 
            this.confirmBtn2.Font = new System.Drawing.Font("Arial", 11F);
            this.confirmBtn2.Location = new System.Drawing.Point(344, 307);
            this.confirmBtn2.Name = "confirmBtn2";
            this.confirmBtn2.Size = new System.Drawing.Size(95, 28);
            this.confirmBtn2.TabIndex = 92;
            this.confirmBtn2.Text = "Confirmar";
            this.confirmBtn2.UseVisualStyleBackColor = true;
            this.confirmBtn2.Visible = false;
            this.confirmBtn2.Click += new System.EventHandler(this.confirmBtn2_Click);
            // 
            // regimeEstudoAluno
            // 
            this.regimeEstudoAluno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regimeEstudoAluno.Enabled = false;
            this.regimeEstudoAluno.FormattingEnabled = true;
            this.regimeEstudoAluno.Items.AddRange(new object[] {
            "Estudante",
            "TrabalhadorEstudante",
            "EstudanteInternacional",
            "Erasmus"});
            this.regimeEstudoAluno.Location = new System.Drawing.Point(344, 228);
            this.regimeEstudoAluno.Name = "regimeEstudoAluno";
            this.regimeEstudoAluno.Size = new System.Drawing.Size(155, 21);
            this.regimeEstudoAluno.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(514, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Biblioteca";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 7F);
            this.label15.Location = new System.Drawing.Point(85, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Nome";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 7F);
            this.label16.Location = new System.Drawing.Point(29, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 100;
            this.label16.Text = "NMEC";
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.eliminarBtn.Location = new System.Drawing.Point(528, 307);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(76, 28);
            this.eliminarBtn.TabIndex = 103;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click_1);
            // 
            // NextPage
            // 
            this.NextPage.BackColor = System.Drawing.SystemColors.Control;
            this.NextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NextPage.Location = new System.Drawing.Point(711, 408);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(77, 30);
            this.NextPage.TabIndex = 104;
            this.NextPage.Text = "Next";
            this.NextPage.UseVisualStyleBackColor = false;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 146;
            this.label8.Text = "Numero de Alunos:";
            // 
            // n_Alunos
            // 
            this.n_Alunos.Location = new System.Drawing.Point(176, 406);
            this.n_Alunos.Name = "n_Alunos";
            this.n_Alunos.ReadOnly = true;
            this.n_Alunos.Size = new System.Drawing.Size(46, 20);
            this.n_Alunos.TabIndex = 145;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Arial", 11F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(690, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 26);
            this.button2.TabIndex = 147;
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
            this.Login.Location = new System.Drawing.Point(753, 9);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(43, 33);
            this.Login.TabIndex = 178;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // FormAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.n_Alunos);
            this.Controls.Add(this.NextPage);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.regimeEstudoAluno);
            this.Controls.Add(this.confirmBtn2);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.limparBtn);
            this.Controls.Add(this.adicionarBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelProf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idadeAluno);
            this.Controls.Add(this.nmecTutorAluno);
            this.Controls.Add(this.idCursoAluno);
            this.Controls.Add(this.idBibliotecaAluno);
            this.Controls.Add(this.idHorarioAluno);
            this.Controls.Add(this.nmecAluno);
            this.Controls.Add(this.emailAluno);
            this.Controls.Add(this.listAluno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomeAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAluno";
            this.Text = "Aluno";
            this.Load += new System.EventHandler(this.FormAluno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nomeAluno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listAluno;
        private System.Windows.Forms.TextBox emailAluno;
        private System.Windows.Forms.TextBox nmecAluno;
        private System.Windows.Forms.TextBox idHorarioAluno;
        private System.Windows.Forms.TextBox idBibliotecaAluno;
        private System.Windows.Forms.TextBox idCursoAluno;
        private System.Windows.Forms.TextBox nmecTutorAluno;
        private System.Windows.Forms.TextBox idadeAluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelProf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button adicionarBtn;
        private System.Windows.Forms.Button limparBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button confirmBtn2;
        private System.Windows.Forms.ComboBox regimeEstudoAluno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox n_Alunos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Login;
    }
}