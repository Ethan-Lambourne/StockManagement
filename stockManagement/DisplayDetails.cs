namespace stockManagement
{
    public class DisplayDetails
    {
        public int laptopStock;
        public int graphicsCardStock;
        public double totalLaptopValue;
        public double totalGraphicsCardValue;

        public void ResetStocksAndValues()
        {
            laptopStock = 0;
            graphicsCardStock = 0;
            totalLaptopValue = 0;
            totalGraphicsCardValue = 0;
        }

        public void DisplayReportSummary()
        {
            Console.WriteLine($"\nLaptop stock: \t\t\t{laptopStock}" +
                $"\nGraphics card stock: \t\t{graphicsCardStock}" +
                $"\nTotal stock: \t\t\t{laptopStock + graphicsCardStock}" +
                $"\n\nTotal laptop value: \t\t£{totalLaptopValue}" +
                $"\nTotal graphics card value: \t£{totalGraphicsCardValue}" +
                $"\nTotal value of all items: \t£{totalLaptopValue + totalGraphicsCardValue}");
        }
    }
}