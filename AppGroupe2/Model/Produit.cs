using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppGroupe2.Model
{
    public partial class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public Nullable <double> PU { get; set; }
        public Nullable<double> QteMin { get; set; }
        public Nullable<double> QteCritique { get; set; }
        public string CodeProduit { get; set; }
        public string CodeCategorie { get; set; }
    }
}
