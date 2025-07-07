using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierRvMedical.Model
{
    public class Soin
    {

        [Key]
        public int IdSoin { get; set; }

        [MaxLength(200)]
        public string libelle { get; set; }

        public float cout { get; set; }
    }
}
