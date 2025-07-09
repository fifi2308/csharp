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
    public class RolesController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // GET: api/Roles
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Role>))]
        public IHttpActionResult GetRoles()
        {
            var roles = db.roles.ToList();
            return Ok(roles);
        }

        // GET: api/Roles/5
        [HttpGet]
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            var role = db.roles.Find(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        // POST: api/Roles
        [HttpPost]
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole([FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.roles.Add(role);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // PUT: api/Roles/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != role.Id)
                return BadRequest("L'id ne correspond pas.");

            db.Entry(role).State = EntityState.Modified;

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

        // DELETE: api/Roles/5
        [HttpDelete]
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            var role = db.roles.Find(id);
            if (role == null)
                return NotFound();

            db.roles.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.roles.Any(r => r.Id == id);
        }
    }
}
