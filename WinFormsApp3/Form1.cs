using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp3.Objects;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        GameCircles gameCircle = new GameCircles(0, 0, 0);
        int score = 0;

        public Form1()
        {
            InitializeComponent();

            // инициализируем объекты
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);
            objects.Add(player);
            objects.Add(new GameCircles(100, 100, 0));

            gameCircle.GenerateRandomly(pbMain.Width, pbMain.Height);

            // реакция на пересечение игрока с объектом
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            // реакция на пересечение игрока с маркером
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            // реакция на пересечение игрока с целью
            player.OnGameCircleOverlap += (c) =>
            {
                score++;
                c.GenerateRandomly(pbMain.Width, pbMain.Height);
                GameCircles.time = 60;
            };
        }
        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);
            uptadePlayer();

            // пересечения
            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            // рендер объектов
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }

            foreach (var obj in objects)
            {
                if (GameCircles.time == 0)
                {
                    GameCircles.End(obj);
                }
            }

            labelScore.Text = $"Очки: {score}";
        }
        private void uptadePlayer()
        { // рассчет положения игрока

            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                // ускорение
                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                // угол поворота игрока 
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            // замедление при достижении маркера
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // пересчет позиция игрока 
            player.X += player.vX;
            player.Y += player.vY;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        { // создание маркера по клику

            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
