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
    public class SpecialitesController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Specialites
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Specialite>))]
        public IHttpActionResult GetSpecialites()
        {
            var specialites = db.Set<Specialite>().ToList();
            return Ok(specialites);
        }

        // GET: api/Specialites/5
        [HttpGet]
        [ResponseType(typeof(Specialite))]
        public IHttpActionResult GetSpecialite(int id)
        {
            var specialite = db.Set<Specialite>().Find(id);
            if (specialite == null)
            {
                return NotFound();
            }
            return Ok(specialite);
        }

        // POST: api/Specialites
        [HttpPost]
        [ResponseType(typeof(Specialite))]
        public IHttpActionResult PostSpecialite([FromBody] Specialite specialite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Set<Specialite>().Add(specialite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = specialite.IdSpecialite }, specialite);
        }

        // PUT: api/Specialites/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecialite(int id, [FromBody] Specialite specialite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != specialite.IdSpecialite)
                return BadRequest("L'ID ne correspond pas.");

            db.Entry(specialite).State = EntityState.Modified;

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

        // DELETE: api/Specialites/5
        [HttpDelete]
        [ResponseType(typeof(Specialite))]
        public IHttpActionResult DeleteSpecialite(int id)
        {
            var specialite = db.Set<Specialite>().Find(id);
            if (specialite == null)
                return NotFound();

            db.Set<Specialite>().Remove(specialite);
            db.SaveChanges();

            return Ok(specialite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool SpecialiteExists(int id)
        {
            return db.Set<Specialite>().Any(s => s.IdSpecialite == id);
        }
    }
}
