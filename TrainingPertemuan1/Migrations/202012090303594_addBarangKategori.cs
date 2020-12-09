namespace TrainingPertemuan1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBarangKategori : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KategoriBarangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Barang_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barangs", t => t.Barang_Id, cascadeDelete: true)
                .Index(t => t.Barang_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KategoriBarangs", "Barang_Id", "dbo.Barangs");
            DropIndex("dbo.KategoriBarangs", new[] { "Barang_Id" });
            DropTable("dbo.KategoriBarangs");
            DropTable("dbo.Barangs");
        }
    }
}
