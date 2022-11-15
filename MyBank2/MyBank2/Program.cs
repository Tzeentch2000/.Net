// See https://aka.ms/new-console-template for more information
using MyBank2;

Console.WriteLine("Hello, World!");

try
{
    var account_1 = new BankAcount("Guillermo", 5000);
    var account_2 = new BankAcount("Lucía", 2000);
    Console.WriteLine($"{account_1.Number} de {account_1.Owner} con {account_1.Balance}");
    Console.WriteLine($"{account_2.Number} de {account_2.Owner} con {account_2.Balance}");

    account_1.MakeDeposit(200,DateTime.Now,"Baloncesto");
    account_1.MakeWithdrawal(700,DateTime.Now,"Viaje");
    Console.WriteLine($"{account_1.Number} de {account_1.Owner} con {account_1.Balance}");
    Console.WriteLine("\n\n");
    Console.WriteLine(account_1.history());

} catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
} catch(InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}