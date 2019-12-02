using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsKatmani;
using System.Data.SqlClient;

namespace EsenyurtUniversitesiYemekHane
{
    public partial class formYemekDetay : Form
    {
        public formYemekDetay()
        {
            InitializeComponent();
        }
        IsKatmani.YemekIslemleri islem = new IsKatmani.YemekIslemleri();
        IsKatmani.MenuIslemleri islem2 = new IsKatmani.MenuIslemleri();

        private void formYemekDetay_Load(object sender, EventArgs e)
        {
            panel1.AutoSize=true;
            SqlDataReader dr= islem2.TarifGetir(formMenuIslemleri.YemekId);
            int i = 1;
            if (dr.HasRows)
            {
                string icerik = "";
                while (dr.Read())
                {

                    icerik += i.ToString()+". "+dr[8].ToString() + "\n";
                    lblYemekAdi.Text = "Yemeğin Tarifi";
                    i++;
                }
                lblIcerik.Text = icerik;
                
            }
            else
            {
                lblIcerik.Text = "Malzeme bilgileri girilmemiştir.\nEn Kısa sürede malzeme girişi yapınız. ";
            }

            IsKatmani.MenuIslemleri menu = new MenuIslemleri();
            SqlDataReader rd1 = menu.KaloriGetir(formMenuIslemleri.YemekId);
            if (rd1.HasRows)
            {
                while (rd1.Read())
                {

                    if (rd1[0].ToString()=="")
                    {
                        lblKalori.Text="Toplam Kalori: 0";
                        return;
                    }
                    lblKalori.Text = "Toplam Kalori: " + " " + rd1[0].ToString() + "Kcal";

                } 
            }

            else
            {
                lblKalori.Text = "0 Toplam Kalori";
            }
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
