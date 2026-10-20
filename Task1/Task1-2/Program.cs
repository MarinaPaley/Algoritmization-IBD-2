namespace Task1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double specificHeat = 2.256;
            double mass = GetNumber("Введите массу");
            double quantityHeat = GetQuantityHeat(mass, specificHeat);
            Console.WriteLine($"Количество теплоты {quantityHeat}");
        }
    }
}
