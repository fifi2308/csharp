using AppGroupe2.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.Model;

namespace AppGroupe2
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateAdmin();
            Application.Run(new frmMedecin());
            
        }
        static void CreateAdmin()
        {
            using (var bd = new BdRvMedicalContexe())
            {
                // Vérifier si le rôle "admin" existe, sinon le créer

                //var adminRole = bd.roles.FirstOrDefault(r => r.code.ToLower() == "admin");
                var adminRole = bd.roles.FirstOrDefault(r => r.code != null && r.code.ToLower() == "admin");

                if (adminRole == null)
                {
                    adminRole = new Role
                    {
                        code = "admin",
                        Libelle = "Administrateur"
                    };
                    bd.roles.Add(adminRole);
                    bd.SaveChanges(); // Sauvegarde le rôle dans la base
                }

                // Vérifier s'il y a déjà un admin dans les utilisateurs
                int AdminExist = bd.Utilisateurs.OfType<Admin>().Count();
                if (AdminExist == 0)
                {
                    Admin admin = new Admin()
                    {
                        Adresse = "Liberte6extension",
                        Identifiant = "admin",
                        Status = true,
                        Tel = "784226719",
                        MotDePasse = Helper.CryptString.GetMd5Hash("Passer"),
                        NomPrenom = "Fall-Fatou",
                        Email = "fatou@gmail.com",
                        IdRole = adminRole.Id  // On utilise l'ID du rôle créé ou existant
                    };
                    bd.Utilisateurs.Add(admin);
                    bd.SaveChanges(); // Sauvegarde l'admin dans la base
                }
            }
        }



    }
}
