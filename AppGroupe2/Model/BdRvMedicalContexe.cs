using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using System.Data.Entity.Migrations;


namespace AppGroupe2.Model
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdRvMedicalContexe:DbContext
    {

        public BdRvMedicalContexe() : base("bdRvMedicalContext") { }
           


        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public  DbSet<Agenda> Agenda { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<RendezVous> RendezVous {  get; set; }

        public DbSet<Soin> Soins { get; set; }
        public DbSet<Secretaire> Secretaires { get; set; }
        public DbSet<Specialite> Specialites {  get; set; }
        public DbSet<GroupeSanguin> GroupeSanguins {  get; set; }
        public DbSet<Td_Erreur> Td_Erreurs{ get; set; }


    }
   
}
