using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Ekwipunek
    {
        public int id { get; set; }
        public string opis { get; set; }

        public virtual ICollection<Gracz> gracze { get; set; }

        public virtual ICollection<Potwor> Potwory { get; set; }
    }
}