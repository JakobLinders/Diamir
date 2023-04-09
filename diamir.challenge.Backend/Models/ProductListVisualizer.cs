using diamir.challenge.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace diamir.challenge.Backend
{
    public class ProductListVisualizer
    {
        private readonly IProductRepository _productRepository;

        public ProductListVisualizer(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        private void PrintProducts(IEnumerable<IProductDto> products, Currency currency)
        {
            foreach (var product in products)
            {
                Console.WriteLine("{0, 10} {1, 40} {2, 10} {3, 10}", product.Id, product.Name, product.Price * currency.Multiplier, currency.CurrencyName);
            }
        }

        public void OutputAllProduct()
        {
            var products = _productRepository.GetProducts();
            Currency currency = CurrencyHandler.GetCurrency();
            PrintProducts(products, currency);
        }
        public void OutputPaginatedProducts()
        {
            IEnumerable<IProductDto> products;
            var currency = CurrencyHandler.GetCurrency();

            var shouldRun = true;
            DisplayPageOptions();

            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing paginated products 1");
                        products = _productRepository.GetProducts(0, 5);
                        PrintProducts(products, currency);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products 2");
                        products = _productRepository.GetProducts(5, 5);
                        PrintProducts(products, currency);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("Printing paginated products 3");
                        products = _productRepository.GetProducts(10, 5);
                        PrintProducts(products, currency);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine("Printing paginated products 4");
                        products = _productRepository.GetProducts(15, 5);
                        PrintProducts(products, currency);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine("Changing Currency");
                        currency = CurrencyHandler.GetCurrency();
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayPageOptions();
            }
        }

        public void OutputProductGroupedByPriceSegment()
        {
            var products = _productRepository.GetProducts();
            Currency currency = CurrencyHandler.GetCurrency();

            var ranges = AddRanges();

            var groups = products.OrderBy(product => product.Price).GroupBy(product => ranges.FirstOrDefault(range => range >= product.Price * currency.Multiplier));

            foreach (var group in groups)
            {
                Console.WriteLine();
                Console.WriteLine($"Price range: {group.Key - 100} - {group.Key}");
                Console.WriteLine();
                foreach (var product in group)
                {
                    Console.WriteLine("{0, 10} {1, 40} {2, 10} {3, 10}", product.Id, product.Name, product.Price * currency.Multiplier, currency.CurrencyName);
                }
            }
        }
        public List<int> AddRanges()
        {
            List<int> ranges = new List<int>();

            for (int i = 0; i < 10000; i += 100)
            {
                ranges.Add(i);
            }
            return ranges;
        }

        private void DisplayPageOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Print page 1");
            Console.WriteLine("2 - Print page 2");
            Console.WriteLine("3 - Print page 3");
            Console.WriteLine("4 - Print page 4");
            Console.WriteLine("5 - Change Currency");
            Console.WriteLine("q - Quit");
        }
    }
}


