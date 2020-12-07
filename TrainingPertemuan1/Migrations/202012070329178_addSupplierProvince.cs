namespace TrainingPertemuan1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSupplierProvince : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.Provinces");
        }
    }
}
