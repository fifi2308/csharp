using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using APIRvMedical.Models;
using AppGroupe2.Helper;  // Pour CryptString

namespace APIRvMedical.Controllers
{
    public class UtilisateursController : ApiController
    {
        private BdRvMedicalContexe db = new BdRvMedicalContexe();

        // POST: api/Utilisateurs/Login
        [HttpPost]
        [Route("api/Utilisateurs/Login")]
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult Login([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = db.Utilisateurs
                         .Include(u => u.Role) // Charger le rôle lié
                         .FirstOrDefault(u => u.Identifiant.ToLower() == login.Identifiant.ToLower());

            if (user == null)
                return Unauthorized();

            // Vérifier le mot de passe (hash MD5)
            if (!CryptString.VerifyMd5Hash(login.MotDePasse, user.MotDePasse))
                return Unauthorized();

            user.MotDePasse = null; // Ne pas renvoyer le mot de passe

            return Ok(user);
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ResponseType(typeof(IQueryable<Utilisateur>))]
        public IHttpActionResult GetUtilisateurs()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Role);
            return Ok(utilisateurs);
        }

        // GET: api/Utilisateurs/5
        [HttpGet]
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult GetUtilisateur(int id)
        {
            var utilisateur = db.Utilisateurs.Include(u => u.Role).FirstOrDefault(u => u.IDU == id);
            if (utilisateur == null)
                return NotFound();

            utilisateur.MotDePasse = null; // Ne pas exposer le mot de passe
            return Ok(utilisateur);
        }

        // POST: api/Utilisateurs
        [HttpPost]
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult PostUtilisateur([FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Hash le mot de passe avant l'insertion
            utilisateur.MotDePasse = CryptString.GetMd5Hash(utilisateur.MotDePasse);

            db.Utilisateurs.Add(utilisateur);
            db.SaveChanges();

            utilisateur.MotDePasse = null; // Ne pas exposer le mot de passe

            return CreatedAtRoute("DefaultApi", new { id = utilisateur.IDU }, utilisateur);
        }

        // PUT: api/Utilisateurs/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUtilisateur(int id, [FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != utilisateur.IDU)
                return BadRequest("L'identifiant ne correspond pas.");

            // Optionnel : gérer la mise à jour du mot de passe (hash)
            if (!string.IsNullOrEmpty(utilisateur.MotDePasse))
            {
                utilisateur.MotDePasse = CryptString.GetMd5Hash(utilisateur.MotDePasse);
            }
            else
            {
                // Garder l'ancien mot de passe s'il n'est pas modifié
                var ancienUser = db.Utilisateurs.AsNoTracking().FirstOrDefault(u => u.IDU == id);
                if (ancienUser != null)
                {
                    utilisateur.MotDePasse = ancienUser.MotDePasse;
                }
            }

            db.Entry(utilisateur).State = EntityState.Modified;

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

        // DELETE: api/Utilisateurs/5
        [HttpDelete]
        [ResponseType(typeof(Utilisateur))]
        public IHttpActionResult DeleteUtilisateur(int id)
        {
            var utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
                return NotFound();

            db.Utilisateurs.Remove(utilisateur);
            db.SaveChanges();

            utilisateur.MotDePasse = null;

            return Ok(utilisateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool UtilisateurExists(int id)
        {
            return db.Utilisateurs.Any(u => u.IDU == id);
        }
    }

    // Modèle pour la réception du login
    public class LoginModel
    {
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
    }
}
