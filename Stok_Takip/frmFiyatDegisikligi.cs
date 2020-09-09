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
    public partial class frmFiyatDegisikligi : Form
    {
        public frmFiyatDegisikligi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B15H0K7;Initial Catalog=StokTakip;Integrated Security=True");

        private void txtbarkod_TextChanged(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + txtbarkod.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtsatis.Text = read["satisfiyati"].ToString();

            }
            baglanti.Close();
        }

        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from sepet", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtbarkod.Text == read["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktarı,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktarı,@alisfiyati,@satisfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@yenifiyat", double.Parse(txtyeni.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün fiyatı güncellendi.");
            }

        }
        private void frmFiyatDegisikligi_Load(object sender, EventArgs e)
        {

        }
    }
}
