using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    public class Secretaire: Utilisateur
    {
        [MaxLength(15)]
        public string TelephoneFixe { get; set; }
    }
}
