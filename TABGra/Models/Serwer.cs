using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Serwer
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public int id_admina { get; set; }
        public int pojemnośc { get; set; }
        public virtual ICollection<Gracz> gracze { get; set; }
    }
}