using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        BdRvMedicalContexe bd = new BdRvMedicalContexe();
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        /// <summary>
        /// retourne la liste des agenda
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetListeAgenda()
        {
            return bd.Agenda.ToList();

        }
        public bool AddAgenda(Agenda agenda)
        {
            try
            {
                bd.Agenda.Add(agenda);
                bd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenda"></param>
        /// <returns></returns>
        public bool UpdateAgenda(Agenda agenda)
        {
            try
            {
                bd.Entry(agenda).State = EntityState.Modified;
                bd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Medecin GetMedecinByID(int id) 
        {
            return bd.Medecins.Find(id);
        }
    }
}