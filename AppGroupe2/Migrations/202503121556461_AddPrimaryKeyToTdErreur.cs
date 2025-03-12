namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrimaryKeyToTdErreur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        IdErreur = c.Int(nullable: false, identity: true),
                        DateErreur = c.DateTime(nullable: false, precision: 0),
                        TitreErreur = c.String(maxLength: 200, storeType: "nvarchar"),
                        DescriptionErreur = c.String(maxLength: 2000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdErreur);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Td_Erreur");
        }
    }
}
