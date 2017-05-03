using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Gildia
    {
        public int id { get; set; }
        public string nazwa { get; set; }

        public int poziom { get; set; }
        public virtual ICollection<Umiejetnosci> umiejetnosci { get; set; }
        public virtual ICollection<Gracz> gracze { get; set; }
    }
}