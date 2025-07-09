using AppGroupe2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmPatient : Form
    {
        private HttpClient client;

        public frmPatient()
        {
            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void frmPatient_Load(object sender, EventArgs e)
        {
            await ChargerListePatients();
            ResetForm();
        }

        private async Task ChargerListePatients()
        {
            try
            {
                var response = await client.GetAsync("api/Patients");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                    dgPatient.DataSource = patients;
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement des patients.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task<bool> AjouterPatientAsync(Patient p)
        {
            try
            {
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Patients", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
                return false;
            }
        }

        private async Task<bool> ModifierPatientAsync(int id, Patient p)
        {
            try
            {
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"api/Patients/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
                return false;
            }
        }

        private async Task<bool> SupprimerPatientAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"api/Patients/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                return false;
            }
        }

        private void ResetForm()
        {
            txtNomPrenom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGroupeSanguin.Text = string.Empty;
            txtPoid.Text = string.Empty;
            txtTaille.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtNomPrenom.Focus();
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtPoid.Text, out float poids) ||
                !float.TryParse(txtTaille.Text, out float taille))
            {
                MessageBox.Show("Veuillez saisir des valeurs valides pour le poids et la taille.");
                return;
            }

            var patient = new Patient
            {
                NomPrenom = txtNomPrenom.Text.Trim(),
                Adresse = txtAdresse.Text.Trim(),
                Tel = txtTelephone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Poids = poids,
                Taille = taille,
                GroupSanguin = txtGroupeSanguin.Text.Trim()
            };

            var success = await AjouterPatientAsync(patient);

            if (success)
            {
                MessageBox.Show("Patient ajouté avec succès.");
                await ChargerListePatients();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du patient.");
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient à modifier.");
                return;
            }

            int id = Convert.ToInt32(dgPatient.CurrentRow.Cells["IDU"].Value); // Assure-toi que le nom de colonne est correct

            if (!float.TryParse(txtPoid.Text, out float poids) ||
                !float.TryParse(txtTaille.Text, out float taille))
            {
                MessageBox.Show("Veuillez saisir des valeurs valides pour le poids et la taille.");
                return;
            }

            var patient = new Patient
            {
                NomPrenom = txtNomPrenom.Text.Trim(),
                Adresse = txtAdresse.Text.Trim(),
                Tel = txtTelephone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Poids = poids,
                Taille = taille,
                GroupSanguin = txtGroupeSanguin.Text.Trim()
            };

            var success = await ModifierPatientAsync(id, patient);

            if (success)
            {
                MessageBox.Show("Patient modifié avec succès.");
                await ChargerListePatients();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification.");
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient à supprimer.");
                return;
            }

            int id = Convert.ToInt32(dgPatient.CurrentRow.Cells["IDU"].Value); // Assure-toi que le nom de colonne est correct

            var confirm = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce patient ?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = await SupprimerPatientAsync(id);
                if (success)
                {
                    MessageBox.Show("Patient supprimé avec succès.");
                    await ChargerListePatients();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression.");
                }
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null)
                return;

            txtNomPrenom.Text = dgPatient.CurrentRow.Cells["NomPrenom"].Value.ToString();
            txtAdresse.Text = dgPatient.CurrentRow.Cells["Adresse"].Value.ToString();
            txtEmail.Text = dgPatient.CurrentRow.Cells["Email"].Value.ToString();
            txtTelephone.Text = dgPatient.CurrentRow.Cells["Tel"].Value.ToString();
            txtGroupeSanguin.Text = dgPatient.CurrentRow.Cells["GroupSanguin"].Value?.ToString() ?? "";
            txtPoid.Text = dgPatient.CurrentRow.Cells["Poids"].Value?.ToString() ?? "";
            txtTaille.Text = dgPatient.CurrentRow.Cells["Taille"].Value?.ToString() ?? "";
        }

        private async void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await client.GetAsync("api/Patients");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var liste = JsonConvert.DeserializeObject<List<Patient>>(json);

                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        liste = liste.Where(a => a.Email != null && a.Email.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (!string.IsNullOrEmpty(txtTelephone.Text))
                    {
                        liste = liste.Where(a => a.Tel != null && a.Tel.Equals(txtTelephone.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    dgPatient.DataSource = liste;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
            }
        }
    }
}
