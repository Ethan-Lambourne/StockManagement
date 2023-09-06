﻿using stockManagement.Models;
using stockManagement.Repos;

namespace stockManagement.Details
{
    public class DisplayDetails
    {
        public int laptopStock;
        public int graphicsCardStock;
        public double totalLaptopValue;
        public double totalGraphicsCardValue;

        public readonly LaptopRepository _laptopRepository;
        public readonly GraphicsCardRepository _graphicsCardRepository;

        public DisplayDetails(LaptopRepository laptopRepository, GraphicsCardRepository graphicsCardRepository)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

        public void CalculateStocksAndValues()
        {
            laptopStock = 0;
            graphicsCardStock = 0;
            totalLaptopValue = 0;
            totalGraphicsCardValue = 0;
            foreach (Laptop item in _laptopRepository.LaptopList)
            {
                laptopStock += item.Stock;
                totalLaptopValue += item.Price;
            }
            foreach (GraphicsCard item in _graphicsCardRepository.GraphicsCardList)
            {
                graphicsCardStock += item.Stock;
                totalGraphicsCardValue += item.Price;
            }
        }

        public void DisplayAllItemsInStock()
        {
            foreach (Laptop item in _laptopRepository.LaptopList)
            {
                Console.WriteLine(item.ToString());
            }
            foreach (GraphicsCard item in _graphicsCardRepository.GraphicsCardList)
            {
                Console.WriteLine(item.ToString());
            }
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