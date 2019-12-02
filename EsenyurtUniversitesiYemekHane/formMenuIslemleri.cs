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
    public partial class formMenuIslemleri : Form
    {
        public formMenuIslemleri()
        {
            InitializeComponent();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {

        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {


        }

        private void btnMenuEkle_Click(object sender, EventArgs e)
        {
            txtMenuArama.Text = "";
            lblMenuHata.Text = "";
            lstYemekSil.Items.Clear();
            comMenuKategori.DataSource = null;
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
            DataTable dt = YemekIslemleri.KategoriGetir();

            comMenuKategori.DataSource = dt;
            comMenuKategori.ValueMember = "kategori_id";
            comMenuKategori.DisplayMember = "kategori_adi";

            grpAnaMenu.Visible = false;
            grpMenuEkle.Visible = true;

        }

        private void btnMenuSil_Click(object sender, EventArgs e)
        {
            grpAnaMenu.Visible = false;
            grpMenuEkle.Visible = false;

        }

        IsKatmani.MenuIslemleri islem = new IsKatmani.MenuIslemleri();
        DateTime dt;
        int menuId = 0;
        private void btnMenuOlustur_Click(object sender, EventArgs e)
        {



        }

        public delegate void delFLwAl(Panel panel);

        public void flwAl(Panel panel)
        {
            if (this.InvokeRequired)
            {

                this.Invoke(new delFLwAl(flwAl),panel);

            }
            else
            {
                flwMenu.Controls.Add(panel);
            }

        }
  
        void BugununMenusunuGetir()
        {
        
         int LabelSayac = 0;
                int PnSayac = 0;
         DateTime dt = DateTime.Now;
         for (int i = 0; i < 7; i++)
         {
               
            
             SqlDataReader rdYemek = islem.BugununMenusunuGetir(dt);
                if (rdYemek==null)
                {
                    return;
                }
             if (rdYemek.HasRows)
             {
                 int yp = 9;
                 Panel pnl = new Panel();
                 pnl.Name = "pnl" + PnSayac.ToString();
                 pnl.Location = new Point(9, 65);

                 pnl.BorderStyle = BorderStyle.FixedSingle;
                 pnl.Size = new System.Drawing.Size(300, 300);
                 Label lblTarih = new Label();
                 int y = 20;
                 lblTarih.Name = "lbl" + LabelSayac.ToString();
                 lblTarih.Location = new Point(20, y);
                 lblTarih.AutoSize = true;
                 lblTarih.ForeColor = Color.Red;
                 lblTarih.Font = new Font("Georgia", 14, FontStyle.Bold);
                 lblTarih.Text = dt.ToShortDateString() + "tarihli menu";
                 pnl.Controls.Add(lblTarih);

                 int c = 0;
                 int y1 = 50;
                 while (rdYemek.Read())
                 {
                      Label lblYemek = new Label();

                 lblYemek.Name = "lbl" +"_"+ rdYemek[4].ToString();
                 lblYemek.Location = new Point(10, y1);
                 lblYemek.AutoSize = true;
                 lblYemek.Font = new Font("Georgia", 10);
                 lblYemek.Click += lblYemek_Click;
                 lblYemek.Text = rdYemek[5].ToString();
                 pnl.Controls.Add(lblTarih);
                 pnl.Controls.Add(lblYemek);
                 y1 += 20;
                 }
                    flwAl(pnl);
             }
             else
             {

                 Label lblTarih = new Label();
                 int y = 500;
                 lblTarih.Name = "lbl" + LabelSayac.ToString();
                 lblTarih.AutoSize = true;
                 lblTarih.ForeColor = Color.Red;
                 lblTarih.Font = new Font("Georgia", 14, FontStyle.Bold);
                 lblTarih.Text = dt.ToShortDateString()+"tarihli menu";
         
             

                 int yp = 9;
                 Panel pnl = new Panel(); 
                 pnl.Name= "pnl"+PnSayac.ToString();
                 pnl.AutoSize = true;
                 pnl.BorderStyle = BorderStyle.FixedSingle;
                 pnl.Size = new System.Drawing.Size(200, 200);
               //  yp += 260;



                 Label lblKategori = new Label();
             
                 lblKategori.Name = "lbl" + LabelSayac.ToString();
                 lblKategori.Location = new Point(10, 30);
                 lblKategori.AutoSize = true;
                 lblKategori.Font = new Font("Georgia", 10);
                 lblKategori.Text = "Bu tarihte menu oluşturulmamıştır.";
                 y += 20;
                 pnl.Controls.Add(lblTarih);
                 pnl.Controls.Add(lblKategori);


                    flwAl(pnl);

             }
             dt= dt.AddDays(1);
             LabelSayac++;
             PnSayac++;
         
         }

        }

        public static int YemekId;

        void lblYemek_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            string[] parcala = l.Name.Split('_');
            YemekId = Convert.ToInt32(parcala[1]);
            formYemekDetay detay = new formYemekDetay();
            detay.Show();
        }


        private void formMenuIslemleri_Load(object sender, EventArgs e)
        {
            
            //Control.CheckForIllegalCrossThreadCalls = false;
            label3.Text = "";
            grpAnaMenu.Visible = true;
            grpMenuEkle.Visible = false;
            timer1.Start();

            Thread th1 = new Thread(new ThreadStart(BugununMenusunuGetir));
            th1.Start();

        }

       
        private void btnMenuYemek_Click(object sender, EventArgs e)
        {
          
       

        }

        private void txtMenuArama_TextChanged(object sender, EventArgs e)
        {
            lblMenuHata.Text = "";
            IsKatmani.YemekIslemleri yemek1 = new IsKatmani.YemekIslemleri();
            lstYemekSil.Items.Clear();
            SqlDataReader rd = yemek1.YemekleriAra(txtMenuArama.Text);
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

        private void comMenuKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMenuHata.Text = "";
            IsKatmani.YemekIslemleri yemek1 = new IsKatmani.YemekIslemleri();
            lstYemekSil.Items.Clear();
            try
            {
                SqlDataReader rd = yemek1.KategoriyeGoreYemekGetir1(Convert.ToInt32(comMenuKategori.SelectedValue.ToString()));
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        string yemekid = rd[0].ToString();
                        string kalori = rd[2].ToString();
                        string kategoriAdi = rd["kategori_adi"].ToString();
                        string yemekAdi = rd[1].ToString();

                        string[] yemekSatir = { yemekid, yemekAdi, kategoriAdi, kalori };
                        var satir = new ListViewItem(yemekSatir);
                        lstYemekSil.Items.Add(satir);

                    }

                }
            }
            catch (Exception ex)
            {
                
                
            }
          
          
        }


        void ListMenuGetir()
        {

            IsKatmani.YemekIslemleri yemek1 = new IsKatmani.YemekIslemleri();
            lstYemekSil.Items.Clear();
            try
            {
                IsKatmani.MenuIslemleri yemek = new IsKatmani.MenuIslemleri();
                lstMenuler.Items.Clear();
                SqlDataReader rd = yemek.YemekMenusuGetir(dt);
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        string yemekid = rd[0].ToString();
                        string kalori = rd[6].ToString();
                        string kategoriAdi = rd[10].ToString();
                        string yemekAdi = rd[5].ToString();

                        string[] yemekSatir = { yemekid, yemekAdi, kategoriAdi, kalori };
                        var satir = new ListViewItem(yemekSatir);
                        lstMenuler.Items.Add(satir);

                    }

                }
            }
            catch (Exception ex)
            {


            }

        }
        private void btnYemekGuncelleSil_Click(object sender, EventArgs e)
        {
            lblMenuHata.Text = "";
            if (lstMenuler.SelectedItems.Count>=0 )
            {

                DialogResult dialog = new DialogResult();
                try
                {
                    dialog = MessageBox.Show(lstMenuler.SelectedItems[0].SubItems[1].Text + " " + "adlı yemeği menüden  " + " " + "silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                
                
                }
                catch (Exception)
                {

                    return;
                }
              
                if (dialog == DialogResult.Yes)
                {
                    int sonuc = islem.MenuYemekSil(Convert.ToInt32(lstMenuler.SelectedItems[0].Text));
                    if (sonuc==1)
                    {
                        lblMenuHata.Text = "Islem basarılı bir şekilde silindi.";
                        ListMenuGetir();
                    }
                    else
                    {
                        MessageBox.Show("Hata oluştu.");
                    }
                }



            
            
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lstMenuler.View = View.Details;
            lstMenuler.GridLines = true;
            lstMenuler.FullRowSelect = true;
            lstMenuler.Columns.Add("No", 30);
            lstMenuler.Columns.Add("Yemek Adi", 200);
            lstMenuler.Columns.Add("Kategori Adi", 50);
            lstMenuler.Columns.Add("Kalori", 50);


            lstYemekSil.View = View.Details;
            lstYemekSil.GridLines = true;
            lstYemekSil.FullRowSelect = true;
            lstYemekSil.Columns.Add("No", 50);
            lstYemekSil.Columns.Add("Yemek Adi", 150);
            lstYemekSil.Columns.Add("Kategori Adi", 200);
            lstYemekSil.Columns.Add("Kalori", 200);
            dtMenuEkle.CustomFormat = "dd-M-yyyy";
            pnlMenuYemek.Visible = false;
            lblMenuAdi.Text = dtMenuEkle.Value.ToShortDateString() + " " + "tarihli menüsü";
         //   BugununMenusunuGetir();
            timer1.Stop();
        }

        private void formMenuIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAnaSayfa_Click_1(object sender, EventArgs e)
        {
            flwMenu.Controls.Clear();
            BugununMenusunuGetir();
            grpAnaMenu.Visible = true;
            grpMenuEkle.Visible = false;
        }

        private void btnMenuEkle_Click_1(object sender, EventArgs e)
        {
            txtMenuArama.Text = "";
            lblMenuHata.Text = "";
            lstYemekSil.Items.Clear();
            comMenuKategori.DataSource = null;
            IsKatmani.YemekIslemleri YemekIslemleri = new IsKatmani.YemekIslemleri();
            DataTable dt = YemekIslemleri.KategoriGetir();

            comMenuKategori.DataSource = dt;
            comMenuKategori.ValueMember = "kategori_id";
            comMenuKategori.DisplayMember = "kategori_adi";

            grpAnaMenu.Visible = false;
            grpMenuEkle.Visible = true;
        }

        private void btnGeriDon_Click_1(object sender, EventArgs e)
        {
            Form1 rm = new Form1();
            rm.Show();
            this.Hide();
        }

        private void btnMenuOlustur_Click_1(object sender, EventArgs e)
        {
            pnlMenuYemek.Visible = true;


            eMenuler menu = new eMenuler();
            dt = Convert.ToDateTime(dtMenuEkle.Value.ToShortDateString());
            menu.Tarih = dt;
            SqlDataReader rd = islem.MenuIdGetir(dt);
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    menuId = Convert.ToInt32(rd["menu_id"].ToString());
                    grpMenuEkle.Visible = true;
                }

            }
            else
            {

                eMenuler menu1 = new eMenuler();
                dt = Convert.ToDateTime(dtMenuEkle.Value.ToShortDateString());
                menu1.Tarih = dt;
                SqlDataReader rdd = islem.MenuIdGetir(dt);
                if (rdd.HasRows)
                {
                    while (rd.Read())
                    {

                        menuId = Convert.ToInt32(rdd["menu_id"].ToString());
                    }

                }

                int sonuc = islem.MenuEkle(menu);
                if (sonuc == 1)
                {
                    lblMenuAdi.Text = dtMenuEkle.Value.ToShortDateString() + " " + "tarihli menüsü";
                    pnlMenuYemek.Visible = true;
                }
                else
                {
                 //  MessageBox.Show("Hata Oluştu");
                }
            }

            ListMenuGetir();
        }

        private void btnMenuYemek_Click_1(object sender, EventArgs e)
        {
            label3.Text = dt.ToShortDateString() + " " + "Menudeki Yemekler";

            IsKatmani.MenuIslemleri menu1 = new MenuIslemleri();
            if (lstYemekSil.SelectedItems.Count > 0)
            {
                eMenuYemek my = new eMenuYemek();
                my.Tarih = dt;
                my.MenuID = new eMenuler
                {
                    MenuID = menuId

                };
                my.YemekID = new eYemekler
                {
                    YemekID = Convert.ToInt32(lstYemekSil.SelectedItems[0].Text)

                };
                int sonuc = menu1.YemekMenu(my);
                if (sonuc == 1)
                {
                    if (menuId == 0)
                    {

                        // return;
                    }

                    IsKatmani.MenuIslemleri yemek1 = new IsKatmani.MenuIslemleri();
                    lstMenuler.Items.Clear();
                    SqlDataReader rd = yemek1.YemekMenusuGetir(dt);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {

                            string yemekid = rd[0].ToString();
                            string kalori = rd[6].ToString();
                            string kategoriAdi = rd[10].ToString();
                            string yemekAdi = rd[5].ToString();

                            string[] yemekSatir = { yemekid, yemekAdi, kategoriAdi, kalori };
                            var satir = new ListViewItem(yemekSatir);
                            lstMenuler.Items.Add(satir);

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Hata Oluştu.");
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblMenuHata.Text = "";
            if (lstMenuler.SelectedItems.Count >= 0)
            {

                DialogResult dialog = new DialogResult();
                try
                {
                    dialog = MessageBox.Show(lstMenuler.SelectedItems[0].SubItems[1].Text + " " + "adlı yemeği menüden  " + " " + "silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);


                }
                catch (Exception)
                {

                    return;
                }

                if (dialog == DialogResult.Yes)
                {
                    int sonuc = islem.MenuYemekSil(Convert.ToInt32(lstMenuler.SelectedItems[0].Text));
                    if (sonuc == 1)
                    {
                        lblMenuHata.Text = "Islem basarılı bir şekilde silindi.";
                        ListMenuGetir();
                    }
                    else
                    {
                        MessageBox.Show("Hata oluştu.");
                    }
                }





            }
        }
    }
}
