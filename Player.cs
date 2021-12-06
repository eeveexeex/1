using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<GameCircles> OnGameCircleOverlap;

        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle) { }
        public override void Render(Graphics g)
        { // создаем игрока

            g.FillEllipse(new SolidBrush(Color.LightSkyBlue), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
        public override GraphicsPath GetGraphicsPath()
        { // описание формы

            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public override void Overlap(BaseObject obj)
        { // пересечение игрока

            base.Overlap(obj);
            // с маркером
            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            // с целью
            if (obj is GameCircles)
            {
                OnGameCircleOverlap(obj as GameCircles);
            }
        }
    }
}
