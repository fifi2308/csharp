using AppGroupe2.Helper;
using AppGroupe2.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGroupe2
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private async void btneConnecter_Click(object sender, EventArgs e)
        {
            try
            {
                var identifiant = txtidentifiant.Text.Trim().ToLower();
                var motDePasse = txtMotDePasse.Text;

                var utilisateur = await AuthentifierUtilisateurAsync(identifiant, motDePasse);

                if (utilisateur != null && utilisateur.Role != null)
                {
                    MessageBox.Show("Connexion réussie !");
                    frmMDI f = new frmMDI();
                    f.role = utilisateur.Role.code;
                    f.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "Identifiant ou mot de passe incorrect";
                }
            }
            catch (Exception ex)
            {
                string msg = $"Erreur : {ex.Message}";
                if (ex.InnerException != null) msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Utilisateur> AuthentifierUtilisateurAsync(string identifiant, string motDePasse)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServerApiURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Création de l’objet à envoyer
                var payload = new
                {
                    Identifiant = identifiant,
                    MotDePasse = motDePasse
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Utilisateurs/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<Utilisateur>(json);
                    return user;
                }

                return null;
            }
        }

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            Utils.WriteLogSystem("Connexion", "Chargement de frmConnexion");
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
