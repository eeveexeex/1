using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp3.Objects
{
    class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;

        public Action<BaseObject, BaseObject> OnOverlap;
        public BaseObject(float x, float y, float angle)
        { // установка стартовых значений

            X = x;
            Y = y;
            Angle = angle;
        }
        public virtual void GenerateRandomly(int maxX, int maxY)
        { // создание рандомных координат

            Random random = new Random();

            X = random.Next(10, maxX - 20);
            Y = random.Next(10, maxY - 20);
        }
        public Matrix GetTransform()
        { // получение матрицы сдвига

            var matrix = new Matrix();

            matrix.Translate(X, Y);
            matrix.Rotate(Angle);

            return matrix;
        }
        public virtual void Render(Graphics g) {}
        public virtual GraphicsPath GetGraphicsPath()
        { // описание формы объекта

            return new GraphicsPath();
        }
        public virtual bool Overlaps(BaseObject obj, Graphics g)
        { // проверка пересечения двух форм

            // берем информацию о форме
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            // применяем к объектам матрицы трансформации
            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());

            // используем класс Region, который позволяет определить пересечение объектов
            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }
        public virtual void Overlap(BaseObject obj)
        {
            if (this.OnOverlap != null)
            {
                this.OnOverlap(this, obj);
            }
        }
    }
}



