using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
    public class Oceny
    {   [Key]
        public int id_oceny { get; set; }
        public int ocena { get; set; }
        public int id_trasy { get; set; }
        public int id_uzytkownika { get; set; }
    }
}
