using DbFirstRestoran.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirstRestoran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RestoranDbEntities db = new RestoranDbEntities();

        private void button2_Click(object sender, EventArgs e)
        {


            flowLayoutPanel1.Controls.Clear();
            foreach (var item in Enum.GetValues(typeof(YemekTur)))
            {
                Button btn = new Button();
                btn.Text = item.ToString();
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);

            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            
                
            Button btn = (Button)sender;

            if (btn.Text == "Corba")
            {
                var filtre = db.CorbaTbls.ToList();
                flowLayoutPanel2.Controls.Clear();

                foreach (var item in filtre)
                {
                    Button btn1 = new Button();
                    btn1.Text = item.CorbaAdi;
                    btn1.Tag = item;
                    flowLayoutPanel2.Controls.Add(btn1);
                    btn1.Click += Btn1_Click;
                }

            }
            else if (btn.Text == "Kebab")
            {
                var filtre = db.KebabTbls.ToList();
                flowLayoutPanel2.Controls.Clear();
                foreach (var item in filtre)
                {
                    Button btn2 = new Button();
                    btn2.Text = item.KebabAdi;
                    btn2.Tag = item;
                    flowLayoutPanel2.Controls.Add(btn2);
                    btn2.Click += Btn2_Click;

                }

            }
            else
            {
                var filtre = db.SalataTbls.ToList();
                flowLayoutPanel2.Controls.Clear();
                foreach (var item in filtre)
                {
                    Button btn3 = new Button();
                    btn3.Text = item.SalataAdi;
                    btn3.Tag = item;
                   
                    flowLayoutPanel2.Controls.Add(btn3);
                    btn3.Click += Btn3_Click;
                }

            }

        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SalataTbl salata = new SalataTbl();
            salata = (SalataTbl)btn.Tag;

            string urun = salata.SalataAdi;
            string fiyat = salata.SalataFiyat.ToString();
            string kategori = salata.salataTur.ToString();

            string[] urunBilgi = { urun, kategori, fiyat };
            toplamFiyat += decimal.Parse(urunBilgi[2]);
            label1.Text = toplamFiyat.ToString("C2");

            ListViewItem listView = new ListViewItem(urunBilgi);
            listView1.Items.Add(listView);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            KebabTbl kebab = new KebabTbl();
            kebab = (KebabTbl)btn.Tag;

            string urun = kebab.KebabAdi;
            string fiyat = kebab.KebabFiyat.ToString();
            string kategori = kebab.kebabTur.ToString();

            string[] urunBilgi = { urun, kategori, fiyat };
            toplamFiyat += decimal.Parse(urunBilgi[2]);
            label1.Text = toplamFiyat.ToString("C2");

            ListViewItem listView = new ListViewItem(urunBilgi);
            listView1.Items.Add(listView);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CorbaTbl corba = new CorbaTbl();
            corba = (CorbaTbl)btn.Tag;
           

            string urun = corba.CorbaAdi;
            string fiyat = corba.CorbaFiyat.ToString();
            string kategori = corba.corbaTur.ToString();

            string[] urunBilgi = { urun, kategori, fiyat };
            toplamFiyat += decimal.Parse(urunBilgi[2]);
            label1.Text = toplamFiyat.ToString("C2");

            ListViewItem listView = new ListViewItem(urunBilgi);
            listView1.Items.Add(listView);
           


           


        }
        decimal toplamFiyat = 0;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.ShowDialog();

        }
    }
}
