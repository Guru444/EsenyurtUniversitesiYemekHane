using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class eTarifler
    {
        public int TarifID { get; set; }
        public eYemekler YemekId { get; set; }
        public eMalzemeler MalzemeID { get; set; }
        public decimal  Gramaj { get; set; }
        public decimal Maliyet { get; set; }
        public DateTime  Tarih { get; set; }
    
    }
}
