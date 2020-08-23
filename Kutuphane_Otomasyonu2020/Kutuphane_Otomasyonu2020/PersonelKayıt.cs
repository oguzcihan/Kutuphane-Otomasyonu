using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public partial class PersonelKayıt : Form
    {
        public PersonelKayıt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public abstract class personel
        {
            public int personelno;
            public string personelAd;
            public string personelSoyad;
            public string Dogumyili;
            public abstract void gorevi();

            
        }
        class admin:personel
        {
            public override void gorevi()
            {
                throw new NotImplementedException();
            }
            public Boolean yetki = true;
        }

        
            public void ekle()
            {
            admin ali = new admin();
            ali.personelAd = textBox1.Text;
            }
        
    }
}
