using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kutuphane9._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnGirisUyeOl_Click(object sender, EventArgs e)
        {
            UyeOl yeniUyeOl = new UyeOl();
            yeniUyeOl.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            String sifre = "";
            String withDoubleQuotes = txtKullaniciAdi.Text.Replace("'", "\"");

            SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select Kullanici_Sifre from Kullanici_Id_Sifre (Nolock) where Kullanici_Adi = @ka;", baglan);
            komut.Parameters.AddWithValue("ka", withDoubleQuotes);
            SqlDataReader oku = komut.ExecuteReader();
            


            while (oku.Read())
            {
                var tmp = oku["Kullanici_Sifre"];
                if (tmp != DBNull.Value)
                {
                    sifre = oku["Kullanici_Sifre"].ToString();
                }
            }


            if(txtSifre.Text != "")
            {
                if (withDoubleQuotes == "admin" && txtSifre.Text == "123")
                {

                    AdminBolumu yeniAdminBolumu = new AdminBolumu();
                    yeniAdminBolumu.Show();
                    this.Hide();


                }
                else if (txtSifre.Text.Equals(sifre))
                {

                    KullaniciBolumu yeniKullaniciBolumu = new KullaniciBolumu();
                    yeniKullaniciBolumu.Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış!!!");
            }
            else
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış!!!");

           

            SabitDegisken.kullaniciAdi = txtKullaniciAdi.Text;

            oku.Close();

            SqlCommand komut1 = new SqlCommand("select Kullanici_Id from Kullanici_Id_Sifre (Nolock) where Kullanici_Adi = ('" + withDoubleQuotes + "');", baglan);
            
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Kullanici_Id"].ToString();
            }

            SabitDegisken.KullaniciId = textBox1.Text;

            /*
            String id = "";

            id =  "select Kullanici_Id from Kullanici_Id_Sifre where Kullanici_Adi = ('" + txtKullaniciAdi.Text + "')";
            
            SqlDataAdapter sda1 = new SqlDataAdapter(id, baglan);

            //sda1.SelectCommand.ExecuteNonQuery();

            //SabitDegisken.KullaniciId = textBox1.Text; ;
             */


        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.ContextMenu = new ContextMenu();
            txtSifre.ContextMenu = new ContextMenu();

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            linkLabel1.BackColor = Color.Transparent;

            txtKullaniciAdi.BackColor = Color.Transparent;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum yeniSifre = new SifremiUnuttum();
            yeniSifre.Show();
            this.Hide();
        }

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }



    }

}

