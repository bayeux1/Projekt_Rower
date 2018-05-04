using DL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext()
            : base("DefaultConnection")
        {

        }

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }

        public DbSet<Trasy> Trasy { get; set; }

        public DbSet<Uzytkownicy> Uzytkownicy { get; set; }

        public DbSet<Trasa_Ulice> Trasa_ulice { get; set; }
        public DbSet<Widoki> Widoki { get; set; }

        public DbSet<Niebezpieczenstwa> Niebezpieczenstwa { get; set; }
        public DbSet<Oceny> Oceny { get; set; }

    }
}
//Enable-Migrations -ContextTypeName DL.UserDbContext -MigrationsDirectory "Migrations\User" -ProjectName DL
//Add-Migration -ConfigurationTypeName ConfigurationBike -ProjectName DL initial
//Update-Database -ProjectName DL -ConfigurationTypeName ConfigurationBike