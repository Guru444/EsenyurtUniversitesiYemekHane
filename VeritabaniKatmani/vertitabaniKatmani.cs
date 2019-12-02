using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class vertitabaniKatmani
    {
        private SqlCommand SorguYaz(string sorgu,CommandType SorguTipi)
        {
            Baglanti baglan = new Baglanti();
            SqlCommand cmd = baglan.baglantiKablosu.CreateCommand();
            cmd.CommandText = sorgu;
            cmd.CommandType = SorguTipi;
            return cmd;

        }
        List<SqlParameter> Parametreler = new List<SqlParameter>();

        public void InputParametreEkle(string parametreAdi,Object Degeri)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parametreAdi;
            prm.Value = Degeri;
            Parametreler.Add(prm);


        }

        public void OutputParametreEkle(string parametreAdi, Object Degeri)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parametreAdi;
            prm.Value = Degeri;
            prm.Direction = ParameterDirection.Output;
            Parametreler.Add(prm);


        }

        private void ParametreleriSorguyaEkle(SqlCommand cmd)
        {
            cmd.Parameters.AddRange(Parametreler.ToArray());

        }

        public object ParametreDegeriniGetir(string ParametreAdi)
        {
            foreach (var item in Parametreler)
            {
                if (item.ParameterName==ParametreAdi)
                {
                    return item.Value.ToString();
                }
                
            }
            return null;

        }
        public int EkleSilGuncelle(string sorgu,CommandType sorguTipi)
        {
            try
            {
                SqlCommand cmd = SorguYaz(sorgu, sorguTipi);
                ParametreleriSorguyaEkle(cmd);
                int sonuc = cmd.ExecuteNonQuery();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();

                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return sonuc;
            }
            catch (Exception ex)
            {

                FileStream fs = new FileStream("Hata.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("EkleSilGuncelle Hata veridi : "+ex.ToString());
                w.Close();
                fs.Close();
                return -1;
            }

        
        }


     

        public object TekDegerScalar(string sorgu, CommandType sorguTipi)
        {
            try
            {
                SqlCommand cmd = SorguYaz(sorgu, sorguTipi);
                ParametreleriSorguyaEkle(cmd);
                object sonuc = cmd.ExecuteScalar();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();

                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return sonuc;
            }
            catch (Exception ex)
            {

                FileStream fs = new FileStream("Hata.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("TekDegerScalar Hata veridi : " + ex.ToString());
                w.Close();
                fs.Close();
                return -1;
            }


        }


        public SqlDataReader DrVeriCek(string sorgu, CommandType sorguTipi)
        {
            try
            {

                SqlCommand cmd = SorguYaz(sorgu, sorguTipi);
                ParametreleriSorguyaEkle(cmd);
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rd;
            }
            catch (Exception ex)
            {

                FileStream fs = new FileStream("Hata.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("TekDegerScalar Hata veridi : " + ex.ToString());
                w.Close();
                fs.Close();
                SqlDataReader rd=null; ;
                return rd;
            }

        }


        public DataTable DtVeriCek(string sorgu, CommandType sorguTipi){

            try
            {
 SqlDataReader rd= DrVeriCek(sorgu, sorguTipi);
            DataTable dt = new DataTable();
            dt.Load(rd);
            return dt;
            }
            catch (Exception ex)
            {

                FileStream fs = new FileStream("Hata.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("TekDegerScalar Hata veridi : " + ex.ToString());
                w.Close();
                fs.Close();
                DataTable dt1=null;
                return dt1;
            }

        }
    }
}
