namespace TABGra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ekwipuneks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        opis = c.String(),
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ekwipuneks", t => t.bron_id)
                .ForeignKey("dbo.Graczs", t => t.gracz_id)
                .ForeignKey("dbo.Ekwipuneks", t => t.zbroja_id)
                .ForeignKey("dbo.Ekwipuneks", t => t.Ekwipunek_id)
                .Index(t => t.bron_id)
                .Index(t => t.gracz_id)
                .Index(t => t.zbroja_id)
                .Index(t => t.Ekwipunek_id);
            
            CreateTable(
                "dbo.Graczs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        doswiadczenie = c.Int(nullable: false),
                        sila = c.Int(nullable: false),
                        zycia = c.Int(nullable: false),
                        poziom = c.Int(nullable: false),
                        gildia_id = c.Int(),
                        serwer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Gildias", t => t.gildia_id)
                .ForeignKey("dbo.Serwers", t => t.serwer_id)
                .Index(t => t.gildia_id)
                .Index(t => t.serwer_id);
            
            CreateTable(
                "dbo.Gildias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        poziom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Umiejetnoscis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        specyfikacja = c.String(),
                        poziom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Serwers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_admina = c.Int(nullable: false),
                        pojemnośc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Zadanies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nagroda = c.String(),
                        NPC = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ekwipuneks", t => t.bron_id)
                .ForeignKey("dbo.Potwors", t => t.potwor_id)
                .ForeignKey("dbo.Ekwipuneks", t => t.zbroja_id)
                .ForeignKey("dbo.Ekwipuneks", t => t.Ekwipunek_id)
                .Index(t => t.bron_id)
                .Index(t => t.potwor_id)
                .Index(t => t.zbroja_id)
                .Index(t => t.Ekwipunek_id);
            
            CreateTable(
                "dbo.Potwors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        doswiadczenie = c.String(),
                        przedmioty = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UmiejetnosciGildias",
                c => new
                    {
                        Umiejetnosci_id = c.Int(nullable: false),
                        Gildia_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Umiejetnosci_id, t.Gildia_id })
                .ForeignKey("dbo.Umiejetnoscis", t => t.Umiejetnosci_id, cascadeDelete: true)
                .ForeignKey("dbo.Gildias", t => t.Gildia_id, cascadeDelete: true)
                .Index(t => t.Umiejetnosci_id)
                .Index(t => t.Gildia_id);
            
            CreateTable(
                "dbo.UmiejetnosciGraczs",
                c => new
                    {
                        Umiejetnosci_id = c.Int(nullable: false),
                        Gracz_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Umiejetnosci_id, t.Gracz_id })
                .ForeignKey("dbo.Umiejetnoscis", t => t.Umiejetnosci_id, cascadeDelete: true)
                .ForeignKey("dbo.Graczs", t => t.Gracz_id, cascadeDelete: true)
                .Index(t => t.Umiejetnosci_id)
                .Index(t => t.Gracz_id);
            
            CreateTable(
                "dbo.ZadanieGraczs",
                c => new
                    {
                        Zadanie_id = c.Int(nullable: false),
                        Gracz_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zadanie_id, t.Gracz_id })
                .ForeignKey("dbo.Zadanies", t => t.Zadanie_id, cascadeDelete: true)
                .ForeignKey("dbo.Graczs", t => t.Gracz_id, cascadeDelete: true)
                .Index(t => t.Zadanie_id)
                .Index(t => t.Gracz_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EkwipunekPotworas", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekPotworas", "zbroja_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekPotworas", "potwor_id", "dbo.Potwors");
            DropForeignKey("dbo.EkwipunekPotworas", "bron_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekGraczas", "Ekwipunek_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.EkwipunekGraczas", "zbroja_id", "dbo.Ekwipuneks");
            DropForeignKey("dbo.ZadanieGraczs", "Gracz_id", "dbo.Graczs");
            DropForeignKey("dbo.ZadanieGraczs", "Zadanie_id", "dbo.Zadanies");
            DropForeignKey("dbo.Graczs", "serwer_id", "dbo.Serwers");
            DropForeignKey("dbo.UmiejetnosciGraczs", "Gracz_id", "dbo.Graczs");
            DropForeignKey("dbo.UmiejetnosciGraczs", "Umiejetnosci_id", "dbo.Umiejetnoscis");
            DropForeignKey("dbo.UmiejetnosciGildias", "Gildia_id", "dbo.Gildias");
            DropForeignKey("dbo.UmiejetnosciGildias", "Umiejetnosci_id", "dbo.Umiejetnoscis");
            DropForeignKey("dbo.Graczs", "gildia_id", "dbo.Gildias");
            DropForeignKey("dbo.EkwipunekGraczas", "gracz_id", "dbo.Graczs");
            DropForeignKey("dbo.EkwipunekGraczas", "bron_id", "dbo.Ekwipuneks");
            DropIndex("dbo.ZadanieGraczs", new[] { "Gracz_id" });
            DropIndex("dbo.ZadanieGraczs", new[] { "Zadanie_id" });
            DropIndex("dbo.UmiejetnosciGraczs", new[] { "Gracz_id" });
            DropIndex("dbo.UmiejetnosciGraczs", new[] { "Umiejetnosci_id" });
            DropIndex("dbo.UmiejetnosciGildias", new[] { "Gildia_id" });
            DropIndex("dbo.UmiejetnosciGildias", new[] { "Umiejetnosci_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EkwipunekPotworas", new[] { "Ekwipunek_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "zbroja_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "potwor_id" });
            DropIndex("dbo.EkwipunekPotworas", new[] { "bron_id" });
            DropIndex("dbo.Graczs", new[] { "serwer_id" });
            DropIndex("dbo.Graczs", new[] { "gildia_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "Ekwipunek_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "zbroja_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "gracz_id" });
            DropIndex("dbo.EkwipunekGraczas", new[] { "bron_id" });
            DropTable("dbo.ZadanieGraczs");
            DropTable("dbo.UmiejetnosciGraczs");
            DropTable("dbo.UmiejetnosciGildias");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Potwors");
            DropTable("dbo.EkwipunekPotworas");
            DropTable("dbo.Zadanies");
            DropTable("dbo.Serwers");
            DropTable("dbo.Umiejetnoscis");
            DropTable("dbo.Gildias");
            DropTable("dbo.Graczs");
            DropTable("dbo.EkwipunekGraczas");
            DropTable("dbo.Ekwipuneks");
        }
    }
}
