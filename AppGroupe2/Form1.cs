using AppGroupe2.Helper;
using AppGroupe2.Model;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Windows.Forms;
using AppGroupe2.Model;
using System.Linq;
using AppGroupe2.Helper;
using System.Data.Entity;


namespace AppGroupe2
{
    public partial class frmConnexion : Form
    {
        BdRvMedicalContexe bd = new BdRvMedicalContexe();
        public frmConnexion()
        {
            InitializeComponent();
        }

        /* private void btneConnecter_Click(object sender, EventArgs e)
          {

              var leUser = bd.Utilisateurs.Where(a=>a.Identifiant.ToLower()==txtidentifiant.Text.ToLower()).FirstOrDefault();

              string hash = CryptString.GetMd5Hash(txtMotDePasse.Text);
              //MessageBox.Show("Hash MD5 saisi : " + hash);


              if ((leUser != null) && (CryptString.VerifyMd5Hash(txtMotDePasse.Text, leUser.MotDePasse)))
              {
                  MessageBox.Show("Admin ");
                  frmMDI f = new frmMDI();
              f.role = leUser.Role.code;
              f.Show();
              this.Hide();
               }
              else
              {
                lblMessage.Text = "identifiant ou mot de passe incorrect";
              }

          }*/
        private void btneConnecter_Click(object sender, EventArgs e)
        {
            try
            {

                var leUser = bd.Utilisateurs
                               .Where(a => a.Identifiant.ToLower() == txtidentifiant.Text.ToLower())
                               .FirstOrDefault();

                string hash = CryptString.GetMd5Hash(txtMotDePasse.Text);

                if (leUser != null && leUser.Role != null && CryptString.VerifyMd5Hash(txtMotDePasse.Text, leUser.MotDePasse))
                {
                    MessageBox.Show("Admin ");
                    frmMDI f = new frmMDI();
                    f.role = leUser.Role.code;
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
                // Affichage détaillé de l'erreur principale et de l'InnerException (cause réelle)
                string messageErreur = "Erreur : " + ex.Message;

                if (ex.InnerException != null)
                {
                    messageErreur += "\n\nInnerException : " + ex.InnerException.Message;

                    if (ex.InnerException.InnerException != null)
                    {
                        messageErreur += "\n\nDétail : " + ex.InnerException.InnerException.Message;
                    }
                }

                MessageBox.Show(messageErreur, "Erreur de connexion à la base", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
