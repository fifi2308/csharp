using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetierRvMedical.Model;

namespace MetierRvMedical.Services
{
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
    }
}