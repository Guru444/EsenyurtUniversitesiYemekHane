using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using IsKatmani;
using System.Data.SqlClient;
using System.Threading;
namespace EsenyurtUniversitesiYemekHane
{
    public partial class YemekIslemleri : Form
    {
        public YemekIslemleri()
        {
            InitializeComponent();
        }

        private void YemekIslemleri_Load(object sender, EventArgs e)
        {
            pnlTarifEkleMalzeme.Visible = false;
            grpMenu.Visible = false;

            lstYemekSil.View = View.Details;
            lstYemekSil.GridLines = true;
            lstYemekSil.FullRowSelect = true;
            lstYemekSil.Columns.Add("No", 50);
            lstYemekSil.Columns.Add("Yemek Adi", 150);
            lstYemekSil.Columns.Add("Kategori Adi", 200);
            lstYemekSil.Columns.Add("Kalori", 200);

            lstTarifEkle.View = View.Details;
            lstTarifEkle.GridLines = true;
            lstTarifEkle.FullRowSelect = true;
            lstTarifEkle.Columns.Add("No", 50);

            lstTarifEkle.Columns.Add("Malzeme Adi", 300);
            lstTarifEkle.Columns.Add("Gramaj", 80);
            lstTarifEkle.Columns.Add("Birimi", 80);
            lstTarifEkle.Columns.Add("Maliyet", 80);

            //ListView TarifEkle Gİrdileri


            pnlYemeklerAnaMenu.Visible = true;
            //    pnlYemekSil.Visible = false;
            pnlYemekGuncelle.Visible = false;
            pnlYemekEkleme.Visible = false;
            pnlYemekSil.Visible = false;
            timer1.Start();
            
          

        }



        void YemekleriGetir()
        {
            comTarEkleYemekler.DataSource = null;
           DataTable dt= yemek1.YemekleriiGetir();
           comTarEkleYemekler.DataSource = dt;
           comTarEkleYemekler.ValueMember = "yemek_id";
           comTarEkleYemekler.DisplayMember = "yemek_adi";

        }
        void KategoriGetir()
        {
          
            comYeEkKategori.DataSource = null;
            comYeEkKategori.Items.Clear();
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
            DataTable dt = YemekIslemleri.KategoriGetir();
            comYeEkKategori.DataSource = dt;
            comYeEkKategori.ValueMember = "kategori_id";
            comYeEkKategori.DisplayMember = "kategori_adi";    
   
        }


        void GuncelleKategoriGetir()
        {

          
        }

        void TarifEkleKategoriGetir()
        {
            
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
            DataTable dt = YemekIslemleri.KategoriGetir();
            comTarifEkleKategori.DataSource = dt;
            comTarifEkleKategori.ValueMember = "kategori_id";
            comTarifEkleKategori.DisplayMember = "kategori_adi";

        }


