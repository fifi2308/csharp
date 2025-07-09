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
    public class MedecinsController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Medecins
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Medecin>))]
        public IHttpActionResult GetMedecins()
        {
            var medecins = db.Utilisateurs.OfType<Medecin>()
                .Include(m => m.Specialite)
                .Include(m => m.agenda)
                .ToList();

            return Ok(medecins);
        }

        // GET: api/Medecins/5
        [HttpGet]
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult GetMedecin(string id)
        {
            var medecin = db.Utilisateurs.OfType<Medecin>()
                .Include(m => m.Specialite)
                .Include(m => m.agenda)
                .FirstOrDefault(m => m.IdMedecin == id);

            if (medecin == null)
                return NotFound();

            return Ok(medecin);
        }

        // POST: api/Medecins
        [HttpPost]
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult PostMedecin([FromBody] Medecin medecin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Utilisateurs.Add(medecin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medecin.IdMedecin }, medecin);
        }

        // PUT: api/Medecins/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedecin(string id, [FromBody] Medecin medecin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != medecin.IdMedecin)
                return BadRequest("L'identifiant ne correspond pas.");

            db.Entry(medecin).State = EntityState.Modified;

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

        // DELETE: api/Medecins/5
        [HttpDelete]
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult DeleteMedecin(string id)
        {
            var medecin = db.Utilisateurs.OfType<Medecin>().FirstOrDefault(m => m.IdMedecin == id);
            if (medecin == null)
                return NotFound();

            db.Utilisateurs.Remove(medecin);
            db.SaveChanges();

            return Ok(medecin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool MedecinExists(string id)
        {
            return db.Utilisateurs.OfType<Medecin>().Any(m => m.IdMedecin == id);
        }
    }
}
