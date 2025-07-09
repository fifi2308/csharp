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
    public class GroupeSanguinController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/GroupeSanguin
        [HttpGet]
        [ResponseType(typeof(IEnumerable<GroupeSanguin>))]
        public IHttpActionResult GetGroupesSanguins()
        {
            var groupes = db.Set<GroupeSanguin>().ToList();
            return Ok(groupes);
        }

        // GET: api/GroupeSanguin/5
        [HttpGet]
        [ResponseType(typeof(GroupeSanguin))]
        public IHttpActionResult GetGroupeSanguin(int id)
        {
            var groupe = db.Set<GroupeSanguin>().Find(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return Ok(groupe);
        }

        // POST: api/GroupeSanguin
        [HttpPost]
        [ResponseType(typeof(GroupeSanguin))]
        public IHttpActionResult PostGroupeSanguin([FromBody] GroupeSanguin groupe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Set<GroupeSanguin>().Add(groupe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupe.IdGroupeSanguin }, groupe);
        }

        // PUT: api/GroupeSanguin/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupeSanguin(int id, [FromBody] GroupeSanguin groupe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != groupe.IdGroupeSanguin)
                return BadRequest("L'ID ne correspond pas.");

            db.Entry(groupe).State = EntityState.Modified;

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

        // DELETE: api/GroupeSanguin/5
        [HttpDelete]
        [ResponseType(typeof(GroupeSanguin))]
        public IHttpActionResult DeleteGroupeSanguin(int id)
        {
            var groupe = db.Set<GroupeSanguin>().Find(id);
            if (groupe == null)
                return NotFound();

            db.Set<GroupeSanguin>().Remove(groupe);
            db.SaveChanges();

            return Ok(groupe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool GroupeSanguinExists(int id)
        {
            return db.Set<GroupeSanguin>().Any(g => g.IdGroupeSanguin == id);
        }
    }
}
