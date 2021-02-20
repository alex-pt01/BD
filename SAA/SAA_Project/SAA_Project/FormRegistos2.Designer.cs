namespace SAA_Project
{
    partial class FormRegistos2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistos2));
            this.NextPage = new System.Windows.Forms.Button();
            this.listBoxUCs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRegistos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nota_media = new System.Windows.Forms.TextBox();
            this.num_faltas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.id_uc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.faltas_justificadas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.faltas_injustificadas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.NextPage.TabIndex = 234;
            this.NextPage.Text = "Back";
            this.NextPage.UseVisualStyleBackColor = false;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // listBoxUCs
            // 
            this.listBoxUCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUCs.FormattingEnabled = true;
            this.listBoxUCs.ItemHeight = 16;
            this.listBoxUCs.Location = new System.Drawing.Point(27, 83);
            this.listBoxUCs.Name = "listBoxUCs";
            this.listBoxUCs.Size = new System.Drawing.Size(173, 276);
            this.listBoxUCs.TabIndex = 235;
            this.listBoxUCs.SelectedIndexChanged += new System.EventHandler(this.listBoxUCs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 236;
            this.label1.Text = "UCs";
            // 
            // labelRegistos
            // 
            this.labelRegistos.AutoSize = true;
            this.labelRegistos.Font = new System.Drawing.Font("Arial", 14F);
            this.labelRegistos.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelRegistos.Location = new System.Drawing.Point(23, 22);
            this.labelRegistos.Name = "labelRegistos";
            this.labelRegistos.Size = new System.Drawing.Size(131, 22);
            this.labelRegistos.TabIndex = 237;
            this.labelRegistos.Text = "Lista Registos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 238;
            this.label2.Text = "Nota Média: ";
            // 
            // nota_media
            // 
            this.nota_media.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nota_media.Location = new System.Drawing.Point(423, 167);
            this.nota_media.Name = "nota_media";
            this.nota_media.ReadOnly = true;
            this.nota_media.Size = new System.Drawing.Size(100, 22);
            this.nota_media.TabIndex = 239;
            // 
            // num_faltas
            // 
            this.num_faltas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_faltas.Location = new System.Drawing.Point(423, 216);
            this.num_faltas.Name = "num_faltas";
            this.num_faltas.ReadOnly = true;
            this.num_faltas.Size = new System.Drawing.Size(100, 22);
            this.num_faltas.TabIndex = 241;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 240;
            this.label3.Text = "Número de Faltas:  ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(673, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 242;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.Login.Location = new System.Drawing.Point(754, 7);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(43, 33);
            this.Login.TabIndex = 243;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // id_uc
            // 
            this.id_uc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_uc.Location = new System.Drawing.Point(423, 114);
            this.id_uc.Name = "id_uc";
            this.id_uc.ReadOnly = true;
            this.id_uc.Size = new System.Drawing.Size(100, 22);
            this.id_uc.TabIndex = 245;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 244;
            this.label4.Text = "ID UC: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(267, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 24);
            this.label5.TabIndex = 246;
            this.label5.Text = "Dados de Registo acerca da UC ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 247;
            this.label6.Text = "Ano Formação";
            // 
            // faltas_justificadas
            // 
            this.faltas_justificadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faltas_justificadas.Location = new System.Drawing.Point(423, 267);
            this.faltas_justificadas.Name = "faltas_justificadas";
            this.faltas_justificadas.ReadOnly = true;
            this.faltas_justificadas.Size = new System.Drawing.Size(100, 22);
            this.faltas_justificadas.TabIndex = 249;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(267, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 248;
            this.label7.Text = "Faltas Justificadas:";
            // 
            // faltas_injustificadas
            // 
            this.faltas_injustificadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faltas_injustificadas.Location = new System.Drawing.Point(423, 315);
            this.faltas_injustificadas.Name = "faltas_injustificadas";
            this.faltas_injustificadas.ReadOnly = true;
            this.faltas_injustificadas.Size = new System.Drawing.Size(100, 22);
            this.faltas_injustificadas.TabIndex = 251;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 20);
            this.label8.TabIndex = 250;
            this.label8.Text = "Faltas Injustificadas:  ";
            // 
            // FormRegistos2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.faltas_injustificadas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.faltas_justificadas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.id_uc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.num_faltas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nota_media);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRegistos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUCs);
            this.Controls.Add(this.NextPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistos2";
            this.Text = "FormRegistos2";
            this.Load += new System.EventHandler(this.FormRegistos2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.ListBox listBoxUCs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRegistos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nota_media;
        private System.Windows.Forms.TextBox num_faltas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox id_uc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox faltas_justificadas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox faltas_injustificadas;
        private System.Windows.Forms.Label label8;
    }
}