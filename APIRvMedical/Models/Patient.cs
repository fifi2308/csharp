using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APIRvMedical.Models
{
    public class Patient: Utilisateur
    {
        [Required, MaxLength(3)]
        public string GroupSanguin { get; set; }
        [Required]
        public float? Poids { get; set; }
        [Required]
        public float? Taille { get; set; }
        public DateTime? DateNaissance { get; set; }
    }
}
