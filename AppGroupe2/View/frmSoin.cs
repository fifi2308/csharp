using AppGroupe2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmSoin : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string apiEndpoint = "api/Soins";

        public frmSoin()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSoin_Load);

            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void frmSoin_Load(object sender, EventArgs e)
        {
            await LoadSoins();
        }

        private async System.Threading.Tasks.Task LoadSoins()
        {
            var response = await client.GetAsync(apiEndpoint);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var soins = JsonConvert.DeserializeObject<List<Soin>>(json);
                dgSoin.DataSource = soins;
            }
            else
            {
                MessageBox.Show("Erreur lors du chargement des soins.");
            }
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtCout.Text, out float cout))
            {
                MessageBox.Show("Veuillez entrer un coût valide.");
                return;
            }

            var soin = new Soin
            {
                libelle = txtLibelle.Text.Trim(),
                cout = cout
            };

            var json = JsonConvert.SerializeObject(soin);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiEndpoint, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Soin ajouté avec succès.");
                await LoadSoins();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de l’ajout du soin.");
            }
        }

        private async void bntModifier_Click(object sender, EventArgs e)
        {
            if (dgSoin.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgSoin.CurrentRow.Cells["IdSoin"].Value);

            if (!float.TryParse(txtCout.Text, out float cout))
            {
                MessageBox.Show("Veuillez entrer un coût valide.");
                return;
            }

            var soin = new Soin
            {
                IdSoin = id,
                libelle = txtLibelle.Text.Trim(),
                cout = cout
            };

            var json = JsonConvert.SerializeObject(soin);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{apiEndpoint}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Soin modifié avec succès.");
                await LoadSoins();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification.");
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgSoin.CurrentRow != null)
            {
                txtLibelle.Text = dgSoin.CurrentRow.Cells["libelle"].Value?.ToString();
                txtCout.Text = dgSoin.CurrentRow.Cells["cout"].Value?.ToString();
            }
        }

        private async void bntSupprimer_Click(object sender, EventArgs e)
        {
            if (dgSoin.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgSoin.CurrentRow.Cells["IdSoin"].Value);

            var response = await client.DeleteAsync($"{apiEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Soin supprimé avec succès.");
                await LoadSoins();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression.");
            }
        }

        private void ResetForm()
        {
            txtLibelle.Clear();
            txtCout.Clear();
            txtLibelle.Focus();
        }
    }
}
