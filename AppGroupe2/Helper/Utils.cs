using System;
using System.Linq;
using System.Web;
using AppGroupe2.Model;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;

namespace AppGroupe2.Helper
{
    public class Utils

    {
        BdRvMedicalContexe db = new BdRvMedicalContexe();
        /// <summary>
        /// cette methode log dans la base de donnees
        /// </summary>
        /// <param name="TitreErreur">le titre du log</param>
        /// <param name="erreur"> le message du log</param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;  
                log.DescriptionErreur = erreur.Length > 1000 ? erreur.Substring(0, 1000) : erreur;
                log.TitreErreur = TitreErreur;
                db.Td_Erreurs.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void WriteFileError(string message)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Error/erreur.txt");
                System.IO.TextWriter writeFile = new StreamWriter(path, true);
                writeFile.WriteLine("" + DateTime.Now);
                writeFile.WriteLine(message);
                writeFile.WriteLine("---------------------------------------------------------------------------------------");
                writeFile.Flush();
                writeFile.Close();
                writeFile = null;
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "WriteFileError");
            }
        }



        /// <summary>
        /// cette methode permet de logger dans le systeme
        /// </summary>
        /// <param name="erreur"> le message d'erreur</param>
        /// <param name="libelle"> le titre de l'erreur </param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "GestionRvMedical";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }

    }
}