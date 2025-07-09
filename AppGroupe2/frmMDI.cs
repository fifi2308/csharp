using AppGroupe2.View;
using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppGroupe2
{
    public partial class frmMDI : Form
    {
        public string role;

        public frmMDI()
        {
            InitializeComponent();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            // Plein écran
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);

            // Affichage dynamique des menus selon rôle
            AfficherMenusSelonRole();
        }

        private void AfficherMenusSelonRole()
        {
            if (role == "Admin")
            {
                couleurToolStripMenuItem.Visible = true;
                planifierToolStripMenuItem.Visible = false;
                utulisateursToolStripMenuItem.Visible = true;
            }
            else if (role == "Med")
            {
                couleurToolStripMenuItem.Visible = false;
                planifierToolStripMenuItem.Visible = true;
                utulisateursToolStripMenuItem.Visible = false;
            }
            else
            {
                couleurToolStripMenuItem.Visible = false;
                planifierToolStripMenuItem.Visible = false;
                utulisateursToolStripMenuItem.Visible = false;
            }
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fermeture de session
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fermer()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void soinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirFormUnique(new frmSoin());
        }

        private void rendezVousToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OuvrirFormUnique(new frmRendezVous());
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirFormUnique(new frmPatient());
        }

        private void utulisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OuvrirFormUnique(new frmMedecin());
        }

        private void OuvrirFormUnique(Form form)
        {
            fermer(); // Fermer tous les formulaires ouverts
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // (optionnel)
        }

        private void rougeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
}
