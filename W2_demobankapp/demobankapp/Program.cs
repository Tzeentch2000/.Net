using Classes;

try
{
    BankAccount account = new BankAccount("Alex", 1000);
    Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
    Console.WriteLine(account.GetAccountHistory());

    BankAccount accountVanessa = new BankAccount("Vanessa", 10000);
    Console.WriteLine($"Account {accountVanessa.Number} was created for {accountVanessa.Owner} with {accountVanessa.Balance} initial balance.");
    accountVanessa.MakeWithdrawal(500, DateTime.Now, "Rent payment");
    Console.WriteLine(accountVanessa.Balance);
    accountVanessa.MakeDeposit(100, DateTime.Now, "Friend paid me back");
    Console.WriteLine(accountVanessa.Balance);
    Console.WriteLine(accountVanessa.GetAccountHistory());

   // accountVanessa.MakeWithdrawal(50000, DateTime.Now, "Rent payment");
    //Console.WriteLine(accountVanessa.Balance);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}
catch (Exception e)
{
    Console.WriteLine("General exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}



