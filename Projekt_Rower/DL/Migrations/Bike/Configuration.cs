namespace DL.Migrations.Shop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DL.Models;

    internal sealed class ConfigurationBike : DbMigrationsConfiguration<DL.BikeDbContext>
    {
        public ConfigurationBike()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Bike";
        }

        protected override void Seed(DL.BikeDbContext context)
        {
            Trasy[] trasy = new Trasy[]
            {
                new Trasy { id_trasy=1, data_dodania = DateTime.Now, przyblizony_czas="10", id_uzytkownika=1, poczatek="Bialystok",koniec="Warszawa",komenatrz="Hehe", srednia_ocena=5.2f, zdjecie="zdjecie.png"},
                new Trasy { id_trasy=2, data_dodania = DateTime.Now, przyblizony_czas="10", id_uzytkownika=1, poczatek="Bialystok",koniec="Warszawa",komenatrz="Hehe", srednia_ocena=5.2f, zdjecie="zdjecie.png"},
                new Trasy { id_trasy=3, data_dodania = DateTime.Now, przyblizony_czas="10", id_uzytkownika=1, poczatek="Bialystok",koniec="Warszawa",komenatrz="Hehe", srednia_ocena=5.2f, zdjecie="zdjecie.png"},
            };

            if (context.Trasy.Count() == 0)
            {
                context.Trasy.AddOrUpdate(trasy);
            }

            Uzytkownicy[] uzytkownicy = new Uzytkownicy[]
            {
                new Uzytkownicy { id_uzytkownika = 1, OwnerId = "49ccafca-1aad-44a5-a9c8-3852f1c483e2", imie = "Michal", naziwsko = "Godun", email ="test.test.v.54@gmail.com", haslo="Bialystok", konto_premium=DateTime.Now, pesel="000222", numer_telefonu=11 },
                new Uzytkownicy { id_uzytkownika = 2, OwnerId = "5e891d52-4550-411b-ba42-418ce9658d1e",imie = "Jan", naziwsko = "Nowak", email ="nowak@o2.pl", haslo="Bialystok", konto_premium=DateTime.Now, pesel="000222", numer_telefonu=11 },
            };
            
            context.Uzytkownicy.AddOrUpdate(uzytkownicy);

        }
    }
}
