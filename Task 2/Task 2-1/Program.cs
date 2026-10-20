namespace Task_2_1
{
    enum ActionType
    {
        None = 0,
        Perimetr,
        Raduis
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double side = GetSide("Введите сторону многоугольника");
            int quantity = GetQuantity("Введите количество сторон");

            ActionType action = GetAtion();
            switch (action)
            {
                case ActionType.Perimetr:
                    {
                        PerimetrProcess(side, quantity);
                        break;
                    }
                case ActionType.Raduis:
                    {
                        RadiusProcess(side, quantity);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Недопустимое значение");
                        break;
                    }
            }
            
        }

        private static void RadiusProcess(double side, int quantity)
        {
            return;
        }

        private static void PerimetrProcess(double side, int quantity)
        {
            return;
        }

        private static ActionType GetAtion()
        {
            return ActionType.None;
        }

        private static int GetQuantity(string message)
        {
            Console.Write(message);
            return 42;
        }

        private static double GetSide(string message)
        {
            Console.Write(message);
            return 42;
        }
    }
}
