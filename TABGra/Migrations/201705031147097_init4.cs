namespace TABGra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EkwipunekGraczas", "bron_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekGraczas", "gracz_id", "dbo.Graczs");
            DropForeignKey("dbo.EkwipunekGraczas", "zbroja_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekGraczas", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekPotworas", "bron_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekPotworas", "potwor_id", "dbo.Potwors");
            DropForeignKey("dbo.EkwipunekPotworas", "zbroja_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekPotworas", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropIndex("dbo.EkwipunekGraczas", new[] { "bron_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "gracz_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "zbroja_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "Ekwipunek_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "bron_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "potwor_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "zbroja_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "Ekwipunek_id" });
            CreateTable(
                "dbo.GraczEkwipuneks",
                c => new
                    {
                        Gracz_id = c.Int(nullable: false),
                        Ekwipunek_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gracz_id, t.Ekwipunek_id })
                .ForeignKey("dbo.Graczs", t => t.Gracz_id, cascadeDelete: true)
                .ForeignKey("dbo.Ekwipuneks", t => t.Ekwipunek_id, cascadeDelete: true)
                .Index(t => t.Gracz_id)
                .Index(t => t.Ekwipunek_id);
            
            CreateTable(
                "dbo.PotworEkwipuneks",
                c => new
                    {
                        Potwor_id = c.Int(nullable: false),
                        Ekwipunek_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Potwor_id, t.Ekwipunek_id })
                .ForeignKey("dbo.Potwors", t => t.Potwor_id, cascadeDelete: true)
                .ForeignKey("dbo.Ekwipuneks", t => t.Ekwipunek_id, cascadeDelete: true)
                .Index(t => t.Potwor_id)
                .Index(t => t.Ekwipunek_id);
            
            DropTable("dbo.EkwipunekGraczas");
            DropTable("dbo.EkwipunekPotworas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EkwipunekPotworas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bron_id = c.Int(),
                        potwor_id = c.Int(),
                        zbroja_id = c.Int(),
                        Ekwipunek_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EkwipunekGraczas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bron_id = c.Int(),
                        gracz_id = c.Int(),
                        zbroja_id = c.Int(),
                        Ekwipunek_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.PotworEkwipuneks", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.PotworEkwipuneks", "Potwor_id", "dbo.Potwors");
            DropForeignKey("dbo.GraczEkwipuneks", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.GraczEkwipuneks", "Gracz_id", "dbo.Graczs");
            DropIndex("dbo.PotworEkwipuneks", new[] { "Ekwipunek_id" });
            DropIndex("dbo.PotworEkwipuneks", new[] { "Potwor_id" });
            DropIndex("dbo.GraczEkwipuneks", new[] { "Ekwipunek_id" });
            DropIndex("dbo.GraczEkwipuneks", new[] { "Gracz_id" });
            DropTable("dbo.PotworEkwipuneks");
            DropTable("dbo.GraczEkwipuneks");
            CreateIndex("dbo.EkwipunekPotworas", "Ekwipunek_id");
            CreateIndex("dbo.EkwipunekPotworas", "zbroja_id");
            CreateIndex("dbo.EkwipunekPotworas", "potwor_id");
            CreateIndex("dbo.EkwipunekPotworas", "bron_id");
            CreateIndex("dbo.EkwipunekGraczas", "Ekwipunek_id");
            CreateIndex("dbo.EkwipunekGraczas", "zbroja_id");
            CreateIndex("dbo.EkwipunekGraczas", "gracz_id");
            CreateIndex("dbo.EkwipunekGraczas", "bron_id");
            AddForeignKey("dbo.EkwipunekPotworas", "Ekwipunek_id", "dbo.Ekwipuneks", "id");
            AddForeignKey("dbo.EkwipunekPotworas", "zbroja_id", "dbo.Ekwipuneks", "id");
            AddForeignKey("dbo.EkwipunekPotworas", "potwor_id", "dbo.Potwors", "id");
            AddForeignKey("dbo.EkwipunekPotworas", "bron_id", "dbo.Ekwipuneks", "id");
            AddForeignKey("dbo.EkwipunekGraczas", "Ekwipunek_id", "dbo.Ekwipuneks", "id");
            AddForeignKey("dbo.EkwipunekGraczas", "zbroja_id", "dbo.Ekwipuneks", "id");
            AddForeignKey("dbo.EkwipunekGraczas", "gracz_id", "dbo.Graczs", "id");
            AddForeignKey("dbo.EkwipunekGraczas", "bron_id", "dbo.Ekwipuneks", "id");
        }
    }
}
