namespace AppGroupe2.View
{
    partial class frmProduit
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
            this.dgProduit = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.Designation = new System.Windows.Forms.Label();
            this.txtPU = new System.Windows.Forms.TextBox();
            this.PU = new System.Windows.Forms.Label();
            this.txtQTEmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQTEcri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcategorie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProduit
            // 
            this.dgProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduit.Location = new System.Drawing.Point(274, 12);
            this.dgProduit.Name = "dgProduit";
            this.dgProduit.RowHeadersWidth = 51;
            this.dgProduit.RowTemplate.Height = 24;
            this.dgProduit.Size = new System.Drawing.Size(497, 493);
            this.dgProduit.TabIndex = 0;
            // 
            // Code
            // 
            this.Code.AutoSize = true;
            this.Code.Location = new System.Drawing.Point(13, 25);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(40, 16);
            this.Code.TabIndex = 1;
            this.Code.Text = "Code";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(16, 55);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(165, 22);
            this.txtcode.TabIndex = 2;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(16, 130);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(165, 22);
            this.txtdescription.TabIndex = 4;
            // 
            // Designation
            // 
            this.Designation.AutoSize = true;
            this.Designation.Location = new System.Drawing.Point(13, 100);
            this.Designation.Name = "Designation";
            this.Designation.Size = new System.Drawing.Size(79, 16);
            this.Designation.TabIndex = 3;
            this.Designation.Text = "Designation";
            this.Designation.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPU
            // 
            this.txtPU.Location = new System.Drawing.Point(16, 204);
            this.txtPU.Name = "txtPU";
            this.txtPU.Size = new System.Drawing.Size(165, 22);
            this.txtPU.TabIndex = 6;
            // 
            // PU
            // 
            this.PU.AutoSize = true;
            this.PU.Location = new System.Drawing.Point(13, 174);
            this.PU.Name = "PU";
            this.PU.Size = new System.Drawing.Size(26, 16);
            this.PU.TabIndex = 5;
            this.PU.Text = "PU";
            // 
            // txtQTEmin
            // 
            this.txtQTEmin.Location = new System.Drawing.Point(16, 278);
            this.txtQTEmin.Name = "txtQTEmin";
            this.txtQTEmin.Size = new System.Drawing.Size(165, 22);
            this.txtQTEmin.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantite Minimal";
            // 
            // txtQTEcri
            // 
            this.txtQTEcri.Location = new System.Drawing.Point(16, 356);
            this.txtQTEcri.Name = "txtQTEcri";
            this.txtQTEcri.Size = new System.Drawing.Size(165, 22);
            this.txtQTEcri.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quanrite Critique";
            // 
            // txtcategorie
            // 
            this.txtcategorie.Location = new System.Drawing.Point(16, 431);
            this.txtcategorie.Name = "txtcategorie";
            this.txtcategorie.Size = new System.Drawing.Size(165, 22);
            this.txtcategorie.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Categorie";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(159, 473);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(109, 44);
            this.btnAjouter.TabIndex = 13;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // frmProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtcategorie);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQTEcri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQTEmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPU);
            this.Controls.Add(this.PU);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.Designation);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.dgProduit);
            this.Name = "frmProduit";
            this.Text = "frmProduit";
            this.Load += new System.EventHandler(this.frmProduit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProduit;
        private System.Windows.Forms.Label Code;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label Designation;
        private System.Windows.Forms.TextBox txtPU;
        private System.Windows.Forms.Label PU;
        private System.Windows.Forms.TextBox txtQTEmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQTEcri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcategorie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAjouter;
    }
}