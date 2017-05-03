using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Potwor
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public string doswiadczenie { get; set; }
        public string przedmioty { get; set; }
        public virtual ICollection<Ekwipunek> ekwipunek { get; set; }
    }
}