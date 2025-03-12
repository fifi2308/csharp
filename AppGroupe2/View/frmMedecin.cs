
using AppGroupe2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BdRvMedicalContexe = AppGroupe2.Model.BdRvMedicalContexe;

namespace AppGroupe2.View
{
    public partial class frmMedecin : Form
       
    {
        BdRvMedicalContexe db=new BdRvMedicalContexe();
        public frmMedecin()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Medecin m = new Medecin();
            m.Adresse = txtAdresse.Text;
            m.NumeroOrdre = txtNumeroOrdreMedecin.Text;
            m.Email = txtEmail.Text;
            m.NomPrenom=txtNomPrenom.Text;
            m.Tel = txtTelephone.Text;
            m.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
            m.Identifiant = txtIdentifiant.Text;
            m.Status = false;
            db.Medecins.Add(m);
            db.SaveChanges();
            ResetForm();
        }
        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtNumeroOrdreMedecin.Text = string.Empty;
            cbbSpecialite.SelectedValue = string.Empty;
            txtTelephone.Text = string.Empty;
            cbbSpecialite.DataSource = LoadCbbSpecialite();
            cbbSpecialite.ValueMember = "Value";
            cbbSpecialite.DisplayMember = "Text";
            dgMedecin.DataSource = db.Medecins.Select(a => new {a.IDU,a.Specialite.NomSpecialite, a.Identifiant,a.NomPrenom,a.Email}) .ToList();
            txtNomPrenom.Focus();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var m = db.Medecins.Find(id);
            if(m!= null)
            {
                txtAdresse.Text = m.Adresse;
                txtEmail.Text = m.Email;
                txtIdentifiant.Text = m.Identifiant;
                txtNomPrenom.Text = m.NomPrenom;
                txtNumeroOrdreMedecin.Text = m.NumeroOrdre;
                cbbSpecialite.SelectedValue = m.IdSpecialite;
                txtTelephone.Text = m.Tel;



            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var m = db.Medecins.Find(id);
            m.Adresse = txtAdresse.Text;
            m.NumeroOrdre = txtNumeroOrdreMedecin.Text;
            m.Email = txtEmail.Text;
            m.NomPrenom = txtNomPrenom.Text;
            m.Tel = txtTelephone.Text;
            m.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
            m.Identifiant = txtIdentifiant.Text;
            db.SaveChanges();
            ResetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var m = db.Medecins.Find(id);
            db.Medecins.Remove(m);
            db.SaveChanges();
            ResetForm();
        }

        private void frmMedecin_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private List<SelectListViewModel> LoadCbbSpecialite()
        {
            var m = db.Specialites.ToList();
            List<SelectListViewModel> liste = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel();
            b.Text = "Selection....";
            b.Value = "";
            liste.Add(b);
            foreach (var c in m)
            {
                SelectListViewModel a = new SelectListViewModel();
                a.Text = c.NomSpecialite;
                a.Value = c.IdSpecialite.ToString();
                liste.Add(a);
            }
            return liste;
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda a = new frmAgenda();
            a.idMedecin = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            a.Show();
        }

        private void dgMedecin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
