using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Plant
    {
        public int Height = 0; // высота
        public virtual String GetInfo()
        {
            var str = String.Format("\nВысота: {0}", this.Height);
            return str;
        }
    }

    // виды цветов
    public enum FlowerColor { белый, розовый, сиреневый, голубой, красный };
    public enum FlowerType { пион, роза, орхидея, лилия, астра };
    // цветы
    public class Flower : Plant
    {
        public int PetalCount = 0; // количество лепестков
        public FlowerColor color = FlowerColor.белый; // цвет
        public FlowerType type = FlowerType.пион; // тип
        // переопределение
        public override String GetInfo()
        {
            var str = "Цветок";
            str += base.GetInfo();
            str += String.Format("\nКоличество лепетсков: {0}", this.PetalCount);
            str += String.Format("\nЦвет: {0}", this.color);
            str += String.Format("\nТип: {0}", this.type);
            return str;
        }
        // генерация случайного цветка
        public static Flower Generate()
        {
            var random = new Random();
            return new Flower
            {
                Height = random.Next(5, 15), // высота
                PetalCount = random.Next(5, 15), // количество лепестков
                color = (FlowerColor)random.Next(5), // цвет
                type = (FlowerType)random.Next(5) // тип
            };
        }

    }
    // кустарник
    public class Shrub : Plant
    {
        public bool WithFlower = false; // наличие цветов
        public int BranchCount = 0; // количество веточек
        // переопределение
        public override String GetInfo()
        {
            var str = "Кустарник";
            str += base.GetInfo();
            str += String.Format("\nНаличие цветов: {0}", this.WithFlower ? "с цветами" : "без цветов");
            str += String.Format("\nКоличество веточек: {0}", this.BranchCount);
            return str;
        }
        // генерация случайного кустарника
        public static Shrub Generate()
        {
            var random = new Random();
            return new Shrub
            {
                Height = random.Next(10, 50), // высота
                WithFlower = random.Next(2) == 0, // наличие цветов
                BranchCount = random.Next(10, 20) // количество веточек
            };
        }
    }
    // виды деревьев
    public enum TreeType { хвойное, листовое };
    // дерево
    public class Tree : Plant
    {
        public TreeType type = TreeType.хвойное; // тип
        public int Radius = 0; // радиус
        // переопределение
        public override String GetInfo()
        {
            var str = "Дерево";
            str += base.GetInfo();
            str += String.Format("\nТип: {0}", this.type);
            str += String.Format("\nРадиус: {0}", this.Radius);
            return str;
        }
        // генерация случайного дерева
        public static Tree Generate()
        {
            var random = new Random();
            return new Tree
            {
                Height = random.Next(50, 100), // высота
                type = (TreeType)random.Next(2), // тип
                Radius = random.Next(10, 50) // радиус
            };
        }
    }
}