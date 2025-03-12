using AppGroupe2.Helper;
using System;
using System.Windows.Forms;

namespace AppGroupe2
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void btneConnecter_Click(object sender, EventArgs e)
        {
            string username = txtidentifiant.Text.Trim();
            string password = txtMotDePasse.Text.Trim();

            if (username == "admin" && password == "passer")
            {
                frmMDI f = new frmMDI();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConnexion_Load(object sender, EventArgs e)

        {
            Utils.WriteLogSystem("test", "ceci est un test");
            GMailer.senMail("fatoufall0320@gmail.com", "test", "un test");

        }

        private void txtidentifiant_TextChanged(object sender, EventArgs e)
        {
            // Code à exécuter lors du changement du texte
        }
        private void txtMotDePasse_TextChanged(object sender, EventArgs e)
        {
            // Code à exécuter lors du changement du texte
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
