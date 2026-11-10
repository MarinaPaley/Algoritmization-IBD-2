namespace Task_2_1
{
    /// <summary>
    /// Действия.
    /// </summary>
    enum ActionType
    {
        /// <summary>
        /// По умолчанию.
        /// </summary>
        None = 0,
        /// <summary>
        /// Периметр.
        /// </summary>
        Perimeter,
        /// <summary>
        /// Радиус.
        /// </summary>
        Radius
    }

    /// <summary>
    /// Коды ошибок
    /// </summary>
    enum ErrorCode
    {
        /// <summary>
        /// Успешное выполнение программы.
        /// </summary>
        None,
        /// <summary>
        /// Ошибка преобразования вещественного числа.
        /// </summary>
        ErrorDouble,
        /// <summary>
        /// Ошибка преобразования целого числа.
        /// </summary>
        ErrorInt,
        /// <summary>
        /// Ошибка преобразования в заданный перечислимый тип.
        /// </summary>
        ErrorEnum,
        /// <summary>
        /// Ошибка. Число меньше или равно нулю.
        /// </summary>
        ErrorLessOrEqualZero,
        /// <summary>
        /// Ошибка предметной области.Невозможно построить многоугольник.
        /// </summary>
        ErrorDomain
    }

    /// <summary>
    /// Главная программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа.
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
        /// Получаем радиус вписанной окружности.
        /// </summary>
        /// <param name="side"> Сторона правильного многоугольника.</param>
        /// <param name="quantity"> Количество сторон правильного многоугольника. </param>
        /// <returns> Радиус вписанной окружности правильного многоугольника. </returns>
        private static double GetRadius(double side, int quantity)
        {
            return side / (2 * Math.Tan(ConvertToRadian(180.0 / quantity)));
        }

        /// <summary>
        /// Преобразует градусы в радианы.
        /// </summary>
        /// <param name="degree"> Градусы. </param>
        /// <returns> Радианы.</returns>
        private static double ConvertToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }

        /// <summary>
        /// Получает периметр правильного многоугольника.
        /// </summary>
        /// <param name="side"> Сторона правильного многоугольника.</param>
        /// <param name="quantity"> Количество сторон правильного многоугольника.</param>
        /// <returns> Периметр правильного многоугольника.</returns>
        private static double GetPerimetr(double side, int quantity)
        {
            return side * quantity;
        }

        /// <summary>
        /// Считывает из консоли необходимое действие.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Значение перечислимого типа. </returns>
        /// <remarks> Аварийно закрывает программу в случае неправильно введенного действия с кодом ошибки <see cref="ErrorCode.ErrorEnum"/>.</remarks>
        private static ActionType GetAtion(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (!Enum.TryParse(input, ignoreCase: true, out ActionType result))
            {
                Console.WriteLine("Введено недопустимое значение");
                Environment.Exit((int)ErrorCode.ErrorEnum);
            }

            return result;
        }

        /// <summary>
        /// Получает количество сторон правильного многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Количество сторон правильного многоугольника. </returns
        /// <remarks> Аварийно закрывает программу в случае невозможности построить многоугольник с кодом ошибки <see cref="ErrorCode.ErrorDomain"/>.</remarks>
        private static int GetQuantity(string message)
        {
            int result = GetInt(message);

            if (result <= 2)
            {
                Console.WriteLine("Количество сторон должно быть не меньше трех");
                Environment.Exit((int)ErrorCode.ErrorDomain);
            }

            return result;
        }

        /// <summary>
        /// Получает из консоли целое число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Целое число. </returns>
        /// <remarks> Аварийно завершает программу в случае неправильного ввода целого числа с кодом ошибки <see cref="ErrorCode.ErrorInt"/></remarks>
        private static int GetInt(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Введено не целочисленное число");
                Environment.Exit((int)ErrorCode.ErrorInt);
            }

            return result;
        }

        /// <summary>
        /// Получает сторону многоугольника.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Сторону многоугольника. </returns>
        private static double GetSide(string message)
        {
            double result = GetDouble(message);

            if (result <= 0)
            {
                Console.WriteLine("Сторона должна быть больше нуля");
                Environment.Exit((int)ErrorCode.ErrorLessOrEqualZero);
            }

            return result;
        }

        /// <summary>
        /// Получает вещественное число из консоли.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Вещественное число. </returns>
        /// <remarks> Аварийно завершает программу в случае неправильного ввода целого числа с кодом ошибки <see cref="ErrorCode.ErrorDouble"/></remarks>
        private static double GetDouble(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double result))
            {
                Console.WriteLine("Введено не вещественное число");
                Environment.Exit((int)ErrorCode.ErrorDouble);
            }

            return result;
        }
    }

}
