using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    public class ClassReportTicketRv
    {
        public string nomPrenom { get; set; }
        public DateTime dateNaissance { get; set; }
        public DateTime DateRv { get; set; }
        public string Medecin { get; set; }
        public string HeureRv { get; set; }
        public byte[] DataQr { get; set; }
    }
}
