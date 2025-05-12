using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using CurrencyCource.Models;
using CurrencyCource.Services.IServices;

namespace CurrencyCource.Services
{
    public class CustomerService : ICustomerService
    {
        public string FilePath { get; set; } = "Customer.json";

        /*-----------------Registration-----------------*/
        public string Registration(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("----------------Customer Registration-----------------\n");

            /*--------------First Name----------------*/

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.Write("First name cannot be empty. Try again: ");
                }
                else if (firstName.Length < 3)
                {
                    Console.Write("First name must be at least 3 characters long. Try again: ");
                }
                else if (firstName.Length > 40)
                {
                    Console.Write("First name must be less than 40 characters long. Try again: ");
                }
                else if (!char.IsUpper(firstName[0]))
                {
                    Console.Write("First name must start with an uppercase letter. Try again: ");
                }
                else if (!firstName.All(c => char.IsLetter(c)))
                {
                    Console.Write("First Name must contain only letters. Try again: ");
                }
                else
                {
                    customer.FirstName = firstName;
                    break;
                }
                firstName = Console.ReadLine();
            }


            /*--------------Last Name----------------*/

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.Write("Last name cannot be empty. Try again: ");
                }
                else if (lastName.Length < 3)
                {
                    Console.Write("Last name must be at least 3 characters long. Try again: ");
                }
                else if (lastName.Length > 40)
                {
                    Console.Write("Last name must be less than 40 characters long. Try again: ");
                }
                else if (!char.IsUpper(lastName[0]))
                {
                    Console.Write("Last name must start with an uppercase letter. Try again: ");
                }
                else if (!lastName.All(c => char.IsLetter(c)))
                {
                    Console.Write("Last Name must contain only letters. Try again: ");
                }
                else
                {
                    customer.LastName = lastName;
                    break;
                }
                lastName = Console.ReadLine();
            }

            /*--------------Age----------------*/

            Console.Write("Enter Age: ");
            string ageInput = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(ageInput))
                {
                    Console.Write("Age cannot be empty. Try again: ");
                }
                else if (!int.TryParse(ageInput, out int age))
                {
                    Console.Write("Age must be a valid number. Try again: ");
                }
                else if (age < 18 || age > 50)
                {
                    Console.Write("Age must be between 18 and 50. Try again: ");
                }
                else
                {
                    customer.Age = age;
                    break;
                }
                ageInput = Console.ReadLine();
            }

            /*--------------Email----------------*/

            Console.Write("Email: ");
            string email = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.Write("Email cannot be empty. Please try again: ");
                }
                else if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.Write("Email must contain '@' and '.' characters. Please try again: ");
                }
                else
                {
                    customer.Email = email;
                    break;
                }
                email = Console.ReadLine();
            }

            /*--------------Password----------------*/

            Console.Write("Password: ");
            string password = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.Write("Password can not be empty!");
                }
                else if (password.Length < 8)
                {
                    Console.Write("Password can not be less 8 characters!");
                }
                else if (!password.Any(char.IsUpper))
                {
                    Console.Write("Password must contain at least one uppercase letter!");
                }
                else if (!password.Any(char.IsLower))
                {
                    Console.Write("Password must contain at least one lowercase letter!");
                }
                else if (!password.Any(char.IsDigit))
                {
                    Console.Write("Password must contain at leat one digit!");
                }
                else if (!password.Any(ch => "!@#$%^&*()-_=+[{]};:'\",<.>/?".Contains(ch)))
                {
                    Console.Write("Password must contain at least one special character!");
                }
                else
                {
                    customer.Password = password;
                    break;
                }
                password = Console.ReadLine();
            }


            /*--------------Birth of date----------------*/

            Console.WriteLine("Date of Birth (yyyy-mm-dd): ");
            int year, month, day;

            Console.Write("Enter Year: ");
            string yearInput = Console.ReadLine();

            while (true)
            {
                if (int.TryParse(yearInput, out year))
                {
                    if (year >= 1900 && year <= DateTime.Now.Year)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"Year must be between 1970 and {DateTime.Now.Year}. Try again: ");
                    }
                }
                else
                {
                    Console.Write("Invalid year. Enter a valid number: ");
                }
                yearInput = Console.ReadLine();
            }

            Console.Write("Enter Month (1 - 12): ");
            string monthInput = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(monthInput, out month))
                {
                    if (month >= 1 && month <= 12)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Month must be between 1 and 12. Try again: ");
                    }
                }
                else
                {
                    Console.Write("Invalid month. Enter a valid number: ");
                }
                monthInput = Console.ReadLine();
            }

            Console.Write("Enter Day: ");
            string dayInput = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(dayInput, out day))
                {
                    if (DateTime.TryParse($"{year}-{month}-{day}", out DateTime kun))
                    {
                        customer.DateOfBirth = kun;
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid day for the given month/year. Try again: ");
                    }
                }
                else
                {
                    Console.Write("Invalid day. Enter a valid number: ");
                }
                dayInput = Console.ReadLine();
            }
            customer.DateOfBirth = new DateTime(year, month, day);


            /* ----------------- Phone Number ------------------ */

            Console.Write("Phone Number (Start With '+998'):  ");
            string phoneNumber = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Console.WriteLine("Phone number cannot be empty. Please try again: ");
                }
                else if (phoneNumber.Length != 13 || !phoneNumber.StartsWith("+998"))
                {
                    Console.WriteLine("Phone number must be in the format +998XXXXXXXXX. Please try again: ");
                }
                else
                {
                    customer.PhoneNumber = phoneNumber;
                    break;
                }
                phoneNumber = Console.ReadLine();
            }


            /* ----------------- Balance ------------------ */

            Console.Write("Balance: ");
            string balance = Console.ReadLine();
            while (true)
            {
                if (decimal.TryParse(balance, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal money))
                {
                    if (money > 0)
                    {
                        customer.Balance = money;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Balance must be greater than 0. Please try again: ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid balance. Please enter a valid number: ");
                }
                balance = Console.ReadLine();
            }


            Customer addCustomer = new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Password = customer.Password,
                Balance = customer.Balance
            };

            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }


            customers.Add(addCustomer);
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, jsonString);

            return $"{customer.FirstName} {customer.LastName}! Your registration is successfull!";
        }


        /*-----------------Login-----------------*/

        public string Login()
        {
            Console.Clear();
            Console.WriteLine("----------------Login-----------------\n");

            Console.Write("Enter ID: ");
            string idInput = Console.ReadLine();

            Guid id;
            while (true)
            {
                if (string.IsNullOrWhiteSpace(idInput))
                {
                    Console.Write("Id cannot be empty. Try again: ");
                }
                else if (!Guid.TryParse(idInput, out id))
                {
                    Console.Write("Id must be a valid GUID. Try again: ");
                }
                else
                {
                    break;
                }
                idInput = Console.ReadLine();
            }


            Console.Write("Password: ");
            string password = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.Write("Password can not be empty!");
                }
                else if (password.Length < 8)
                {
                    Console.Write("Password can not be less 8 characters!");
                }
                else if (!password.Any(char.IsUpper))
                {
                    Console.Write("Password must contain at least one uppercase letter!");
                }
                else if (!password.Any(char.IsLower))
                {
                    Console.Write("Password must contain at least one lowercase letter!");
                }
                else if (!password.Any(char.IsDigit))
                {
                    Console.Write("Password must contain at leat one digit!");
                }
                else if (!password.Any(ch => "!@#$%^&*()-_=+[{]};:'\",<.>/?".Contains(ch)))
                {
                    Console.Write("Password must contain at least one special character!");
                }
                else
                {
                    break;
                }
                password = Console.ReadLine();
            }


            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            Customer? customer = customers.FirstOrDefault(c => c.Id == id && c.Password == password);
            if (customer != null)
            {
                return $"\nWelcome {customer.FirstName} {customer.LastName}!";
            }
            else
            {
                return "Invalid ID or password. Please try again.";
            }
        }


        /*-------------------Enter System--------------------*/

        public async Task<string> EnterSystem()
        {
            Console.WriteLine("-----------------Welcome to Currency Exchange Service------------------\n");

            while (true)
            {
                Console.WriteLine("Please select an option:\n");
                Console.WriteLine("1. Update Profile");
                Console.WriteLine("2. Get Balance");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Exchange Currency");
                Console.WriteLine("6. Exit");
                Console.WriteLine("-----------------------------------------------------\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        UpdateProfile(new Customer());
                        break;
                    case "2":
                        GetBalance();
                        break;
                    case "3":
                        Deposit();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        string result = ExchangeCurrency().GetAwaiter().GetResult();
                        Console.WriteLine("\n" + result);
                        break;
                    case "6":
                        return "Exiting the program...";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }







    }
}