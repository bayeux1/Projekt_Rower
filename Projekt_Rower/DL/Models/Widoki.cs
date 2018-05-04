using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DL.Models
{
    public class Widoki
    {
        [Key]
        public int id_widoku { get; set; }
        public string rodzaj { get; set; }
        public string komenatrz { get; set; }
        public DateTime data_dodania { get; set; }
        public int id_trasy { get; set; }
        public string wspolrzedne { get; set; }
    }
}
