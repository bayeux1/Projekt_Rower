using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DL.Models
{
    public class Trasy
    {   [Key]
        public int id_trasy { get; set; }
        public string poczatek { get; set; }
        public string koniec { get; set; }
        public string zdjecie { get; set; }
        public string przyblizony_czas { get; set; }
        public DateTime data_dodania { get; set; }
        public string komenatrz { get; set; }
        public int id_trasa_ulice { get; set; }
        public float srednia_ocena { get; set; }
        public Uzytkownicy User { get; set; }
        public int id_uzytkownika { get; set; }
    }
}
