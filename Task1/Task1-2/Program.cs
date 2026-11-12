namespace Task1_2
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const double specificHeat = 2.256;
            double mass = GetNumber("Введите массу");
            double quantityHeat = GetQuantityHeat(mass, specificHeat);
            Console.WriteLine($"Количество теплоты {quantityHeat}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="specificHeat"></param>
        /// <returns></returns>
        private static double GetQuantityHeat(double mass, double specificHeat)
        {
            return 42;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static double GetNumber(string message)
        {
            return 42;
        }


    }
}
