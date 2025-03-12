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
using AppGroupe2.View;

namespace AppGroupe2.View
{

    public partial class frmRendezVous : Form
    {

       
        public frmRendezVous()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmRendezVous_Load);
        }
        BdRvMedicalContexe db = new BdRvMedicalContexe();

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            // Charger les patients dans le ComboBox
            cbPatient.DataSource = db.Patients.ToList();
            cbPatient.DisplayMember = "NomPrenom"; // Afficher le nom du patient
            cbPatient.ValueMember = "IDU"; // Utiliser l'ID du patient comme valeur

            // Charger les médecins dans le ComboBox
            cbMedecin.DataSource = db.Medecins.ToList();
            cbMedecin.DisplayMember = "NomPrenom"; // Afficher le nom du médecin
            cbMedecin.ValueMember = "IDU"; // Utiliser l'ID du médecin comme valeur

            // Charger les soins dans le ComboBox
            cbSoin.DataSource = db.Soins.ToList();
            cbSoin.DisplayMember = "libelle"; // Afficher le nom du soin
            cbSoin.ValueMember = "IdSoin"; // Utiliser l'ID du soin comme valeur

            // Charger la liste des rendez-vous dans le DataGridView
            var rendezVousList = db.RendezVous
              .Select(rv => new
                  {
                     rv.IdRv,
                     rv.DateRv,
                     rv.Statut,
                     Patient = rv.patient.NomPrenom,  // Remplace l'ID du patient par son nom
                     Medecin = rv.Medecin.NomPrenom,  // Remplace l'ID du médecin par son nom
                     Soin = rv.Soin.libelle         // Remplace l'ID du soin par son libellé
                 })
                     .ToList();

                      dgRendezVous.DataSource = rendezVousList;

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            RendezVous rendezVous = new RendezVous
            {

                DateRv = dtpDateRv.Value,
                Statut = txtStatut.Text,
                IdPatient = (int)cbPatient.SelectedValue,
                IdMedecin = (int)cbMedecin.SelectedValue,
                IdSoin = (int)cbSoin.SelectedValue
            };

            // Ajouter le rendez-vous à la base de données
            db.RendezVous.Add(rendezVous);
            db.SaveChanges();

            // Recharger la liste des rendez-vous
            dgRendezVous.DataSource = db.RendezVous.ToList();
        }

        private void frmRendezVous_Load_1(object sender, EventArgs e)
        {

        }
    }
}
