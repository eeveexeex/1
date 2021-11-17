using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {


        List<Plant> plantsList = new List<Plant>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void ShowInfo()
        {
            int flowerCount = 0;
            int shrubCount = 0;
            int treeCount = 0;

            foreach (var plant in this.plantsList)
            {
                if (plant is Flower)
                {
                    flowerCount += 1;
                }
                else if (plant is Shrub)
                {
                    shrubCount += 1;
                }
                else if (plant is Tree)
                {
                    treeCount += 1;
                }
            }

            int sum = flowerCount + shrubCount + treeCount;
            countInfo.Text = "Количество доступных растений: " + sum;

        }
        private void GetPlants_Click(object sender, EventArgs e)
        {
            if (this.plantsList.Count == 0)
            {
                txtOut.Text = "Автомат пуст";
                return;
            }

            var plant = this.plantsList[0];
            this.plantsList.RemoveAt(0);
            txtInfo.Lines = txtInfo.Lines.Skip(1).ToArray();

            txtOut.Text = plant.GetInfo();
            ShowInfo();
        }

        private void AddPlants_Click_1(object sender, EventArgs e)
        {
            this.plantsList.Clear();
            txtInfo.Clear();
            txtOut.Clear();
            var random = new Random();
            for (var i = 0; i < 11; ++i)
            {
                switch (random.Next() % 3)
                {
                    case 0:
                        this.plantsList.Add(Flower.Generate());
                        txtInfo.Text += "Цветок\n";
                        break;
                    case 1:
                        this.plantsList.Add(Shrub.Generate());
                        txtInfo.Text += "Кустарник\n";
                        break;
                    case 2:
                        this.plantsList.Add(Tree.Generate());
                        txtInfo.Text += "Дерево\n";
                        break;
                }
            }
            ShowInfo();
        }
    }
}

