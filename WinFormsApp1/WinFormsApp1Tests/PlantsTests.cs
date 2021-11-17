using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Tests
{
    [TestClass()]
    public class PlantsTests
    {
        [TestMethod()]
        public void GenerateFlower()
        {
            bool isCorrect = true;
            Flower plant = new Flower();

            plant.Height = 15;
            plant.PetalCount = 12;
            plant.color = FlowerColor.розовый;
            plant.type = FlowerType.пион;

            if (plant.GetInfo() != "Высота: 15\nКоличество лепестков: 12\nЦвет: розовый\nТип: пион")
                isCorrect = false;

            plant.type = FlowerType.орхидея;

            if (plant.GetInfo() != "Высота: 15\nКоличество лепестков: 12\nЦвет: розовый\nТип: орхидея")
                isCorrect = false;

            plant.color = FlowerColor.сиреневый;

            if (plant.GetInfo() != "Высота: 15\nКоличество лепестков: 12\nЦвет: сиреневый\nТип: орхидея")
                isCorrect = false;

            Assert.IsTrue(isCorrect);
        }
    }

    [TestClass()]
    public class ShrubTests
    {
        [TestMethod()]
        public void GenerateShrub()
        {
            bool isCorrect = true;
            Shrub plant = new Shrub();

            plant.Height = 45;
            plant.WithFlower = true;
            plant.BranchCount = 14;

            if (plant.GetInfo() != "Высота: 45\nНаличие цветов: с цветами\nКоличество веточек: 14")
                isCorrect = false;

            plant.BranchCount = 10;

            if (plant.GetInfo() != "Высота: 45\nНаличие цветов: с цветами\nКоличество веточек: 10")
                isCorrect = false;

            plant.WithFlower = false;

            if (plant.GetInfo() != "Высота: 45\nНаличие цветов: без цветов\nКоличество веточек: 10")
                isCorrect = false;

            Assert.IsTrue(isCorrect);
        }
    }

    [TestClass()]
    public class TreeTests
    {
        [TestMethod()]
        public void GenerateTree()
        {
            bool isCorrect = true;
            Tree plant = new Tree();

            plant.Height = 88;
            plant.type = TreeType.хвойное;
            plant.Radius = 20;

            if (plant.GetInfo() != "Высота: 88\nТип: хвойное\nРадиус: 20")
                isCorrect = false;

            plant.Radius = 30;

            if (plant.GetInfo() != "Высота: 88\nТип: хвойное\nРадиус: 30")
                isCorrect = false;

            plant.type = TreeType.листовое;

            if (plant.GetInfo() != "Высота: 88\nТип: листовое\nРадиус: 30")
                isCorrect = false;

            Assert.IsTrue(isCorrect);
        }
    }
}