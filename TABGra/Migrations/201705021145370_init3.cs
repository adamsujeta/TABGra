namespace TABGra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gildias", "nazwa", c => c.String());
            AddColumn("dbo.Zadanies", "opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zadanies", "opis");
            DropColumn("dbo.Gildias", "nazwa");
        }
    }
}
