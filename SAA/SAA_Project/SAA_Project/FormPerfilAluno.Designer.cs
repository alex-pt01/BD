namespace SAA_Project
{
    partial class FormPerfilAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPerfilAluno));
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxDep = new System.Windows.Forms.ComboBox();
            this.comboBoxCurso = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxAluno = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxTurma = new System.Windows.Forms.ComboBox();
            this.PreviousPage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmecAluno = new System.Windows.Forms.TextBox();
            this.emailAluno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nomeAluno = new System.Windows.Forms.TextBox();
            this.comboBoxBiblio = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.n_Alunos = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.listUCs = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.idCursoAluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.n_ucs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.media_aluno = new System.Windows.Forms.TextBox();
            this.id_uc_aluno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.falta_justificada = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.faltas_injustificada = new System.Windows.Forms.TextBox();
            this.labelProf = new System.Windows.Forms.Label();
            this.hideBtn = new System.Windows.Forms.Button();
            this.filtros_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 11F);
            this.button1.Location = new System.Drawing.Point(692, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 26);
            this.button1.TabIndex = 96;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 10F);
            this.label14.Location = new System.Drawing.Point(57, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 16);
            this.label14.TabIndex = 108;
            this.label14.Text = "Departamento";
            this.label14.Visible = false;
            // 
            // comboBoxDep
            // 
            this.comboBoxDep.FormattingEnabled = true;
            this.comboBoxDep.Location = new System.Drawing.Point(60, 115);
            this.comboBoxDep.Name = "comboBoxDep";
            this.comboBoxDep.Size = new System.Drawing.Size(95, 21);
            this.comboBoxDep.TabIndex = 107;
            this.comboBoxDep.Visible = false;
            this.comboBoxDep.SelectedIndexChanged += new System.EventHandler(this.comboBoxDep_SelectedIndexChanged);
            // 
            // comboBoxCurso
            // 
            this.comboBoxCurso.FormattingEnabled = true;
            this.comboBoxCurso.Location = new System.Drawing.Point(60, 174);
            this.comboBoxCurso.Name = "comboBoxCurso";
            this.comboBoxCurso.Size = new System.Drawing.Size(95, 21);
            this.comboBoxCurso.TabIndex = 106;
            this.comboBoxCurso.Visible = false;
            this.comboBoxCurso.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurso_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 10F);
            this.label13.Location = new System.Drawing.Point(57, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 16);
            this.label13.TabIndex = 105;
            this.label13.Text = "Curso";
            this.label13.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 7F);
            this.label9.Location = new System.Drawing.Point(278, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "Nome";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7F);
            this.label8.Location = new System.Drawing.Point(222, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "NMEC";
            // 
            // listBoxAluno
            // 
            this.listBoxAluno.FormattingEnabled = true;
            this.listBoxAluno.Location = new System.Drawing.Point(225, 58);
            this.listBoxAluno.Name = "listBoxAluno";
            this.listBoxAluno.Size = new System.Drawing.Size(159, 277);
            this.listBoxAluno.TabIndex = 101;
            this.listBoxAluno.SelectedIndexChanged += new System.EventHandler(this.listBoxAluno_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.Location = new System.Drawing.Point(57, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 103;
            this.label10.Text = "ID Turma";
            this.label10.Visible = false;
            // 
            // comboBoxTurma
            // 
            this.comboBoxTurma.FormattingEnabled = true;
            this.comboBoxTurma.Location = new System.Drawing.Point(60, 243);
            this.comboBoxTurma.Name = "comboBoxTurma";
            this.comboBoxTurma.Size = new System.Drawing.Size(95, 21);
            this.comboBoxTurma.TabIndex = 102;
            this.comboBoxTurma.Visible = false;
            this.comboBoxTurma.SelectedIndexChanged += new System.EventHandler(this.comboBoxTurma_SelectedIndexChanged);
            // 
            // PreviousPage
            // 
            this.PreviousPage.BackColor = System.Drawing.SystemColors.Control;
            this.PreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PreviousPage.Location = new System.Drawing.Point(711, 408);
            this.PreviousPage.Name = "PreviousPage";
            this.PreviousPage.Size = new System.Drawing.Size(77, 30);
            this.PreviousPage.TabIndex = 109;
            this.PreviousPage.Text = "Back";
            this.PreviousPage.UseVisualStyleBackColor = false;
            this.PreviousPage.Click += new System.EventHandler(this.PreviousPage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "NMEC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Email";
            // 
            // nmecAluno
            // 
            this.nmecAluno.Location = new System.Drawing.Point(510, 156);
            this.nmecAluno.Name = "nmecAluno";
            this.nmecAluno.ReadOnly = true;
            this.nmecAluno.Size = new System.Drawing.Size(90, 20);
            this.nmecAluno.TabIndex = 113;
            // 
            // emailAluno
            // 
            this.emailAluno.Location = new System.Drawing.Point(510, 198);
            this.emailAluno.Name = "emailAluno";
            this.emailAluno.ReadOnly = true;
            this.emailAluno.Size = new System.Drawing.Size(152, 20);
            this.emailAluno.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 111;
            this.label1.Text = "Nome";
            // 
            // nomeAluno
            // 
            this.nomeAluno.Location = new System.Drawing.Point(510, 110);
            this.nomeAluno.Name = "nomeAluno";
            this.nomeAluno.ReadOnly = true;
            this.nomeAluno.Size = new System.Drawing.Size(185, 20);
            this.nomeAluno.TabIndex = 110;
            // 
            // comboBoxBiblio
            // 
            this.comboBoxBiblio.FormattingEnabled = true;
            this.comboBoxBiblio.Location = new System.Drawing.Point(60, 314);
            this.comboBoxBiblio.Name = "comboBoxBiblio";
            this.comboBoxBiblio.Size = new System.Drawing.Size(95, 21);
            this.comboBoxBiblio.TabIndex = 141;
            this.comboBoxBiblio.Visible = false;
            this.comboBoxBiblio.SelectedIndexChanged += new System.EventHandler(this.comboBoxBiblio_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 10F);
            this.label15.Location = new System.Drawing.Point(57, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 16);
            this.label15.TabIndex = 142;
            this.label15.Text = "ID Biblioteca";
            this.label15.Visible = false;
            // 
            // n_Alunos
            // 
            this.n_Alunos.Location = new System.Drawing.Point(288, 342);
            this.n_Alunos.Name = "n_Alunos";
            this.n_Alunos.ReadOnly = true;
            this.n_Alunos.Size = new System.Drawing.Size(46, 20);
            this.n_Alunos.TabIndex = 143;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(222, 344);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 15);
            this.label16.TabIndex = 144;
            this.label16.Text = "Nº  Alunos:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
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
            this.Login.Location = new System.Drawing.Point(755, 9);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(43, 33);
            this.Login.TabIndex = 179;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // listUCs
            // 
            this.listUCs.FormattingEnabled = true;
            this.listUCs.Location = new System.Drawing.Point(390, 58);
            this.listUCs.Name = "listUCs";
            this.listUCs.Size = new System.Drawing.Size(68, 277);
            this.listUCs.TabIndex = 180;
            this.listUCs.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(606, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 125;
            this.label11.Text = "Curso";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // idCursoAluno
            // 
            this.idCursoAluno.Location = new System.Drawing.Point(609, 156);
            this.idCursoAluno.Name = "idCursoAluno";
            this.idCursoAluno.ReadOnly = true;
            this.idCursoAluno.Size = new System.Drawing.Size(86, 20);
            this.idCursoAluno.TabIndex = 140;
            this.idCursoAluno.TextChanged += new System.EventHandler(this.idCursoAluno_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 181;
            this.label2.Text = "Nº  Ucs:";
            // 
            // n_ucs
            // 
            this.n_ucs.Location = new System.Drawing.Point(412, 342);
            this.n_ucs.Name = "n_ucs";
            this.n_ucs.ReadOnly = true;
            this.n_ucs.Size = new System.Drawing.Size(46, 20);
            this.n_ucs.TabIndex = 182;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7F);
            this.label3.Location = new System.Drawing.Point(387, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 183;
            this.label3.Text = "ID Uc";
            // 
            // media_aluno
            // 
            this.media_aluno.Location = new System.Drawing.Point(609, 243);
            this.media_aluno.Name = "media_aluno";
            this.media_aluno.ReadOnly = true;
            this.media_aluno.Size = new System.Drawing.Size(86, 20);
            this.media_aluno.TabIndex = 185;
            // 
            // id_uc_aluno
            // 
            this.id_uc_aluno.Location = new System.Drawing.Point(510, 243);
            this.id_uc_aluno.Name = "id_uc_aluno";
            this.id_uc_aluno.ReadOnly = true;
            this.id_uc_aluno.Size = new System.Drawing.Size(90, 20);
            this.id_uc_aluno.TabIndex = 187;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 186;
            this.label7.Text = "ID UC";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(606, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 188;
            this.label12.Text = "Nota média";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 190;
            this.label6.Text = "Faltas Justificadas";
            // 
            // falta_justificada
            // 
            this.falta_justificada.Location = new System.Drawing.Point(510, 288);
            this.falta_justificada.Name = "falta_justificada";
            this.falta_justificada.ReadOnly = true;
            this.falta_justificada.Size = new System.Drawing.Size(90, 20);
            this.falta_justificada.TabIndex = 189;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(606, 272);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 192;
            this.label18.Text = "Faltas Injustificas";
            // 
            // faltas_injustificada
            // 
            this.faltas_injustificada.Location = new System.Drawing.Point(609, 288);
            this.faltas_injustificada.Name = "faltas_injustificada";
            this.faltas_injustificada.ReadOnly = true;
            this.faltas_injustificada.Size = new System.Drawing.Size(86, 20);
            this.faltas_injustificada.TabIndex = 191;
            // 
            // labelProf
            // 
            this.labelProf.AutoSize = true;
            this.labelProf.Font = new System.Drawing.Font("Arial", 14F);
            this.labelProf.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelProf.Location = new System.Drawing.Point(16, 9);
            this.labelProf.Name = "labelProf";
            this.labelProf.Size = new System.Drawing.Size(133, 22);
            this.labelProf.TabIndex = 193;
            this.labelProf.Text = "Perfil do Aluno";
            // 
            // hideBtn
            // 
            this.hideBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideBtn.Location = new System.Drawing.Point(60, 58);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.Size = new System.Drawing.Size(90, 28);
            this.hideBtn.TabIndex = 216;
            this.hideBtn.Text = "Esconder";
            this.hideBtn.UseVisualStyleBackColor = true;
            this.hideBtn.Visible = false;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // filtros_btn
            // 
            this.filtros_btn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtros_btn.Location = new System.Drawing.Point(60, 58);
            this.filtros_btn.Name = "filtros_btn";
            this.filtros_btn.Size = new System.Drawing.Size(90, 28);
            this.filtros_btn.TabIndex = 217;
            this.filtros_btn.Text = "Filtros";
            this.filtros_btn.UseVisualStyleBackColor = true;
            this.filtros_btn.Click += new System.EventHandler(this.filtros_btn_Click);
            // 
            // FormPerfilAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filtros_btn);
            this.Controls.Add(this.hideBtn);
            this.Controls.Add(this.labelProf);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.faltas_injustificada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.falta_justificada);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.id_uc_aluno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.media_aluno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.n_ucs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listUCs);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.n_Alunos);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBoxBiblio);
            this.Controls.Add(this.idCursoAluno);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nmecAluno);
            this.Controls.Add(this.emailAluno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomeAluno);
            this.Controls.Add(this.PreviousPage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxDep);
            this.Controls.Add(this.comboBoxCurso);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBoxAluno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxTurma);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPerfilAluno";
            this.Text = "FormPerfilAluno";
            this.Load += new System.EventHandler(this.FormPerfilAluno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxDep;
        private System.Windows.Forms.ComboBox comboBoxCurso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxAluno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxTurma;
        private System.Windows.Forms.Button PreviousPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nmecAluno;
        private System.Windows.Forms.TextBox emailAluno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomeAluno;
        private System.Windows.Forms.ComboBox comboBoxBiblio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox n_Alunos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.ListBox listUCs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox idCursoAluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox n_ucs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox media_aluno;
        private System.Windows.Forms.TextBox id_uc_aluno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox falta_justificada;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox faltas_injustificada;
        private System.Windows.Forms.Label labelProf;
        private System.Windows.Forms.Button hideBtn;
        private System.Windows.Forms.Button filtros_btn;
    }
}