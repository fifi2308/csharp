using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "MedecinService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez MedecinService.svc ou MedecinService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class MedecinService : IMedecinService
    {
        private BdRvMedicalContexe _context = new BdRvMedicalContexe();

        public List<Medecin> GetAllMedecins()
        {
            return _context.Medecins.Include("Specialite").ToList();
        }

        public Medecin GetMedecinById(string id)
        {
            return _context.Medecins.Find(id);
        }

        public void AddMedecin(Medecin medecin)
        {
            _context.Medecins.Add(medecin);
            _context.SaveChanges();
        }

        public void UpdateMedecin(Medecin medecin)
        {
            _context.Entry(medecin).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMedecin(string id)
        {
            var medecin = _context.Medecins.Find(id);
            if (medecin != null)
            {
                _context.Medecins.Remove(medecin);
                _context.SaveChanges();
            }
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
