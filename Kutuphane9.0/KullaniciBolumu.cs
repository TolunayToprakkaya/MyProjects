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
    public partial class KullaniciBolumu : Form
    {
        public KullaniciBolumu()
        {
            InitializeComponent();
        }

        DataGridViewCheckBoxColumn checkSatilmis = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn checkKiralanmis = new DataGridViewCheckBoxColumn();

        private void btnGoster_Click(object sender, EventArgs e)
        {
            dataGridViewKullaniciListe.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            label13.Visible = false;
            label14.Visible = false;

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            DataTable table = new DataTable();

            SqlDataAdapter SDA = new SqlDataAdapter("select Kitap_Id, Kitap_Adi, Yazar_Ad, Yazar_Soyad,Katagori_Ad,  Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel,Satilacak_Stok, Kiralanacak_Stok from Kitaplik as ktp (Nolock) Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Where Satilacak_Stok > 0 And Kiralanacak_Stok > 0 ", baglan);
            SDA.Fill(table);
            dataGridViewKullaniciListe.DataSource = table;

            dataGridViewKullaniciListe.Columns[0].HeaderText = "Kitap Id";
            dataGridViewKullaniciListe.Columns[1].HeaderText = "Kitap Adı";
            dataGridViewKullaniciListe.Columns[2].HeaderText = "Yazar Ad";
            dataGridViewKullaniciListe.Columns[3].HeaderText = "Yazar Soyad";
            dataGridViewKullaniciListe.Columns[4].HeaderText = "Katagori Ad";
            dataGridViewKullaniciListe.Columns[5].HeaderText = "Sayfa Sayısı";
            dataGridViewKullaniciListe.Columns[6].HeaderText = "Basım Tarihi";
            dataGridViewKullaniciListe.Columns[7].HeaderText = "Yayın Evi Ad";
            dataGridViewKullaniciListe.Columns[8].HeaderText = "Yayın Evi Adres";
            dataGridViewKullaniciListe.Columns[9].HeaderText = "Yayın Evi Telefon";
            dataGridViewKullaniciListe.Columns[10].HeaderText = "Satılanların Stok Sayısı";
            dataGridViewKullaniciListe.Columns[11].HeaderText = "Kiralananların Stok Sayısı";

            dataGridViewKullaniciListe.Columns[0].Visible = false;

            dataGridViewKullaniciListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnKitaplarim_Click(object sender, EventArgs e)
        {
            dataGridViewKullaniciListe.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;

            label13.Visible = true;
            label14.Visible = true;
            //this.dataGridViewKullaniciListe.Parent.Refresh();

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            //baglan.Open();
            DataTable table1= new DataTable(); //kll.Kullanici_Id   KULLANICI ID KISMI
            DataTable table2 = new DataTable();
            //SqlDataAdapter SDA1 = new SqlDataAdapter("select distinct Kitap_Adi, Yazar_Ad, Yazar_Soyad, Katagori_Ad, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel, ktp.Kitap_Id, (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) as [Satın Alınmış Adet], (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  group by Kitap_Id ) as [Kiralanmış Adet], (SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) As [Teslim Tarihi] from Kitaplik as ktp Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Inner Join Satin_Alinanlar as satin (Nolock) on  ktp.Kitap_Id = satin.Kitap_Id Inner Join Kiralananlar as kira (Nolock) on  ktp.Kitap_Id = kira.Kitap_Id where kira.Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') or  satin.Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')", baglan);
            SqlDataAdapter SDA1 = new SqlDataAdapter(" select distinct Kitap_Adi, Yazar_Ad, Yazar_Soyad, Katagori_Ad, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel, ktp.Kitap_Id, (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  group by Kitap_Id ) as [Kiralanmış Adet] ,(SELECT CASE  WHEN (select count(Kitap_Id) from Kiralananlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  group by Kitap_Id ) IS Not NULL THEN Geri_Donus_Tarihi END ) As [Teslim Tarihi], (select DATEDIFF(day,  GETDATE() , kira.Geri_Donus_Tarihi) from Kiralananlar (Nolock) where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  group by Kitap_Id ) as [Kalan Gün Sayısı] from  Kitaplik as ktp Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Inner Join Satin_Alinanlar as satin (Nolock) on  ktp.Kitap_Id = satin.Kitap_Id Inner Join Kiralananlar as kira (Nolock) on  ktp.Kitap_Id = kira.Kitap_Id  where  kira.Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') or  satin.Kullanici_Id = ('" + SabitDegisken.KullaniciId + "')  and (Select Case When (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) Is Not Null Then (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) End ) Is  Null ", baglan);
            //SqlDataAdapter SDA1 = new SqlDataAdapter("select Case When Kiralananlar_Sayisi IS NOT NULL Then 1 Else 0 End [Boolean Status] from Kitaplik");
            SDA1.Fill(table1);
            dataGridView1.DataSource = table1;

            

            //checkSatilmis.HeaderText = "Satın Alınmış Kitap";
            //checkKiralanmis.HeaderText = "Kiralanmış Kitap";
            
            //dataGridViewKullaniciListe.Columns.Add(checkSatilmis);
            //dataGridViewKullaniciListe.Columns.Add(checkKiralanmis);

            //dataGridViewKullaniciListe.Columns[0].HeaderText = "Kullanıcı Id";
            dataGridView1.Columns[0].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].HeaderText = "Yazar Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Soyadı";
            dataGridView1.Columns[3].HeaderText = "Katagori Ad";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
            dataGridView1.Columns[6].HeaderText = "Yayın Evi Ad";
            dataGridView1.Columns[7].HeaderText = "Yayın Evi Adres";
            dataGridView1.Columns[8].HeaderText = "Yayın Evi Telefon";
            dataGridView1.Columns[9].HeaderText = "Kitap Id";
            dataGridView1.Columns[10].HeaderText = "Kiralanmış Adet";
            dataGridView1.Columns[11].HeaderText = "Teslim Tarihi Adet";
            dataGridView1.Columns[12].HeaderText = "Kalan Gün Sayısı";
            //dataGridViewKullaniciListe.Columns[7].HeaderText = "Kullanıcı Adı";

            dataGridView1.Columns[9].Visible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


             for (int i = 0; i < dataGridView1.Rows.Count  ; i++)
            {
                Application.DoEvents();
 
               DataGridViewCellStyle rowColor = new DataGridViewCellStyle();
                 /*
               if (Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value)> 28)
               {
                   rowColor.BackColor = Color.OrangeRed;
                   rowColor.ForeColor = Color.White;
               }
                 */
               if (Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value) >= 0 && Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value) < 3)
               {
                   rowColor.BackColor = Color.Red;
                   rowColor.ForeColor = Color.White;
               }
                   /*
               else if (Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value) == 0)
               {
                  rowColor.BackColor = Color.LightGreen;
                  rowColor.ForeColor = Color.White;
               }
                 */
                dataGridView1.Rows[i].DefaultCellStyle = rowColor;
            }


            SqlDataAdapter SDA2 = new SqlDataAdapter("select distinct Kitap_Adi, Yazar_Ad, Yazar_Soyad, Katagori_Ad, Sayfa_Sayisi, Basim_Tarihi, Yayin_Evi_Ad, Yayin_Evi_Adres, Yayin_Evi_Tel, ktp.Kitap_Id, (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) as [Satın Alınmış Adet] from  Kitaplik as ktp (Nolock) Inner Join Yazar as yzr (nolock) On ktp.Yazar_Id = yzr.Yazar_Id Inner Join Katagori as ktg (nolock) On ktp.Katagori_Id = ktg.Katagori_Id Inner Join Yayin_Evi as ynev (nolock) On ktp.Yayin_Evi_Id = ynev.Yayin_Evi_Id Inner Join Satin_Alinanlar as satin (Nolock) on  ktp.Kitap_Id = satin.Kitap_Id Inner Join Kiralananlar as kira (Nolock) on  ktp.Kitap_Id = kira.Kitap_Id  where   satin.Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') and (Select Case When (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) Is Not Null Then (select count(Kitap_Id) from Satin_Alinanlar where Kitap_Id = ktp.Kitap_Id and Kullanici_Id = ('" + SabitDegisken.KullaniciId + "') Group by Kitap_Id) End ) Is Not Null", baglan);
            SDA2.Fill(table2);
            dataGridView2.DataSource = table2;

            dataGridView2.Columns[0].HeaderText = "Kitap Adı";
            dataGridView2.Columns[1].HeaderText = "Yazar Adı";
            dataGridView2.Columns[2].HeaderText = "Yazar Soyadı";
            dataGridView2.Columns[3].HeaderText = "Katagori Ad";
            dataGridView2.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView2.Columns[5].HeaderText = "Basım Tarihi";
            dataGridView2.Columns[6].HeaderText = "Yayın Evi Ad";
            dataGridView2.Columns[7].HeaderText = "Yayın Evi Adres";
            dataGridView2.Columns[8].HeaderText = "Yayın Evi Telefon";
            dataGridView2.Columns[9].HeaderText = "Kitap Id";
            dataGridView2.Columns[10].HeaderText = "Satın Alınmış Adet";

            dataGridView2.Columns[9].Visible = false;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void btnKtp_Click(object sender, EventArgs e)
        {
            String query1, query2, query3, query4, query5;

            if (txtKitapId.Text != "" && txtKitapAdi.Text != "")
            {
                SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan.Open();

                query1 = "Select Kullanici_Adi From Kullanici_Id_Sifre (NOLOCK) Where Kullanici_Adi = '" + SabitDegisken.kullaniciAdi + "'";

                query2 = "Select Kitap_Id From Kitaplik (NOLOCK) Where Kitap_Id = ('" + txtKitapId.Text + "') ";
                //CONVERT(DATETIME,CONVERT(Date,GETDATE()+30))
                query3 = "Insert into Kiralananlar(Kitap_Id, Kullanici_Id, Geri_Donus_Tarihi) values ('" + txtKitapId.Text + "', '" + SabitDegisken.KullaniciId + "', CONVERT(DATETIME,CONVERT(Date,GETDATE()+30)) )";

                query4 = "Update Kiralananlar Set Geri_Donus_Tarihi = CONVERT(DATETIME,CONVERT(Date,GETDATE()+60)) From Kiralananlar inner join Uye_Bilgileri as uye on uye.Kullanici_Id = Kiralananlar.Kullanici_Id  where Uye_Turu_Id = '2' ";
                
                query5 = "Update Kitaplik Set Kiralanacak_Stok = Kiralanacak_Stok + 1 , Satilacak_Stok = Satilacak_Stok - 1 Where Kitap_Adi = ('" + txtKitapAdi.Text + "') ";

                //query5 = "Update Kiralananlar Set Geri_Donus_Tarihi = Null Where Kiralananlar_Id = @@IDENTITY";

                SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);
                SqlDataAdapter sda5 = new SqlDataAdapter(query5, baglan);
                //SqlDataAdapter sda5 = new SqlDataAdapter(query5, baglan);

                sda1.SelectCommand.ExecuteNonQuery();
                sda2.SelectCommand.ExecuteNonQuery();
                sda3.SelectCommand.ExecuteNonQuery();
                sda4.SelectCommand.ExecuteNonQuery();
                sda5.SelectCommand.ExecuteNonQuery();
                //sda5.SelectCommand.ExecuteNonQuery();

                baglan.Close();

                MessageBox.Show("Kitap Kiralandı");

                txtKitapId.Clear();
                txtKitapAdi.Clear();

            }
            else
                MessageBox.Show("Kitap Seçiniz.");
        
        }

        private void btnKtpAl_Click(object sender, EventArgs e)
        {

            //SabitDegisken.kullaniciAdi = txtKullaniciId.Text;

            String query1, query2, query3, query4, query5;

            if (txtKitapId.Text != "" && txtKitapAdi.Text != "")
            {
                SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                baglan.Open();

                query1 = "Select Kullanici_Adi From Kullanici_Id_Sifre (NOLOCK) Where Kullanici_Adi = '" + SabitDegisken.kullaniciAdi + "'";

                query2 = "Select Kitap_Id From Kitaplik (NOLOCK) Where Kitap_Id = ('" + txtKitapId.Text + "') ";

                query3 = "Insert into Satin_Alinanlar(Kitap_Id, Kullanici_Id) values ('" + txtKitapId.Text + "', '" + SabitDegisken.KullaniciId + "')";

                query4 = "Update Kitaplik Set Satilacak_Stok = Satilacak_Stok - 1  Where Kitap_Adi = ('" + txtKitapAdi.Text + "')";

                //query5 = "Update Kiralananlar Set Geri_Donus_Tarihi = Null Where Kiralananlar_Id = @@IDENTITY";

                /*
                query1 = "Select Kullanici_Adi From Kullanici_Id_Sifre (NOLOCK) Where Kullanici_Adi = '" + SabitDegisken.kullaniciAdi + "'";

                query2 = "Select Kitap_Id From Kitaplik (NOLOCK) Where Kitap_Id = ('" + txtKullaniciKitapId.Text + "') ";

                query3 = "Insert into Satin_Alinanlar(Kitap_Id, Kullanici_Id) values ('" + txtKullaniciKitapId.Text + "', '" + SabitDegisken.kullaniciAdi + "')";

                query4 = "Update Kitaplik Set Satilacak_Stok = Satilacak_Stok - 1  Where Kitap_Adi = ('" + txtKulKitapAdi.Text + "')";
                */

                SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);//isnull(cast(stok as float),0)
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);
                //SqlDataAdapter sda5 = new SqlDataAdapter(query5, baglan);

                sda1.SelectCommand.ExecuteNonQuery();
                sda2.SelectCommand.ExecuteNonQuery();
                sda3.SelectCommand.ExecuteNonQuery();
                sda4.SelectCommand.ExecuteNonQuery();
                //sda5.SelectCommand.ExecuteNonQuery();


                baglan.Close();

                MessageBox.Show("Kitap Satın Alındı.");

                txtKitapId.Clear();
                txtKitapAdi.Clear();

            }
            else
            {
                MessageBox.Show("Kitap Seçiniz.");
            }
            
        }

        private void dataGridViewKullaniciListe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //txtKullaniciId.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[2].Value.ToString();
            try
            {
                txtKitapId.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[0].Value.ToString();
                txtKitapAdi.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[1].Value.ToString();
            }catch(Exception)
            {

            }
                /*
            txtKullaniciKitapId.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[0].Value.ToString();
            txtKulKitapAdi.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[1].Value.ToString();
            txtKulKitpAdi.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[2].Value.ToString();
            txtKullaniciStokText.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[3].Value.ToString();
            */        
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

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Kitap Adı")
            {
                label4.Visible = true;
                txtKitapIsmiyleAra.Visible = true;

                label5.Visible = false;
                txtYazarAdiAra.Visible = false;
                label6.Visible = false;
                txtYazarSoyadiAra.Visible = false;

                label7.Visible = false;
                txtYayinEviAdiAra.Visible = false;

                label8.Visible = false;
                txtKatagoriAra.Visible = false;

                btnAra.Visible = true;

            }
            else if (comboBox1.SelectedItem == "Yazar Adı Soyadı")
            {
                label4.Visible = false;
                txtKitapIsmiyleAra.Visible = false;

                label5.Visible = true;
                txtYazarAdiAra.Visible = true;
                label6.Visible = true;
                txtYazarSoyadiAra.Visible = true;

                label7.Visible = false;
                txtYayinEviAdiAra.Visible = false;

                label8.Visible = false;
                txtKatagoriAra.Visible = false;

                btnAra.Visible = true;
            }
            else if (comboBox1.SelectedItem == "Yayın Evi Adı")
            {
                label4.Visible = false;
                txtKitapIsmiyleAra.Visible = false;

                label5.Visible = false;
                txtYazarAdiAra.Visible = false;
                label6.Visible = false;
                txtYazarSoyadiAra.Visible = false;

                label7.Visible = true;
                txtYayinEviAdiAra.Visible = true;

                label8.Visible = false;
                txtKatagoriAra.Visible = false;

                btnAra.Visible = true;
            }
            else if (comboBox1.SelectedItem == "Katagori")
            {
                label4.Visible = false;
                txtKitapIsmiyleAra.Visible = false;

                label5.Visible = false;
                txtYazarAdiAra.Visible = false;
                label6.Visible = false;
                txtYazarSoyadiAra.Visible = false;

                label7.Visible = false;
                txtYayinEviAdiAra.Visible = false;

                label8.Visible = true;
                txtKatagoriAra.Visible = true;

                btnAra.Visible = true;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            if (txtKitapIsmiyleAra.Text != "" || txtYazarAdiAra.Text != "" || txtYazarSoyadiAra.Text != "" || txtYayinEviAdiAra.Text != "" || txtKatagoriAra.Text != "")
            {

                if (comboBox1.SelectedItem == "Kitap Adı")
                {
                    label4.Visible = true;
                    txtKitapIsmiyleAra.Visible = true;

                    label5.Visible = false;
                    txtYazarAdiAra.Visible = false;
                    label6.Visible = false;
                    txtYazarSoyadiAra.Visible = false;

                    label7.Visible = false;
                    txtYayinEviAdiAra.Visible = false;

                    label8.Visible = false;
                    txtKatagoriAra.Visible = false;

                    btnAra.Visible = true;

                    String query1;

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    DataTable table = new DataTable();
                    baglan.Open();

                    query1 = "select Kitap_Adi,Yazar_Ad, Yazar_Soyad, Katagori_Ad,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel,Satilacak_Stok,Kiralanacak_Stok  from Kitaplik (Nolock) inner join Yazar on Kitaplik.Yazar_Id = Yazar.Yazar_Id inner join Katagori on Kitaplik.Katagori_Id = Katagori.Katagori_Id inner join Yayin_Evi on Kitaplik.Yayin_Evi_Id = Yayin_Evi.Yayin_Evi_Id Where Kitap_Adi = ('" + txtKitapIsmiyleAra.Text + "') And Satilacak_Stok > 0";

                    //query1 = "Select * From Kitaplik Where Kitap_Adi = ('" + txtKitapIsmiyleAra.Text + "') And Satilacak_Stok >0 ";
                    SqlDataAdapter SDA = new SqlDataAdapter(query1, baglan);

                    SDA.Fill(table);
                    dataGridViewKullaniciListe.DataSource = table;

                    dataGridViewKullaniciListe.Columns[0].HeaderText = "Kitap Adı";
                    dataGridViewKullaniciListe.Columns[1].HeaderText = "Yazar Ad";
                    dataGridViewKullaniciListe.Columns[2].HeaderText = "Yazar Soyad";
                    dataGridViewKullaniciListe.Columns[3].HeaderText = "Katagori Ad";
                    dataGridViewKullaniciListe.Columns[4].HeaderText = "Sayfa Sayısı";
                    dataGridViewKullaniciListe.Columns[5].HeaderText = "Basım Tarihi";
                    dataGridViewKullaniciListe.Columns[6].HeaderText = "Yayın Evi Ad";
                    dataGridViewKullaniciListe.Columns[7].HeaderText = "Yayın Evi Adres";
                    dataGridViewKullaniciListe.Columns[8].HeaderText = "Yayın Evi Tel";
                    dataGridViewKullaniciListe.Columns[9].HeaderText = "Satılanların Stok Sayısı";
                    dataGridViewKullaniciListe.Columns[10].HeaderText = "Kiralananların Stok Sayısı";


                    dataGridViewKullaniciListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    baglan.Close();

                    txtKitapIsmiyleAra.Clear();
                    txtYazarAdiAra.Clear();
                    txtYazarSoyadiAra.Clear();
                    txtYayinEviAdiAra.Clear();
                    txtKatagoriAra.Clear();

                }
                else if (comboBox1.SelectedItem == "Yazar Adı Soyadı")
                {
                    label4.Visible = false;
                    txtKitapIsmiyleAra.Visible = false;

                    label5.Visible = true;
                    txtYazarAdiAra.Visible = true;
                    label6.Visible = true;
                    txtYazarSoyadiAra.Visible = true;

                    label7.Visible = false;
                    txtYayinEviAdiAra.Visible = false;

                    label8.Visible = false;
                    txtKatagoriAra.Visible = false;

                    btnAra.Visible = true;

                    String query1;

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    DataTable table = new DataTable();
                    baglan.Open();

                    query1 = "select Kitap_Adi,Yazar_Ad, Yazar_Soyad, Katagori_Ad,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel,Satilacak_Stok,Kiralanacak_Stok  from Kitaplik (Nolock) inner join Yazar on Kitaplik.Yazar_Id = Yazar.Yazar_Id inner join Katagori on Kitaplik.Katagori_Id = Katagori.Katagori_Id inner join Yayin_Evi on Kitaplik.Yayin_Evi_Id = Yayin_Evi.Yayin_Evi_Id Where Yazar_Ad = ('" + txtYazarAdiAra.Text + "') And Yazar_Soyad = ('" + txtYazarSoyadiAra.Text + "') And Satilacak_Stok > 0";

                    //query1 = "select Kitap_Id,Kitap_Adi,Yazar_Ad,Yazar_Soyad,Katagori_Id,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Id,Satilacak_Stok,Kiralanacak_Stok from Kitaplik inner join Yazar on Kitaplik.Yazar_Id = Yazar.Yazar_Id Where Yazar_Ad = ('" + txtYazarAdiAra.Text + "') And Yazar_Soyad = ('" + txtYazarSoyadiAra.Text + "') And Satilacak_Stok > 0";

                    SqlDataAdapter SDA = new SqlDataAdapter(query1, baglan);

                    SDA.Fill(table);
                    dataGridViewKullaniciListe.DataSource = table;

                    dataGridViewKullaniciListe.Columns[0].HeaderText = "Kitap Adı";
                    dataGridViewKullaniciListe.Columns[1].HeaderText = "Yazar Ad";
                    dataGridViewKullaniciListe.Columns[2].HeaderText = "Yazar Soyad";
                    dataGridViewKullaniciListe.Columns[3].HeaderText = "Katagori Ad";
                    dataGridViewKullaniciListe.Columns[4].HeaderText = "Sayfa Sayısı";
                    dataGridViewKullaniciListe.Columns[5].HeaderText = "Basım Tarihi";
                    dataGridViewKullaniciListe.Columns[6].HeaderText = "Yayın Evi Ad";
                    dataGridViewKullaniciListe.Columns[7].HeaderText = "Yayın Evi Adres";
                    dataGridViewKullaniciListe.Columns[8].HeaderText = "Yayın Evi Tel";
                    dataGridViewKullaniciListe.Columns[9].HeaderText = "Satılanların Stok Sayısı";
                    dataGridViewKullaniciListe.Columns[10].HeaderText = "Kiralananların Stok Sayısı";

                    dataGridViewKullaniciListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    baglan.Close();

                    txtKitapIsmiyleAra.Clear();
                    txtYazarAdiAra.Clear();
                    txtYazarSoyadiAra.Clear();
                    txtYayinEviAdiAra.Clear();
                    txtKatagoriAra.Clear();

                }
                else if (comboBox1.SelectedItem == "Yayın Evi Adı")
                {
                    label4.Visible = false;
                    txtKitapIsmiyleAra.Visible = false;

                    label5.Visible = false;
                    txtYazarAdiAra.Visible = false;
                    label6.Visible = false;
                    txtYazarSoyadiAra.Visible = false;

                    label7.Visible = true;
                    txtYayinEviAdiAra.Visible = true;

                    label8.Visible = false;
                    txtKatagoriAra.Visible = false;

                    btnAra.Visible = true;

                    String query1;

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    DataTable table = new DataTable();
                    baglan.Open();

                    query1 = "select Kitap_Adi,Yazar_Ad, Yazar_Soyad, Katagori_Ad,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel,Satilacak_Stok,Kiralanacak_Stok  from Kitaplik (Nolock) inner join Yazar on Kitaplik.Yazar_Id = Yazar.Yazar_Id inner join Katagori on Kitaplik.Katagori_Id = Katagori.Katagori_Id inner join Yayin_Evi on Kitaplik.Yayin_Evi_Id = Yayin_Evi.Yayin_Evi_Id Where Yayin_Evi_Ad = ('" + txtYayinEviAdiAra.Text + "') And Satilacak_Stok > 0";

                    //query1 = "select Kitap_Id,Kitap_Adi,Yazar_Id,Katagori_Id,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel,Satilacak_Stok,Kiralanacak_Stok from Kitaplik inner join Yayin_Evi on Kitaplik.Yayin_Evi_Id = Yayin_Evi.Yayin_Evi_Id Where Yayin_Evi_Ad = ('" + txtYayinEviAdiAra.Text + "') And Satilacak_Stok > 0";

                    SqlDataAdapter SDA = new SqlDataAdapter(query1, baglan);

                    SDA.Fill(table);
                    dataGridViewKullaniciListe.DataSource = table;


                    dataGridViewKullaniciListe.Columns[0].HeaderText = "Kitap Adı";
                    dataGridViewKullaniciListe.Columns[1].HeaderText = "Yazar Ad";
                    dataGridViewKullaniciListe.Columns[2].HeaderText = "Yazar Soyad";
                    dataGridViewKullaniciListe.Columns[3].HeaderText = "Katagori Ad";
                    dataGridViewKullaniciListe.Columns[4].HeaderText = "Sayfa Sayısı";
                    dataGridViewKullaniciListe.Columns[5].HeaderText = "Basım Tarihi";
                    dataGridViewKullaniciListe.Columns[6].HeaderText = "Yayın Evi Ad";
                    dataGridViewKullaniciListe.Columns[7].HeaderText = "Yayın Evi Adres";
                    dataGridViewKullaniciListe.Columns[8].HeaderText = "Yayın Evi Tel";
                    dataGridViewKullaniciListe.Columns[9].HeaderText = "Satılanların Stok Sayısı";
                    dataGridViewKullaniciListe.Columns[10].HeaderText = "Kiralananların Stok Sayısı";


                    dataGridViewKullaniciListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    baglan.Close();

                    txtKitapIsmiyleAra.Clear();
                    txtYazarAdiAra.Clear();
                    txtYazarSoyadiAra.Clear();
                    txtYayinEviAdiAra.Clear();
                    txtKatagoriAra.Clear();

                }
                else if (comboBox1.SelectedItem == "Katagori")
                {
                    label4.Visible = false;
                    txtKitapIsmiyleAra.Visible = false;

                    label5.Visible = false;
                    txtYazarAdiAra.Visible = false;
                    label6.Visible = false;
                    txtYazarSoyadiAra.Visible = false;

                    label7.Visible = false;
                    txtYayinEviAdiAra.Visible = false;

                    label8.Visible = true;
                    txtKatagoriAra.Visible = true;

                    btnAra.Visible = true;

                    String query1;

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    DataTable table = new DataTable();
                    baglan.Open();

                    query1 = "select Kitap_Adi,Yazar_Ad, Yazar_Soyad, Katagori_Ad,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Ad,Yayin_Evi_Adres,Yayin_Evi_Tel,Satilacak_Stok,Kiralanacak_Stok  from Kitaplik (Nolock) inner join Yazar on Kitaplik.Yazar_Id = Yazar.Yazar_Id inner join Katagori on Kitaplik.Katagori_Id = Katagori.Katagori_Id inner join Yayin_Evi on Kitaplik.Yayin_Evi_Id = Yayin_Evi.Yayin_Evi_Id Where Katagori_Ad = ('" + txtKatagoriAra.Text + "') And Satilacak_Stok > 0";

                    //query1 = "select Kitap_Id,Kitap_Adi,Yazar_Id,Katagori_Ad,Sayfa_Sayisi,Basim_Tarihi,Yayin_Evi_Id,Satilacak_Stok,Kiralanacak_Stok from Kitaplik inner join Katagori on Kitaplik.Katagori_Id = Katagori.Katagori_Id Where Katagori_Ad = ('" + txtKatagoriAra.Text + "') And Satilacak_Stok > 0";

                    SqlDataAdapter SDA = new SqlDataAdapter(query1, baglan);

                    SDA.Fill(table);
                    dataGridViewKullaniciListe.DataSource = table;

                    dataGridViewKullaniciListe.Columns[0].HeaderText = "Kitap Adı";
                    dataGridViewKullaniciListe.Columns[1].HeaderText = "Yazar Ad";
                    dataGridViewKullaniciListe.Columns[2].HeaderText = "Yazar Soyad";
                    dataGridViewKullaniciListe.Columns[3].HeaderText = "Katagori Ad";
                    dataGridViewKullaniciListe.Columns[4].HeaderText = "Sayfa Sayısı";
                    dataGridViewKullaniciListe.Columns[5].HeaderText = "Basım Tarihi";
                    dataGridViewKullaniciListe.Columns[6].HeaderText = "Yayın Evi Ad";
                    dataGridViewKullaniciListe.Columns[7].HeaderText = "Yayın Evi Adres";
                    dataGridViewKullaniciListe.Columns[8].HeaderText = "Yayın Evi Tel";
                    dataGridViewKullaniciListe.Columns[9].HeaderText = "Satılanların Stok Sayısı";
                    dataGridViewKullaniciListe.Columns[10].HeaderText = "Kiralananların Stok Sayısı";

                    dataGridViewKullaniciListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    baglan.Close();

                    txtKitapIsmiyleAra.Clear();
                    txtYazarAdiAra.Clear();
                    txtYazarSoyadiAra.Clear();
                    txtYayinEviAdiAra.Clear();
                    txtKatagoriAra.Clear();
                }
            }
            else
                MessageBox.Show("Kesin Sonuç İçin Arama Kısmını Eksiksiz Doldurunuz.");


            
        }

        private void KullaniciBolumu_Load(object sender, EventArgs e)
        {

            txtKitapIsmiyleAra.ContextMenu = new ContextMenu();
            txtYazarAdiAra.ContextMenu = new ContextMenu();
            txtYazarSoyadiAra.ContextMenu = new ContextMenu();
            txtYayinEviAdiAra.ContextMenu = new ContextMenu();
            txtKatagoriAra.ContextMenu = new ContextMenu();


            dataGridViewKullaniciListe.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void dataGridViewKullaniciListe_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtKitapId.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[0].Value.ToString();
                txtKitapAdi.Text = dataGridViewKullaniciListe.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeslimTarihleri yeniTeslimTarihleri = new TeslimTarihleri();
            yeniTeslimTarihleri.Show();
            this.Hide();
        }

        private void txtKitapIsmiyleAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtYazarAdiAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtYazarSoyadiAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtYayinEviAdiAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtKatagoriAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^44 ','^^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }




    }
}
