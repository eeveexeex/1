using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            a.Text = Properties.Settings.Default.a.ToString();
            b.Text = Properties.Settings.Default.b.ToString();
            c.Text = Properties.Settings.Default.c.ToString();
            d.Text = Properties.Settings.Default.d.ToString();
            n.Text = Properties.Settings.Default.n.ToString();
            m.Text = Properties.Settings.Default.m.ToString();
        }

        public class Logic
        {
            public static string Compare(int a, int b, int c, int d, int n, int m)
            {
                string outMessage = "";

                    if ((n == 0 && a != 0 && c == 0 && m <= d) || (n == 0 && a == 0 && c != 0 && m >= b) || (n == a && n <= c && m >= b) || (n >= a && n == c && m <= d) || (n == 0 && a != 0 && c != 0) || (n != 0 && a != 0 && c == 0 && m >=b) || (n != 0 && a == 0 && c != 0 && m <= d))
                    outMessage = "Поезд стоит на платформе";

                    else
                        outMessage = "Поезд не стоит на платформе";

                    return outMessage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d, n, m;
            try
            {
                a = Convert.ToInt32(this.a.Text);
                b = Convert.ToInt32(this.b.Text);
                c = Convert.ToInt32(this.c.Text);
                d = Convert.ToInt32(this.d.Text);
                n = Convert.ToInt32(this.n.Text);
                m = Convert.ToInt32(this.m.Text);
            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.a = a;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.c = c;
            Properties.Settings.Default.d = d;
            Properties.Settings.Default.n = n;
            Properties.Settings.Default.m = m;
            Properties.Settings.Default.Save();

            if (a > 23 || a < 0 || b > 59 || b < 0 || c > 23 || c < 0 || d > 59 || d < 0 || n > 23 || n < 0 || m > 59 || m < 0)
                MessageBox.Show("Неверно введены значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(Logic.Compare(a, b, c, d, n, m), "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int a, b, c, d, n, m;
            try
            {
                a = Convert.ToInt32(this.a.Text);
                b = Convert.ToInt32(this.b.Text);
                c = Convert.ToInt32(this.c.Text);
                d = Convert.ToInt32(this.d.Text);
                n = Convert.ToInt32(this.n.Text);
                m = Convert.ToInt32(this.m.Text);
            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.a = a;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.c = c;
            Properties.Settings.Default.d = d;
            Properties.Settings.Default.n = n;
            Properties.Settings.Default.m = m;
            Properties.Settings.Default.Save();

            this.a.Text = null;
            this.b.Text = null;
            this.c.Text = null;
            this.d.Text = null;
            this.n.Text = null;
            this.m.Text = null;

        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, false, true);
            }
        }
        private void a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label10.Visible = true;
                a.ForeColor = Color.OrangeRed;
            }
            else
            {
                label10.Visible = false;
                a.ForeColor = Color.Black;
            }

        }
        private void b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label11.Visible = true;
                b.ForeColor = Color.OrangeRed;
            }
            else
            {
                label11.Visible = false;
                b.ForeColor = Color.Black;
            }
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label12.Visible = true;
                c.ForeColor = Color.OrangeRed;
            }
            else
            {
                label12.Visible = false;
                c.ForeColor = Color.Black;
            }
        }

        private void d_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label13.Visible = true;
                d.ForeColor = Color.OrangeRed;
            }
            else
            {
                label13.Visible = false;
                d.ForeColor = Color.Black;
            }
        }
        private void n_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label14.Visible = true;
                n.ForeColor = Color.OrangeRed;
            }
            else
            {
                label14.Visible = false;
                n.ForeColor = Color.Black;
            }
        }

        private void m_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label15.Visible = true;
                m.ForeColor = Color.OrangeRed;
            }
            else
            {
                label15.Visible = false;
                m.ForeColor = Color.Black;
            }
        }
    }
}
