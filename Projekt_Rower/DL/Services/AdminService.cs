using DL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class AdminService
    {
        private BikeDbContext _context;

        private DbSet<Trasy> _tracks;
        private DbSet<Oceny> _oceny;

        public AdminService()
        {
            _context = new BikeDbContext();
            _tracks = _context.Trasy;
            _oceny = _context.Oceny;
        }

        public Oceny GetOceny(int id_oceny)
        {
            Oceny ocena = _context.Oceny.Where(o => o.id_oceny == id_oceny).SingleOrDefault();
            if (ocena == null)
                return null;

            return ocena;
        }
        public Trasa_Ulice GetTrasa_Ulice(int id_trasa_ulice)
        {
            Trasa_Ulice trasa_ulice = _context.Trasa_ulice.Where(tu => tu.id_trasa_ulice == id_trasa_ulice).SingleOrDefault();
            if (trasa_ulice == null)
                return null;

            return trasa_ulice;
        }
        public Niebezpieczenstwa GetNiebezpieczenstwa(int id_niebezieczenstwa)
        {
            Niebezpieczenstwa niebezpieczenstwa = _context.Niebezpieczenstwa.Where(n => n.id_niebezieczenstwa == id_niebezieczenstwa).SingleOrDefault();
            if (niebezpieczenstwa == null)
                return null;

            return niebezpieczenstwa;
        }
        public Trasy GetTrasy(int id_trasy)
        {
            Trasy trasa = _context.Trasy.Where(t => t.id_trasy == id_trasy).SingleOrDefault();
            if (trasa == null)
                return null;

            return trasa;
        }
        public Widoki GetWidoki(int id_widoku)
        {
            Widoki widok = _context.Widoki.Where(w => w.id_widoku == id_widoku).SingleOrDefault();
            if (widok == null)
                return null;

            return widok;
        }
        public IEnumerable<Niebezpieczenstwa> GetNiebezpieczenstwa()
        {
            var query = from n in _context.Niebezpieczenstwa
                        select n;
            var niebezpieczenstwa = query.ToList();

            return niebezpieczenstwa;
        }
        public IEnumerable<Oceny> GetOceny()
            {
                var query = from o in _context.Oceny
                            select o;
                var oceny = query.ToList();

                return oceny;
            }
        public IEnumerable<Trasa_Ulice> GetTrasa_Ulice()
        {
            var query = from tu in _context.Trasa_ulice
                        select tu;
            var trasa_ulice = query.ToList();

            return trasa_ulice;
        }

        public IEnumerable<Widoki> GetWidoki()
        {
            var query = from w in _context.Widoki
                        select w;
            var widoki = query.ToList();

            return widoki;
        }
        public IEnumerable<Trasy> GetTrasy()
        {
            var query = from t in _context.Trasy
                        select t;
            var trasy = query.ToList();

            return trasy;
        }
        public IEnumerable<Uzytkownicy> GetUser()
        {
            var query = from u in _context.Uzytkownicy
                        select u;
            var uzytkownicy = query.ToList();

            return uzytkownicy;
        }
        public Uzytkownicy GetUserData(int id_uzytkownika)
        {
            Uzytkownicy uzytkownik = _context.Uzytkownicy.Where(u => u.id_uzytkownika.Equals(id_uzytkownika)).FirstOrDefault();
            return uzytkownik;
        }
        public void UserProfileEdit(Uzytkownicy user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddTrack(Trasy trasa)
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
                id_uzytkownika = trasa.id_uzytkownika,
            };

            _context.Trasy.Add(t);
            _context.SaveChanges();
        }

        public void AddNiebezpieczenstwa(Niebezpieczenstwa niebezpieczenstwo)
        {
            Niebezpieczenstwa n = new Niebezpieczenstwa
            {
                data_dodania = DateTime.Now,
                rodzaj = niebezpieczenstwo.rodzaj,
                wspolrzedne = niebezpieczenstwo.wspolrzedne,
                komenatrz = niebezpieczenstwo.komenatrz,
                id_niebezieczenstwa = niebezpieczenstwo.id_niebezieczenstwa,
                id_trasy = niebezpieczenstwo.id_trasy,

            };

            _context.Niebezpieczenstwa.Add(n);
            _context.SaveChanges();
        }
        public void AddOceny(Oceny ocena)
        {
            Oceny o = new Oceny
            {
                id_oceny = ocena.id_oceny,
                ocena = ocena.ocena,
                id_uzytkownika = ocena.id_uzytkownika,
                id_trasy = ocena.id_trasy,
                
               
            };

            _oceny.Add(o);
            _context.SaveChanges();
        }

        public void AddTrasa_Ulice(Trasa_Ulice trasa_ulice)
        {
            Trasa_Ulice tu = new Trasa_Ulice
            {
                data_trasy = DateTime.Now,
                nazwa_ulicy = trasa_ulice.nazwa_ulicy,
                id_trasa_ulice = trasa_ulice.id_trasa_ulice,
                id_trasy = trasa_ulice.id_trasy,
                wspolrzedne = trasa_ulice.wspolrzedne,

            };

            _context.Trasa_ulice.Add(tu);
            _context.SaveChanges();
        }
        public void AddWidok(Widoki widok)
        {
            Widoki w = new Widoki
            {
                data_dodania = DateTime.Now,
                wspolrzedne = widok.wspolrzedne,
                komenatrz = widok.komenatrz,
                rodzaj = widok.rodzaj,
                id_widoku = widok.id_widoku,
                id_trasy = widok.id_trasy,
            };

            _context.Widoki.Add(w);
            _context.SaveChanges();
        }

        public void DeleteTrack(int id_trasy)
        {
            var tr = _context.Trasy.Where(t => t.id_trasy.Equals(id_trasy)).FirstOrDefault();
            _context.Trasy.Remove(tr);
            _context.SaveChanges();
        }
        public void DeleteNiebezpieczenstwa(int id_niebezieczenstwa)
        {
            var ni = _context.Niebezpieczenstwa.Where(n => n.id_niebezieczenstwa.Equals(id_niebezieczenstwa)).FirstOrDefault();
            _context.Niebezpieczenstwa.Remove(ni);
            _context.SaveChanges();
        }
        public void DeleteOceny(int id_oceny)
        {
            var oc = _context.Oceny.Where(o => o.id_oceny.Equals(id_oceny)).FirstOrDefault();
            _context.Oceny.Remove(oc);
            _context.SaveChanges();
        }
        public void DeleteTrasa_Ulice(int id_trasa_ulice)
        {
            var tus = _context.Trasa_ulice.Where(tu => tu.id_trasa_ulice.Equals(id_trasa_ulice)).FirstOrDefault();
            _context.Trasa_ulice.Remove(tus);
            _context.SaveChanges();
        }

        public void DeleteUser(int id_uzytkownika)
        {
            var u = _context.Uzytkownicy.Where(p => p.id_uzytkownika.Equals(id_uzytkownika)).FirstOrDefault();
            _context.Uzytkownicy.Remove(u);
            _context.SaveChanges();
        }

        public void DeleteWidoki(int id_widoku)
        {
            var wi = _context.Widoki.Where(w => w.id_widoku.Equals(id_widoku)).FirstOrDefault();
            _context.Widoki.Remove(wi);
            _context.SaveChanges();
        }

        public void EditNiebezpieczenstwa(Niebezpieczenstwa niebezpieczenstwo)
        {
            _context.Entry(niebezpieczenstwo).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditOceny(Oceny ocena)
        {
            _context.Entry(ocena).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditTrasa_Ulice(Trasa_Ulice trasa_ulice)
        {
            _context.Entry(trasa_ulice).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditTrack(Trasy trasa)
        {
            _context.Entry(trasa).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditWidoki(Widoki widok)
        {
            _context.Entry(widok).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Uzytkownicy GetUserData(string id_uzytkownika)
        {
            Uzytkownicy uzytkownik = _context.Uzytkownicy.Where(u => u.OwnerId.Equals(id_uzytkownika)).FirstOrDefault();
            return uzytkownik;
        }

    }
}
