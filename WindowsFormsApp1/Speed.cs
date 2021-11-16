using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum MeasureType { m, km, u, mah };
    public class Speed
    {
        private double value;
        private MeasureType type;

        public Speed(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.m:
                    typeVerbose = "м/с";
                    break;
                case MeasureType.km:
                    typeVerbose = "км/ч";
                    break;
                case MeasureType.u:
                    typeVerbose = "узел";
                    break;
                case MeasureType.mah:
                    typeVerbose = "мах";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        // сложение
        public static Speed operator +(Speed instance, double number)
        {
            var newValue = instance.value + number;
            var speed = new Speed(newValue, instance.type);

            return speed;
        }
        public static Speed operator +(double number, Speed instance)
        {
            return instance + number;
        }

        // умножение
        public static Speed operator *(Speed instance, double number)
        {
            return new Speed(instance.value * number, instance.type); ;
        }

        public static Speed operator *(double number, Speed instance)
        {
            return instance * number;
        }

        // вычитание
        public static Speed operator -(Speed instance, double number)
        {
            return new Speed(instance.value - number, instance.type); ;
        }

        public static Speed operator -(double number, Speed instance)
        {
            return instance - number;
        }

        public Speed To(MeasureType newType)
        {

            var newValue = this.value;

            if (this.type == MeasureType.m) // текущий тип метр
            {
                switch (newType)
                {
                    case MeasureType.m:
                        newValue = this.value;
                        break;
                    case MeasureType.km:
                        newValue = this.value * 3.6;
                        break;
                    case MeasureType.u:
                        newValue = this.value * 1.94;
                        break;
                    case MeasureType.mah:
                        newValue = this.value / 330;
                        break;
                }
            }
            else if (newType == MeasureType.m)
            {
                switch (this.type)
                {
                    case MeasureType.m:
                        newValue = this.value;
                        break;
                    case MeasureType.km:
                        newValue = this.value / 3.6;
                        break;
                    case MeasureType.u:
                        newValue = this.value / 1.94;
                        break;
                    case MeasureType.mah:
                        newValue = this.value * 330;
                        break;
                }
            }

            else
            {
                newValue = this.To(MeasureType.m).To(newType).value;
            }
            return new Speed(newValue, newType);
        }

        // сложение 
        public static Speed operator +(Speed instance1, Speed instance2)
        {
            return instance1 + instance2.To(instance1.type).value;
        }

        // вычитание
        public static Speed operator -(Speed instance1, Speed instance2)
        {
            return instance1 - instance2.To(instance1.type).value;
        }

        // умножение
        public static Speed operator *(Speed instance1, Speed instance2)
        {
            return instance1 * instance2.To(instance1.type).value;
        }

        // сравнение
        public static bool operator ==(Speed instance1, Speed instance2)
        {
            return instance1.value == instance2.To(instance1.type).value;
        }
        public static bool operator !=(Speed instance1, Speed instance2)
        {
            return instance1.value != instance2.To(instance2.type).value;
        }
        public static bool operator >(Speed instance1, Speed instance2)
        {
            return instance1.value > instance2.To(instance2.type).value;
        }
        public static bool operator <(Speed instance1, Speed instance2)
        {
            return instance1.value < instance2.To(instance2.type).value;
        }
    }
}

