using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var measureItems = new string[]
            {
            "м/с",
            "км/ч",
            "узел",
            "мах",
            };

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);

            txtFirst.Text = Properties.Settings.Default.txtFirst.ToString();
            txtSecond.Text = Properties.Settings.Default.txtSecond.ToString();
            txtResult.Text = Properties.Settings.Default.txtResult.ToString();
        }
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "м/с":
                    measureType = MeasureType.m;
                    break;
                case "км/ч":
                    measureType = MeasureType.km;
                    break;
                case "узел":
                    measureType = MeasureType.u;
                    break;
                case "мах":
                    measureType = MeasureType.mah;
                    break;
                default:
                    measureType = MeasureType.m;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstSpeed = new Speed(firstValue, firstType);
                var secondSpeed = new Speed(secondValue, secondType);

                Speed sumSpeed;

                switch (cmbOperation.Text)
                {
                    case "сложение":
                        sumSpeed = firstSpeed + secondSpeed;
                        txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "вычитание":
                        sumSpeed = firstSpeed - secondSpeed;
                        txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "умножение":
                        sumSpeed = firstSpeed * secondSpeed;
                        txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "сравнение":
                        if (firstSpeed == secondSpeed.To(firstType))
                            txtResult.Text = "Значения равны";
                        if (firstSpeed > secondSpeed.To(firstType))
                            txtResult.Text = "Значение 1 больше";
                        if (firstSpeed < secondSpeed.To(firstType))
                            txtResult.Text = "Значение 2 больше";
                        break;
                    default:
                        sumSpeed = new Speed(0, MeasureType.m);
                        break;
                }
           
            }
            catch (FormatException)
            {
           
            }
        }
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbFirstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SelectNextControl(ActiveControl, true, true, false, true);
                }
        }
        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }
        }
        private void txtSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtFirst.Clear();
            txtSecond.Clear();
            txtResult.Clear();
            cmbOperation.SelectedIndex = -1;
        }
    }
}

