using System;
using System.Collections.Generic;
using System.Drawing;

namespace CourseWork
{
    class Emitter
    {
        List<Particle> particles = new List<Particle>();

        public float GravitationX = 0;
        public float GravitationY = 1;      // пусть гравитация силой один пиксель за такт

        public int X;                       // координата X центра эмиттера
        public int Y;                       // соответствующая координата Y 
        public int Direction = 0;           // вектор направления в градус соах
        public int Spreading = 360;         // разброс частиц относительно Direction
        public int SpeedMin = 1;            // начальная минимальная скорость движения частицы
        public int SpeedMax = 10;           // начальная максимальная скорость движения частицы
        public int RadiusMin = 2;           // минимальный радиус частицы
        public int RadiusMax = 10;          // максимальный радиус частицы
        public int LifeMin = 20;            // минимальное время жизни частицы
        public int LifeMax = 100;           // максимальное время жизни частицы
        public int ParticlesPerTick = 1;    // количество частиц в тик
        public int ParticlesCount = 0;      // счетчик количества частиц

        public Color ColorFrom = Color.White;                       // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black);      // конечный цвет частиц

        public void Render(Graphics g)      // функция рендеринга
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);           // отрисовка частиц
            }
        }

        public virtual Particle CreateParticle()                    // метод генерации частицы
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        public virtual void ResetParticle(Particle particle)        // метод сброса частицы
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        // обновление положения частиц
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;       // фиксируем счетчик частиц за тик

            foreach (var particle in particles)
            {
                if (particle.Life <= 0)                     // если частицы умерла
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;             // уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {  
                    particle.SpeedX += GravitationX;        // пересчет вектора скорости
                    particle.SpeedY += GravitationY;        // с учетом гравитации

                    particle.X += particle.SpeedX;          // пересчет положения частицы
                    particle.Y += particle.SpeedY;          // в пространстве 

                }
            }

            while (particlesToCreate >= 1)                  // цикл будет срабатывать только в самом начале работы эмиттера
            {
                particlesToCreate -= 1;                     // уменьшаем счётчик созданных частиц на 1
                var particle = CreateParticle();            // вызываем метод CreateParticle()
                ResetParticle(particle);
                particles.Add(particle);
                ParticlesCount++;                           // считаем количество частиц
            }
        }
    }
}
