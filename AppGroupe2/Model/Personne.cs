    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;


    namespace AppGroupe2.Model
    {
        public class Personne
        {
            [Key]
            public int IDU { get; set; }
            [Required, MaxLength(160)]
            public string NomPrenom { get; set; }
            [Required, MaxLength(200)]
            public string Adresse { get; set; }
            [Required,MaxLength(80),DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required,MaxLength(20)]
            public string Tel { get; set; }
        }
    }
