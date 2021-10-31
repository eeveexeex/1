using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp8
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            int a, b;

            Console.WriteLine("Введите время прибытия поезда");

            Console.Write("Часы =  "); a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минуты = "); b = Convert.ToInt32(Console.ReadLine());

            if (a > 23 || a < 0 || b > 59 || b < 0)
            {
                Console.WriteLine("Время введено неверно");
                return;
            }

            int c, d;

            Console.WriteLine("Введите время отправления поезда");

            Console.Write("Часы =  "); c = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минуты = "); d = Convert.ToInt32(Console.ReadLine());

            if (c > 23 || c < 0 || d > 59 || d < 0)
            {
                Console.WriteLine("Время введено неверно");
                return;
            }

            int n, m;

            Console.WriteLine("Введите время прибытия пассажира");

            Console.Write("Часы =  "); n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минуты = "); m = Convert.ToInt32(Console.ReadLine());

            if (n > 23 || n < 0 || m > 59 || m < 0)
            {
                Console.WriteLine("Время введено неверно");
                return;
            }

            if ((n == 0 && a != 0 && c == 0 && m <= d) || (n == 0 && a == 0 && c != 0 && m >= b) || (n == a && n <= c && m >= b) || (n >= a && n == c && m <= d) || (n == 0 && a != 0 && c != 0) || (n != 0 && a != 0 && c == 0 && m >= b) || (n != 0 && a == 0 && c != 0 && m <= d))
                Console.WriteLine("Поезд стоит на платформе");

            else
                Console.WriteLine("Поезд не стоит на платформе");

            Console.ReadLine();
            return;

        }
    }
}
