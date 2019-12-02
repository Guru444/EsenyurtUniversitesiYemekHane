using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using Entity;

namespace IsKatmani
{
  public  class MenuIslemleri
    {

      VeritabaniKatmani.vertitabaniKatmani katman=new VeritabaniKatmani.vertitabaniKatmani();

      public SqlDataReader MenuIdGetir(DateTime menu)
      {

          VeritabaniKatmani.vertitabaniKatmani katman = new VeritabaniKatmani.vertitabaniKatmani();
          katman.InputParametreEkle("@durum", 5);
          katman.InputParametreEkle("@tarih", menu);
          SqlDataReader sonuc = katman.DrVeriCek("spYemekMenuler", System.Data.CommandType.StoredProcedure);
          return sonuc;

      }


      public SqlDataReader YemekMenusuGetir(DateTime menu)
      {

          VeritabaniKatmani.vertitabaniKatmani katman = new VeritabaniKatmani.vertitabaniKatmani();
          katman.InputParametreEkle("@durum", 5);
          katman.InputParametreEkle("@tarih", menu);
          SqlDataReader sonuc = katman.DrVeriCek("spYemekMenusu", System.Data.CommandType.StoredProcedure);
          return sonuc;

      }



      public int MenuEkle(eMenuler menu)
      {

          VeritabaniKatmani.vertitabaniKatmani katman = new VeritabaniKatmani.vertitabaniKatmani();
          katman.InputParametreEkle("@durum", 4);
          katman.InputParametreEkle("@tarih", menu.Tarih.ToShortDateString());
          int sonuc = katman.EkleSilGuncelle("spYemekMenuler", System.Data.CommandType.StoredProcedure);
          return sonuc;

      }


      public int YemekMenu(eMenuYemek menu)
      {
          VeritabaniKatmani.vertitabaniKatmani katman = new VeritabaniKatmani.vertitabaniKatmani();
          katman.InputParametreEkle("@durum", 4);
          katman.InputParametreEkle("@yemek_id", menu.YemekID.YemekID);
          katman.InputParametreEkle("@menu_id", menu.MenuID.MenuID);
          katman.InputParametreEkle("@tarih", menu.Tarih);
       int sonuc= katman.EkleSilGuncelle("spYemekMenusu",System.Data.CommandType.StoredProcedure);
       return sonuc;

      }



   
      public SqlDataReader KaloriGetir(int katID)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 8);
            veri1.InputParametreEkle("@yemek_id", katID);
            SqlDataReader rd = veri1.DrVeriCek("spYemekTarifler", System.Data.CommandType.StoredProcedure);
            return rd;
        }


      public SqlDataReader TarifGetir(int katID)
      {
          VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
          veri1.InputParametreEkle("@durum", 7);
          veri1.InputParametreEkle("@yemek_id", katID);
          SqlDataReader rd = veri1.DrVeriCek("spYemekTarifler", System.Data.CommandType.StoredProcedure);
          return rd;
      }
 

      public SqlDataReader BugununMenusunuGetir(DateTime katID)
      {
          VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
          veri1.InputParametreEkle("@durum", 6);
          veri1.InputParametreEkle("@tarih", katID);
          SqlDataReader rd = veri1.DrVeriCek("spYemekMenusu", System.Data.CommandType.StoredProcedure);
          return rd;
      }

  



      public int MenuYemekSil(int menu)
      {
          VeritabaniKatmani.vertitabaniKatmani katman = new VeritabaniKatmani.vertitabaniKatmani();
          katman.InputParametreEkle("@durum", 3);
          katman.InputParametreEkle("@menuyemek_id", menu);
          int sonuc = katman.EkleSilGuncelle("spYemekMenusu", System.Data.CommandType.StoredProcedure);
          return sonuc;

      }
     
    }
}
