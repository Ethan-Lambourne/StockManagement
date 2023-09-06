﻿using stockManagement.Models;
using stockManagement.Repos;

namespace stockManagement.Details
{
    public class AddDetail
    {
        public readonly LaptopRepository _laptopRepository;
        public readonly GraphicsCardRepository _graphicsCardRepository;

        public AddDetail(LaptopRepository laptopRepository, GraphicsCardRepository graphicsCardRepository)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

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

        public int GenerateID()
        {
            List<int> ExistingIDs = new();
            foreach (Laptop laptop in _laptopRepository.LaptopList)
            {
                ExistingIDs.Add(laptop.ID);
            }
            foreach (GraphicsCard graphicsCard in _graphicsCardRepository.GraphicsCardList)
            {
                ExistingIDs.Add(graphicsCard.ID);
            }
            int ID = 1;
            bool isInList = ExistingIDs.IndexOf(ID) != -1;
            while (isInList == true)
            {
                ID++;
                isInList = ExistingIDs.IndexOf(ID) != -1;
            }
            return ID;
        }
    }
}