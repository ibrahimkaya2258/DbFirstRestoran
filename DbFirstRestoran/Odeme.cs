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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }

        void HesapOde(string text ,string caption,MessageBoxButtons button,MessageBoxIcon icon)
        {
            DialogResult dialog = MessageBox.Show(text, caption, button, icon);
            if (dialog==DialogResult.Yes)
            {
                Application.Restart();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HesapOde("Ödeme işlemi nakit olarak yapıldı. Tekrar sipariş vermek ister misiniz?", "Ödeme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HesapOde("Ödeme işlemi kredi kartı ile yapıldı. Tekrar sipariş vermek ister misiniz?", "Ödeme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HesapOde("Ödeme işlemi sodexo ile yapıldı. Tekrar sipariş vermek ister misiniz?", "Ödeme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
