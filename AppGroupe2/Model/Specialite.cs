using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    public class Specialite
    {
        [Key]
        public int IdSpecialite { get; set; }
        [Required,MaxLength(10)]
        public string CodeSpecialite { get; set; }
        [Required,MaxLength(100)]
        public string NomSpecialite {  get; set; }
    }
}
