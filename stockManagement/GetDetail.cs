namespace stockManagement
{
    public class GetDetail
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
            var loop = true;
            int x = 0;
            while (loop)
            {
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    Convert.ToInt32(x);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            }
            return x;
        }

        public double AddDouble()
        {
            var loop = true;
            double x = 0.00;
            while (loop)
            {
                if (double.TryParse(Console.ReadLine(), out x))
                {
                    Convert.ToDouble(x);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid double integer.");
                }
            }
            return x;
        }
    }
}