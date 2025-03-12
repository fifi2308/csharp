using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    public class Agenda
    {
        [Key]
        public int IdAgenda { get; set;}
        public DateTime? DatePlanifier {  get; set;}
        public string Titre { get; set; }
        public string HeureDebut { get; set; }
        public string HeureFin { get; set; }
        public int Creaneau { get;set; }
        public string lieu { get; set; }
        public string Statut { get;set; }

        public int IdMedecin { get; set; }
        [ForeignKey("IdMedecin")]
        public Medecin Medecin { get; set; }
        public virtual ICollection<RendezVous> rendezVous   {get; set;}

    }
}
