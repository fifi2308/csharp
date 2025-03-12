namespace AppGroupe2.View
{
    partial class frmRendezVous
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtStatut = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.dgRendezVous = new System.Windows.Forms.DataGridView();
            this.bntModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSoin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMedecin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateRv = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 236);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "Statut";
            // 
            // txtStatut
            // 
            this.txtStatut.Location = new System.Drawing.Point(208, 256);
            this.txtStatut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatut.Name = "txtStatut";
            this.txtStatut.Size = new System.Drawing.Size(279, 22);
            this.txtStatut.TabIndex = 45;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.IndianRed;
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSupprimer.Location = new System.Drawing.Point(687, 188);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 33);
            this.btnSupprimer.TabIndex = 44;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            // 
            // btnChoisir
            // 
            this.btnChoisir.BackColor = System.Drawing.Color.SlateGray;
            this.btnChoisir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnChoisir.Location = new System.Drawing.Point(535, 188);
            this.btnChoisir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(125, 33);
            this.btnChoisir.TabIndex = 43;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = false;
            // 
            // dgRendezVous
            // 
            this.dgRendezVous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRendezVous.Location = new System.Drawing.Point(535, 238);
            this.dgRendezVous.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgRendezVous.Name = "dgRendezVous";
            this.dgRendezVous.RowHeadersWidth = 51;
            this.dgRendezVous.Size = new System.Drawing.Size(497, 287);
            this.dgRendezVous.TabIndex = 42;
            // 
            // bntModifier
            // 
            this.bntModifier.BackColor = System.Drawing.SystemColors.Highlight;
            this.bntModifier.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntModifier.Location = new System.Drawing.Point(363, 492);
            this.bntModifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntModifier.Name = "bntModifier";
            this.bntModifier.Size = new System.Drawing.Size(125, 33);
            this.bntModifier.TabIndex = 41;
            this.bntModifier.Text = "Modifier";
            this.bntModifier.UseVisualStyleBackColor = false;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SlateGray;
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAjouter.Location = new System.Drawing.Point(208, 492);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(125, 33);
            this.btnAjouter.TabIndex = 40;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 417);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Soin";
            // 
            // cbSoin
            // 
            this.cbSoin.FormattingEnabled = true;
            this.cbSoin.Location = new System.Drawing.Point(208, 437);
            this.cbSoin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSoin.Name = "cbSoin";
            this.cbSoin.Size = new System.Drawing.Size(279, 24);
            this.cbSoin.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 358);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Patient";
            // 
            // cbPatient
            // 
            this.cbPatient.FormattingEnabled = true;
            this.cbPatient.Location = new System.Drawing.Point(208, 377);
            this.cbPatient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPatient.Name = "cbPatient";
            this.cbPatient.Size = new System.Drawing.Size(279, 24);
            this.cbPatient.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 298);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Medecin";
            // 
            // cbMedecin
            // 
            this.cbMedecin.FormattingEnabled = true;
            this.cbMedecin.Location = new System.Drawing.Point(208, 316);
            this.cbMedecin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMedecin.Name = "cbMedecin";
            this.cbMedecin.Size = new System.Drawing.Size(279, 24);
            this.cbMedecin.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date du rendez-vous";
            // 
            // dtpDateRv
            // 
            this.dtpDateRv.Location = new System.Drawing.Point(208, 197);
            this.dtpDateRv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateRv.Name = "dtpDateRv";
            this.dtpDateRv.Size = new System.Drawing.Size(279, 22);
            this.dtpDateRv.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "Parametrage des rendez-vous";
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::AppGroupe2.Properties.Resources._010c7810e3b8bb164c14b2ac1d94d25d;
            this.ClientSize = new System.Drawing.Size(1236, 634);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStatut);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.dgRendezVous);
            this.Controls.Add(this.bntModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSoin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMedecin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateRv);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRendezVous";
            this.Text = "RendezVous";
            this.Load += new System.EventHandler(this.frmRendezVous_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStatut;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.DataGridView dgRendezVous;
        private System.Windows.Forms.Button bntModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSoin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPatient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMedecin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateRv;
        private System.Windows.Forms.Label label3;
    }
}