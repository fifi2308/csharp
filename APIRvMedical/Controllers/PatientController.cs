using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using APIRvMedical.Models;

namespace APIRvMedical.Controllers
{
    public class PatientsController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Patients
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Patient>))]
        public IHttpActionResult GetPatients()
        {
            var patients = db.Utilisateurs.OfType<Patient>().ToList();
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet]
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            var patient = db.Utilisateurs.OfType<Patient>().FirstOrDefault(p => p.IDU == id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // POST: api/Patients
        [HttpPost]
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Utilisateurs.Add(patient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patient.IDU }, patient);
        }

        // PUT: api/Patients/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != patient.IDU)
                return BadRequest("L'identifiant ne correspond pas.");

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Patients/5
        [HttpDelete]
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            var patient = db.Utilisateurs.OfType<Patient>().FirstOrDefault(p => p.IDU == id);
            if (patient == null)
                return NotFound();

            db.Utilisateurs.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Utilisateurs.OfType<Patient>().Any(p => p.IDU == id);
        }
    }
}
