using System;

namespace oopsh8
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount pers = new BankAccount(10);
            pers.Notify += DisplayMessage;
            pers.AddToAcc(5);
            Console.WriteLine($"Add: {pers.GetCash} Accounts: {pers.AccountsAmount()} ");
            pers.SubstractFromAcc(30);
            Console.WriteLine($"Substract: {pers.GetCash}");
            pers.DeleteAcc();
            Console.WriteLine($"Delete: {pers.GetCash} Accounts: {BankAccount.StaticAccountsAmount()}");
            pers.AddToAcc(2);
            Console.WriteLine($"Add to closed acc: {pers.GetCash} Accounts: {pers.GetCash}");
        }
        
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}