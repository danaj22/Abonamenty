namespace Abonamenty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nothing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tariffs", "name_of_tariff");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tariffs", "name_of_tariff", c => c.String());
        }
    }
}
