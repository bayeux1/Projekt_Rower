namespace DL.Migrations.Shop
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "User_Id1", "dbo.UserProfiles");
            DropForeignKey("dbo.Comments", "Track_Id1", "dbo.Tracks");
            DropForeignKey("dbo.Comments", "User_Id1", "dbo.UserProfiles");
            DropIndex("dbo.Comments", new[] { "Track_Id1" });
            DropIndex("dbo.Comments", new[] { "User_Id1" });
            DropIndex("dbo.Tracks", new[] { "User_Id1" });
            CreateTable(
                "dbo.Niebezpieczenstwas",
                c => new
                    {
                        id_niebezieczenstwa = c.Int(nullable: false, identity: true),
                        rodzaj = c.String(),
                        komenatrz = c.String(),
                        data_dodania = c.DateTime(nullable: false),
                        id_trasy = c.Int(nullable: false),
                        wspolrzedne = c.String(),
                    })
                .PrimaryKey(t => t.id_niebezieczenstwa);
            
            CreateTable(
                "dbo.Ocenies",
                c => new
                    {
                        id_oceny = c.Int(nullable: false, identity: true),
                        ocena = c.Int(nullable: false),
                        id_trasy = c.Int(nullable: false),
                        id_uzytkownika = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_oceny);
            
            CreateTable(
                "dbo.Trasa_Ulice",
                c => new
                    {
                        id_trasa_ulice = c.Int(nullable: false, identity: true),
                        id_trasy = c.Int(nullable: false),
                        wspolrzedne = c.String(),
                        data_trasy = c.DateTime(nullable: false),
                        nazwa_ulicy = c.String(),
                    })
                .PrimaryKey(t => t.id_trasa_ulice);
            
            CreateTable(
                "dbo.Trasies",
                c => new
                    {
                        id_trasy = c.Int(nullable: false, identity: true),
                        poczatek = c.String(),
                        koniec = c.String(),
                        zdjecie = c.String(),
                        przyblizony_czas = c.String(),
                        data_dodania = c.DateTime(nullable: false),
                        komenatrz = c.String(),
                        id_trasa_ulice = c.Int(nullable: false),
                        srednia_ocena = c.Double(nullable: false),
                        id_uzytkownika = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_trasy)
                .ForeignKey("dbo.Uzytkownicies", t => t.id_uzytkownika, cascadeDelete: true)
                .Index(t => t.id_uzytkownika);
            
            CreateTable(
                "dbo.Uzytkownicies",
                c => new
                    {
                        id_uzytkownika = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        naziwsko = c.String(),
                        pesel = c.String(),
                        haslo = c.String(),
                        email = c.String(),
                        numer_telefonu = c.Int(nullable: false),
                        konto_premium = c.DateTime(nullable: false),
                        OwnerId = c.String(),
                    })
                .PrimaryKey(t => t.id_uzytkownika);
            
            CreateTable(
                "dbo.Widokis",
                c => new
                    {
                        id_widoku = c.Int(nullable: false, identity: true),
                        rodzaj = c.String(),
                        komenatrz = c.String(),
                        data_dodania = c.DateTime(nullable: false),
                        id_trasy = c.Int(nullable: false),
                        wspolrzedne = c.String(),
                    })
                .PrimaryKey(t => t.id_widoku);
            
            DropTable("dbo.Comments");
            DropTable("dbo.Tracks");
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        OwnerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Long = c.Single(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        Track_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Track_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Trasies", "id_uzytkownika", "dbo.Uzytkownicies");
            DropIndex("dbo.Trasies", new[] { "id_uzytkownika" });
            DropTable("dbo.Widokis");
            DropTable("dbo.Uzytkownicies");
            DropTable("dbo.Trasies");
            DropTable("dbo.Trasa_Ulice");
            DropTable("dbo.Ocenies");
            DropTable("dbo.Niebezpieczenstwas");
            CreateIndex("dbo.Tracks", "User_Id1");
            CreateIndex("dbo.Comments", "User_Id1");
            CreateIndex("dbo.Comments", "Track_Id1");
            AddForeignKey("dbo.Comments", "User_Id1", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Comments", "Track_Id1", "dbo.Tracks", "Id");
            AddForeignKey("dbo.Tracks", "User_Id1", "dbo.UserProfiles", "Id");
        }
    }
}
