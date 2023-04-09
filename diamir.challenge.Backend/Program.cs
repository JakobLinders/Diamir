using diamir.challenge.Backend.Models;
using StructureMap;
using System;

namespace diamir.challenge.Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new ProductRegistry());

            var productListVisualizer = container.GetInstance<ProductListVisualizer>();

            var shouldRun = true;
            DisplayOptions();

            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing all products");
                        productListVisualizer.OutputAllProduct();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        productListVisualizer.OutputPaginatedProducts();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("Printing products grouped by price");
                        productListVisualizer.OutputProductGroupedByPriceSegment();
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayOptions();
            }

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("WELCOME TO DIAMIR CHALLENGE: Choose an option:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine("q - Quit");
        }
    }
}