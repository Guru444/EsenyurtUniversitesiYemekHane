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
using Entity;
using System.Threading;

namespace EsenyurtUniversitesiYemekHane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
          
           

        }

        private void btnYemekIslemleri_Click(object sender, EventArgs e)
        {
           


        }

 

        private void button1_Click(object sender, EventArgs e)
        {
           
          
          
        }

        private void btnMenuIslemleri_Click(object sender, EventArgs e)
        {
            formMenuIslemleri islem = new formMenuIslemleri();
            islem.Show();
            this.Hide();
        }

        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
    
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnYemekIslemleri_Click_1(object sender, EventArgs e)
        {
            YemekIslemleri yIslem = new YemekIslemleri();
            yIslem.Show();
            this.Hide();
        }

        private void btnMenuIslemleri_Click_1(object sender, EventArgs e)
        {
            formMenuIslemleri islem = new formMenuIslemleri();
            islem.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Programdan çıkılsın mı?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

              
                    Application.Exit();
                
             

            }
        }

        private void btnExceleAktar_Click_1(object sender, EventArgs e)
        {
            frmWordAktar frm = new frmWordAktar();
            frm.Show();
        }
    }
}
