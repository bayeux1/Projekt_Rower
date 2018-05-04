using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DL.Models
{
    public class Trasa_Ulice
    {   [Key]
        public int id_trasa_ulice { get; set; }
        public int id_trasy { get; set; }
        public string wspolrzedne { get; set; }
        public DateTime data_trasy { get; set; }
        public string nazwa_ulicy { get; set; }
        
    }
}