        void YemekIstatislikleriGetir()
        {
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
           
            SqlDataReader rd = YemekIslemleri.YemekIstatislikleriGetir();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                 lblYemekSayisi.Text =rd[0].ToString();
              
                }
            }
            else
            {
                lblYemekSayisi.Text = "0";
                lblBugunYemekSayisi.Text = "0";
            }

        }


        void YemekIstatislikleriGetir1()
        {
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();

            SqlDataReader rd = YemekIslemleri.YemekIstatislikleriGetir1();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lblBugunYemekSayisi.Text = rd[0].ToString();

                }
            }
            else
            {
                lblYemekSayisi.Text = "0";
                lblBugunYemekSayisi.Text = "0";
            }

        }
        void EnSonYemekleriListele()
        {
            lstYemekler.Items.Clear();
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
            SqlDataReader rd = YemekIslemleri.EnSonYemekleriListele();
            if (rd.HasRows)
            {
                lstYemekler.Visible = true;
                while (rd.Read())
                {
                    string yemekid = rd[0].ToString();
                    string yemekadi = rd[1].ToString();
                    string yemekalori = rd[2].ToString();
                    string yemektarih = rd[4].ToString();
                    string yemekkategori = rd[7].ToString();
                    string[] yemekSatir = { yemekid, yemekadi, yemekalori, yemekkategori, yemektarih};
                    var satir = new ListViewItem(yemekSatir);
                    lstYemekler.Items.Add(satir);
                    
                }
            }
            else
            {
                lblYemekEnSonYemek.Text = "Yemek bulunmamaktadır. ";
                lstYemekler.Visible = false;
            }
            
 


        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            lbEnSonYemekHata.Text = "";
            lstYemekSil.Visible = false;
      
            pnlYemekSil.Visible = false;
            pnlTarifEkleMalzeme.Visible = false;
            lstYemekler.Items.Clear();

            YemekIstatislikleriGetir1();


            //ListView TarifEkle Gİrdileri


            pnlYemeklerAnaMenu.Visible = true;
            //    pnlYemekSil.Visible = false;
            pnlYemekGuncelle.Visible = false;
            pnlYemekEkleme.Visible = false;


            //Listview Yemeklerin verileri 
            /*lstYemekler.Visible = false;
            lstYemekler.View = View.Details;
            lstYemekler.GridLines = true;
            lstYemekler.FullRowSelect = true;
            lstYemekler.Columns.Add("Numara", 200);
            lstYemekler.Columns.Add("Yemek Adi", 200);
            lstYemekler.Columns.Add("Kalori", 70);
            lstYemekler.Columns.Add("Kategori", 200);
            lstYemekler.Columns.Add("Tarih", 300);*/
            EnSonYemekleriListele();
            YemekIstatislikleriGetir();
            pnlYeEkKategori.Visible = false;
            
            pnlYemeklerAnaMenu.Visible = true;
         //   pnlYemekSil.Visible = false;
            pnlYemekGuncelle.Visible = false;
        pnlYemekEkleme.Visible = false;
        }

        private void btnYemekEkle_Click(object sender, EventArgs e)
        {
            blbYeEkYemekHata.Text = "";
            MalzemeGetir();
           
            pnlYemeklerAnaMenu.Visible = false;
          //  pnlYemekSil.Visible = false;
            pnlYemekGuncelle.Visible = false;
            pnlYemekEkleme.Visible = true;
            pnlYemekSil.Visible = false;
            KategoriGetir();
            TarifEkleKategoriGetir();
        }

        private void btnYemekSil_Click(object sender, EventArgs e)
        {
            MalzemeGetir();
      
            pnlYemekSil.Visible = false;
            pnlYemeklerAnaMenu.Visible = false;
         //   pnlYemekSil.Visible = true;
            pnlYemekGuncelle.Visible = true;
           pnlYemekEkleme.Visible = false;
           KategoriGetir();
        }
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void btnListviewSil_Click(object sender, EventArgs e)
        {

            if (lstYemekler.SelectedItems.Count != 0)
            {

                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show(lstYemekler.SelectedItems[0].SubItems[1].Text+"  "+"Silinmesini istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    int sonuc = yemek1.YemekSil(Convert.ToInt32(lstYemekler.SelectedItems[0].Text));
                    if (sonuc == 1)
                    {
                        EnSonYemekleriListele();
                        MessageBox.Show("Basarili bir şekilde silindi.");
                        txtYemekSilArama.Text = "";
                     
                    }
                    else
                    {
                        MessageBox.Show("Hata Oluştu.");
                    }

                }
            }


            else
            {
                lbEnSonYemekHata.Text = "Lütfen Yemek seçimi yapınız.";

            }
        }

        private void lnkYeEkKategori_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            pnlYeEkKategori.Visible = true;
            lblKategoriHata.Text = "";
        }

        void KategoriEkle()
        {
          
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
          int sonuc=  YemekIslemleri.KategoriEkle(txtYeEkKategori.Text, DateTime.Now.ToShortDateString());
          if (sonuc==1)
          {
              lblKategoriHata.Text = "Islem Basarili şekilde kaydedildi.";
            

          }
          else
          {
              lblKategoriHata.Text = "Işlem sırasında hatayla karşılaşıldı. Lütfen tekrar deneyiniz.";
              

          }


        }
        private void btnYeEkKategoriEkle_Click(object sender, EventArgs e)
        {
            if (txtYeEkKategori.Text=="")
            {
                lblKategoriHata.Text = "Kategori adı giriniz.";
                return;
            }

            KategoriEkle();
            KategoriGetir();
            pnlYeEkKategori.Visible = false;
            txtYeEkKategori.Clear();
        }

     

        private void grpYemekEkleme_Enter(object sender, EventArgs e)
        {
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlYeEkKategori.Visible = false;
            txtYeEkKaloeri.Text = "";
            txtYeEkYemekAdi.Text = "";
        }

        void YemekEkle()
        {
         
            IsKatmani.YemekIslemleri yemek = new IsKatmani.YemekIslemleri();
            Entity.eYemekler y = new eYemekler();

            try
            {
                y.YemekKalori = Convert.ToInt32(txtYeEkKaloeri.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen sayısal bir değer giriniz.");
                return;
            }
         
            y.YemekAdi = txtYeEkYemekAdi.Text;
            y.Tarih = DateTime.Now;
            if (comYeEkKategori.SelectedText=="")
            {
                Entity.eKategoriler kat = new eKategoriler();
                kat.KategoriID = Convert.ToInt32(comYeEkKategori.SelectedValue.ToString());
                kat.KategoriAdi = comYeEkKategori.Text;
                y.KategoriID = kat;

            }
            else
            {
                lblKategoriHata.Text = "lUTFEN KATEGORİ SEÇİNİZ.";
                return;
            }
            int sonuc= yemek.YemekEkle(y);

            if (sonuc==1)
            {
                blbYeEkYemekHata.Text = "Islem başarılı şekilde kaydedildi.";
            }
            else
            {
                blbYeEkYemekHata.Text = "hata oluştu.Lütfen sonra tekrar deneyiniz. ";
            }


        }

        private void btnYeEkEkleme_Click(object sender, EventArgs e)
        {
            
            YemekEkle();
            
         
            lstYemekler.Items.Clear();
            EnSonYemekleriListele();
            txtYeEkKaloeri.Text = "";
            txtYeEkYemekAdi.Text = "";
        }

        private void lnkTarifEkleMalzeme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlTarifEkleMalzeme.Visible = true;
            btnTarfEkleme.Visible = false;
        }

        void MalzemeGetir()
        {

            comTarifEkleMalzeme.DataSource = null;
            comTarifEkleMalzeme.Items.Clear();
            IsKatmani.YemekIslemleri isl = new IsKatmani.YemekIslemleri();
            DataTable rd = isl.MalzemeGetir();
            comTarifEkleMalzeme.DataSource = rd;
            comTarifEkleMalzeme.DisplayMember = "malzeme_adi";
            comTarifEkleMalzeme.ValueMember = "malzeme_id";

           
        }
        IsKatmani.YemekIslemleri yemek1 = new IsKatmani.YemekIslemleri();

        string sonucTarifler = "";
        void MalzemeEkle()
        {
           
            Entity.eMalzemeler malzeme = new eMalzemeler();
            malzeme.MalzemeAdi = txtTarifEkleMalzemeAdi.Text;
            malzeme.Tarih = DateTime.Now;
         int sonuc= yemek1.MalzemeEkle(malzeme);
         if (sonuc==1)
         {

             sonucTarifler = "İşlem başarılı";
         }
         else
         {
             sonucTarifler = "Aynı malzemeden bulunmaktadır.";
         
         }

        }
        private void btnTarifEkleMalzemeEkle_Click(object sender, EventArgs e)
        {
            lblTarifEkleHata.Text = "";
            btnTarfEkleme.Visible = true;
            pnlTarifEkleMalzeme.Visible = false;
            
            MalzemeEkle();
            lblTarifEkleHata.Text = sonucTarifler;
            txtTarifEkleMalzemeAdi.Text = "";
            MalzemeGetir();
            btnTarfEkleme.Enabled = true;
            lblTarfifEkleHata.Text = "";
        }


        private void btnTarifIptal_Click(object sender, EventArgs e)
        {
            lblTarifEkleHata.Text = "";
            txtTarEkleGramaj.Clear();
            txtTarifEkleMaliyet.Clear();
            txtTarifEkleMalzemeAdi.Clear();
            pnlTarifEkleMalzeme.Visible = false;
            btnTarfEkleme.Visible = true;
        }

        private void btnTarfEkleme_Click(object sender, EventArgs e)
        {
           
           
            if (txtTarEkleGramaj.Text!="" && txtTarifEkleMaliyet.Text!="")
            {



                IsKatmani.YemekIslemleri islem = new IsKatmani.YemekIslemleri();
                if (EkleGuncelle == true)
                {
                    eTarifler tarif1 = new eTarifler();

                    tarif1.Maliyet = Convert.ToDecimal(txtTarifEkleMaliyet.Text);
                    tarif1.Gramaj = Convert.ToDecimal(txtTarEkleGramaj.Text);
                    eMalzemeler malzeme = new eMalzemeler();
                    eYemekler yemek = new eYemekler();
                    yemek.YemekID = Convert.ToInt32(comTarEkleYemekler.SelectedValue.ToString());
                    malzeme.MalzemeID = Convert.ToInt32(comTarifEkleMalzeme.SelectedValue.ToString());
                    tarif1.TarifID = TarifId;
                    tarif1.MalzemeID = malzeme;
                    tarif1.YemekId = yemek;
                    int sonuc = islem.TarifGuncelle(tarif1);
                    if (sonuc == 1)
                    {
                        lblTarfifEkleHata.Text = "Islem basarili bir şekilde guncellendi.";
                    }
                    else
                    {
                        lblTarfifEkleHata.Text = "Hata oluştu.";
                    }
                    listViewTarifGetir();
                    EkleGuncelle = false;
                    return;
                }

                
                eTarifler tarif = new eTarifler();
                try
                {
                tarif.Maliyet =Convert.ToDecimal(txtTarifEkleMaliyet.Text);
                tarif.Gramaj = Convert.ToDecimal(txtTarEkleGramaj.Text);
                }
                catch (Exception)
                {
                    
                    MessageBox.Show("Lütfen sayısal değer giriniz.");
                    return;
                }
         
                eMalzemeler malzeme1 = new eMalzemeler();
                eYemekler yemek1 = new eYemekler();
                yemek1.YemekID = Convert.ToInt32(comTarEkleYemekler.SelectedValue.ToString());
                malzeme1.MalzemeID = Convert.ToInt32(comTarifEkleMalzeme.SelectedValue.ToString());
                tarif.MalzemeID = malzeme1;
                tarif.YemekId = yemek1;
           int sonuc1= islem.TarifEkle(tarif);
           if (sonuc1==1)
           {
               lblTarfifEkleHata.Text = "Islem basarili bir şekilde kaydedildi.";
           }
           else
           {
               lblTarfifEkleHata.Text = "Hata oluştu.";
           }
            }

            listViewTarifGetir();
        }

        int tarif = 0;
        private void comTarEkleYemekler_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (Convert.ToInt32(comTarEkleYemekler.SelectedItem.ToString())<0)
          //  {
          //      MessageBox.Show("Lütfen yemek seçiniz.");
         //       return;
         //   }

            if (tarif==0 )

            {
                tarif++;
                return;
            }

            listViewTarifGetir();

        }


        void listViewTarifGetir()
        {

            try
            {
                lstTarifEkle.Items.Clear();
                IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
                eYemekler yemek = new eYemekler();
               
                yemek.YemekID = Convert.ToInt32(comTarEkleYemekler.SelectedValue.ToString());
                SqlDataReader rd = YemekIslemleri.YemeklereGoreTarifGetir(yemek);
                if (rd.HasRows)
                {
                    lstYemekler.Visible = true;
                    while (rd.Read())
                    {
                        string tarifid = rd[0].ToString();
                        string gramaj = rd["gramaj"].ToString();
                        string maliyet = rd["maliyet"].ToString();
                        //  string tariftarih = rd[5].ToString();
                     //   string yemekkategori = rd["kategori_adi"].ToString();
                       
                        string malzemeAdi = rd["malzeme_adi"].ToString();
                        string[] yemekSatir = { tarifid, malzemeAdi, gramaj,rd["Tip"].ToString() ,maliyet };
                        var satir = new ListViewItem(yemekSatir);
                        lstTarifEkle.Items.Add(satir);

                    }
                }
            }
            catch (Exception ex)
            {
                string s = "";
                s = ex.ToString();
            }
     

        }


        void TarifSil()
        {
            eTarifler t = new eTarifler();
            t.TarifID = Convert.ToInt32(lstTarifEkle.SelectedItems[0].Text);
          int sonuc= yemek1.TarifSil(t);
          if (sonuc==1)
          {
              
          }
          else
          {
              MessageBox.Show("Hata Oluştu.");
          }

        }
        private void btnTarifSil_Click(object sender, EventArgs e)
        {
            
            if (lstTarifEkle.SelectedItems.Count != 0)
            {
                txtTarEkleGramaj.Text = "";
                txtTarifEkleMaliyet.Text = "";

                ListViewItem Secilenarif = lstTarifEkle.SelectedItems[0];
               
                DialogResult dialog = new DialogResult();
                lblTarifEkleHata.Text = "";
                dialog = MessageBox.Show(lstTarifEkle.SelectedItems[0].SubItems[1].Text + "adlı yemeğin " + " " + lstTarifEkle.SelectedItems[0].SubItems[2].Text + " malzemesini"+ "silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    TarifSil();
                    listViewTarifGetir();
                }
            

            }
            else
            {
              

            }
        }

        void TarifVeriCek()
        {
            ListViewItem ite = lstTarifEkle.SelectedItems[0];
            TarifId = Convert.ToInt32(ite.Text);
            SqlDataReader rd = yemek1.TarifGetir(TarifId);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    comTarEkleYemekler.Text = rd[7].ToString();
                    txtTarEkleGramaj.Text=rd[3].ToString();

                    txtTarifEkleMaliyet.Text = rd[4].ToString();
                    comTarifEkleMalzeme.Text = rd[12].ToString();
                }

            }
        }

        bool EkleGuncelle = false;
        int TarifId = 0;
        private void btnTarifGuncelle_Click(object sender, EventArgs e)
        {
            lblTarifEkleHata.Text = "";
            EkleGuncelle = true;
            if (lstTarifEkle.SelectedItems.Count != 0)
            {

                TarifVeriCek();
             


            }
        }

        private void pnlYemekGuncelle_Paint(object sender, PaintEventArgs e)
        {

        }

    
        private void txtYemekSilArama_TextChanged_1(object sender, EventArgs e)
        {
            lstYemekSil.Visible = true;
            lstYemekSil.Items.Clear();
            SqlDataReader rd = yemek1.YemekleriAra(txtYemekSilArama.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    string yemekid = rd[0].ToString();
                    string kalori = rd[2].ToString();
                    string kategoriAdi = rd[3].ToString();
                    string yemekAdi = rd[1].ToString();
                
                    string[] yemekSatir = { yemekid, yemekAdi, kategoriAdi, kalori };
                    var satir = new ListViewItem(yemekSatir);
                    lstYemekSil.Items.Add(satir);

                }

            }




        }

   

        private void lstYemekSil_DoubleClick(object sender, EventArgs e)
        {
    
        }

        int yemekid = 0;
        private void btnYemekGuncelleSil_Click(object sender, EventArgs e)
        {
            if (lstYemekSil.SelectedItems.Count != 0)
            {

                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show(lstYemekSil.SelectedItems[0].SubItems[1].Text+" "+"Silinmesini istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    int sonuc = yemek1.YemekSil(Convert.ToInt32(lstYemekSil.SelectedItems[0].Text));
                    if (sonuc == 1)
                    {
                        MessageBox.Show("Basarili bir şekilde silindi.");
                        txtYemekSilArama.Text = "";
                  
                    }
                    else
                    {
                        MessageBox.Show("Hata Oluştu.");
                    }

                }
                }

         
            else
            {
                lbEnSonYemekHata.Text = "Lütfen Yemek seçimi yapınız.";

            }

        }

        
  

        private void comTarifEkleKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comTarifEkleKategori.SelectedIndex>=0)
            {
                try
                {
                 
                    int ketogoriID = Convert.ToInt32(comTarifEkleKategori.SelectedValue.ToString());
                    IsKatmani.YemekIslemleri YI = new IsKatmani.YemekIslemleri();
                    DataTable dt = YI.KategoriyeGoreYemekGetir(ketogoriID);
                    comTarEkleYemekler.DataSource = dt;
                    comTarEkleYemekler.ValueMember = "yemek_id";
                    comTarEkleYemekler.DisplayMember = "yemek_adi";
                   
                }
                catch (Exception ex)
                {

                    string hata = "";
                    hata = ex.ToString();
                }
 
            }


        }

        private void lblTarifEkleMalzeme_Click(object sender, EventArgs e)
        {

        }

     
   

        private void comTarifEkleMalzeme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string x = "";
                try
                {

                    DataTable rd = yemek1.KategoriGetirArama(comTarifEkleMalzeme.Text);
                    comTarifEkleMalzeme.DataSource = null;
                    comTarifEkleMalzeme.DataSource = rd;

                    comTarifEkleMalzeme.ValueMember = "malzeme_id";
                    comTarifEkleMalzeme.DisplayMember = "malzeme_adi";
                }
                catch (Exception ex)
                {

                    x = ex.ToString();
                }
            }
        }

        private void comTarEkleYemekler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string x = "";
                try
                {

                    DataTable rd = yemek1.YemekGetirArama(comTarEkleYemekler.Text);
                    comTarEkleYemekler.DataSource = null;
                    comTarEkleYemekler.DataSource = rd;

                    comTarEkleYemekler.ValueMember = "yemek_id";
                    comTarEkleYemekler.DisplayMember = "yemek_adi";
                }
                catch (Exception ex)
                {

                    x = ex.ToString();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lstYemekSil.Visible = false;
         

            lstYemekGuncelle.Visible = false;
            lstYemekGuncelle.View = View.Details;
            lstYemekGuncelle.GridLines = true;
            lstYemekGuncelle.FullRowSelect = true;
            lstYemekGuncelle.Columns.Add("Numara", 200);
            lstYemekGuncelle.Columns.Add("Yemek Adi", 300);
            lstYemekGuncelle.Columns.Add("Kalori", 70);
            lstYemekGuncelle.Columns.Add("Kategori", 150);

            YemekIstatislikleriGetir1();

            //Listview Yemeklerin verileri 
            lstYemekler.Visible = false;
            lstYemekler.View = View.Details;
            lstYemekler.GridLines = true;
            lstYemekler.FullRowSelect = true;
            lstYemekler.Columns.Add("Numara", 200);
            lstYemekler.Columns.Add("Yemek Adi", 300);
            lstYemekler.Columns.Add("Kalori", 70);
            lstYemekler.Columns.Add("Kategori", 200);
            lstYemekler.Columns.Add("Tarih", 150);
            EnSonYemekleriListele();
            YemekIstatislikleriGetir();
            pnlYeEkKategori.Visible = false;
            //comYeEkKategori.Items.Add("");

            //  YemekleriGetir();
            timer1.Stop();
        }

        private void YemekIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void txtYemekGuncelleArama_TextChanged(object sender, EventArgs e)
        {
            lblYemekGunHata.Text = "";
            lstYemekGuncelle.Visible = true;
            lstYemekGuncelle.Items.Clear();
            SqlDataReader rd = yemek1.YemekleriAra(txtYemekGuncelleArama.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    string yemekid = rd[0].ToString();
                    string kalori = rd[3].ToString();
                    string kategoriAdi = rd[2].ToString();
                    string yemekAdi = rd[1].ToString();

                    string[] yemekSatir = { yemekid, yemekAdi, kategoriAdi, kalori };
                    var satir = new ListViewItem(yemekSatir);
                    lstYemekGuncelle.Items.Add(satir);

                }

            }
        }

        private void lstYemekGuncelle_DoubleClick(object sender, EventArgs e)
        {
            if (lstYemekGuncelle.SelectedItems.Count > 0)
            {
                grpMenu.Visible = true;
                IsKatmani.YemekIslemleri YemekIslemleri1 = new IsKatmani.YemekIslemleri();
                DataTable dt1 = YemekIslemleri1.KategoriGetir();
                comYemekGuncelleKategori.DataSource = dt1;
                comYemekGuncelleKategori.ValueMember = "kategori_id";
                comYemekGuncelleKategori.DisplayMember = "kategori_adi";
                yemekid = Convert.ToInt32(lstYemekGuncelle.SelectedItems[0].Text);
                SqlDataReader rd = yemek1.YemekleriGetirId(Convert.ToInt32(lstYemekGuncelle.SelectedItems[0].Text));
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        txtYemekAdi.Text = rd[1].ToString();
                        txtYemekKalori.Text = rd[2].ToString();
                        comYemekGuncelleKategori.SelectedText = "";


                        string c = rd[6].ToString();
                        comYemekGuncelleKategori.SelectedValue = rd[5].ToString();



                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtYemekGuncelleArama.Text = "";
            lblYemekGunHata.Text = "";
            grpMenu.Visible = false ;
            pnlYemekSil.Visible = true;
            pnlYemeklerAnaMenu.Visible = false;
            pnlYemekGuncelle.Visible = false;
            pnlYemekEkleme.Visible = false;
                
        }

  

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstYemekGuncelle.SelectedItems.Count > 0)
            {
                eYemekler yemek = new eYemekler();
                yemek.YemekID = yemekid;
                yemek.YemekAdi = txtYemekAdi.Text;
                yemek.YemekKalori = Convert.ToInt32(txtYemekKalori.Text);

                eKategoriler k = new eKategoriler();
                k.KategoriID = Convert.ToInt32(comYemekGuncelleKategori.SelectedValue.ToString());
                //Yapılacak..
                //          k.KategoriID = Convert.ToInt32(cmYemekGuncelleKategori.SelectedValue.ToString());
                yemek.KategoriID = k;

                int sonuc1 = yemek1.YemekGucelle1(yemek);
                if (sonuc1 == 1)
                {
                    lblYemekGunHata.Text = "Islem basarılı şekilde gercekleşti.";
                    lstYemekGuncelle.Items.Clear();
                }
                else
                {
                    lblYemekGunHata.Text = "Hata oluştu.";
                }




            }
        }

     


     
    

    }
}
