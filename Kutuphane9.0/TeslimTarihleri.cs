using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane9._0
{
    public partial class TeslimTarihleri : Form
    {

        int h;
        int m;
        int s;

        int g1, g2, a1, a2, t1, t2, t3, t4; 


        public TeslimTarihleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                textBox6.Text = "0";
            }

            if (textBox5.Text == "")
            {
                textBox5.Text = "0";
            }


            if (textBox9.Text == "")
            {
                textBox9.Text = "0";
            }
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }

            if (textBox7.Text == "")
            {
                textBox7.Text = "0";
            }
            if (textBox11.Text == "")
            {
                textBox11.Text = "0";
            }

            if (textBox12.Text == "")
            {
                textBox12.Text = "0";
            }

            /////////////////////////////////////////////7

            if(textBox1.Text == "")
            {
                textBox1.Text = "0";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }


            g1 = Convert.ToInt32(textBox6.Text);
            g2 = Convert.ToInt32(textBox5.Text);
            a1 = Convert.ToInt32(textBox9.Text);
            a2 = Convert.ToInt32(textBox8.Text);
            t1 = Convert.ToInt32(textBox4.Text);
            t2 = Convert.ToInt32(textBox7.Text);
            t3 = Convert.ToInt32(textBox11.Text);
            t4 = Convert.ToInt32(textBox12.Text);

            h = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            s = Convert.ToInt32(textBox3.Text);

            timer1.Start();        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1;

            if(s == -1)
            {
                m = m - 1;
                s = 59;
            }

            if(m == -1)
            {
                h = h - 1;
                m = 59;
            }

            if(h == 0 && m == 0 && s == 0)
            {
                timer1.Stop();
                MessageBox.Show("Zaman Doldu!", "Teslim Süresi");
            }

            String hh = Convert.ToString(h);
            String mm = Convert.ToString(m);
            String ss = Convert.ToString(s);

            label1.Text = hh;
            label3.Text = mm;
            label5.Text = ss;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }




    }
}
