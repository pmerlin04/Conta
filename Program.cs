using ExceptionAccount.Entities;
using ExceptionAccount.Entities.Exceptions;
using System.Globalization;

namespace ExceptionAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Fazer um programa para ler os dados de uma conta bancária e depois realizar um
            saque nesta conta bancária, mostrando o novo saldo. Um saque não pode ocorrer
            ou se não houver saldo na conta, ou se o valor do saque for superior ao limite de
            saque da conta. Implemente a conta bancária conforme projeto abaixo:
            */
            try
            {


                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw Limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, balance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account.WithDraw(amount);

                Console.Write(account);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error in format: " + e.Message);
            }

        }
    }
}
