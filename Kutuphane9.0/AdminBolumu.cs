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

namespace Kutuphane9._0
{
    public partial class AdminBolumu : Form
    {
        public AdminBolumu()
        {
            InitializeComponent();
        }
        int deger ;
        String tmpId = "";

        private void guncel()
        {
            dataGridView1.Visible = false;

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Kitap_Id, Kitap_Adi, yzr.Yazar_Id, Yazar_Ad, Yazar_Soyad, ktg.Katagori_Id, Katagori_Ad,  Sayfa_Sayisi, Basim_Tarihi, ynev.Yayin_Evi_Id, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel,Satilacak_Stok, Kiralanacak_Stok from Kitaplik as ktp (Nolock) Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id", baglan);
            DataTable DATA = new DataTable();
            sda.Fill(DATA);
            dataGridViewAdmKtpBolumu.DataSource = DATA;

            dataGridViewAdmKtpBolumu.Columns[0].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[2].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[5].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[9].Visible = false;

            baglan.Close();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            guncel();
            /*
            dataGridView1.Visible = false;

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            baglan.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Kitap_Id, Kitap_Adi, yzr.Yazar_Id, Yazar_Ad, Yazar_Soyad, ktg.Katagori_Id, Katagori_Ad,  Sayfa_Sayisi, Basim_Tarihi, ynev.Yayin_Evi_Id, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel,Satilacak_Stok, Kiralanacak_Stok from Kitaplik as ktp Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id", baglan);
            DataTable DATA = new DataTable();
            sda.Fill(DATA);
            dataGridViewAdmKtpBolumu.DataSource = DATA;
            
            dataGridViewAdmKtpBolumu.Columns[0].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[2].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[5].Visible = false;
            dataGridViewAdmKtpBolumu.Columns[9].Visible = false;
            
            baglan.Close();
            */
        }

        private void btnKtpEkle_Click(object sender, EventArgs e)
        {
            String query1, query2, query3, query4;

            if (txtAdmYzrAd.Text != "" && txtAdmYzrSoyad.Text != "" && txtAdmYayinEviAd.Text != "" && txtAdmYayinEviAdres.Text != "" && txtAdmYayinEviTel.Text != "" && txtAdmKatagoriAd.Text != "" && txtAdmKtpAdi.Text != "" && txtAdmSayfaSayisi.Text != "" && maskedTextBoxBasim.Text != "" && txtAdmSaticakStokSayisi.Text != "" && txtAdmKiralanacakStokSayisi.Text != "")
            {

                //try
                //{
                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    baglan.Open();

                    query1 = "insert into Yazar(Yazar_Ad, Yazar_Soyad) values ('" + txtAdmYzrAd.Text + "', '" + txtAdmYzrSoyad.Text + "')";

                    query2 = "insert into Katagori(Katagori_Ad) values ('" + txtAdmKatagoriAd.Text + "')";
                
                    query3 = "insert into Yayin_Evi(Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel) values ('" + txtAdmYayinEviAd.Text + "', '" + txtAdmYayinEviAdres.Text + "', '" + txtAdmYayinEviTel.Text + "')";

                    query4 = "insert into Kitaplik(Kitap_Adi,Yazar_Id, Katagori_Id, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Id, Satilacak_Stok, Kiralanacak_Stok) values ('" + txtAdmKtpAdi.Text + "',@@IDENTITY,@@IDENTITY ,'" + txtAdmSayfaSayisi.Text + "', '" + maskedTextBoxBasim.Text + "', @@IDENTITY, '" + txtAdmSaticakStokSayisi.Text + "', '" + txtAdmKiralanacakStokSayisi.Text + "')";

                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                    SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);

                    sda1.SelectCommand.ExecuteNonQuery();
                    sda2.SelectCommand.ExecuteNonQuery();
                    sda3.SelectCommand.ExecuteNonQuery();
                    sda4.SelectCommand.ExecuteNonQuery();

                    baglan.Close();

                    txtAdmYzrAd.Clear();
                    txtAdmYzrSoyad.Clear();
                    txtAdmYayinEviAd.Clear();
                    txtAdmYayinEviAdres.Clear();
                    txtAdmYayinEviTel.Clear();
                    txtAdmKatagoriAd.Clear();
                    txtAdmKtpAdi.Clear();
                    txtAdmSayfaSayisi.Clear();
                    maskedTextBoxBasim.Clear();
                    txtAdmSaticakStokSayisi.Clear();
                    txtAdmKiralanacakStokSayisi.Clear();

                    MessageBox.Show("Kitap Kaydedildi.");

                    guncel();
                //}catch(Exception)
                //{
                 //   MessageBox.Show("Kitap Eklenemedi");
                //}          

            }
            else
                MessageBox.Show("Kitap Bilgilerini Eksiksiz Giriniz.");
     
        }

