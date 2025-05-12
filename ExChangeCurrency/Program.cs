
using CurrencyCource.Models;
using CurrencyCource.Services;

namespace CurrencyCource
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("-----------------Welcome to Currency Exchange Service------------------\n");

            CustomerService customerService = new CustomerService();

            Console.Clear();
            while (true)
            {
                Console.WriteLine("Please select an option:\n");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-----------------------------------------------------\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(customerService.Registration(new Customer()));
                        Console.WriteLine();

                        break;
                    case "2":
                        Console.WriteLine(customerService.Login());
                        Console.WriteLine();

                        await customerService.EnterSystem();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return;
                }

            }
        }
    }
}