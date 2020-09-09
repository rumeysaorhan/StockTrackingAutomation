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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B15H0K7;Initial Catalog=StokTakip;Integrated Security=True");
        DataSet daset = new DataSet();

        private void sepetListele()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            baglanti.Close();

        }



        private void button5_Click(object sender, EventArgs e)
        {
            frmMüşteriEkle ekle = new frmMüşteriEkle();
            ekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMüşteriListele listele = new frmMüşteriListele();
            listele.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmÜrünEkle ekle = new frmÜrünEkle();
            ekle.ShowDialog();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            frmFiyatDegisikligi degisiklik = new frmFiyatDegisikligi();
            degisiklik.ShowDialog();
        }

        private void btniadeformu_Click(object sender, EventArgs e)
        {
            frmİadeFormu iade = new frmİadeFormu();
            iade.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmİndirim indirim = new frmİndirim();
            indirim.ShowDialog();
        }

        private void btndegisim_Click(object sender, EventArgs e)
        {
            frmDeğişimFişi fis = new frmDeğişimFişi();
            fis.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmÜrünListeleme listele = new frmÜrünListeleme();
            listele.ShowDialog();
        }
        private void hesapla()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand komut = new SqlCommand("select sum(toplamfiyati) from sepet", baglanti);
                lblGenelToplam.Text = komut.ExecuteScalar() + "TL";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            sepetListele();
        }

        private void textTc_TextChanged(object sender, EventArgs e)
        {
            if (txtTc.Text == "")
            {
                txtAdSoyad.Text = "";
                txtTelefon.Text = "";
            }
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from müşteri where tc like '" + txtTc.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtTelefon.Text = read["telefon"].ToString();

            }
            baglanti.Close();
        }

        private void textBarkodNo_TextChanged(object sender, EventArgs e)
        {
            Temizle();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + txtBarkodNo.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtÜrünAdı.Text = read["urunadi"].ToString();
                txtSatışFiyatı.Text = read["satisfiyati"].ToString();

            }
            baglanti.Close();
        }

        private void Temizle()
        {
            if (txtBarkodNo.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtMiktarı)
                        {
                            item.Text = "";
                        }
                    }
                }

            }
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
                if (txtBarkodNo.Text == read["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                if (baglanti.State != ConnectionState.Closed)
                    baglanti.Close();
                else
                    baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@urunadi", txtÜrünAdı.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktarı.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışFiyatı.Text));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(txtToplamFiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                if (baglanti.State == ConnectionState.Closed)

                    baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update sepet miktari=miktari+'" + int.Parse(txtMiktarı.Text) + "'where barkodno= '" + txtBarkodNo.Text + "'", baglanti);
                komut2.ExecuteNonQuery();
                SqlCommand komut3 = new SqlCommand("update sepet toplamfiyat=miktari*satisfiyati where barkodno= '" + txtBarkodNo.Text + "'", baglanti);

                komut3.ExecuteNonQuery();
                baglanti.Close();
            }

            txtMiktarı.Text = "1";
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtMiktarı)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void textMiktarı_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktarı.Text) * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void textSatışFiyatı_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktarı.Text) * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Ürün sepetten çıkarıldı");
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }

        private void buttonSatışİptal_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Ürünler sepetten çıkarıldı");
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSatışListele listele = new frmSatışListele();
            listele.ShowDialog();
        }

        private void buttonSatışYap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update urun set miktarı=miktarı-'" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "' where barkodno ='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "' ", baglanti);
                komut2.ExecuteNonQuery();

            }


            baglanti.Close();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from sepet", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }

      
    }

}