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
    public partial class frmİadeFormu : Form
    {
        public frmİadeFormu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B15H0K7;Initial Catalog=StokTakip;Integrated Security=True");

        private void btnİade_Click(object sender, EventArgs e)
        {


            SqlCommand komut = new SqlCommand("insert into müşteri (tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışFiyatı.Text));
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("İade Formu\nMüşteri\nTC:" + txtTc.Text + "\nAd Soyad :" + txtAdSoyad.Text + "\nTelefon" + txtTelefon.Text + "\nEmail :" + txtEmail.Text +"\nÜrün:\nBarkod No" + txtBarkodNo.Text+"\nSatış Fiyatı:"+txtSatışFiyatı+"\nTarih"+ DateTime.Now.ToString()+"\n\nİade Sebebi:"+txtIade.Text);


        }
    }
}