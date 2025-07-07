using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIRvMedical.Models
{
    public class MonContexte : DbContext
    {
        public MonContexte() : base("name=DefaultConnection")
        {
        }

        public DbSet<Produit> Produits { get; set; }
    }
}