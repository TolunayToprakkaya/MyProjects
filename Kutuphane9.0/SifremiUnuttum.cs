using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Kutuphane9._0
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("tolunaytoprakkaya@gmail.com", "sifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(textBox1.Text);
            mesajim.From = new MailAddress(textBox1.Text);
            textBox2.Text = "Parola Kodunuz";
            mesajim.Subject = textBox2.Text;
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000, 99999);
            textBox3.Text = Convert.ToString(myRandomNo);
            mesajim.Body = textBox3.Text;
            istemci.Send(mesajim);
            MessageBox.Show("Mail Gönderildi");
        }
    }
}
