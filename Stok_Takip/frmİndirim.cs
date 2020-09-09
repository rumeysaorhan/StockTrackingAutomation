using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Takip
{
    public partial class frmİndirim : Form
    {
        public frmİndirim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B15H0K7;Initial Catalog=StokTakip;Integrated Security=True");
        bool durum;
        double a = 0;
        
        private void indirim()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from hizliindirim", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["barkodno"].ToString() && textBox2.Text == read["satisfiyati"].ToString() || textBox1.Text == "" || textBox2.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
         indirim();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into hizliindirim(barkodno,satisfiyati) values('" + textBox1.Text + "', '" + textBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İndirim Uygulandı");
            }
            else
            {
                MessageBox.Show("Bu ürün şu anda indirimli hali ile saatılıyor.", "Uyarı");
            }

            
            a = Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox2.Text) * (Convert.ToDouble(textBox3.Text) / 100);
            textBox4.Text = a.ToString();
        }
        private void frmİndirim_Load(object sender, EventArgs e)
        {
            indirim();
        }
    }
}
