namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAJourProduit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        IdProduit = c.Int(nullable: false, identity: true),
                        Designation = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        pu = c.Double(),
                        QteMin = c.Double(),
                        QteCritique = c.Double(),
                        CodeProduit = c.String(unicode: false),
                        CodeCategorie = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdProduit);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produits");
        }
    }
}
