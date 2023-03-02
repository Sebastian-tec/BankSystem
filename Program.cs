namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            int choice = 0;
            do
            {
                Console.WriteLine("[1] Bank | [2] Kunde");
            } while (!int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2);

            switch (choice)
            {
                case 1:
                    Bank bank = new Bank();
                    bank.CreateBank();
                    break;
                case 2:
                    Customer customer = new();
                    customer.CreateCustomer();
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg");
                    break;
            }
        }
    }
}