        private void btnKtpSil_Click(object sender, EventArgs e)
        {
            string query1, query2, query3, query4;

            if (txtAdmYzrAd.Text != "" && txtAdmYzrSoyad.Text != "" && txtAdmYayinEviAd.Text != "" && txtAdmYayinEviAdres.Text != "" && txtAdmYayinEviTel.Text != "" && txtAdmKatagoriAd.Text != "" && txtAdmKtpAdi.Text != "" && txtAdmSayfaSayisi.Text != "" && maskedTextBoxBasim.Text != "" && txtAdmSaticakStokSayisi.Text != "" && txtAdmKiralanacakStokSayisi.Text != "")
            {

                try
                {
                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    baglan.Open();

                    query1 = "Delete from Kitaplik where Kitap_Id = ('" + txtAdmKitapId.Text + "')";

                    query2 = "Delete from Yazar where Yazar_Id = ('" + txtAdmYazarId.Text + "')";

                    query3 = "Delete from Katagori where Katagori_Id = ('" + txtAdmKatagoriId.Text + "')";

                    query4 = "Delete from Yayin_Evi where Yayin_Evi_Id = ('" + txtAdmYayinEviId.Text + "')";


                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                    SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);

                    sda1.SelectCommand.ExecuteNonQuery();
                    sda2.SelectCommand.ExecuteNonQuery();
                    sda3.SelectCommand.ExecuteNonQuery();
                    sda4.SelectCommand.ExecuteNonQuery();

                    baglan.Close();

                    txtAdmYzrAd.Clear();
                    txtAdmYzrSoyad.Clear();
                    txtAdmYayinEviAd.Clear();
                    txtAdmYayinEviAdres.Clear();
                    txtAdmYayinEviTel.Clear();
                    txtAdmKatagoriAd.Clear();
                    txtAdmKtpAdi.Clear();
                    txtAdmSayfaSayisi.Clear();
                    maskedTextBoxBasim.Clear();
                    txtAdmSaticakStokSayisi.Clear();
                    txtAdmKiralanacakStokSayisi.Clear();

                    MessageBox.Show("Kitap Silindi.");

                    guncel();
                }catch(Exception)
                {
                    MessageBox.Show("Kitap Silinmedi");
                }

            }
            else
                MessageBox.Show("Kitap Bilgilerini Eksiksiz Giriniz.");
        
        }

        private void dataGridViewAdmKtpBolumu_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                txtAdmKitapId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[0].Value.ToString();
                txtAdmKtpAdi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[1].Value.ToString();
                txtAdmYazarId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[2].Value.ToString();
                txtAdmKatagoriId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[3].Value.ToString();
                txtAdmSayfaSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[4].Value.ToString();
                maskedTextBoxBasim.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[5].Value.ToString();
                txtAdmYayinEviId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[6].Value.ToString();
                txtAdmSaticakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[7].Value.ToString();
                txtAdmKiralanacakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[8].Value.ToString();

                String YazarAd = "", YazarSoyad = "";
                String YayinEviAd = "", YayinEviAdres = "", YayinEviTel = "";
                String KatagoriAd = "";

                ////////////////////////////////////////////////////////////////////////////////////////////////////7
                SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan.Open();

                SqlCommand komut = new SqlCommand("Select Yazar_Ad, Yazar_Soyad From Yazar (Nolock) Where Yazar_Id = '" + txtAdmYazarId.Text + "';", baglan);

                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    var tmp1 = oku["Yazar_Ad"];

                    var tmp2 = oku["Yazar_Soyad"];
                    if (tmp1 != DBNull.Value && tmp2 != DBNull.Value)
                    {
                        YazarAd = oku["Yazar_Ad"].ToString();
                        YazarSoyad = oku["Yazar_Soyad"].ToString();

                        txtAdmYzrAd.Text = YazarAd;
                        txtAdmYzrSoyad.Text = YazarSoyad;
                    }

                }

                baglan.Close();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlConnection baglan2 = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan2.Open();

                SqlCommand komut2 = new SqlCommand("select  Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel from Yayin_Evi (Nolock) where Yayin_Evi_Id = '" + txtAdmYayinEviId.Text + "';", baglan2);

                SqlDataReader oku2 = komut2.ExecuteReader();

                while (oku2.Read())
                {
                    var tmp1 = oku2["Yayin_Evi_Ad"];

                    var tmp2 = oku2["Yayin_Evi_Adres"];

                    var tmp3 = oku2["Yayin_Evi_Tel"];

                    if (tmp1 != DBNull.Value && tmp2 != DBNull.Value && tmp3 != DBNull.Value)
                    {
                        YayinEviAd = oku2["Yayin_Evi_Ad"].ToString();
                        YayinEviAdres = oku2["Yayin_Evi_Adres"].ToString();
                        YayinEviTel = oku2["Yayin_Evi_Tel"].ToString();

                        txtAdmYayinEviAd.Text = YayinEviAd;
                        txtAdmYayinEviAdres.Text = YayinEviAdres;
                        txtAdmYayinEviTel.Text = YayinEviTel;
                    }
                }

                baglan2.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlConnection baglan3 = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan3.Open();

                SqlCommand komut3 = new SqlCommand("select Katagori_Ad from Katagori (Nolock) where Katagori_Id = '" + txtAdmKatagoriId.Text + "';", baglan3);

                SqlDataReader oku3 = komut3.ExecuteReader();

                while (oku3.Read())
                {
                    var tmp1 = oku3["Katagori_Ad"];

                    if (tmp1 != DBNull.Value)
                    {
                        KatagoriAd = oku3["Katagori_Ad"].ToString();

                        txtAdmKatagoriAd.Text = KatagoriAd;
                    }
                }

                baglan3.Close();
            }catch(Exception)
            {

            }

            

        }

        private void btnAdmKtpDznl_Click(object sender, EventArgs e)
        {
            String  query1, query2, query3, query4;

            if (txtAdmYzrAd.Text != "" && txtAdmYzrSoyad.Text != "" && txtAdmYayinEviAd.Text != "" && txtAdmYayinEviAdres.Text != "" && txtAdmYayinEviTel.Text != "" && txtAdmKatagoriAd.Text != "" && txtAdmKtpAdi.Text != "" && txtAdmSayfaSayisi.Text != "" && maskedTextBoxBasim.Text != "" && txtAdmSaticakStokSayisi.Text != "" && txtAdmKiralanacakStokSayisi.Text != "")
            {
                //try
                //{
                    int sayfa = Convert.ToInt32(txtAdmSayfaSayisi.Text);

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    baglan.Open();

                    query1 = "Update Kitaplik Set Kitap_Adi = '" + txtAdmKtpAdi.Text + "', Sayfa_Sayisi = '" + txtAdmSayfaSayisi.Text + "', Basim_Tarihi = '" + maskedTextBoxBasim.Text + "',  Satilacak_Stok = '" + txtAdmSaticakStokSayisi.Text + "', Kiralanacak_Stok =  '" + txtAdmKiralanacakStokSayisi.Text + "' Where Kitap_Id = '" + txtAdmKitapId.Text + "'";

                    query2 = "Update Yazar Set Yazar_Ad = '" + txtAdmYzrAd.Text + "', Yazar_Soyad = '" + txtAdmYzrSoyad.Text + "' where Yazar_Id = '" + txtAdmYazarId.Text + "'";

                    query3 = "Update Yayin_Evi Set Yayin_Evi_Ad = '" + txtAdmYayinEviAd.Text + "' ,Yayin_Evi_Adres = '" + txtAdmYayinEviAdres.Text + "', Yayin_Evi_Tel = '" + txtAdmYayinEviTel.Text + "' where Yayin_Evi_Id = '" + txtAdmYayinEviId.Text + "'";

                    query4 = "Update Katagori Set Katagori_Ad = '" + txtAdmKatagoriAd.Text + "' Where Katagori_Id = '" + txtAdmKatagoriId.Text + "'";

                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                    SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);

                    sda1.SelectCommand.ExecuteNonQuery();
                    sda2.SelectCommand.ExecuteNonQuery();
                    sda3.SelectCommand.ExecuteNonQuery();
                    sda4.SelectCommand.ExecuteNonQuery();

                    baglan.Close();

                    txtAdmYzrAd.Clear();
                    txtAdmYzrSoyad.Clear();
                    txtAdmYayinEviAd.Clear();
                    txtAdmYayinEviAdres.Clear();
                    txtAdmYayinEviTel.Clear();
                    txtAdmKatagoriAd.Clear();
                    txtAdmKtpAdi.Clear();
                    txtAdmSayfaSayisi.Clear();
                    maskedTextBoxBasim.Clear();
                    txtAdmSaticakStokSayisi.Clear();
                    txtAdmKiralanacakStokSayisi.Clear();

                    MessageBox.Show("Değişiklikler Kaydedildi.");

                    guncel();
                //}catch(Exception)
                //{
                    //MessageBox.Show("Kitap Düzenlenmedi");
                //}

               

            }
            else
                MessageBox.Show("Kitap Bilgilerini Eksiksiz Giriniz.");
       
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult x;

            x = MessageBox.Show("Çıkış Yapmak İstedğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else if (x == DialogResult.No)
            {

            }
        }

        private void btnTcAra_Click(object sender, EventArgs e)
        {

            txtAdmKtpAdi.Clear();
            txtAdmYzrAd.Clear();
            txtAdmYzrSoyad.Clear();
            txtAdmSayfaSayisi.Clear();
            maskedTextBoxBasim.Clear();
            txtAdmYayinEviAd.Clear();
            txtAdmYayinEviAdres.Clear();
            txtAdmYayinEviTel.Clear();
            txtAdmKatagoriAd.Clear();
            txtAdmSaticakStokSayisi.Clear();
            txtAdmKiralanacakStokSayisi.Clear();


            dataGridView1.Visible = true;

            String query1;

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            DataTable table = new DataTable();
            baglan.Open();


            SqlCommand komut1 = new SqlCommand("select Kullanici_Id from Uye_Bilgileri (Nolock) Where Uye_Tc = '" + txtKullaniciTc.Text + "';", baglan);

            SqlDataReader oku1 = komut1.ExecuteReader();


            while (oku1.Read())
            {
                var tmp1 = oku1["Kullanici_Id"];

                if (tmp1 != DBNull.Value)
                {
                    tmpId = oku1["Kullanici_Id"].ToString();

                    txtKullaniciId.Text = tmpId;
                }
            }

            oku1.Dispose();

            query1 = "select distinct Kiralananlar_Id,Uye_Tc,Kitap_Adi, Yazar_Ad, Yazar_Soyad, Katagori_Ad, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel, ktp.Kitap_Id, (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) as [Kiralanmış Adet] ,(SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) As [Teslim Tarihi] from Uye_Bilgileri,Kitaplik as ktp (Nolock) Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Inner Join Satin_Alinanlar as satin (Nolock) on  ktp.Kitap_Id = satin.Kitap_Id Inner Join Kiralananlar as kira (Nolock) on  ktp.Kitap_Id = kira.Kitap_Id where Uye_Tc = ('" + txtKullaniciTc.Text + "') and kira.Kullanici_Id = ('" + txtKullaniciId.Text + "') and (SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) Is Not Null";

            SqlDataAdapter SDA = new SqlDataAdapter(query1, baglan);

            SDA.Fill(table);
            dataGridView1.DataSource = table;


            dataGridView1.Columns[0].HeaderText = "Kiralanan Id";
            dataGridView1.Columns[1].HeaderText = "Üye Tc";
            dataGridView1.Columns[2].HeaderText = "Kitap Adı";
            dataGridView1.Columns[3].HeaderText = "Yazar Adı";
            dataGridView1.Columns[4].HeaderText = "Yazar Soyadı";
            dataGridView1.Columns[5].HeaderText = "Katagori Ad";
            dataGridView1.Columns[6].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[7].HeaderText = "Basım Tarihi";
            dataGridView1.Columns[8].HeaderText = "Yayın Evi Ad";
            dataGridView1.Columns[9].HeaderText = "Yayın Evi Adres";
            dataGridView1.Columns[10].HeaderText = "Yayın Evi Telefon";
            dataGridView1.Columns[11].HeaderText = "Kitap Id";
            dataGridView1.Columns[12].HeaderText = "Kiralanmış Adet";
            dataGridView1.Columns[13].HeaderText = "Teslim Tarihi";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            baglan.Close();
        }

        private void teslimEtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
                if (MessageBox.Show("Son Kararınız Mı ?", "Teslim Et", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //if (KiralananlarId.Text != "")
                    //{
                        KiralananlarId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                        /*
                        txtAdmKtpAdi.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        txtAdmYzrAd.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        txtAdmYzrSoyad.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        txtAdmKatagoriAd.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        txtAdmSayfaSayisi.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        maskedTextBoxBasim.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                        txtAdmYayinEviAd.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                        txtAdmYayinEviAdres.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                        txtAdmYayinEviTel.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                        //txtAdmSaticakStokSayisi.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                        //txtAdmKiralanacakStokSayisi.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                        //
                        */


                        String query;

                        SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                        baglan.Open();

                        query = "delete from Kiralananlar where Kiralananlar_Id = ('" + KiralananlarId.Text + "')";

                        SqlDataAdapter sda1 = new SqlDataAdapter(query, baglan);

                        sda1.SelectCommand.ExecuteNonQuery();

                        baglan.Close();

                        MessageBox.Show("Kitap Teslim Edildi.");

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    //}
                    //else
                      //  MessageBox.Show("Kitap Seçiniz.");
 
                }
            
          
        }

        private void btnKitapAra_Click(object sender, EventArgs e)
        {

            txtAdmKtpAdi.Clear();
            txtAdmYzrAd.Clear();
            txtAdmYzrSoyad.Clear();
            txtAdmSayfaSayisi.Clear();
            maskedTextBoxBasim.Clear();
            txtAdmYayinEviAd.Clear();
            txtAdmYayinEviAdres.Clear();
            txtAdmYayinEviTel.Clear();
            txtAdmKatagoriAd.Clear();
            txtAdmSaticakStokSayisi.Clear();
            txtAdmKiralanacakStokSayisi.Clear();

            String query;

            //txtKitapAdiIdArama.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            DataTable table = new DataTable();
            baglan.Open();

            /*
            SqlCommand komut1 = new SqlCommand("select Kitap_Adi from Kitaplik Where Kitap_Id = '" + txtKitapAdiIdArama.Text + "';", baglan);

            SqlDataReader oku1 = komut1.ExecuteReader();


            while (oku1.Read())
            {
                var tmp1 = oku1["Kitap_Adi"];

                if (tmp1 != DBNull.Value)
                {
                    tmpId = oku1["Kitap_Adi"].ToString();

                    txtKitapAdiIdArama.Text = tmpId;
                }
            }

            oku1.Dispose();
            */

            query = "Select distinct Kiralananlar_Id ,Uye_Tc,Kitap_Adi, Yazar_Ad, Yazar_Soyad, Katagori_Ad, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel, ktp.Kitap_Id, (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) as [Kiralanmış Adet] ,(SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) As [Teslim Tarihi] from Uye_Bilgileri,Kitaplik as ktp (Nolock) Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Inner Join Satin_Alinanlar as satin (Nolock) on  ktp.Kitap_Id = satin.Kitap_Id Inner Join Kiralananlar as kira (Nolock) on  ktp.Kitap_Id = kira.Kitap_Id  where Kitap_Adi = '" + txtAramaKitapAdi.Text + "' and Uye_Tc = ('" + txtKullaniciTc.Text + "') and kira.Kullanici_Id = ('" + txtKullaniciId.Text + "') and (SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + txtKullaniciId.Text + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) Is Not Null ";

            SqlDataAdapter sda1 = new SqlDataAdapter(query, baglan);

            sda1.Fill(table);
            dataGridView1.DataSource = table;

            sda1.SelectCommand.ExecuteNonQuery();

            baglan.Close();
        }

        private void AdminBolumu_Load(object sender, EventArgs e)
        {

            txtAdmKtpAdi.ContextMenu = new ContextMenu();
            txtAdmYzrAd.ContextMenu = new ContextMenu();
            txtAdmYzrSoyad.ContextMenu = new ContextMenu();
            txtAdmSayfaSayisi.ContextMenu = new ContextMenu();
            maskedTextBoxBasim.ContextMenu = new ContextMenu();
            txtAdmYayinEviAd.ContextMenu = new ContextMenu();
            txtAdmYayinEviAdres.ContextMenu = new ContextMenu();
            txtAdmYayinEviTel.ContextMenu = new ContextMenu();
            txtAdmKatagoriAd.ContextMenu = new ContextMenu();
            txtAdmSaticakStokSayisi.ContextMenu = new ContextMenu();
            txtAdmKiralanacakStokSayisi.ContextMenu = new ContextMenu();
            txtKullaniciTc.ContextMenu = new ContextMenu();
            txtAramaKitapAdi.ContextMenu = new ContextMenu();

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
        }


        private void dataGridViewAdmKtpBolumu_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            txtAdmKitapId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[0].Value.ToString();
            txtAdmKtpAdi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[1].Value.ToString();
            txtAdmYazarId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[2].Value.ToString();
            txtAdmKatagoriId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[3].Value.ToString();
            txtAdmSayfaSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[4].Value.ToString();
            maskedTextBoxBasim.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[5].Value.ToString();
            txtAdmYayinEviId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[6].Value.ToString();
            txtAdmSaticakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[7].Value.ToString();
            txtAdmKiralanacakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[8].Value.ToString();
            */
            try
            {
                txtAdmKitapId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[0].Value.ToString();
                txtAdmKtpAdi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[1].Value.ToString();
                txtAdmYazarId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[2].Value.ToString();
                txtAdmYzrAd.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[3].Value.ToString();
                txtAdmYzrSoyad.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[4].Value.ToString();
                txtAdmKatagoriId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[5].Value.ToString();
                txtAdmKatagoriAd.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[6].Value.ToString();
                txtAdmSayfaSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[7].Value.ToString();
                maskedTextBoxBasim.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[8].Value.ToString();
                txtAdmYayinEviId.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[9].Value.ToString();
                txtAdmYayinEviAd.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[10].Value.ToString();
                txtAdmYayinEviAdres.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[11].Value.ToString();
                txtAdmYayinEviTel.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[12].Value.ToString();
                txtAdmSaticakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[13].Value.ToString();
                txtAdmKiralanacakStokSayisi.Text = dataGridViewAdmKtpBolumu.SelectedRows[0].Cells[14].Value.ToString();

                String YazarAd = "", YazarSoyad = "";
                String YayinEviAd = "", YayinEviAdres = "", YayinEviTel = "";
                String KatagoriAd = "";

                ////////////////////////////////////////////////////////////////////////////////////////////////////7
                SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan.Open();

                SqlCommand komut = new SqlCommand("Select Yazar_Ad, Yazar_Soyad From Yazar (Nolock) Where Yazar_Id = '" + txtAdmYazarId.Text + "';", baglan);

                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    var tmp1 = oku["Yazar_Ad"];

                    var tmp2 = oku["Yazar_Soyad"];
                    if (tmp1 != DBNull.Value && tmp2 != DBNull.Value)
                    {
                        YazarAd = oku["Yazar_Ad"].ToString();
                        YazarSoyad = oku["Yazar_Soyad"].ToString();

                        txtAdmYzrAd.Text = YazarAd;
                        txtAdmYzrSoyad.Text = YazarSoyad;
                    }

                }

                baglan.Close();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlConnection baglan2 = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan2.Open();

                SqlCommand komut2 = new SqlCommand("select  Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel from Yayin_Evi (Nolock) where Yayin_Evi_Id = '" + txtAdmYayinEviId.Text + "';", baglan2);

                SqlDataReader oku2 = komut2.ExecuteReader();

                while (oku2.Read())
                {
                    var tmp1 = oku2["Yayin_Evi_Ad"];

                    var tmp2 = oku2["Yayin_Evi_Adres"];

                    var tmp3 = oku2["Yayin_Evi_Tel"];

                    if (tmp1 != DBNull.Value && tmp2 != DBNull.Value && tmp3 != DBNull.Value)
                    {
                        YayinEviAd = oku2["Yayin_Evi_Ad"].ToString();
                        YayinEviAdres = oku2["Yayin_Evi_Adres"].ToString();
                        YayinEviTel = oku2["Yayin_Evi_Tel"].ToString();

                        txtAdmYayinEviAd.Text = YayinEviAd;
                        txtAdmYayinEviAdres.Text = YayinEviAdres;
                        txtAdmYayinEviTel.Text = YayinEviTel;
                    }
                }

                baglan2.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlConnection baglan3 = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan3.Open();

                SqlCommand komut3 = new SqlCommand("select Katagori_Ad from Katagori (Nolock) where Katagori_Id = '" + txtAdmKatagoriId.Text + "';", baglan3);

                SqlDataReader oku3 = komut3.ExecuteReader();

                while (oku3.Read())
                {
                    var tmp1 = oku3["Katagori_Ad"];

                    if (tmp1 != DBNull.Value)
                    {
                        KatagoriAd = oku3["Katagori_Ad"].ToString();

                        txtAdmKatagoriAd.Text = KatagoriAd;
                    }
                }

                baglan3.Close();
            }catch(Exception)
            {

            }
            
        }

        private void maskedTextBoxBasim_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                maskedTextBoxBasim.Select(0, 0);
            });       
        }

        private void txtAdmSaticakStokSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAdmKiralanacakStokSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAdmYayinEviTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAdmSayfaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void maskedTextBoxBasim_MouseUp(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void txtAdmYayinEviTel_MouseUp(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void txtKullaniciTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtAdmKtpAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmYzrAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmYzrSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBoxBasim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmYayinEviAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmYayinEviAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmYayinEviTel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAdmKatagoriAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtAramaKitapAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

    }
}
