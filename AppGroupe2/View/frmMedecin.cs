using AppGroupe2.Helper;
using AppGroupe2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmMedecin : Form
    {
        private HttpClient client;
        private List<Specialite> specialites;

        public frmMedecin()
        {
            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void frmMedecin_Load(object sender, EventArgs e)
        {
            await LoadSpecialites();
            await ChargerListeMedecins();
            ResetForm();
        }

        private async Task LoadSpecialites()
        {
            try
            {
                var response = await client.GetAsync("api/Specialites");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    specialites = JsonConvert.DeserializeObject<List<Specialite>>(json);

                    cbbSpecialite.DataSource = specialites;
                    cbbSpecialite.DisplayMember = "NomSpecialite";
                    cbbSpecialite.ValueMember = "IdSpecialite";
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement des spécialités.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task ChargerListeMedecins()
        {
            try
            {
                var response = await client.GetAsync("api/Medecins");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var medecins = JsonConvert.DeserializeObject<List<Medecin>>(json);

                    // Pour afficher aussi le nom de spécialité dans le grid, tu peux projeter ici:
                    var listeAffichage = new List<dynamic>();
                    foreach (var m in medecins)
                    {
                        var specName = specialites?.Find(s => s.IdSpecialite == m.IdSpecialite)?.NomSpecialite ?? "";
                        listeAffichage.Add(new
                        {
                            m.IDU,
                            Specialite = specName,
                            m.Identifiant,
                            m.NomPrenom,
                            m.Email
                        });
                    }

                    dgMedecin.DataSource = listeAffichage;
                }
                else
                {
                    MessageBox.Show("Erreur lors du chargement des médecins.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task<bool> AjouterMedecinAsync(Medecin m)
        {
            try
            {
                var json = JsonConvert.SerializeObject(m);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Medecins", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
                return false;
            }
        }

        private async Task<bool> ModifierMedecinAsync(int id, Medecin m)
        {
            try
            {
                var json = JsonConvert.SerializeObject(m);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"api/Medecins/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
                return false;
            }
        }

        private async Task<bool> SupprimerMedecinAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"api/Medecins/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                return false;
            }
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cbbSpecialite.SelectedValue == null || !int.TryParse(cbbSpecialite.SelectedValue.ToString(), out int idSpec))
            {
                MessageBox.Show("Veuillez sélectionner une spécialité valide.");
                return;
            }

            var medecin = new Medecin
            {
                Adresse = txtAdresse.Text.Trim(),
                NumeroOrdre = txtNumeroOrdreMedecin.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NomPrenom = txtNomPrenom.Text.Trim(),
                Tel = txtTelephone.Text.Trim(),
                IdSpecialite = idSpec,
                Identifiant = txtIdentifiant.Text.Trim(),
                MotDePasse = CryptString.GetMd5Hash("Passer"), // tu peux améliorer pour demander vrai mdp
                IdRole = 2, // Remplace par la bonne IdRole côté API, ou récupère dynamiquement
                Status = true
            };

            var success = await AjouterMedecinAsync(medecin);

            if (success)
            {
                MessageBox.Show("Médecin ajouté avec succès.");
                await ChargerListeMedecins();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du médecin.");
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgMedecin.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un médecin à modifier.");
                return;
            }

            int id = Convert.ToInt32(dgMedecin.CurrentRow.Cells[0].Value);

            if (!int.TryParse(cbbSpecialite.SelectedValue?.ToString(), out int idSpec))
            {
                MessageBox.Show("Veuillez sélectionner une spécialité valide.");
                return;
            }

            var medecin = new Medecin
            {
                Adresse = txtAdresse.Text.Trim(),
                NumeroOrdre = txtNumeroOrdreMedecin.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NomPrenom = txtNomPrenom.Text.Trim(),
                Tel = txtTelephone.Text.Trim(),
                IdSpecialite = idSpec,
                Identifiant = txtIdentifiant.Text.Trim()
            };

            var success = await ModifierMedecinAsync(id, medecin);
            if (success)
            {
                MessageBox.Show("Médecin modifié avec succès.");
                await ChargerListeMedecins();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification.");
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgMedecin.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un médecin à supprimer.");
                return;
            }

            int id = Convert.ToInt32(dgMedecin.CurrentRow.Cells[0].Value);

            var confirm = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce médecin ?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = await SupprimerMedecinAsync(id);
                if (success)
                {
                    MessageBox.Show("Médecin supprimé avec succès.");
                    await ChargerListeMedecins();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression.");
                }
            }
        }

        private async void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgMedecin.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgMedecin.CurrentRow.Cells[0].Value);

            try
            {
                var response = await client.GetAsync($"api/Medecins/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var m = JsonConvert.DeserializeObject<Medecin>(json);

                    txtAdresse.Text = m.Adresse;
                    txtEmail.Text = m.Email;
                    txtIdentifiant.Text = m.Identifiant;
                    txtNomPrenom.Text = m.NomPrenom;
                    txtNumeroOrdreMedecin.Text = m.NumeroOrdre;
                    txtTelephone.Text = m.Tel;
                    cbbSpecialite.SelectedValue = m.IdSpecialite;
                }
                else
                {
                    MessageBox.Show("Médecin non trouvé.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement : " + ex.Message);
            }
        }

        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtNumeroOrdreMedecin.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            cbbSpecialite.SelectedIndex = -1;
            txtNomPrenom.Focus();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            if (dgMedecin.CurrentRow == null) return;

            int idMedecin = Convert.ToInt32(dgMedecin.CurrentRow.Cells[0].Value);
            frmAgenda f = new frmAgenda();
            f.idMedecin = idMedecin;
            f.Show();
        }
    }
}
