using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace VeritabaniKatmani
{
    class Baglanti
    {
        SqlConnection baglanti;

        public SqlConnection baglantiKablosu
       {
           get
           {
               if (baglanti!=null)
               {
                   if (baglanti.State==ConnectionState.Closed)
                   {
                       baglanti.Open();
                 
                   }
            
                   
               }
               else
               {
                   baglanti = new SqlConnection(baglantiCumlecigi());
                   if (baglanti.State == ConnectionState.Closed)
                   {
                       baglanti.Open();

                   }
                   return baglanti;
               }

               return baglanti;
           }

          


       }
        private string baglantiCumlecigi()
       {
           return ConfigurationManager.AppSettings["baglantiCumlecigi"].ToString();


       }
       
    }
}
