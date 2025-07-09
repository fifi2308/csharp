using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.Model;

namespace AppGroupe2.View
{
    public partial class frmProduit : Form
    {
        public frmProduit()
        {
            InitializeComponent();
        }



        private void frmProduit_Load(object sender, EventArgs e)
        {
            dgProduit.AutoGenerateColumns = true;
            ChargerListeProduits();
        }

        private void ChargerListeProduits()
        {
            var produits = servGetListProduit();
            dgProduit.DataSource = null;
            dgProduit.DataSource = produits;
        }

        public List<Produit> servGetListProduit()
        {
            var services = new List<Produit>();

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/Produits/GetProduit").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Produit>>(responseData);
                }
                else
                {
                    MessageBox.Show("Erreur HTTP : " + response.StatusCode.ToString(), "Réponse de l'API");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s’est produite : " + (ex.InnerException?.Message ?? ex.Message), "Erreur d’appel API");
            }

            return services;
        }

        public async Task<bool> AddProduitAsync(Produit emp)
        {
            bool rep = false;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsync("api/Produits/PostProduit", content);
                    rep = response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = "Erreur lors de l'ajout : " + ex.Message;
                if (ex.InnerException != null)
                    errorMsg += "\nInner Exception: " + ex.InnerException.Message;
                MessageBox.Show(errorMsg + "\n" + ex.StackTrace);
            }

            return rep;
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPU.Text, out double pu) ||
                !double.TryParse(txtQTEmin.Text, out double qteMin) ||
                !double.TryParse(txtQTEcri.Text, out double qteCrit))
            {
                MessageBox.Show("Veuillez saisir des valeurs numériques valides pour PU, QteMin et QteCritique.");
                return;
            }

            var produit = new Produit
            {
                PU = pu,
                QteMin = qteMin,
                QteCritique = qteCrit,
                CodeCategorie = txtcategorie.Text.Trim(),
                CodeProduit = txtcode.Text.Trim(),
                Description = txtdescription.Text.Trim(),
                Designation = txtdescription.Text.Trim()
            };

            bool success = await AddProduitAsync(produit);
            if (success)
            {
                MessageBox.Show("Produit ajouté avec succès.");

                // Recharge les données dans le tableau
                ChargerListeProduits();

                // Réinitialise les champs
                ViderChamps();
            }
            else
            {
                MessageBox.Show("L'ajout du produit a échoué.");
            }
        }

        private void ViderChamps()
        {
            txtPU.Clear();
            txtQTEmin.Clear();
            txtQTEcri.Clear();
            txtcategorie.Clear();
            txtcode.Clear();
            txtdescription.Clear();
            txtdescription.Clear();
        }
    }
}
