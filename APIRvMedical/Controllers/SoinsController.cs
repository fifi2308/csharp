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
    public class SoinsController : ApiController
    {
        private BdRvMedicalContexe bd = new BdRvMedicalContexe();

        // GET: api/Soins
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Soin>))]
        public IHttpActionResult GetSoins()
        {
            var soins = bd.Soins.ToList();
            return Ok(soins);
        }

        // GET: api/Soins/5
        [HttpGet]
        [ResponseType(typeof(Soin))]
        public IHttpActionResult GetSoin(int id)
        {
            var soin = bd.Soins.Find(id);
            if (soin == null)
            {
                return NotFound();
            }

            return Ok(soin);
        }

        // POST: api/Soins
        [HttpPost]
        [ResponseType(typeof(Soin))]
        public IHttpActionResult PostSoin([FromBody] Soin soin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bd.Soins.Add(soin);
            bd.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = soin.IdSoin }, soin);
        }

        // PUT: api/Soins/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoin(int id, [FromBody] Soin soin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soin.IdSoin)
            {
                return BadRequest("L'identifiant ne correspond pas.");
            }

            bd.Entry(soin).State = EntityState.Modified;

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

        // DELETE: api/Soins/5
        [HttpDelete]
        [ResponseType(typeof(Soin))]
        public IHttpActionResult DeleteSoin(int id)
        {
            var soin = bd.Soins.Find(id);
            if (soin == null)
            {
                return NotFound();
            }

            bd.Soins.Remove(soin);
            bd.SaveChanges();

            return Ok(soin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoinExists(int id)
        {
            return bd.Soins.Any(s => s.IdSoin == id);
        }
    }
}
