using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_2_1
{
    /// <summary>
    /// Определяет действие.
    /// </summary>
    enum ActionType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        None = 0,

        /// <summary>
        /// Расчет периметра.
        /// </summary>
        Perimeter,

        /// <summary>
        /// Расчет радиуса.
        /// </summary>
        Radius
    }

    /// <summary>
    /// Коды ошибок.
    /// </summary>
    enum CodeError
    {
        /// <summary>
        /// Успешное завершение программы.
        /// </summary>
        None = 0,

        /// <summary>
        /// Ошибка преобразования к вещественному типу данных.
        /// </summary>
        ErrorDouble,

        /// <summary>
        /// Ошибка преобразования к целочисленному типу данных.
        /// </summary>
        ErrorInt,

        /// <summary>
        /// Ошибка преобразования к указанному перечислимому типу данных.
        /// </summary>
        ErrorEnum,

        /// <summary>
        /// Значение меньше или равно нулю.
        /// </summary>
        ErrorLessOrEqualZero,

        /// <summary>
        /// Ошибка предметной области.
        /// </summary>
        ErrorDomain

    }

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список формальных аргументов. </param>
        static void Main(string[] args)
        {
            double side = GetSide("Введите сторону многоугольника = ");
            int quantity = GetQuantity("Введите количество сторон = ");

            ActionType action = GetAtion("Что вы хотите посчитать? Perimeter или Radius");
            switch (action)
            {
                case ActionType.Perimeter:
                    {
                        double perimeter = GetPerimetr(side, quantity);
                        Console.WriteLine($"Периметр заданного многоугольника равен {perimeter}");
                        break;
                    }
                case ActionType.Radius:
                    {
                        double radius = GetRadius(side, quantity);
                        Console.WriteLine($"Радиус вписанной окружности равен {radius}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Недопустимое значение");
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Расчет радиуса вписанной окружности.
        /// </summary>
        /// <param name="side"> Длина стороны многоугольника. </param>
        /// <param name="quantity"> Количество сторон. </param>
        /// <returns></returns>
        private static double GetRadius(double side, int quantity)
        {
            return side / (2 * Math.Tan(ConvertToRadian(180.0 / quantity)));
        }

        /// <summary>
        /// Функция преобразования из градусов в радианы.
        /// </summary>
        /// <param name="degree"> Угол в градусах. </param>
        /// <returns> Угол в радианах. </returns>
        private static double ConvertToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }

        /// <summary>
        /// Рассчитывает периметр правильного многоугольника.
        /// </summary>
        /// <param name="side"> Длина стороны многоугольника. </param>
        /// <param name="quantity"> Количество сторон. </param>
        /// <returns></returns>
        private static double GetPerimetr(double side, int quantity)
        {
            return side * quantity;
        }

        /// <summary>
        /// Считывает действие.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Действие. </returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorEnum"/>.</remarks>
        private static ActionType GetAtion(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (!Enum.TryParse(input, ignoreCase: true, out ActionType result))
            {
                Console.WriteLine("Недопустимое значение действия");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorEnum);
            }

            return result;
        }

        /// <summary>
        /// Получает количество сторон многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю.</param>
        /// <returns> Количество сторон многоугольника.</returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorDomain"/>. </remarks>
        private static int GetQuantity(string message)
        {
            int result = GetInt(message);

            if (result <= 2)
            {
                Console.WriteLine("Количество сторон должно быть больше двух");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorDomain);
            }

            return result;
        }

        /// <summary>
        /// Считывает целочисленное значение из консоли.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Целое число.</returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorInt"/>.</remarks>
        private static int GetInt(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Недопустимое значение для целого типа данных");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorInt);
            }

            return result;
        }

        /// <summary>
        /// Получаем сторону многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Сторона многоугольника. </returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorLessOrEqualZero"/>.</remarks>
        private static double GetSide(string message)
        {
            double result = GetDouble(message);

            if (result <= 0)
            {
                Console.WriteLine("Сторона должна быть больше нуля");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorLessOrEqualZero);
            }

            return result;
        }

        /// <summary>
        /// Считывает из консоли вещественное число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю.</param>
        /// <returns> Вещественное число. </returns>
        /// <remarks> Аварийно закрывает программу при неправильном вводе с кодом ошибки <see cref="CodeError.ErrorDouble"/>.</remarks>
        private static double GetDouble(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double result))
            {
                Console.WriteLine("Недопустимое значение для вещественного типа данных");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorDouble);
            }

            return result;
        }
    }
}
