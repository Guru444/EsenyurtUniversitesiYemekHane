using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using IsKatmani;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Threading;


namespace EsenyurtUniversitesiYemekHane
{
    public partial class frmWordAktar : Form
    {
        public frmWordAktar()
        {
            InitializeComponent();
        }


        IsKatmani.MenuIslemleri islem = new MenuIslemleri();
        private void btnAktar_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            sheet1.PageSetup.PrintGridlines = true;
       
            DateTime dtbas = Convert.ToDateTime(dtpBaslangic.Value);
            DateTime dtbitis = Convert.ToDateTime(dtpBitis.Value);
            int deger = 0;
            bool durum=false;
       
            Microsoft.Office.Interop.Excel.Range myRangex = (Range)sheet1.Cells[1, 4];
            myRangex.Font.Bold = 1;
            myRangex.Font.Size = 24;
            myRangex.Value2 = "İnfak Yemekçilik-IESU";
            myRangex.HorizontalAlignment = HorizontalAlignment.Center;
            sheet1.get_Range("B1:E1", Type.Missing).Merge(Type.Missing);
            excel.Cells[1, 4].ColumnWidth = 20;
           
          

            Microsoft.Office.Interop.Excel.Range myRangetarih = (Range)sheet1.Cells[3, 4];
            myRangetarih.Value2 = "Tarih" +": "+DateTime.Now.ToShortDateString();
            myRangetarih.Font.Bold = 0;
            excel.Cells[3, 4].ColumnWidth = 20;
            myRangetarih.Font.Size = 12;

            int TarihSayacSatir = 5;
            int TArihSayacSutun = 2;

            int BaslikSayacSatir = 7;
            int BaslikSayacSutun = 1;
            int VeriSatir = 8;
            int VeriSutun = 1;
            int sayac=1;
        
            TArihSayacSutun = 2;
           do{
              
                SqlDataReader rd = islem.BugununMenusunuGetir(dtbas);
                if (rd.HasRows)
                {
      
            Range myRangeKalori1 = (Range)sheet1.Cells[TarihSayacSatir, TArihSayacSutun];
            myRangeKalori1.Value2 = "Menu Tarihi";
            excel.Cells[TarihSayacSatir, TArihSayacSutun].ColumnWidth = 20;
            myRangeKalori1.Select();
            TArihSayacSutun++;

            Range myRangeKt = (Range)sheet1.Cells[TarihSayacSatir, TArihSayacSutun];
            excel.Cells[TarihSayacSatir, TArihSayacSutun].ColumnWidth = 20;
            myRangeKt.Value2 = dtbas.ToShortDateString();
            myRangeKt.Select();
            TArihSayacSutun = 2;

                        string[] baslik = { "No", "Yemek Adi", "Çeşiti", "Kalori" };
                        for (int x = 0; x < 4; x++)
                        {


                            Microsoft.Office.Interop.Excel.Range myRange = (Range)sheet1.Cells[BaslikSayacSatir, BaslikSayacSutun];
                            myRange.Value2 = baslik[x];
                            excel.Cells[BaslikSayacSatir, BaslikSayacSutun].ColumnWidth = 20;
                            myRange.Font.Size = 12;
                            myRange.Font.Bold = 1;
                            excel.Cells[BaslikSayacSatir, BaslikSayacSutun].Interior.Color = System.Drawing.Color.Yellow;


                            BaslikSayacSutun++;

                        }
                        BaslikSayacSutun = 1;

                    while (rd.Read())
                    {

                        Range myRangeid = (Range)sheet1.Cells[VeriSatir , VeriSutun];
                        myRangeid.Value2 = sayac.ToString();
                        myRangeid.Select();
                        VeriSutun++;
                        sayac++;
                     
                         Range myRange1 = (Range)sheet1.Cells[VeriSatir , VeriSutun];
                        myRange1.Value2 = rd[5].ToString();
                        myRange1.Select();
                        VeriSutun++;

                    
                        Range myRangeKategori = (Range)sheet1.Cells[VeriSatir, VeriSutun];
                        myRangeKategori.Value2 = rd["kategori_adi"].ToString();
                        myRangeKategori.Select();
                          VeriSutun++;
                 
                        Range myRangeKalori = (Range)sheet1.Cells[VeriSatir, VeriSutun];
                        myRangeKalori.Value2 = rd[6].ToString();
                        myRangeKalori.Select();
                        VeriSutun=1;
                        VeriSatir++;

                    }
                    TarihSayacSatir = VeriSatir + 2;
                    BaslikSayacSatir = VeriSatir + 4;
                    VeriSatir = BaslikSayacSatir + 1;

                }
                else
                {

                }

                dtbas = Convert.ToDateTime(dtbas.AddDays(1).ToShortDateString());
           c = DateTime.Compare(dtbas, dtbitis);
           } while (c<0);

       
        }


        int c;


        private void frmWordAktar_Load(object sender, EventArgs e)
        {
            dtpBaslangic.CustomFormat = "dd-M-yyyy";
            dtpBitis.CustomFormat = "dd-M-yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
