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
        public IEnumerable<Uzytkownicy> GetData(string UserProfileId)
        {
            var query = from u in _userdata
                        where u.OwnerId.Equals(UserProfileId)
                        select u;
            var data = query.ToList();

            return data;
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
