using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp9
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

            Random ran = new Random();

            int n, sum = 0;

            Console.Write("Введите длину текста = ");

            n = Convert.ToInt32(Console.ReadLine());

            if (n < 1)
            {
                Console.Write("Неверно введено число");

                return;
            }

            int[] mas = new int[n];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = ran.Next(1, 10);

                if (i == 0) sum += mas[i];
                if (i % 2 == 1) sum += mas[i];
                if (i % 2 == 0 && i != 0) sum -= mas[i];

                if (i % 2 == 0 && i != n - 1) Console.Write(mas[i] + " + ");
                if (i % 2 == 1 && i != n - 1) Console.Write(mas[i] + " - ");
                if (i == n - 1) Console.Write(mas[i] + " = " + sum);
            }
        }
    }
}
