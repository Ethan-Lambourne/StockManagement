using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.Details
{
    public class AddDetail
    {
        public string AddType()
        {
            int typeChoice;
            if (int.TryParse(Console.ReadLine(), out typeChoice))
            {
                switch (typeChoice)
                {
                    case 1:
                        return "laptop";

                    case 2:
                        return "graphics card";

                    default:
                        Console.WriteLine("Please enter a valid input (1 or 2).");
                        return AddType();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
                return AddType();
            }
        }

        public string AddName()
        {
            string? name = string.Empty;
            while (string.IsNullOrEmpty(name))
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be null, try again.");
                }
            }
            return name;
        }

        public int AddInt()
        {
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Please enter a valid integer.");
            }
            return x;
        }

        public double AddDouble()
        {
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Please enter a valid double integer.");
            }
            return x;
        }
    }
}