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
using System.Text.RegularExpressions;

namespace Kutuphane9._0
{
    public partial class UyeOl : Form
    {
        private static int[] characters;
        static UyeOl()
        {
            characters = "qwertyuıopğüasdfghjklşizxcvbnmöç1234567890".Select(c => (int)c).ToArray();
        }


        public UyeOl()
        {
            InitializeComponent();
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            if (txtUyeTc.Text != "" && txtUyeAd.Text != "" && txtUyeSoyad.Text != "" && txtUyePosta.Text != "" && txtUyeTel.Text != "" && txtUyeAdres.Text != "" && txtUyeKullaniciAdi.Text != "" && txtUyeSifre.Text != "" && comboBox1.Text.ToString() != "")
            {

                


                if (txtUyeSifre.Text == txtUyeSifreTekrar.Text)
                {
                    //String query1, query2, query3, query4, query5, query6, query7;

                    SqlConnection baglan = new SqlConnection("Data Source=KARAŞIMŞEK;Initial Catalog=Kutuphane9.0;Integrated Security=True");
                    baglan.Open();

                    SqlCommand cmd1 = new SqlCommand("sp_Uye_Olustur", baglan);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "sp_Uye_Olustur";
                    cmd1.Parameters.Add("@Uye_Tc", SqlDbType.NVarChar, 11).Value = txtUyeTc.Text;
                    cmd1.Parameters.Add("@Uye_Ad", SqlDbType.NVarChar, 50).Value = txtUyeAd.Text;
                    cmd1.Parameters.Add("@Uye_Soyad", SqlDbType.NVarChar, 50).Value = txtUyeSoyad.Text;
                    cmd1.Parameters.Add("@Uye_Posta", SqlDbType.NVarChar, 30).Value = txtUyePosta.Text;
                    cmd1.Parameters.Add("@Uye_Tel", SqlDbType.NVarChar, 15).Value = txtUyeTel.Text;
                    cmd1.Parameters.Add("@Uye_Adres", SqlDbType.NVarChar, 50).Value = txtUyeAdres.Text;
                    cmd1.Parameters.Add("@Kullanici_Adi", SqlDbType.NVarChar, 50).Value = txtUyeKullaniciAdi.Text;
                    cmd1.Parameters.Add("@Kullanici_Sifre", SqlDbType.NVarChar, 30).Value = txtUyeSifre.Text;
                    cmd1.Parameters.Add("@Uye_Cesidi", SqlDbType.NVarChar, 30).Value = comboBox1.Text.ToString();


                    cmd1.ExecuteNonQuery();

                    /*
                    String query1, query2, query3, query4;

                    query1 = "Update Uye_Turu Set  Uye_Turu_Id = '1'  Where Uye_Cesidi = 'Standart Üyelik'";

                    query2 = "Update Uye_Turu Set  Uye_Turu_Id = '2'  Where Uye_Cesidi = 'Premium Üyelik'";

                    query3 = "Update Uye_Bilgileri Set  Uye_Turu_Id = '1'  Where Uye_Cesidi = 'Standart Üyelik'";

                    query4 = "Update Uye_Bilgileri Set  Uye_Turu_Id = '2'  Where Uye_Cesidi = 'Premium Üyelik'";

                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                    SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);

                    sda1.SelectCommand.ExecuteNonQuery();
                    sda2.SelectCommand.ExecuteNonQuery();
                    sda3.SelectCommand.ExecuteNonQuery();
                    sda4.SelectCommand.ExecuteNonQuery();
                    */
                    /*
                    SqlCommand cmd1 = new SqlCommand("sp_UyeTuru", baglan);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "sp_UyeTuru";
                    cmd1.Parameters.Add("@Uye_Cesidi", SqlDbType.NVarChar, 50).Value = comboBox1.Text;
                    cmd1.ExecuteNonQuery();
                
                    SqlCommand cmd2 = new SqlCommand("sp_KullaniciIdSifre", baglan);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "sp_KullaniciIdSifre";
                    cmd2.Parameters.Add("@Kullanici_Adi", SqlDbType.NVarChar, 50).Value = txtUyeKullaniciAdi.Text;
                    cmd2.Parameters.Add("@Kullanici_Sifre", SqlDbType.NVarChar, 30).Value = txtUyeSifre.Text;
                    cmd2.ExecuteNonQuery();


                    SqlCommand cmd3 = new SqlCommand("sp_UyeBilgileri", baglan);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "sp_UyeBilgileri";
                    cmd3.Parameters.Add("@Uye_Tc", SqlDbType.Int).Value = txtUyeTc.Text;
                    cmd3.Parameters.Add("@Uye_Ad", SqlDbType.NVarChar, 50).Value = txtUyeAd.Text;
                    cmd3.Parameters.Add("@Uye_Soyad", SqlDbType.NVarChar, 50).Value = txtUyeSoyad.Text;
                    cmd3.Parameters.Add("@Uye_Posta", SqlDbType.NVarChar, 30).Value = txtUyePosta.Text;
                    cmd3.Parameters.Add("@Uye_Tel", SqlDbType.NVarChar, 15).Value = txtUyeTel.Text;
                    //cmd3.Parameters.Add("@Uye_Turu_Id") = 
                    cmd3.Parameters.Add("@Uye_Adres", SqlDbType.NVarChar, 50).Value = txtUyeAdres.Text;
                    //cmd3.Parameters.Add("@Kullanici_Id", SqlDbType.Int).Value = txtUyeSifre.Text;
                    cmd3.Parameters.Add("@Kullanici_Adi", SqlDbType.NVarChar, 50).Value = txtUyeKullaniciAdi.Text;
                    cmd3.Parameters.Add("@Kullanici_Sifre", SqlDbType.NVarChar, 30).Value = txtUyeSifre.Text;
                    cmd3.ExecuteNonQuery();
                    */
                    /*

                    query1 = "declare @UyeTuruId int";

                    query2 = "declare @KullaniciId int";

                    query3 = "insert into Uye_Turu values('" + comboBox1.Text + "')";

                    query4 = "set @UyeTuruId = @@IDENTITY";

                    query5 = "insert into Kullanici_Id_Sifre values ('" + txtUyeKullaniciAdi.Text + "', '" + txtUyeSifre.Text + "')";

                    query6 = "set @KullaniciId = @@IDENTITY";

                    query7 = "insert into Uye_Bilgileri(Uye_Tc, Uye_Ad, Uye_Soyad, Uye_Posta, Uye_Tel, Uye_Turu_Id, Uye_Adres, Kullanici_Id, Kullanici_Adi, Kullanici_Sifre) values ('" + txtUyeTc.Text + "', '" + txtUyeAd.Text + "', '" + txtUyeSoyad.Text + "', '" + txtUyePosta.Text + "', '" + txtUyeTel.Text + "', @UyeTuruId , '" + txtUyeAdres.Text + "', @KullaniciId ,'" + txtUyeKullaniciAdi.Text + "' ,'" + txtUyeSifre.Text + "') ";

                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, baglan);
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, baglan);
                    SqlDataAdapter sda3 = new SqlDataAdapter(query3, baglan);
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, baglan);
                    SqlDataAdapter sda5 = new SqlDataAdapter(query5, baglan);
                    SqlDataAdapter sda6 = new SqlDataAdapter(query6, baglan);
                    SqlDataAdapter sda7 = new SqlDataAdapter(query7, baglan);

                    sda1.SelectCommand.ExecuteNonQuery();
                    sda2.SelectCommand.ExecuteNonQuery();
                    sda3.SelectCommand.ExecuteNonQuery();
                    sda4.SelectCommand.ExecuteNonQuery();
                    sda5.SelectCommand.ExecuteNonQuery();
                    sda6.SelectCommand.ExecuteNonQuery();
                    sda7.SelectCommand.ExecuteNonQuery();
                 
                     */

                    baglan.Close();

                    SabitDegisken.kullaniciAdi = txtUyeKullaniciAdi.Text;

                    MessageBox.Show("Başarıyla Üye Oldunuz.");
                    Form1 yeniForm1 = new Form1();
                    yeniForm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor!!!");
                    txtUyeSifre.Clear();
                    txtUyeSifreTekrar.Clear();
                }
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Eksiksiz Giriniz!!!");
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 yeniForm1 = new Form1();
            yeniForm1.Show();
            this.Hide();
        }

        private void txtUyeTc_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                txtUyeTc.Select(0, 0);
            });        
        }

        private void txtUyeTel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                txtUyeTel.Select(0, 0);
            });   
        }

        private void txtUyeAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                             && !char.IsSeparator(e.KeyChar);    
        }

        private void txtUyeSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtUyeTc_MouseUp(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void txtUyeTel_MouseUp(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void txtUyeKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
       {
           //int ascii = KeyInterop.VirtualKeyFromKey(e.Key);
            //e.KeyData
            /*
            if(e.KeyValue ==16)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            */
            /*
            if (!characters.Contains(e.KeyValue) && e.KeyValue != 8 )
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            */
        }

        private void txtUyeKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^ĞÜŞİÖÇ^^A-Z^^çşığüö^^32 ' '^^\b^a-z^0-9^+^\-^\/^\*^\(^\)]"))
            {
                e.Handled = true;
            }
        }

        private void UyeOl_Load(object sender, EventArgs e)
        {
           txtUyeTc. ContextMenu = new ContextMenu();
           txtUyeAd.ContextMenu = new ContextMenu();
           txtUyeSoyad.ContextMenu = new ContextMenu();
           txtUyePosta.ContextMenu = new ContextMenu();
           txtUyeTel.ContextMenu = new ContextMenu();
           txtUyeAdres.ContextMenu = new ContextMenu();
           txtUyeKullaniciAdi .ContextMenu = new ContextMenu();
           txtUyeSifre.ContextMenu = new ContextMenu();
           comboBox1.ContextMenu = new ContextMenu();
        }

    }
}
