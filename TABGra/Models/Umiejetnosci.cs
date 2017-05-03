﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABGra.Models
{
    public class Umiejetnosci
    {
        public int id { get; set; }
        public string specyfikacja { get; set; }
        public int poziom { get; set; }
        public virtual ICollection<Gildia> gildie { get; set; }
        public virtual ICollection<Gracz> gracze { get; set; }
    }
}