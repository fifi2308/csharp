using AppGroupe2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmRendezVous : Form
    {
        HttpClient client = new HttpClient();

        public frmRendezVous()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Load += frmRendezVous_Load;
        }

        private async void frmRendezVous_Load(object sender, EventArgs e)
        {
            await LoadComboPatients();
            await LoadComboMedecins();
            await LoadComboSoins();
            await LoadRendezVous();
        }

        private async System.Threading.Tasks.Task LoadComboPatients()
        {
            var res = await client.GetAsync("api/Patients");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var patients = JsonConvert.DeserializeObject<List<Patient>>(data);
                cbPatient.DataSource = patients;
                cbPatient.DisplayMember = "NomPrenom";
                cbPatient.ValueMember = "IDU";
            }
        }

        private async System.Threading.Tasks.Task LoadComboMedecins()
        {
            var res = await client.GetAsync("api/Medecins");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var medecins = JsonConvert.DeserializeObject<List<Medecin>>(data);
                cbMedecin.DataSource = medecins;
                cbMedecin.DisplayMember = "NomPrenom";
                cbMedecin.ValueMember = "IDU";
            }
        }

        private async System.Threading.Tasks.Task LoadComboSoins()
        {
            var res = await client.GetAsync("api/Soins");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var soins = JsonConvert.DeserializeObject<List<Soin>>(data);
                cbSoin.DataSource = soins;
                cbSoin.DisplayMember = "libelle";
                cbSoin.ValueMember = "IdSoin";
            }
        }

        private async System.Threading.Tasks.Task LoadRendezVous()
        {
            var res = await client.GetAsync("api/RendezVous");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var rvs = JsonConvert.DeserializeObject<List<RendezVous>>(data);

                var listeAffichee = rvs.Select(rv => new
                {
                    rv.IdRv,
                    rv.DateRv,
                    rv.Statut,
                    Patient = rv.patient?.NomPrenom ?? "N/A",
                    Medecin = rv.Medecin?.NomPrenom ?? "N/A",
                    Soin = rv.Soin?.libelle ?? "N/A"
                }).ToList();

                dgRendezVous.DataSource = listeAffichee;
            }
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cbPatient.SelectedValue == null || cbMedecin.SelectedValue == null || cbSoin.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient, un médecin et un soin.");
                return;
            }

            RendezVous rv = new RendezVous
            {
                DateRv = dtpDateRv.Value,
                Statut = txtStatut.Text,
                IdPatient = Convert.ToInt32(cbPatient.SelectedValue),
                IdMedecin = Convert.ToInt32(cbMedecin.SelectedValue),
                IdSoin = Convert.ToInt32(cbSoin.SelectedValue)
            };

            var json = JsonConvert.SerializeObject(rv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync("api/RendezVous", content);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Rendez-vous ajouté avec succès.");
                await LoadRendezVous();
            }
            else
            {
                MessageBox.Show("Erreur lors de l’ajout du rendez-vous.");
            }
        }
    }
}
