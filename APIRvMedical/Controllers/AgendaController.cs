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
    public class AgendasController : ApiController
    {
        private BdRvMedicalContexe bd = new BdRvMedicalContexe();

        // GET: api/Agendas
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Agenda>))]
        public IHttpActionResult GetAgendas()
        {
            var agendas = bd.Agenda.Include(a => a.Medecin).ToList();
            return Ok(agendas);
        }

        // GET: api/Agendas/5
        [HttpGet]
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult GetAgenda(int id)
        {
            var agenda = bd.Agenda.Include(a => a.Medecin).FirstOrDefault(a => a.IdAgenda == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // POST: api/Agendas
        [HttpPost]
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult PostAgenda([FromBody] Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bd.Agenda.Add(agenda);
            bd.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenda.IdAgenda }, agenda);
        }

        // PUT: api/Agendas/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenda(int id, [FromBody] Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenda.IdAgenda)
            {
                return BadRequest("L'identifiant ne correspond pas.");
            }

            var existingAgenda = bd.Agenda.Find(id);
            if (existingAgenda == null)
            {
                return NotFound();
            }

            // Mise à jour des propriétés
            existingAgenda.DatePlanifier = agenda.DatePlanifier;
            existingAgenda.Titre = agenda.Titre;
            existingAgenda.HeureDebut = agenda.HeureDebut;
            existingAgenda.HeureFin = agenda.HeureFin;
            existingAgenda.Creaneau = agenda.Creaneau;
            existingAgenda.lieu = agenda.lieu;
            existingAgenda.Statut = agenda.Statut;
            existingAgenda.IdMedecin = agenda.IdMedecin;

            bd.Entry(existingAgenda).State = EntityState.Modified;

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

        // DELETE: api/Agendas/5
        [HttpDelete]
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult DeleteAgenda(int id)
        {
            var agenda = bd.Agenda.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            bd.Agenda.Remove(agenda);
            bd.SaveChanges();

            return Ok(agenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendaExists(int id)
        {
            return bd.Agenda.Any(a => a.IdAgenda == id);
        }
    }
}
