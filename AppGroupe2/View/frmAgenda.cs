using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.Model;
using Newtonsoft.Json;
using System.Linq;

namespace AppGroupe2.View
{
    public partial class frmAgenda : Form
    {
        public int idMedecin;
        private HttpClient client;

        public frmAgenda()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void frmAgenda_Load(object sender, EventArgs e)
        {
            await ChargerMedecin();
            await ChargerAgenda();
            ResetForm();
        }

        private async Task ChargerMedecin()
        {
            try
            {
                var response = await client.GetAsync($"api/Medecins/{idMedecin}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var medecin = JsonConvert.DeserializeObject<Medecin>(jsonData);
                    lblMedecin.Text = $"N ordre: {medecin.NumeroOrdre}, Nom prenom: {medecin.NomPrenom}";
                    lblIdMedecin.Text = medecin.IDU.ToString();
                    lblIdMedecin.Visible = false;
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement du médecin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task ChargerAgenda()
        {
            try
            {
                var response = await client.GetAsync("api/Agenda");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var agendas = JsonConvert.DeserializeObject<List<Agenda>>(jsonData);
                    // Filtrer les agendas pour le médecin connecté et les dates futures
                    var agendasMedecin = agendas
                        .Where(a => a.IdMedecin == idMedecin && a.DatePlanifier >= DateTime.Now)
                        .ToList();

                    dgAgenda.DataSource = null;
                    dgAgenda.DataSource = agendasMedecin;
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement des agendas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task<bool> AjouterAgendaAsync(Agenda agenda)
        {
            try
            {
                var json = JsonConvert.SerializeObject(agenda);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Agenda", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
                return false;
            }
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCrenau.Text, out int crenau))
            {
                MessageBox.Show("Veuillez saisir un créneau valide (nombre entier).");
                return;
            }

            var agenda = new Agenda
            {
                Creaneau = crenau,
                HeureDebut = txtHeureDebut.Text.Trim(),
                HeureFin = txtHeureFin.Text.Trim(),
                IdMedecin = idMedecin,
                DatePlanifier = txtDateAgenda.Value,
                Statut = "brouillon",
                lieu = txtLieu.Text.Trim(),
                Titre = txtTitre.Text.Trim()
            };

            bool success = await AjouterAgendaAsync(agenda);

            if (success)
            {
                MessageBox.Show("Agenda ajouté avec succès.");
                await ChargerAgenda();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout de l'agenda.");
            }
        }

        private void ResetForm()
        {
            txtCrenau.Text = string.Empty;
            txtHeureDebut.Text = string.Empty;
            txtHeureFin.Text = string.Empty;
            txtLieu.Text = string.Empty;
            txtTitre.Text = string.Empty;
            txtDateAgenda.Value = DateTime.Now;
            txtTitre.Focus();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
