namespace AppGroupe2.View
{
    partial class frmSoin
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
            this.bntSupprimer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.bntModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.dgSoin = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSoin)).BeginInit();
            this.SuspendLayout();
            // 
            // bntSupprimer
            // 
            this.bntSupprimer.BackColor = System.Drawing.Color.Tomato;
            this.bntSupprimer.ForeColor = System.Drawing.SystemColors.Control;
            this.bntSupprimer.Location = new System.Drawing.Point(649, 203);
            this.bntSupprimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntSupprimer.Name = "bntSupprimer";
            this.bntSupprimer.Size = new System.Drawing.Size(108, 33);
            this.bntSupprimer.TabIndex = 25;
            this.bntSupprimer.Text = "Supprimer";
            this.bntSupprimer.UseVisualStyleBackColor = false;
            this.bntSupprimer.Click += new System.EventHandler(this.bntSupprimer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Parametrage des soin";
            // 
            // btnChoisir
            // 
            this.btnChoisir.BackColor = System.Drawing.Color.SlateGray;
            this.btnChoisir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnChoisir.Location = new System.Drawing.Point(507, 203);
            this.btnChoisir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(108, 33);
            this.btnChoisir.TabIndex = 22;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = false;
            this.btnChoisir.Click += new System.EventHandler(this.btnChoisir_Click);
            // 
            // bntModifier
            // 
            this.bntModifier.BackColor = System.Drawing.SystemColors.Highlight;
            this.bntModifier.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntModifier.Location = new System.Drawing.Point(372, 361);
            this.bntModifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntModifier.Name = "bntModifier";
            this.bntModifier.Size = new System.Drawing.Size(108, 33);
            this.bntModifier.TabIndex = 23;
            this.bntModifier.Text = "Modifier";
            this.bntModifier.UseVisualStyleBackColor = false;
            this.bntModifier.Click += new System.EventHandler(this.bntModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SlateGray;
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAjouter.Location = new System.Drawing.Point(243, 361);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(108, 33);
            this.btnAjouter.TabIndex = 21;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // dgSoin
            // 
            this.dgSoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSoin.Location = new System.Drawing.Point(507, 244);
            this.dgSoin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgSoin.Name = "dgSoin";
            this.dgSoin.RowHeadersWidth = 51;
            this.dgSoin.Size = new System.Drawing.Size(323, 150);
            this.dgSoin.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cout";
            // 
            // txtCout
            // 
            this.txtCout.Location = new System.Drawing.Point(243, 310);
            this.txtCout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCout.Name = "txtCout";
            this.txtCout.Size = new System.Drawing.Size(236, 22);
            this.txtCout.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Libelle";
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(243, 244);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(236, 22);
            this.txtLibelle.TabIndex = 16;
            // 
            // frmSoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::AppGroupe2.Properties.Resources._010c7810e3b8bb164c14b2ac1d94d25d;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.bntSupprimer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.bntModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dgSoin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLibelle);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSoin";
            this.Text = "frmSoin";
            this.Load += new System.EventHandler(this.frmSoin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgSoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntSupprimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button bntModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DataGridView dgSoin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLibelle;
    }
}