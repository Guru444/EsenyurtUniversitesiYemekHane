using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using Entity;

namespace IsKatmani
{
  public  class YemekIslemleri
    {

      

        //Yemekler Procedure de
        //0-- Listele
        //1-Select
        //2-Update
        //3-delete
        //4-insert
        //5-enSon 5 tane yemek getirir.
      //6-bilgileri getirir.
        public SqlDataReader EnSonYemekleriListele()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 5);
            SqlDataReader rd = veri.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }




        public int YemekEkle(Entity.eYemekler yemek)
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 4);
            veri.InputParametreEkle("@yemek_adi",yemek.YemekAdi);
            veri.InputParametreEkle("@yemek_kalori", yemek.YemekKalori);
            veri.InputParametreEkle("@kategori_id", yemek.KategoriID.KategoriID);
            veri.InputParametreEkle("@tarih", yemek.Tarih);
            int rd = veri.EkleSilGuncelle("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }

        public SqlDataReader YemekIstatislikleriGetir()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 6);
            SqlDataReader rd = veri.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }


        public SqlDataReader YemekIstatislikleriGetir1()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 10);
            SqlDataReader rd = veri.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }


        public DataTable KategoriGetirArama(string ara)
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 5);
            veri.InputParametreEkle("@malzeme_adi", ara);
            DataTable rd = veri.DtVeriCek("spYemekMalzemeler", System.Data.CommandType.StoredProcedure);

            return rd;


        }

        public DataTable YemekGetirArama(string ara)
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 9);
            veri.InputParametreEkle("@yemek_adi", ara);
            DataTable rd = veri.DtVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }
        public DataTable YemekiGetir()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 0);
            DataTable rd = veri.DtVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }


        public int KategoriEkle(string txtYeEkKategori,string dat)
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 4);
              veri.InputParametreEkle( "@kategori_adi", txtYeEkKategori);
              veri.InputParametreEkle("@tarih", dat);
            int rd = veri.EkleSilGuncelle("spYemekKategori", System.Data.CommandType.StoredProcedure);

            return rd;



        }


        public DataTable MalzemeGetir()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 0);
            DataTable rd = veri.DtVeriCek("spYemekMalzemeler", System.Data.CommandType.StoredProcedure);

            return rd;


        }


        public int MalzemeEkle(Entity.eMalzemeler malzeme)
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 4);
            veri1.InputParametreEkle("@malzeme_adi", malzeme.MalzemeAdi);
            veri1.InputParametreEkle("@tarih", malzeme.Tarih);
            int rd = veri1.EkleSilGuncelle("spYemekMalzemeler", System.Data.CommandType.StoredProcedure);

            return rd;


        }
      
        public DataTable KategoriGetir()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 0);
            DataTable rd = veri.DtVeriCek("spYemekKategori", System.Data.CommandType.StoredProcedure);

            return rd;


        }

        public SqlDataReader KategoriGetirDr()
        {
            VeritabaniKatmani.vertitabaniKatmani veri = new vertitabaniKatmani();
            veri.InputParametreEkle("@durum", 0);
            SqlDataReader rd = veri.DrVeriCek("spYemekKategori", System.Data.CommandType.StoredProcedure);

            return rd;


        }



        public DataTable YemekleriiGetir()
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 0);
            DataTable rd = veri1.DtVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);

            return rd;


        }

        public int TarifEkle(eTarifler tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 4);
            veri1.InputParametreEkle("@yemek_id", tarif.YemekId.YemekID);
             veri1.InputParametreEkle("@malzeme_id",tarif.MalzemeID.MalzemeID);
             veri1.InputParametreEkle("@gramaj",tarif.Gramaj);
             veri1.InputParametreEkle("@maliyet", tarif.Maliyet);
            int rd = veri1.EkleSilGuncelle("spYemekTarifler", System.Data.CommandType.StoredProcedure);

            return rd;



        }


        public int TarifGuncelle(eTarifler tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 2);
            veri1.InputParametreEkle("@yemek_id", tarif.YemekId.YemekID);
            veri1.InputParametreEkle("@malzeme_id", tarif.MalzemeID.MalzemeID);
            veri1.InputParametreEkle("@gramaj", tarif.Gramaj);
            veri1.InputParametreEkle("@maliyet", tarif.Maliyet);
            veri1.InputParametreEkle("@tarif_id", tarif.TarifID);
            int rd = veri1.EkleSilGuncelle("spYemekTarifler", System.Data.CommandType.StoredProcedure);

            return rd;



        }

      


        public SqlDataReader YemeklereGoreTarifGetir(eYemekler tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 5);
            veri1.InputParametreEkle("@yemek_id", tarif.YemekID);
            SqlDataReader rd = veri1.DrVeriCek("spYemekTarifler", System.Data.CommandType.StoredProcedure);

            return rd;



        }

        public int TarifSil(eTarifler tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 3);
            veri1.InputParametreEkle("@tarif_id", tarif.TarifID);
            int rd = veri1.EkleSilGuncelle("spYemekTarifler", System.Data.CommandType.StoredProcedure);

            return rd;



        }


        public SqlDataReader YemekleriAra(string tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 7);
            veri1.InputParametreEkle("@yemek_adi", tarif);
            SqlDataReader rd = veri1.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }


        public SqlDataReader YemekleriGetirId(int tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 1);
            veri1.InputParametreEkle("@yemek_id", tarif);
            SqlDataReader rd = veri1.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }


        public int YemekGucelle1(eYemekler tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum",2);
            veri1.InputParametreEkle("@yemek_adi", tarif.YemekAdi);
            veri1.InputParametreEkle("@kategori_id", tarif.KategoriID.KategoriID);
            veri1.InputParametreEkle("@yemek_kalori", tarif.YemekKalori);
            veri1.InputParametreEkle("@yemek_id", tarif.YemekID);
            int rd = veri1.EkleSilGuncelle("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }

        public int YemekSil(int tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 3);
            veri1.InputParametreEkle("@yemek_id", tarif);
            int rd = veri1.EkleSilGuncelle("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }

        public DataTable KategoriyeGoreYemekGetir(int tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 8);
            veri1.InputParametreEkle("@kategori_id", tarif);
            DataTable rd = veri1.DtVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }

        public SqlDataReader KategoriyeGoreYemekGetir1(int tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 8);
            veri1.InputParametreEkle("@kategori_id", tarif);
            SqlDataReader rd = veri1.DrVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;
        }



        public DataTable YemekleriAraDtg(string tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 7);
            veri1.InputParametreEkle("@yemek_adi", tarif);
            DataTable rd = veri1.DtVeriCek("spYemekler", System.Data.CommandType.StoredProcedure);
            return rd;





        }
        public SqlDataReader TarifGetir(int tarif)
        {
            VeritabaniKatmani.vertitabaniKatmani veri1 = new vertitabaniKatmani();
            veri1.InputParametreEkle("@durum", 6);
            veri1.InputParametreEkle("@tarif_id", tarif);
            SqlDataReader rd = veri1.DrVeriCek("spYemekTarifler", System.Data.CommandType.StoredProcedure);

            return rd;



        }

    }
}
