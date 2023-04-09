using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diamir.challenge.Backend.Models
{
    public class CurrencyHandler
    {
        public static Currency GetCurrency()
        {
            Console.Write("Choose Currency: ");
            DisplayCurrencyOptions();
            var input = Console.ReadKey();
            Console.WriteLine("\n");
            switch (input.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.WriteLine("You chose USD");
                    return new Currency { CurrencyName = "USD", Multiplier = 1.00M };
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.WriteLine("You chose GBP");
                    return new Currency { CurrencyName = "GBP", Multiplier = 0.71M };
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.WriteLine("You chose SEK");
                    return new Currency { CurrencyName = "SEK", Multiplier = 8.38M };
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.WriteLine("You chose DKK");
                    return new Currency { CurrencyName = "DKK", Multiplier = 6.06M };
                default:
                    return new Currency { CurrencyName = "USD", Multiplier = 1.00M };
            }
            Console.WriteLine();

        }

        private static void DisplayCurrencyOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - USD");
            Console.WriteLine("2 - GBP");
            Console.WriteLine("3 - SEK");
            Console.WriteLine("4 - DKK");
        }
    }
}
