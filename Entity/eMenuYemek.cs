﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class eMenuYemek
    {
        public int MenuYemekID { get; set; }
        public eYemekler YemekID { get; set; }
        public eMenuler MenuID { get; set; }
        public DateTime Tarih { get; set; }
    }
}
