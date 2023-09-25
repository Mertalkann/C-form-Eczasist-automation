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

namespace db
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=pharmacy;Integrated Security=True");
		
		/*################### MAÝN ###################*/
		private void btn_BaglantiyiAc_Click(object sender, EventArgs e)
		{

			if (baglanti.State.ToString()=="Closed")
			{
                baglanti.Open();
			    MessageBox.Show("veritabaný baðlantýsý Kuruldu");
			}
			else
			{
				MessageBox.Show("Baðlantý Zaten Açýk");
			}

		}
		private void btn_BaglantiyiKapat_Click(object sender, EventArgs e)
		{


			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
				MessageBox.Show("veritabaný baðlantýsý Kapatýldý");
			}
			else
			{
				MessageBox.Show("Baðlantý Zaten kapalý");
			}
			
		}
		private void btn_BaglantiyiDurum_Click(object sender, EventArgs e)
		{
			MessageBox.Show(baglanti.State.ToString());
		}

		/*################# ÝLAÇLAR ##################*/
		private void btn_datagrid_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT * FROM ilaclar";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);
			
			dataGridView1.DataSource = table;
 		}
		private void Btn_ilacekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("SET IDENTITY_INSERT ilaclar ON INSERT INTO ilaclar(barkod_no,ilac_adi,stok_miktari,son_kullanma_tarihi,fiyat) VALUES(@barkodno,@ilacadi,@stok,@sonkullanma,@fiyat) SET IDENTITY_INSERT ilaclar OFF", baglanti);
			komut.Parameters.AddWithValue("@barkodno", Convert.ToInt32(txt_barkodno.Text));
			komut.Parameters.AddWithValue("@ilacadi", txt_ilacadi.Text);
			komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txt_stok.Text));
			komut.Parameters.AddWithValue("@sonkullanma", Convert.ToDateTime(txt_sonkullanma.Text));
			komut.Parameters.AddWithValue("@fiyat", Convert.ToInt32(txt_fiyat.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Ýlaç Bilgisi Baþarýyla eklendi...");
		}
		private void btn_ilacsil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM ilaclar WHERE barkod_no =@barkodno ", baglanti);
			komut.Parameters.AddWithValue("@barkodno", Convert.ToInt32(txt_ilacsil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Ýlaç Bilgisi Baþarýyla Silindi...");
		}
		private void btn_guncelle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE ilaclar SET ilac_adi=@ilacadi , stok_miktari=@stok , son_kullanma_tarihi=@sonkullanma , fiyat=@fiyat  WHERE barkod_no =@barkodno ", baglanti);
			komut.Parameters.AddWithValue("@barkodno", Convert.ToInt32(txt_gnc_barkodno.Text));
			komut.Parameters.AddWithValue("@ilacadi", txt_gnc_ilacadi.Text);
			komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txt_gnc_stok.Text));
			komut.Parameters.AddWithValue("@sonkullanma", Convert.ToDateTime(txt_gnc_SonKullanma.Text));
			komut.Parameters.AddWithValue("@fiyat", Convert.ToInt32(txt_gnc_fiyat.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();
			
			MessageBox.Show("Ýlaç Bilgisi Baþarýyla Güncellendi...");
		}

		/*################# MÜÞTERÝLER ##################*/
		private void btn_datagrid1_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT * FROM musteriler";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);

			dataGridView2.DataSource = table;
		}
		private void btn_musteri_ekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("INSERT INTO musteriler(musteri_tc_no,musteri_adi,musteri_soyadi,telefon_no) VALUES(@musteri_tc_no,@musteri_adi,@musteri_soyadi,@telefon_no)", baglanti);
			komut.Parameters.AddWithValue("@musteri_tc_no", Convert.ToDecimal(txt_musteri_tc.Text));
			komut.Parameters.AddWithValue("@musteri_adi", txt_musteri_adi.Text);
			komut.Parameters.AddWithValue("@musteri_soyadi", txt_musteri_soyadi.Text);
			komut.Parameters.AddWithValue("@telefon_no", Convert.ToDecimal(txt_musteri_tel.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Müþteri Bilgisi Baþarýyla eklendi...");
		}		
		private void btn_musterisil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM musteriler WHERE musteri_tc_no =@musteri_tc_no ", baglanti);
			komut.Parameters.AddWithValue("@musteri_tc_no", Convert.ToDecimal(txt_musterisil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Müþteri Bilgisi Baþarýyla Silindi...");
		}
		private void btn_musteri_gnc_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE musteriler SET musteri_adi=@musteri_adi , musteri_soyadi=@musteri_soyadi , telefon_no=@telefon_no   WHERE musteri_tc_no =@musteri_tc_no ", baglanti);
			komut.Parameters.AddWithValue("@musteri_tc_no", Convert.ToDecimal(txt_gnc_musteri_tc.Text));
			komut.Parameters.AddWithValue("@musteri_adi", txt_gnc_musteri_adi.Text);
			komut.Parameters.AddWithValue("@musteri_soyadi", txt_gnc_musteri_soyadi.Text);
			komut.Parameters.AddWithValue("@telefon_no", Convert.ToDecimal(txt_gnc_musteri_tc.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Müþteri Bilgisi Baþarýyla Güncellendi...");
		}

		/*################# REÇETELER ##################*/
		private void btn_datagrid2_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT * FROM receteler";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);

			dataGridView3.DataSource = table;
		}
		private void btn_recete_ekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("INSERT INTO receteler(recete_no,doktor_tc_no,musteri_tc_no,recete_tarihi) VALUES(@recete_no,@doktor_tc_no,@musteri_tc_no,@recete_tarihi)", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_recete_no.Text));
			komut.Parameters.AddWithValue("@doktor_tc_no", Convert.ToDecimal(txt_doktor_tc.Text));
			komut.Parameters.AddWithValue("@musteri_tc_no", Convert.ToDecimal(txt_musteri_tc2.Text));
			komut.Parameters.AddWithValue("@recete_tarihi", Convert.ToDateTime(txt_recete_tarih.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete Bilgisi Baþarýyla eklendi...");
		}
		private void btn_recetesil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM receteler WHERE recete_no =@recete_no ", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_recetesil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete Bilgisi Baþarýyla Silindi...");
		}
		private void btn_recete_gnc_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE receteler SET doktor_tc_no=@doktor_tc_no , musteri_tc_no=@musteri_tc_no , recete_tarihi=@recete_tarihi   WHERE recete_no =@recete_no ", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_gnc_recete_no.Text));
			komut.Parameters.AddWithValue("@doktor_tc_no", Convert.ToDecimal(txt_gnc_doktor_tc.Text));
			komut.Parameters.AddWithValue("@musteri_tc_no", Convert.ToDecimal(txt_gnc_musteri_tc2.Text));
			komut.Parameters.AddWithValue("@recete_tarihi", Convert.ToDateTime(txt_gnc_recete_tarih.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete Bilgisi Baþarýyla Güncellendi...");
		}

		/*############## REÇETE DETAYLARI ###############*/
		private void btn_datagrid3_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT * FROM recete_detaylari";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);

			dataGridView4.DataSource = table;
		}
		private void btn_recete_dty_ekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("INSERT INTO recete_detaylari(recete_no,barkod_no,adet) VALUES(@recete_no,@barkod_no,@adet)", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_recete_no2.Text));
			komut.Parameters.AddWithValue("@barkod_no", Convert.ToInt32(txt_barkod_no2.Text));
			komut.Parameters.AddWithValue("@adet", Convert.ToInt32(txt_adet.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete detayý Bilgisi Baþarýyla eklendi...");
		}
		private void btn_gnc_recete_dty_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE recete_detaylari SET barkod_no=@barkod_no , adet=@adet  WHERE recete_no =@recete_no ", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_gnc_recete_no2.Text));
			komut.Parameters.AddWithValue("@barkod_no", Convert.ToInt32(txt_gnc_barkod_no2.Text));
			komut.Parameters.AddWithValue("@adet", Convert.ToInt32(txt_gnc_adet.Text));
		
			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete Detayý Bilgisi Baþarýyla Güncellendi...");
		}
		private void btn_recete_dty_sil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM recete_detaylari WHERE recete_no =@recete_no ", baglanti);
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_recete_dty_sil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Reçete Detayý Bilgisi Baþarýyla Silindi...");
		}

		/*################# DOKTORLAR ##################*/
		private void btn_datagrid4_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT * FROM doktorlar";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);

			dataGridView5.DataSource = table;
		}
		private void btn_doktor_ekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("INSERT INTO doktorlar(doktor_tc_no,doktor_adi,doktor_soyadi,uzmanlik_alani) VALUES(@doktor_tc_no,@doktor_adi,@doktor_soyadi,@uzmanlik_alani)", baglanti);
			komut.Parameters.AddWithValue("@doktor_tc_no", Convert.ToDecimal(txt_doktor_tc3.Text));
			komut.Parameters.AddWithValue("@doktor_adi", txt_doktor_adi.Text);
			komut.Parameters.AddWithValue("@doktor_soyadi", txt_doktor_soyadi.Text);
			komut.Parameters.AddWithValue("@uzmanlik_alani", txt_uzamanlik.Text);

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Doktor Bilgisi Baþarýyla eklendi...");
		}
		private void btn_doktor_gnc_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE doktorlar SET doktor_adi=@doktor_adi , doktor_soyadi=@doktor_soyadi ,  uzmanlik_alani=@uzmanlik_alani WHERE doktor_tc_no =@doktor_tc_no ", baglanti);
			komut.Parameters.AddWithValue("@doktor_tc_no", txt_gnc_doktor_tc3.Text);
			komut.Parameters.AddWithValue("@doktor_adi", txt_gnc_doktor_adi.Text);
			komut.Parameters.AddWithValue("@doktor_soyadi", txt_gnc_doktor_soyadi.Text);
			komut.Parameters.AddWithValue("@uzmanlik_alani", txt_gnc_doktor_uzmanlýk.Text);

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Doktor Bilgisi Baþarýyla Güncellendi...");
		}
		private void btn_doktor_sil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM doktorlar WHERE doktor_tc_no =@doktor_tc_no ", baglanti);
			komut.Parameters.AddWithValue("@doktor_tc_no", Convert.ToDecimal(txt_doktor_sil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Doktor Bilgisi Baþarýyla Silindi...");
		}

		/*################# SATIÞLAR ##################*/

		private void btn_datagrid5_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand();
			komut.CommandText = "SELECT satis_no, satislar.recete_no, satis_tarihi, SUM(adet*fiyat) AS toplam_tutar FROM satislar JOIN recete_detaylari ON satislar.recete_no = recete_detaylari.recete_no JOIN ilaclar ON recete_detaylari.barkod_no = ilaclar.barkod_no GROUP BY satis_no, satislar.recete_no, satis_tarihi; ";
			komut.Connection = baglanti;

			SqlDataAdapter adapter = new SqlDataAdapter(komut);
			DataTable table = new DataTable();

			adapter.Fill(table);

			dataGridView6.DataSource = table;
		}
		private void btn_satis_ekle_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("INSERT INTO satislar(satis_no,recete_no,satis_tarihi) VALUES(@satis_no,@recete_no,@satis_tarihi) UPDATE ilaclar SET stok_miktari = stok_miktari - (SELECT adet FROM recete_detaylari  WHERE recete_detaylari.barkod_no = ilaclar.barkod_no AND  recete_detaylari.recete_no = @recete_no) WHERE barkod_no IN (SELECT barkod_no FROM recete_detaylari WHERE recete_no = @recete_no);", baglanti);
			komut.Parameters.AddWithValue("@satis_no", Convert.ToInt32(txt_satis_no.Text));
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_recete_no3.Text));
			komut.Parameters.AddWithValue("@satis_tarihi", Convert.ToDateTime(txt_satis_tarih.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Satýþ Bilgisi Baþarýyla eklendi...");
		}
		private void btn_satis_gnc_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("UPDATE satislar SET recete_no=@recete_no , satis_tarihi=@satis_tarihi  WHERE satis_no =@satis_no  UPDATE ilaclar SET stok_miktari = stok_miktari - (SELECT adet FROM recete_detaylari  WHERE recete_detaylari.barkod_no = ilaclar.barkod_no AND  recete_detaylari.recete_no = @recete_no) WHERE barkod_no IN (SELECT barkod_no FROM recete_detaylari WHERE recete_no = @recete_no) ", baglanti);
			komut.Parameters.AddWithValue("@satis_no", Convert.ToInt32(txt_gnc_satis_no.Text));
			komut.Parameters.AddWithValue("@recete_no", Convert.ToInt32(txt_gnc_recete_no3.Text));
			komut.Parameters.AddWithValue("@satis_tarihi", Convert.ToDateTime(txt_gnc_satis_tarih.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Satýþ Bilgisi Baþarýyla Güncellendi...");
		}
		private void btn_satis_sil_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("DElETE FROM satislar WHERE satis_no =@satis_no ", baglanti);
			komut.Parameters.AddWithValue("@satis_no", Convert.ToInt32(txt_satis_sil.Text));

			if (baglanti.State.ToString() == "Open")
			{
				baglanti.Close();
			}
			baglanti.Open();
			komut.ExecuteNonQuery();
			baglanti.Close();

			MessageBox.Show("Satýþ Bilgisi Baþarýyla Silindi...");
		}

		private void lbl_ilacadi_Click(object sender, EventArgs e)
		{
		}
		private void tabPage2_Click(object sender, EventArgs e)
		{
		}
		private void tabPage24_Click(object sender, EventArgs e)
		{
		}
		private void txt_gnc_musteri_tc_TextChanged(object sender, EventArgs e)
		{
		}
		private void Form1_Load(object sender, EventArgs e)
		{
		}
		private void txt_gnc_doktor_soyadi_TextChanged(object sender, EventArgs e)
		{
		}
		private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}
	}
}