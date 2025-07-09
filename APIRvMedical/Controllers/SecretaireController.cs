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
    public class SecretaireController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Secretaire
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Secretaire>))]
        public IHttpActionResult GetSecretaires()
        {
            var secretaires = db.Utilisateurs.OfType<Secretaire>().ToList();
            return Ok(secretaires);
        }

        // GET: api/Secretaire/5
        [HttpGet]
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult GetSecretaire(int id)
        {
            var secretaire = db.Utilisateurs.OfType<Secretaire>().FirstOrDefault(s => s.IDU == id);
            if (secretaire == null)
            {
                return NotFound();
            }
            return Ok(secretaire);
        }

        // POST: api/Secretaire
        [HttpPost]
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult PostSecretaire([FromBody] Secretaire secretaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Utilisateurs.Add(secretaire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = secretaire.IDU }, secretaire);
        }

        // PUT: api/Secretaire/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecretaire(int id, [FromBody] Secretaire secretaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secretaire.IDU)
            {
                return BadRequest("L'identifiant ne correspond pas.");
            }

            db.Entry(secretaire).State = EntityState.Modified;

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

        // DELETE: api/Secretaire/5
        [HttpDelete]
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult DeleteSecretaire(int id)
        {
            var secretaire = db.Utilisateurs.OfType<Secretaire>().FirstOrDefault(s => s.IDU == id);
            if (secretaire == null)
            {
                return NotFound();
            }

            db.Utilisateurs.Remove(secretaire);
            db.SaveChanges();

            return Ok(secretaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecretaireExists(int id)
        {
            return db.Utilisateurs.OfType<Secretaire>().Any(s => s.IDU == id);
        }
    }
}
