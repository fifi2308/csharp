using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.Helper;
using AppGroupe2.Model;

namespace AppGroupe2.View
{
    public partial class frmAgenda : Form
    {
        public int idMedecin;
        Utils utils = new Utils();
        public frmAgenda()
        {
            InitializeComponent();
        }
        BdRvMedicalContexe db = new BdRvMedicalContexe();

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            var m = db.Medecins.Find(idMedecin);
            lblMedecin.Text = string.Format("N ordre: {0}, Nom prenom: {1}",m.NumeroOrdre , m.NomPrenom);
            lblIdMedecin.Text = m.IDU.ToString();
            lblIdMedecin.Visible = false;
            ResetForm();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                Agenda a = new Agenda();
                a.Creaneau = int.Parse(txtCrenau.Text);
                a.HeureFin = txtHeureFin.Text;
                a.HeureDebut = txtHeureDebut.Text;
                a.IdMedecin = idMedecin;
                a.DatePlanifier = txtDateAgenda.Value;
                a.Statut = "brouillon";
                a.lieu = txtLieu.Text;
                db.Agenda.Add(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                utils.WriteDataError("frmAgenda-btnAjouter_Click",ex.ToString());
            }

            finally {
                ResetForm();
            }
           
         
        }
        private void ResetForm()
        {
            dgAgenda.DataSource = db.Agenda.Where(a => a.DatePlanifier >= DateTime.Now&& a.IdMedecin==idMedecin).ToList();
            txtCrenau.Text = string.Empty;
            txtDateAgenda.Text = string.Empty;
            txtHeureDebut.Text = string.Empty;
            txtHeureFin.Text = string.Empty;
            txtLieu.Text = string.Empty;
            txtTitre.Text= string.Empty;
            txtTitre.Focus();

        }
    }
}
