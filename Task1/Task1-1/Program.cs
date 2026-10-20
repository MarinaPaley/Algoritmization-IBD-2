using System;

namespace Task1_1
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная функция.
        /// </summary>
        /// <param name="args"> Список параметров. </param>
        static void Main(string[] args)
        {
            const double a = 2;
            const double b = 1;
            const double c = 3;
            double x = GetNumber("Введите x =");
            double y = GetResult(a, b, c, x);

            Console.WriteLine($"x = {x}, y = {y}");
        }

        /// <summary>
        /// Расчет заданной функции.
        /// </summary>
        /// <param name="a"> Константа а. </param>
        /// <param name="b"> Константа b. </param>
        /// <param name="c"> Константа c. </param>
        /// <param name="x"> Константа x. </param>
        /// <returns></returns>
        private static double GetResult(double a, double b, double c, double x)
        {
            return (a * Math.Abs(x * x * x) + 5.0 / 2 * b * Math.Sqrt(x * x + 1)) /
                            (c + Math.Sin(x) * Math.Cos(x));
        }

        /// <summary>
        /// Считывает из консоли число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Считанное число.</returns>
        private static double GetNumber(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return double.Parse(input);
        }
    }
}