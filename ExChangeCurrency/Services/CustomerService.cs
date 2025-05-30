﻿using System;
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


        /*-----------------UpdateProfile-----------------*/

        public string UpdateProfile(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("----------------Update Profile-----------------\n");

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


            /* -----------------Balance ------------------ */

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

            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            Customer? existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                customer = existingCustomer;
            }
            else
            {
                return "Customer not found.";
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Age = customer.Age;
            existingCustomer.DateOfBirth = customer.DateOfBirth;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Password = customer.Password;
            existingCustomer.Balance = customer.Balance;

            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, jsonString);


            return "Update profile is successfull!";
        }


        /*-----------------Get Balance-----------------*/
        public void GetBalance()
        {
            Console.Clear();
            Console.WriteLine("----------------Get Balance-----------------\n");

            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

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

            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine($"\nYour Balance: {customer.Balance}\n");
            }
        }


        /*-----------------Deposit-----------------*/

        public void Deposit()
        {
            Console.Clear();
            Console.WriteLine("----------------Deposit-----------------\n");

            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

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

            Console.Write("Enter Amount: ");
            string amountInput = Console.ReadLine();

            decimal amount;
            while (true)
            {
                if (string.IsNullOrWhiteSpace(amountInput))
                {
                    Console.Write("Amount cannot be empty. Try again: ");
                }
                else if (!decimal.TryParse(amountInput, out amount))
                {
                    Console.Write("Amount must be a valid number. Try again: ");
                }
                else if (amount <= 0)
                {
                    Console.Write("Amount must be greater than 0. Try again: ");
                }
                else
                {
                    break;
                }
                amountInput = Console.ReadLine();
            }


            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
            }
            else
            {
                customer.Balance += amount;
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(FilePath, jsonString);

                Console.WriteLine($"\nYour Balance: {customer.Balance}\n");
            }
        }


        /*-----------------Withdraw-----------------*/

        public void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("----------------Withdraw-----------------\n");

            List<Customer> customers = new List<Customer>();
            if (File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

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

            Console.Write("Enter Amount: ");
            string amountInput = Console.ReadLine();

            decimal amount;
            while (true)
            {
                if (string.IsNullOrWhiteSpace(amountInput))
                {
                    Console.Write("Amount cannot be empty. Try again: ");
                }
                else if (!decimal.TryParse(amountInput, out amount))
                {
                    Console.Write("Amount must be a valid number. Try again: ");
                }
                else if (amount <= 0)
                {
                    Console.Write("Amount must be greater than 0. Try again: ");
                }
                else
                {
                    break;
                }
                amountInput = Console.ReadLine();
            }

            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
            }
            else
            {
                if (customer.Balance <= amount)
                {
                    Console.WriteLine("Insufficient balance.\n");
                }
                else
                {
                    customer.Balance -= amount;
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(FilePath, jsonString);

                    Console.WriteLine($"\nYour Balance{customer.Balance}\n");
                    Console.WriteLine();
                }
            }
        }


        /*-----------------ExchangeCurrency-----------------*/

        public async Task<string> ExchangeCurrency()
        {
            Console.Clear();
            Console.WriteLine("\n----------------Exchange Currency-----------------\n");

            HttpClient client = new HttpClient();
            string url = "https://cbu.uz/oz/arkhiv-kursov-valyut/json/all/2018-12-11/";

            try
            {
                var response = await client.GetStringAsync(url);
                var currencies = JsonSerializer.Deserialize<List<Currency>>(response);

                Console.WriteLine("Currencies:");
                foreach (var currency in currencies)
                {
                    Console.WriteLine($"{currency.id} - {currency.Ccy} - {currency.CcyNm_UZ} - {currency.Rate} so'm");
                }

                Console.Write("\nEnter currency code (eg: USD): ");
                string ccy = Console.ReadLine().ToUpper();

                while (true)
                {
                    if (string.IsNullOrWhiteSpace(ccy))
                    {
                        Console.Write("Currency code cannot be empty. Try again: ");
                    }
                    else if (ccy.Length != 3)
                    {
                        Console.Write("Currency code must be 3 characters long. Try again: ");
                    }
                    else if (!ccy.All(c => char.IsLetter(c)))
                    {
                        Console.Write("Currency code must contain only letters. Try again: ");
                    }
                    else if (currencies.Any(c => c.Ccy == ccy))
                    {
                        break;
                    }
                    ccy = Console.ReadLine().ToUpper();
                }

                var selectedCurrency = currencies.FirstOrDefault(c => c.Ccy == ccy);
                if (selectedCurrency == null)
                {
                    return "Invalid: This currency is notfound!";
                }

                Console.WriteLine("1. From Sum To Currency");
                Console.WriteLine("2. From Currency To Sum");
                Console.Write("Enter your choice: ");
                int direction = int.Parse(Console.ReadLine());

                while (true)
                {
                    if (direction != 1 && direction != 2)
                    {
                        Console.Write("Invalid choice. Please enter 1 or 2: ");
                    }
                    else
                    {
                        break;
                    }
                    direction = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                while (true)
                {
                    if (amount <= 0)
                    {
                        Console.Write("Amount must be greater than 0. Try again: ");
                    }
                    else
                    {
                        break;
                    }
                    amount = decimal.Parse(Console.ReadLine());
                }

                decimal rate = decimal.Parse(selectedCurrency.Rate, System.Globalization.CultureInfo.InvariantCulture);

                decimal result = 0;

                if (direction == 1)
                {
                    result = amount / rate;
                    return $"{amount} so'm = {result:F2} {ccy}\n";
                }
                else if (direction == 2)
                {
                    result = amount * rate;
                    return $"{amount} {ccy} = {result:F2} so'm\n";
                }
                else
                {
                    return "Invalid choise!";
                }
            }
            catch (Exception ex)
            {
                return $"Invalid error: {ex.Message}";
            }
        }
    }
}