namespace Abonamenty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToTariff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tariffs", "name_of_tariff", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tariffs", "name_of_tariff");
        }
    }
}
