using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetierRvMedical.Model;
using System.Data.Entity;

namespace MetierRvMedical.Services
{
    public class PatientService : IPatientService
    {
        private BdRvMedicalContexe _context = new BdRvMedicalContexe();

        public PatientService()
        {
        }

        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.IDU == id);
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
