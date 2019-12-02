using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using Entity;
using System.Data.SqlClient;

namespace IsKatmani
{
   public class Dersler
    {
        VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();

        public int DersEkle(string DersAdi)
        {

            veri.InputParametreEkle("@dersadi", DersAdi);
            int sonuc= veri.EkleSilGuncelle("sp_DersEkle", System.Data.CommandType.StoredProcedure);
            return sonuc;
        }


        public DataTable DersleriGoruntule()
        {
            DataTable dt= veri.DtVeriCek("DersleriGetir", CommandType.StoredProcedure);
            return dt;

        }

       List<Ders> de=new List<Ders>();
       public List<Ders> Getir()
       {
           SqlDataReader rd = veri.DrVeriCek("DersleriGetir", CommandType.StoredProcedure);
           if (rd.HasRows)
	{
		  while (rd.Read())
           {
              Ders d=new Ders{
                  id=Convert.ToInt32(rd[0].ToString()),
                  Adi=rd[1].ToString()
              } ;
              de.Add(d);
           }
          return de;
	}
           return null;



       }


    }
}
