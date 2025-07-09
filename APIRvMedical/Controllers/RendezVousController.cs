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
    public class RendezVousController : ApiController
    {
        private BdRvMedicalContexe bd = new BdRvMedicalContexe();

        // GET: api/RendezVous
        [HttpGet]
        [ResponseType(typeof(IEnumerable<RendezVous>))]
        public IHttpActionResult GetRendezVous()
        {
            var rdvs = bd.RendezVous
                         .Include(r => r.Soin)
                         .Include(r => r.patient)
                         .Include(r => r.Medecin)
                         .ToList();
            return Ok(rdvs);
        }

        // GET: api/RendezVous/5
        [HttpGet]
        [ResponseType(typeof(RendezVous))]
        public IHttpActionResult GetRendezVous(int id)
        {
            var rdv = bd.RendezVous
                        .Include(r => r.Soin)
                        .Include(r => r.patient)
                        .Include(r => r.Medecin)
                        .FirstOrDefault(r => r.IdRv == id);

            if (rdv == null)
                return NotFound();

            return Ok(rdv);
        }

        // POST: api/RendezVous
        [HttpPost]
        [ResponseType(typeof(RendezVous))]
        public IHttpActionResult PostRendezVous([FromBody] RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bd.RendezVous.Add(rv);
            bd.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rv.IdRv }, rv);
        }

        // PUT: api/RendezVous/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRendezVous(int id, [FromBody] RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != rv.IdRv)
                return BadRequest("L'identifiant ne correspond pas.");

            bd.Entry(rv).State = EntityState.Modified;

            try
            {
                bd.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/RendezVous/5
        [HttpDelete]
        [ResponseType(typeof(RendezVous))]
        public IHttpActionResult DeleteRendezVous(int id)
        {
            var rdv = bd.RendezVous.Find(id);
            if (rdv == null)
                return NotFound();

            bd.RendezVous.Remove(rdv);
            bd.SaveChanges();

            return Ok(rdv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                bd.Dispose();

            base.Dispose(disposing);
        }

        private bool RendezVousExists(int id)
        {
            return bd.RendezVous.Any(r => r.IdRv == id);
        }
    }
}
