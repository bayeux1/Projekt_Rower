namespace DL.Migrations.Shop
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trasies", "srednia_ocena", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trasies", "srednia_ocena", c => c.Double(nullable: false));
        }
    }
}
