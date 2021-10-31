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

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            m.Text = Properties.Settings.Default.m.ToString();
        }

        public class Logic
        {
            public static string Compare(string m)
            {
                string outMessage = "";

                int sum = 0;
                string txt = "";
                string a = "";
                string[] numbers = m.Split(' ', ',');
                int i = 0;
                foreach (var num in numbers)
                {
                    if (i == 0) sum += Convert.ToInt32(num);
                    if (i % 2 == 1) sum += Convert.ToInt32(num);
                    if (i % 2 == 0 && i != 0) sum -= Convert.ToInt32(num);
                    
                    if (i % 2 == 0 && i != numbers.Length) a = Convert.ToInt32(num) + " + ";
                    if (i % 2 == 1 && i != numbers.Length) a = Convert.ToInt32(num) + " - ";
                    if (i == numbers.Length-1) a = Convert.ToInt32(num) + " ";
                    i++;
                    txt += a;
                }
                outMessage = "Текст " + txt + "\nСумма значений = " + sum;
                return outMessage;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string m;
            try
            {
                m = Convert.ToString(this.m.Text);
            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.m = m;
            Properties.Settings.Default.Save();

            if (m.Length <= 1)
                MessageBox.Show("Длина текста < 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show(Logic.Compare(m), "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string m;

            try
            {
                m = Convert.ToString(this.m.Text);

            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.m = m;
            Properties.Settings.Default.Save();

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
        private void m_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',')
            {
                label5.Visible = true;
                m.ForeColor = Color.OrangeRed;
            }
            else
            {
                label5.Visible = false;
                m.ForeColor = Color.Black;
            }

        }
    }
}
