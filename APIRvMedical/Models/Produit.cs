using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRvMedical.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
    }
}