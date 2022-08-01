using DbFirstRestoran.Data;
using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        void ekleme()
        {
            dataGridView1.DataSource = db.CorbaTbls.ToList();
            dataGridView2.DataSource = db.KebabTbls.ToList();
            dataGridView3.DataSource = db.SalataTbls.ToList();

            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView3.Columns[0].Visible = false;
        }
        public RestoranDbEntities db = new RestoranDbEntities();
        private void Menu_Load(object sender, EventArgs e)

        {


            foreach (var item in Enum.GetValues(typeof(YemekTur)))
            {
                cmbKategori.Items.Add(item);
            }

            ekleme();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedIndex!=-1)
            {
                if ((YemekTur)cmbKategori.SelectedItem==YemekTur.Corba)
                {
                    CorbaTbl yeni = new CorbaTbl();
                    string gelen = txtEkleme.Text;
                    decimal fiyatgelen = decimal.Parse(txtFiyat.Text);
                    YemekTur yemekTur = (YemekTur)cmbKategori.SelectedItem;
                    yeni.corbaTur = yemekTur;
                    yeni.CorbaAdi = gelen;
                    yeni.CorbaFiyat = fiyatgelen;

                    db.CorbaTbls.Add(yeni);
                    int kayitsayisi=db.SaveChanges();
                    if (kayitsayisi>0)
                    {
                        MessageBox.Show("Ekleme Yapıldı.");
                    }

                }
                else if ((YemekTur)cmbKategori.SelectedItem == YemekTur.Kebab)
                {
                    KebabTbl yeni = new KebabTbl();
                    string gelen = txtEkleme.Text;
                    decimal fiyatgelen = decimal.Parse(txtFiyat.Text);
                    YemekTur yemekTur = (YemekTur)cmbKategori.SelectedItem;
                    yeni.kebabTur = yemekTur;
                    yeni.KebabAdi = gelen;
                    yeni.KebabFiyat = fiyatgelen;
                    db.KebabTbls.Add(yeni);
                    int kayitsayisi = db.SaveChanges();
                    if (kayitsayisi > 0)
                    {
                        MessageBox.Show("Ekleme Yapıldı.");
                    }

                }
                else 
                {
                    SalataTbl yeni = new SalataTbl();
                    string gelen = txtEkleme.Text;
                    decimal fiyatgelen = decimal.Parse(txtFiyat.Text);
                    YemekTur yemekTur = (YemekTur)cmbKategori.SelectedItem;
                    yeni.salataTur = yemekTur;
                    yeni.SalataAdi = gelen;
                    yeni.SalataFiyat = fiyatgelen;
                    db.SalataTbls.Add(yeni);
                    int kayitsayisi = db.SaveChanges();
                    if (kayitsayisi > 0)
                    {
                        MessageBox.Show("Ekleme Yapıldı.");
                    }

                }
                ekleme();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();

        }
    }
}
