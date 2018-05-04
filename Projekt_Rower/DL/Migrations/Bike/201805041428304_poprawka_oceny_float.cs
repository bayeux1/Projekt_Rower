namespace DL.Migrations.Shop
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawka_oceny_float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ocenies", "ocena", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ocenies", "ocena", c => c.Int(nullable: false));
        }
    }
}
