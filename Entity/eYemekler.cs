using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class eYemekler
    {
        public int YemekID { get; set; }
        public string YemekAdi { get; set; }
        public int  YemekKalori { get; set; }
        public eKategoriler KategoriID { get; set; }
        public DateTime Tarih { get; set; }
    
    }
}
