using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Konto : Bank
    {
        public double balance { get; set; }
        public Customer customer { get; set; }
        public int AccNumber { get; set; }
        private int _id;

        public Konto(string name, double balance, Customer customer)
        {
            this.id = Interlocked.Increment(ref _id);
            this.Name = name;
            this.balance = balance;
            this.customer = customer;
            this.AccNumber = customer.AccNumber;
        }

        public void KontoMain()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("[1] Vis saldo | [2] Indsæt penge | [3] Hæv penge");
            } while (!int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3);

            switch (choice)
            {
                case 1:
                    PrintBalance();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg");
                    KontoMain();
                    break;
            }
        }
        public override string ToString()
        {
            return $"Konto: {id} - {Name} - {balance} - {customer}";
        }

        public void PrintBalance()
        {
            Console.WriteLine($"\n[{id}] Konto: {Name}\n Saldo: {balance} Bruger: {customer}");
            KontoMain();
        }
        public void Deposit()
        {
            PrintBalance();
            Console.Write("Indsæt penge: ");

            balance += Convert.ToDouble(Console.ReadLine());
            KontoMain();
        }

        public void Withdraw()
        {
            PrintBalance();
            Console.Write("Hæv penge: ");
            balance -= Convert.ToDouble(Console.ReadLine());
            KontoMain();
        }
    }
}
