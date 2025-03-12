using AppGroupe2.View;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGroupe2
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            Form[] charr = this.MdiChildren;

            //For each child form set the window state to Maximized 
            foreach (Form chform in charr)
            {
                //chform.WindowState = FormWindowState.Maximized;
                chform.Close();
            }
        }
        private void frmMdiParent_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
        }

        private void rougeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmPatient f = new frmPatient();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {

        }

        private void medecinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmMedecin f = new frmMedecin();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void rendezvousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRendezVous frmRendezVous = new frmRendezVous();
            frmRendezVous.MdiParent = this;
            frmRendezVous.Show();
            frmRendezVous.WindowState = FormWindowState.Maximized;
        }

        private void soinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSoin frmsoin = new frmSoin();
            frmsoin.MdiParent= this;
            frmsoin.Show();
            frmsoin.WindowState = FormWindowState.Maximized;
        }
    }
}
