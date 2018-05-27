using DL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class ProfileService
    {
        private BikeDbContext _context;

        private DbSet<Uzytkownicy> _userdata;

        public ProfileService()
        {
            _context = new BikeDbContext();
            _userdata = _context.Uzytkownicy;
        }
        public void AddTrack(Trasy trasa,int userId)
        {
            Trasy t = new Trasy
            {
                data_dodania = DateTime.Now,
                poczatek = trasa.poczatek,
                koniec = trasa.koniec,
                komenatrz = trasa.komenatrz,
                srednia_ocena = trasa.srednia_ocena,
                przyblizony_czas = trasa.przyblizony_czas,
                zdjecie = trasa.zdjecie,
                id_trasa_ulice = trasa.id_trasa_ulice,
                id_trasy = trasa.id_trasy,
                id_uzytkownika = userId,
            };

            _context.Trasy.Add(t);
            _context.SaveChanges();
        }
        public IEnumerable<Uzytkownicy> GetData(string UserProfileId)
        {
            var query = from u in _userdata
                        where u.OwnerId.Equals(UserProfileId)
                        select u;
            var data = query.ToList();

            return data;
        }
        public IEnumerable<Trasy> GetTrasy(string UserProfileId)
        {
            var query = from t in _context.Trasy
                        where t.User.OwnerId.Equals(UserProfileId)
                        select t;
            var trasy = query.ToList();

            return trasy;
        }

        public IEnumerable<Uzytkownicy> GetUserId(string UserProfileId)
        {
            var query = from u in _context.Uzytkownicy
                        where u.OwnerId.Equals(UserProfileId)
                        select u;
            var user = query.ToList();

            return user;
        }
        public Uzytkownicy GetUserData(string userId)
        {
            Uzytkownicy user = _userdata.Where(u => u.OwnerId.Equals(userId)).FirstOrDefault();
            return user;
        }
        public void UserProfileEdit(Uzytkownicy user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
