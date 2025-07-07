using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
            //Thread.Sleep(20000);
            dgProduit.DataSource = servGetListProduit();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // Code ici
        }

        public List<Produit> servGetListProduit()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Produit>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application"));
            var response = client.GetAsync("api/Produits/GetProduit").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Produit>>(responseData);

            }
            return services;
        }

        public bool AddProduit(Produit emp)
        {
            bool rep = false;
            string Id = emp.IdProduit > 0 ? emp.IdProduit.ToString() : "0";
            var values = new Dictionary<string, string>
            {
                { "IdProduit", Id },
                { "CodeProduit", emp.CodeProduit },
                { "Designation", emp.Description },
                { "Description", emp.Description },
                { "PU", emp.pu.ToString() },
                 { "QteMin", emp.QteMin.ToString() },
                { "QteCri", emp.QteCritique.ToString() },
                { "CodeCategorie", emp.CodeCategorie }
            };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["serverApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync("api/Produits/PostProduit", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            produit.pu=double.Parse(txtPU.Text);
            produit.QteCritique= double.Parse(txtQTEcri.Text);
            produit.QteMin=double.Parse(txtQTEmin.Text);
            produit.CodeCategorie=txtcategorie.Text;
            produit.CodeProduit=txtcode.Text;
            produit.Description=txtdescription.Text;
            AddProduit(produit);
            dgProduit.DataSource = servGetListProduit();
        }
    }
}

            
