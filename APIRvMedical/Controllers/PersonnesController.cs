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
    public class PersonnesController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Personnes
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Personne>))]
        public IHttpActionResult GetPersonnes()
        {
            var personnes = db.Set<Personne>().ToList();
            return Ok(personnes);
        }

        // GET: api/Personnes/5
        [HttpGet]
        [ResponseType(typeof(Personne))]
        public IHttpActionResult GetPersonne(int id)
        {
            var personne = db.Set<Personne>().Find(id);
            if (personne == null)
            {
                return NotFound();
            }
            return Ok(personne);
        }

        // POST: api/Personnes
        [HttpPost]
        [ResponseType(typeof(Personne))]
        public IHttpActionResult PostPersonne([FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Set<Personne>().Add(personne);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personne.IDU }, personne);
        }

        // PUT: api/Personnes/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonne(int id, [FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != personne.IDU)
                return BadRequest("L'identifiant ne correspond pas.");

            db.Entry(personne).State = EntityState.Modified;

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

        // DELETE: api/Personnes/5
        [HttpDelete]
        [ResponseType(typeof(Personne))]
        public IHttpActionResult DeletePersonne(int id)
        {
            var personne = db.Set<Personne>().Find(id);
            if (personne == null)
                return NotFound();

            db.Set<Personne>().Remove(personne);
            db.SaveChanges();

            return Ok(personne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool PersonneExists(int id)
        {
            return db.Set<Personne>().Any(p => p.IDU == id);
        }
    }
}
