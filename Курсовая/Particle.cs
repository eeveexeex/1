using System;
using System.Drawing;

namespace CourseWork
{
    public class Particle
    {
        public int Radius;          // радиус частицы
        public float X;             // X координата положения частицы в пространстве
        public float Y;             // Y координата положения частицы в пространстве

        public float SpeedX;        // скорость перемещения по оси X
        public float SpeedY;        // скорость перемещения по оси Y
        public float Life;          // запас здоровья частицы

        public static Random rand = new Random();

        public Particle()                               // конструктор для создания частицы
        {   
            var direction = (double)rand.Next(360);     // произвольное направление
            var speed = 1 + rand.Next(10);              // и скорость

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);      // рассчитываем
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);     // вектор скорости

            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }
        public virtual void Draw(Graphics g)                    // тут добавил слово virtual чтобы переопределить функцию
        {
            float k = Math.Min(1f, Life / 100);                 // коэффициент прозрачности по шкале от 0 до 1.0
            int alpha = (int)(k * 255);                         // значение альфа канала в шкале от 0 до 255

            var color = Color.FromArgb(alpha, Color.Black);     // цвет с привязкой альфа канала
            var b = new SolidBrush(color);                      // кисть для рисования

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();                                        // удаление кисти из памяти
        }
    }

    public class ParticleColorful : Particle            // класс для цветных частиц
    {
        public Color FromColor;                         // начальный цвет
        public Color ToColor;                           // конечный цвет

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        public override void Draw(Graphics g)           // переопределение отрисовки
        {
            float k = Math.Min(1f, Life / 100);
            
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);              // кисть для рисования

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();                                // удаление кисти из памяти
        }
    }
}