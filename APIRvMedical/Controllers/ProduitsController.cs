using System;
using System.Collections.Generic;
using System.Data.Entity; // il manquait ce using pour EntityState
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using APIRvMedical.Models;

namespace APIRvMedical.Controllers
{
    public class ProduitsController : ApiController
    {
        private BdRvMedicalContexe bd = new BdRvMedicalContexe();

        // POST: api/Produits
        [ResponseType(typeof(Produit))]
        public IHttpActionResult PostProduit(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bd.Produits.Add(produit);
            bd.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produit.Id }, produit);
        }

        // GET: api/Produits/5
        [ResponseType(typeof(Produit))]
        public IHttpActionResult GetProduit(int id)
        {
            Produit produit = bd.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();
            }

            return Ok(produit);
        }

        // PUT: api/Produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduit(int id, Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produit.Id)
            {
                return BadRequest();
            }

            bd.Entry(produit).State = EntityState.Modified;

            try
            {
                bd.SaveChanges();
            }
            catch (Exception ex)
            {
                // tu peux logguer l'erreur si besoin
                return InternalServerError(ex);
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent); // retour 204 No Content
        }

        // DELETE: api/Produits/5
        [ResponseType(typeof(Produit))]
        public IHttpActionResult DeleteProduit(int id)
        {
            Produit produit = bd.Produits.Find(id);
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
            return bd.Produits.Count(p => p.Id == id) > 0;
        }
    }
}
