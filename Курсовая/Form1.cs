using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {

        List<Particle> particles = new List<Particle>();
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;                                // поле для эмиттера

        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);     // привязка изображения

            this.emitter = new Emitter
            {
                Direction = 100,
                Spreading = 100,
                SpeedMin = 10,
                SpeedMax = 15,
                ColorFrom = Color.GreenYellow,
                ColorTo = Color.FromArgb(0, Color.DarkTurquoise),
                ParticlesPerTick = 30,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); 
        }

        private void timer1_Tick(object sender, EventArgs e)            // обработка тика таймера
        {
            using (var g = Graphics.FromImage(picDisplay.Image))        // возвращает новый объект Graphics для picDisplay
            {
                g.Clear(Color.Black);                                   // очистка
                emitter.Render(g);                                      // рендерим систему
            }
            emitter.UpdateState();                                      // обновляем эмиттер
            picDisplay.Invalidate();                                    // вызываем событие Paint для перерисовки

            label6.Text = $"Количество частиц: {emitter.ParticlesCount}";
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;                      // управление направлением
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value;                      // управление распределением
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMax = tbSpeed.Value;                           // управление скоростью
        }

        private void tbParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbParticlesPerTick.Value;        // управление количеством частиц в тик
        }

        private void tbLife_Scroll(object sender, EventArgs e)
        {
            emitter.LifeMax = tbLife.Value;                             // управление продолжительностью жизни
        }
    }
}