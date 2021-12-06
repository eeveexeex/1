using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Objects
{
    class GameCircles : BaseObject
    {
        public static int time = 60;
        public GameCircles(float x, float y, float angle) : base(x, y, angle) { }
        public override void Render(Graphics g)
        { // создаем цель

            g.FillEllipse(new SolidBrush(Color.GreenYellow), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.GreenYellow), -15, -15, 30, 30);
            g.DrawString($"{Timer()}", new Font("Verdana", 8), new SolidBrush(Color.YellowGreen), 10, 10);
        }
        public override GraphicsPath GetGraphicsPath()
        { // описание формы

            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public int Timer()
        { // счетчик зеленого кружка

            if (time > 0)
            {
                time -= 1;
            }
            return time;
        }
        public static void End(BaseObject obj)
        { // событие конца отсчета
            if (time == 0)
            {
                if (obj is GameCircles)
                {
                    obj.GenerateRandomly(450, 250);
                    time = 60;
                }
            }
        }
    }
}
