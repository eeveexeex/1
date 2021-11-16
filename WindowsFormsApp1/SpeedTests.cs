using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class SpeedTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            var speed = new Speed(38, MeasureType.m);
            Assert.AreEqual("38 м/с", speed.Verbose());

            speed = new Speed(38, MeasureType.km);
            Assert.AreEqual("38 км/ч", speed.Verbose());

            speed = new Speed(38, MeasureType.u);
            Assert.AreEqual("38 узел", speed.Verbose());

            speed = new Speed(38, MeasureType.mah);
            Assert.AreEqual("38 мах", speed.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest()
        {
            var speed = new Speed(1, MeasureType.m);
            speed = speed + 4.25;
            Assert.AreEqual("5,25 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()
        {
            var speed = new Speed(3, MeasureType.m);
            speed = speed - 1.75;
            Assert.AreEqual("1,25 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var speed = new Speed(3, MeasureType.m);
            speed = speed * 3;
            Assert.AreEqual("9 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest()
        {
            Speed speed;

            speed = new Speed(4 * 3.6, MeasureType.m);
            Assert.AreEqual("51,84 км/ч", speed.To(MeasureType.km).Verbose());

            speed = new Speed(1.94 * 2, MeasureType.m);
            Assert.AreEqual("7,5272 узел", speed.To(MeasureType.u).Verbose());

            speed = new Speed(3 * 330, MeasureType.m);
            Assert.AreEqual("3 мах", speed.To(MeasureType.mah).Verbose());
        }

        [TestMethod()]
        public void AnyToMeterTest()
        {
            Speed speed;

            speed = new Speed(1, MeasureType.km);
            Assert.AreEqual("0,277777777777778 м/с", speed.To(MeasureType.m).Verbose());

            speed = new Speed(1, MeasureType.u);
            Assert.AreEqual("0,515463917525773 м/с", speed.To(MeasureType.m).Verbose());

            speed = new Speed(1, MeasureType.mah);
            Assert.AreEqual("330 м/с", speed.To(MeasureType.m).Verbose());
        }

        [TestMethod()]
        public void AddSubKmMetersTest()
        {
            var m = new Speed(1, MeasureType.m);
            var km = new Speed(5, MeasureType.km);

            Assert.AreEqual("2,38888888888889 м/с", (m + km).Verbose());
            Assert.AreEqual("8,6 км/ч", (km + m).Verbose());

            Assert.AreEqual("1,4 км/ч", (km - m).Verbose());
            Assert.AreEqual("-0,388888888888889 м/с", (m - km).Verbose());
        }
    }
}