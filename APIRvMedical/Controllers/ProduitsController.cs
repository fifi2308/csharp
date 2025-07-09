using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AppGroupe2.Model;


namespace APIRvMedical.Controllers
{
    public class ProduitsController : ApiController
    {
        // Utilisation explicite du bon DbContext
        private APIRvMedical.Models.BdRvMedicalContexe bd = new APIRvMedical.Models.BdRvMedicalContexe();

        // GET: api/Produits
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AppGroupe2.Model.Produit>))]
        public IHttpActionResult GetProduits()
        {
            var produits = bd.Produits.ToList();
            return Ok(produits);
        }

        // GET: api/Produits/5
        [HttpGet]
        [ResponseType(typeof(AppGroupe2.Model.Produit))]
        public IHttpActionResult GetProduit(int id)
        {
            var produit = bd.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(produit);
        }

        // POST: api/Produits
        [HttpPost]
        [ResponseType(typeof(AppGroupe2.Model.Produit))]
        public IHttpActionResult PostProduit([FromBody] AppGroupe2.Model.Produit produit)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bd.Produits.Add(produit);
            bd.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produit.IdProduit }, produit);
        }

        // PUT: api/Produits/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduit(int id, AppGroupe2.Model.Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produit.IdProduit)
            {
                return BadRequest("L'identifiant ne correspond pas.");
            }

            bd.Entry(produit).State = EntityState.Modified;

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

        // DELETE: api/Produits/5
        [HttpDelete]
        [ResponseType(typeof(AppGroupe2.Model.Produit))]
        public IHttpActionResult DeleteProduit(int id)
        {
            var produit = bd.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();
            }

            bd.Produits.Remove(produit);
            bd.SaveChanges();

            return Ok(produit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProduitExists(int id)
        {
            return bd.Produits.Any(p => p.IdProduit == id);
        }
    }
}
