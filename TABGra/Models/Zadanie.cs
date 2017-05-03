using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Zadanie
    {
        public int id { get; set; }
        public string opis { get; set; }
        public string nagroda { get; set; }
        public string NPC { get; set; }
        public virtual ICollection<Gracz> gracze { get; set; }
    }
}