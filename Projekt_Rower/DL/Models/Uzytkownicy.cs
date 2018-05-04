using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DL.Models
{
    public class Uzytkownicy
    {   [Key]
        public int id_uzytkownika { get; set; }
        public string imie { get; set; }
        public string naziwsko { get; set; }
        public string pesel { get; set; }
        public string haslo { get; set; }
        public string email { get; set; }
        public int numer_telefonu { get; set; }
        public DateTime konto_premium { get; set; }
        public string OwnerId { get; set; }
        
    }
}
