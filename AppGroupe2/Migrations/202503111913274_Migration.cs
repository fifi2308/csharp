namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        IdAgenda = c.Int(nullable: false, identity: true),
                        DatePlanifier = c.DateTime(precision: 0),
                        Titre = c.String(unicode: false),
                        HeureDebut = c.String(unicode: false),
                        HeureFin = c.String(unicode: false),
                        Creaneau = c.Int(nullable: false),
                        lieu = c.String(unicode: false),
                        Statut = c.String(unicode: false),
                        IdMedecin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgenda)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin, cascadeDelete: true)
                .Index(t => t.IdMedecin);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        IDU = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Adresse = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Tel = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        IdUtilisateur = c.Int(),
                        Identifiant = c.String(maxLength: 20, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 250, storeType: "nvarchar"),
                        Status = c.Boolean(),
                        IdMedecin = c.String(unicode: false),
                        IdSpecialite = c.Int(),
                        NumeroOrdre = c.String(maxLength: 10, storeType: "nvarchar"),
                        GroupSanguin = c.String(maxLength: 3, storeType: "nvarchar"),
                        Poids = c.Single(),
                        Taille = c.Single(),
                        DateNaissance = c.DateTime(precision: 0),
                        TelephoneFixe = c.String(maxLength: 15, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IDU)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite)
                .Index(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        CodeSpecialite = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        NomSpecialite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.RendezVous",
                c => new
                    {
                        IdRv = c.Int(nullable: false, identity: true),
                        DateRv = c.DateTime(nullable: false, precision: 0),
                        Statut = c.String(maxLength: 10, storeType: "nvarchar"),
                        IdSoin = c.Int(),
                        IdPatient = c.Int(),
                        IdMedecin = c.Int(),
                        Agenda_IdAgenda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRv)
                .ForeignKey("dbo.Personnes", t => t.IdMedecin)
                .ForeignKey("dbo.Personnes", t => t.IdPatient)
                .ForeignKey("dbo.Soins", t => t.IdSoin)
                .ForeignKey("dbo.Agenda", t => t.Agenda_IdAgenda)
                .Index(t => t.IdSoin)
                .Index(t => t.IdPatient)
                .Index(t => t.IdMedecin)
                .Index(t => t.Agenda_IdAgenda);
            
            CreateTable(
                "dbo.Soins",
                c => new
                    {
                        IdSoin = c.Int(nullable: false, identity: true),
                        libelle = c.String(maxLength: 200, storeType: "nvarchar"),
                        cout = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdSoin);
            
            CreateTable(
                "dbo.GroupeSanguins",
                c => new
                    {
                        IdGroupeSanguin = c.Int(nullable: false, identity: true),
                        CodeGroupeSanguin = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdGroupeSanguin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "Agenda_IdAgenda", "dbo.Agenda");
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes");
            DropForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Agenda", "IdMedecin", "dbo.Personnes");
            DropIndex("dbo.RendezVous", new[] { "Agenda_IdAgenda" });
            DropIndex("dbo.RendezVous", new[] { "IdMedecin" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropIndex("dbo.Personnes", new[] { "IdSpecialite" });
            DropIndex("dbo.Agenda", new[] { "IdMedecin" });
            DropTable("dbo.GroupeSanguins");
            DropTable("dbo.Soins");
            DropTable("dbo.RendezVous");
            DropTable("dbo.Specialites");
            DropTable("dbo.Personnes");
            DropTable("dbo.Agenda");
        }
    }
}
