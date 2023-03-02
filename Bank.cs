using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Bank
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Customer> customers = new List<Customer>();
        private static int _id = 0;

        public Bank()
        {

        }
        public Bank(string name, string password)
        {
            id = Interlocked.Increment(ref _id);
            this.Name = name;
            this.Password = password;
        }

        public void CreateBank()
        {
            Customer customer = new Customer();
            this.customers.AddRange(customer.CreateCustomers());
            Console.WriteLine("*----- OPRET BANK -----*");
            Console.Write("Navn: ");
            this.Name = Console.ReadLine();
            Console.Write("Password: ");
            this.Password = Console.ReadLine();
            Console.WriteLine("*----- BANK OPRETTET -----*");
            BankMain();
        }

        public void BankMain()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("[1] Opret kunde | [2] Vis kunder");
            } while (!int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2);

            switch (choice)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    PrintCustomers();
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg");
                    BankMain();
                    break;
            }
        }
        public void AddCustomer()
        {
            Customer customer = new();
            Console.WriteLine("*----- OPRET KUNDE -----*");
            Console.Write("Navn: ");
            customer.Name = Console.ReadLine();
            Console.Write("Mail: ");
            customer.Mail = Console.ReadLine();
            Console.Write("Password: ");
            customer.Password = Console.ReadLine();
            customer.BankId = this.id;
            Console.WriteLine("*----- KUNDE OPRETTET -----*");
            customers.Add(customer);
            BankMain();
        }

        public void PrintCustomers()
        {
            foreach (var customer in customers)
            {
                if (customer.BankId == this.id)
                {
                    Console.WriteLine(customer.ToString());
                    foreach (var konto in customer.KontoList)
                    {
                        Console.WriteLine(konto.ToString());
                    }
                }

            }
            BankMain();
        }

        public List<Bank> CreateBanks()
        {
            List<Bank> banks = new List<Bank>();

            Bank bank = new Bank("Nordea", "stort-n");
            banks.Add(bank);
            Bank bank1 = new Bank("Jyske Bank", "Marker");
            banks.Add(bank1);
            Bank bank2 = new Bank("Danske Bank", "København");
            banks.Add(bank2);
            Bank bank3 = new Bank("Sparekassen", "Money");
            banks.Add(bank3);
            return banks;
        }
    }
}
