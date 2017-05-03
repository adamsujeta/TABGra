using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Gracz
    {
        public int id { get; set; }
        public virtual Serwer serwer { get; set; }
        public virtual Gildia gildia { get; set; }
        public string nazwa { get; set; }
        public int doswiadczenie { get; set; }
        public int sila { get; set; }
        public int zycia { get; set; }
        public int poziom { get; set; }

        public virtual ICollection<Umiejetnosci> umiejetnosci { get; set; }
        public virtual ICollection<Zadanie> zadania { get; set; }
        public virtual ICollection<Ekwipunek> ekwipunek { get; set; }
    }
}