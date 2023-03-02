using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Customer : Bank
    {
        public string Mail { get; set; }
        public string Password { get; set; }

        public int AccNumber { get; set; }
        public List<Konto> KontoList { get; set; } = new List<Konto>();

        public int BankId { get; set; }

        public List<Bank> Banks { get; set; } = new List<Bank>();

        private int _id;

        public Customer()
        {
            id = Interlocked.Increment(ref _id);
        }
        public Customer(string name, string mail, string password, int bankid)
        {
            this.BankId = bankid;
            id = Interlocked.Increment(ref _id);
            this.Name = name;
            Mail = mail;
            Password = password;
            AccNumber = GenerateAccountNumber();
        }

        public void CreateCustomer()
        {
            Bank bank = new Bank();

            this.Banks.AddRange(bank.CreateBanks());
            Console.WriteLine("*----- OPRET KUNDE -----*");
            Console.Write("Navn: ");
            this.Name = Console.ReadLine();
            Console.Write("Mail: ");
            this.Mail = Console.ReadLine();
            Console.Write("Password: ");
            this.Password = Console.ReadLine();
            Console.WriteLine("*----- KUNDE OPRETTET -----*");
            
            foreach (var item in Banks)
            {
                Console.WriteLine($"[{item.id}] {item.Name}");
            }
            
            int choice = 0;
            do
            {
                Console.Write("Vælg bank: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) && choice < Banks.Count);
            this.BankId = choice;

            CustomerMain();

        }
        public void CustomerMain()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("[1] Vis oplysninger | [2] Tilføj konto | [3] Vis kontoer | [4] Administrer konto");
            } while (!int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3);

            switch (choice)
            {
                case 1:
                    Console.WriteLine(this.ToString());
                    break;
                case 2:
                    CreateKonto();
                    break;
                case 3:
                    ShowKontos();
                    break;
                case 4:

                default:
                    Console.WriteLine("Ugyldigt valg");
                    CustomerMain();
                    break;
            }
        }
        public override string ToString()
        {
            return $"Customer: {Name} [{id}] - {Mail} - {Password}\nKontoNummer: {AccNumber} Konto(er): {KontoList.Count}";
        }


        public int GenerateAccountNumber() // Ligesom i en rigtig bank :tm: <- watermark
        {
            Random rnd = new Random();
            int Number = 0;

            for (int i = 0; i < 16; i++)
            {
                Number += rnd.Next(10);
            }
            return Number;
        }

        public void CreateKonto()
        {
            Console.Write("Kontonavn: ");
            Konto konto = new(Console.ReadLine(), 0, this);
            KontoList.Add(konto);
            konto.KontoMain();
        }

        public void ShowKontos( )
        {
            Console.WriteLine($"{Name} konto(er):\n");
            foreach (var item in KontoList)
            {
                Console.WriteLine($"Kontonavn: {item.Name} KontoNummer: {item.AccNumber}\nSaldo: {item.balance}");
            }
            CustomerMain();
        }

        public void AdminKonto()
        {
            foreach (var item in KontoList)
            {
                Console.WriteLine($"[{item.id}] {item.Name}");
            }
            int choice = 0;

            do
            {
                Console.Write("Vælg konto-id: ");
            } while (!int.TryParse(Console.ReadLine(), out choice));

            Konto konto = KontoList[choice];
            konto.KontoMain();
        }

        public List<Customer> CreateCustomers()
        {
            List<Customer> list = new List<Customer>();
            Customer customer = new Customer("Seb", "seb@gmail.com", "seb7", 2);
            list.Add(customer);
            Customer customer1 = new Customer("Mads", "madsmail@live.dk", "nordea-mads", 0);
            list.Add(customer1);
            Customer customer2 = new Customer("Morten", "mort@outlook.com", "morteren", 1);
            list.Add(customer2);
            Customer customer3 = new Customer("Mikkel", "Mikker21@gmail.com", "MikkelPuds", 3);
            list.Add(customer3);
            Customer customer4 = new Customer("Emma", "emma@example.com", "emma123", 1);
            list.Add(customer4);
            Customer customer5 = new Customer("Jack", "jack@email.com", "jack11", 2);
            list.Add(customer5);
            Customer customer6 = new Customer("Liam", "liam@mail.com", "liam99", 0);
            list.Add(customer6);
            Customer customer7 = new Customer("Olivia", "olivia@yahoo.com", "olivia123", 3);
            list.Add(customer7);
            Customer customer8 = new Customer("Sophia", "sophia@hotmail.com", "sophia22", 1);
            list.Add(customer8);

            return list;

        }
    }
}
