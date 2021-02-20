namespace SAA_Project
{
    partial class FormHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHorario));
            this.comboBoxHorarios = new System.Windows.Forms.ComboBox();
            this.listHorarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelnome2 = new System.Windows.Forms.Label();
            this.labelnmec2 = new System.Windows.Forms.Label();
            this.labelBiblio = new System.Windows.Forms.Label();
            this.regimeEstudoAluno = new System.Windows.Forms.ComboBox();
            this.confirmBtn2 = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.limparBtn = new System.Windows.Forms.Button();
            this.adicionarBtn = new System.Windows.Forms.Button();
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
            this.listaUsers = new System.Windows.Forms.ListBox();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.adicionarHorarioBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxHorarios
            // 
            this.comboBoxHorarios.Enabled = false;
            this.comboBoxHorarios.FormattingEnabled = true;
            this.comboBoxHorarios.Items.AddRange(new object[] {
            "Aluno",
            "Professor",
            "Turma",
            "UC"});
            this.comboBoxHorarios.Location = new System.Drawing.Point(138, 58);
            this.comboBoxHorarios.Name = "comboBoxHorarios";
            this.comboBoxHorarios.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHorarios.TabIndex = 98;
            this.comboBoxHorarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxHorarios_SelectedIndexChanged);
            // 
            // listHorarios
            // 
            this.listHorarios.FormattingEnabled = true;
            this.listHorarios.Location = new System.Drawing.Point(26, 62);
            this.listHorarios.Name = "listHorarios";
            this.listHorarios.Size = new System.Drawing.Size(75, 264);
            this.listHorarios.TabIndex = 99;
            this.listHorarios.SelectedIndexChanged += new System.EventHandler(this.listHorarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Horarios";
            // 
            // labelnome2
            // 
            this.labelnome2.AutoSize = true;
            this.labelnome2.Font = new System.Drawing.Font("Arial", 7F);
            this.labelnome2.Location = new System.Drawing.Point(189, 85);
            this.labelnome2.Name = "labelnome2";
            this.labelnome2.Size = new System.Drawing.Size(35, 13);
            this.labelnome2.TabIndex = 104;
            this.labelnome2.Text = "Nome";
            this.labelnome2.Visible = false;
            // 
            // labelnmec2
            // 
            this.labelnmec2.AutoSize = true;
            this.labelnmec2.Font = new System.Drawing.Font("Arial", 7F);
            this.labelnmec2.Location = new System.Drawing.Point(135, 85);
            this.labelnmec2.Name = "labelnmec2";
            this.labelnmec2.Size = new System.Drawing.Size(37, 13);
            this.labelnmec2.TabIndex = 103;
            this.labelnmec2.Text = "NMEC";
            this.labelnmec2.Visible = false;
            // 
            // labelBiblio
            // 
            this.labelBiblio.AutoSize = true;
            this.labelBiblio.Location = new System.Drawing.Point(529, 206);
            this.labelBiblio.Name = "labelBiblio";
            this.labelBiblio.Size = new System.Drawing.Size(53, 13);
            this.labelBiblio.TabIndex = 129;
            this.labelBiblio.Text = "Biblioteca";
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
            this.regimeEstudoAluno.Location = new System.Drawing.Point(347, 264);
            this.regimeEstudoAluno.Name = "regimeEstudoAluno";
            this.regimeEstudoAluno.Size = new System.Drawing.Size(155, 21);
            this.regimeEstudoAluno.TabIndex = 128;
            // 
            // confirmBtn2
            // 
            this.confirmBtn2.Font = new System.Drawing.Font("Arial", 11F);
            this.confirmBtn2.Location = new System.Drawing.Point(346, 299);
            this.confirmBtn2.Name = "confirmBtn2";
            this.confirmBtn2.Size = new System.Drawing.Size(86, 28);
            this.confirmBtn2.TabIndex = 127;
            this.confirmBtn2.Text = "Confirmar";
            this.confirmBtn2.UseVisualStyleBackColor = true;
            this.confirmBtn2.Visible = false;
            this.confirmBtn2.Click += new System.EventHandler(this.confirmBtn2_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.confirmBtn.Location = new System.Drawing.Point(346, 299);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(85, 28);
            this.confirmBtn.TabIndex = 126;
            this.confirmBtn.Text = "Confirmar";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Visible = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.cancelarBtn.Location = new System.Drawing.Point(521, 298);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(86, 29);
            this.cancelarBtn.TabIndex = 124;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Visible = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(433, 299);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(76, 28);
            this.updateBtn.TabIndex = 123;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // limparBtn
            // 
            this.limparBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.limparBtn.Location = new System.Drawing.Point(438, 299);
            this.limparBtn.Name = "limparBtn";
            this.limparBtn.Size = new System.Drawing.Size(77, 28);
            this.limparBtn.TabIndex = 122;
            this.limparBtn.Text = "Limpar";
            this.limparBtn.UseVisualStyleBackColor = true;
            this.limparBtn.Visible = false;
            this.limparBtn.Click += new System.EventHandler(this.limparBtn_Click);
            // 
            // adicionarBtn
            // 
            this.adicionarBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.adicionarBtn.Location = new System.Drawing.Point(347, 299);
            this.adicionarBtn.Name = "adicionarBtn";
            this.adicionarBtn.Size = new System.Drawing.Size(76, 28);
            this.adicionarBtn.TabIndex = 121;
            this.adicionarBtn.Text = "Adicionar";
            this.adicionarBtn.UseVisualStyleBackColor = true;
            this.adicionarBtn.Click += new System.EventHandler(this.adicionarBtn_Click);
            // 
            // labelCurso
            // 
            this.labelCurso.AutoSize = true;
            this.labelCurso.Location = new System.Drawing.Point(343, 206);
            this.labelCurso.Name = "labelCurso";
            this.labelCurso.Size = new System.Drawing.Size(34, 13);
            this.labelCurso.TabIndex = 120;
            this.labelCurso.Text = "Curso";
            // 
            // labelIdade
            // 
            this.labelIdade.AutoSize = true;
            this.labelIdade.Location = new System.Drawing.Point(529, 126);
            this.labelIdade.Name = "labelIdade";
            this.labelIdade.Size = new System.Drawing.Size(34, 13);
            this.labelIdade.TabIndex = 119;
            this.labelIdade.Text = "Idade";
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Location = new System.Drawing.Point(435, 204);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(41, 13);
            this.labelHorario.TabIndex = 118;
            this.labelHorario.Text = "Horario";
            // 
            // labelNMEC
            // 
            this.labelNMEC.AutoSize = true;
            this.labelNMEC.Location = new System.Drawing.Point(344, 126);
            this.labelNMEC.Name = "labelNMEC";
            this.labelNMEC.Size = new System.Drawing.Size(38, 13);
            this.labelNMEC.TabIndex = 117;
            this.labelNMEC.Text = "NMEC";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(344, 165);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 116;
            this.labelEmail.Text = "Email";
            // 
            // labelNMEC_TUTOR
            // 
            this.labelNMEC_TUTOR.AutoSize = true;
            this.labelNMEC_TUTOR.Location = new System.Drawing.Point(436, 126);
            this.labelNMEC_TUTOR.Name = "labelNMEC_TUTOR";
            this.labelNMEC_TUTOR.Size = new System.Drawing.Size(66, 13);
            this.labelNMEC_TUTOR.TabIndex = 115;
            this.labelNMEC_TUTOR.Text = "NMEC Tutor";
            // 
            // labelRegime
            // 
            this.labelRegime.AutoSize = true;
            this.labelRegime.Location = new System.Drawing.Point(344, 248);
            this.labelRegime.Name = "labelRegime";
            this.labelRegime.Size = new System.Drawing.Size(79, 13);
            this.labelRegime.TabIndex = 114;
            this.labelRegime.Text = "Regime Estudo";
            // 
            // idadeAluno
            // 
            this.idadeAluno.Location = new System.Drawing.Point(532, 142);
            this.idadeAluno.Name = "idadeAluno";
            this.idadeAluno.ReadOnly = true;
            this.idadeAluno.Size = new System.Drawing.Size(75, 20);
            this.idadeAluno.TabIndex = 113;
            // 
            // nmecTutorAluno
            // 
            this.nmecTutorAluno.Location = new System.Drawing.Point(439, 142);
            this.nmecTutorAluno.Name = "nmecTutorAluno";
            this.nmecTutorAluno.ReadOnly = true;
            this.nmecTutorAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecTutorAluno.TabIndex = 112;
            // 
            // idCursoAluno
            // 
            this.idCursoAluno.Location = new System.Drawing.Point(346, 222);
            this.idCursoAluno.Name = "idCursoAluno";
            this.idCursoAluno.ReadOnly = true;
            this.idCursoAluno.Size = new System.Drawing.Size(77, 20);
            this.idCursoAluno.TabIndex = 111;
            // 
            // idBibliotecaAluno
            // 
            this.idBibliotecaAluno.Location = new System.Drawing.Point(532, 222);
            this.idBibliotecaAluno.Name = "idBibliotecaAluno";
            this.idBibliotecaAluno.ReadOnly = true;
            this.idBibliotecaAluno.Size = new System.Drawing.Size(75, 20);
            this.idBibliotecaAluno.TabIndex = 110;
            // 
            // idHorarioAluno
            // 
            this.idHorarioAluno.Location = new System.Drawing.Point(439, 222);
            this.idHorarioAluno.Name = "idHorarioAluno";
            this.idHorarioAluno.ReadOnly = true;
            this.idHorarioAluno.Size = new System.Drawing.Size(76, 20);
            this.idHorarioAluno.TabIndex = 109;
            // 
            // nmecAluno
            // 
            this.nmecAluno.Location = new System.Drawing.Point(347, 142);
            this.nmecAluno.Name = "nmecAluno";
            this.nmecAluno.ReadOnly = true;
            this.nmecAluno.Size = new System.Drawing.Size(76, 20);
            this.nmecAluno.TabIndex = 108;
            // 
            // emailAluno
            // 
            this.emailAluno.Location = new System.Drawing.Point(347, 181);
            this.emailAluno.Name = "emailAluno";
            this.emailAluno.ReadOnly = true;
            this.emailAluno.Size = new System.Drawing.Size(260, 20);
            this.emailAluno.TabIndex = 107;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(344, 81);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(47, 17);
            this.labelNome.TabIndex = 106;
            this.labelNome.Text = "Nome";
            // 
            // nomeAluno
            // 
            this.nomeAluno.Location = new System.Drawing.Point(347, 101);
            this.nomeAluno.Name = "nomeAluno";
            this.nomeAluno.ReadOnly = true;
            this.nomeAluno.Size = new System.Drawing.Size(260, 20);
            this.nomeAluno.TabIndex = 105;
            // 
            // listaUsers
            // 
            this.listaUsers.FormattingEnabled = true;
            this.listaUsers.Location = new System.Drawing.Point(138, 101);
            this.listaUsers.Name = "listaUsers";
            this.listaUsers.Size = new System.Drawing.Size(162, 225);
            this.listaUsers.TabIndex = 130;
            this.listaUsers.Visible = false;
            this.listaUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxAlunos_SelectedIndexChanged);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarBtn.Location = new System.Drawing.Point(520, 298);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(87, 28);
            this.eliminarBtn.TabIndex = 131;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(26, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 45);
            this.button2.TabIndex = 132;
            this.button2.Text = "Eliminar Horario";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // adicionarHorarioBtn
            // 
            this.adicionarHorarioBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adicionarHorarioBtn.Location = new System.Drawing.Point(26, 342);
            this.adicionarHorarioBtn.Name = "adicionarHorarioBtn";
            this.adicionarHorarioBtn.Size = new System.Drawing.Size(75, 45);
            this.adicionarHorarioBtn.TabIndex = 133;
            this.adicionarHorarioBtn.Text = "Adicionar Horario";
            this.adicionarHorarioBtn.UseVisualStyleBackColor = true;
            this.adicionarHorarioBtn.Click += new System.EventHandler(this.adicionarHorarioBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 150;
            this.label2.Text = "Selecione um";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(670, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 177;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
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
            this.Login.Location = new System.Drawing.Point(751, 10);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(43, 33);
            this.Login.TabIndex = 179;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // FormHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adicionarHorarioBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.listaUsers);
            this.Controls.Add(this.labelBiblio);
            this.Controls.Add(this.regimeEstudoAluno);
            this.Controls.Add(this.confirmBtn2);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.limparBtn);
            this.Controls.Add(this.adicionarBtn);
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
            this.Controls.Add(this.labelnome2);
            this.Controls.Add(this.labelnmec2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listHorarios);
            this.Controls.Add(this.comboBoxHorarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHorario";
            this.Text = "FromHorario";
            this.Load += new System.EventHandler(this.FormHorario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxHorarios;
        private System.Windows.Forms.ListBox listHorarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelnome2;
        private System.Windows.Forms.Label labelnmec2;
        private System.Windows.Forms.Label labelBiblio;
        private System.Windows.Forms.ComboBox regimeEstudoAluno;
        private System.Windows.Forms.Button confirmBtn2;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button limparBtn;
        private System.Windows.Forms.Button adicionarBtn;
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
        private System.Windows.Forms.ListBox listaUsers;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button adicionarHorarioBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Login;
    }
}