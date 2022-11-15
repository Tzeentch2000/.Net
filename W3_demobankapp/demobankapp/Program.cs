using Classes;
using System.Text;

Console.WriteLine("Bienvenido a NGB");
/*string line = Console.ReadLine();
Console.WriteLine(line);*/

List<BankAccount> allBankAccounts = new List<BankAccount>();
// Para finalizar el programa
bool condition = true;
// Variables para comprobar que se introduce un num valido
bool initialAmount = false;
decimal initial = 0;
//Variable de introducir num de cuenta en anadir,retirar y listar operaciones de cuenta
string number = "";
BankAccount account = null;
do
{
    try
    {
        var message = new StringBuilder();
        message.AppendLine("Pulse 1 para crear cuenta");
        message.AppendLine("Pulse 2 para añadir dinero");
        message.AppendLine("Pulse 3 para sacar dinero");
        message.AppendLine("Pulse 4 para ver el listado de operaciones");
        Console.WriteLine(message.ToString());
        int value = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(value);

        switch (value)
        {
            case 1:
                Console.WriteLine("Introduce tu nombre");
                string name = Console.ReadLine();
                initialAmount = false;
                initial = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Introduce el deposito inicial");
                        initial = Convert.ToDecimal(Console.ReadLine());
                        initialAmount = true;
                    }
                    catch (System.FormatException)
                    {
                    }

                } while (!initialAmount);
                allBankAccounts.Add(new BankAccount(name, initial));
                Console.WriteLine($"Cuenta creada con éxito, este es su número de cuenta {allBankAccounts.ElementAt(allBankAccounts.Count() - 1).Number}");
                break;

            case 2:
                Console.WriteLine("Introduce el número de cuenta");
                number = Console.ReadLine();
                account = allBankAccounts.Find(x => x.Number == number);
                if (account != null)
                {
                    initialAmount = false;
                    initial = 0;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Introduce el deposito");
                            initial = Convert.ToDecimal(Console.ReadLine());
                            initialAmount = true;
                        }
                        catch (System.FormatException)
                        {
                        }

                    } while (!initialAmount);
                    Console.WriteLine("Introduce el concepto");
                    string concept = Console.ReadLine();
                    account.MakeDeposit(initial, DateTime.Now, concept);
                    Console.WriteLine($"{initial} ha sido añadida a la cuenta {number}");
                }
                else
                {
                    Console.WriteLine("Número de cuenta incorrecto");
                }
                break;

            case 3:
                Console.WriteLine("Introduce el número de cuenta");
                number = Console.ReadLine();
                account = allBankAccounts.Find(x => x.Number == number);
                if (account != null)
                {
                    initialAmount = false;
                    initial = 0;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Introduce la cantidad a retirar");
                            initial = Convert.ToDecimal(Console.ReadLine());
                            if (account.Balance >= initial)
                            {
                                initialAmount = true;
                            }
                            else
                            {
                                Console.WriteLine("¡Error, no puedes retirar tanto dinero, es lo que hay. It is what it is!" + account.Balance + ">=" + initial);
                            }

                        }
                        catch (System.FormatException)
                        {
                        }

                    } while (!initialAmount);
                    Console.WriteLine("Introduce el concepto");
                    string concept = Console.ReadLine();
                    account.MakeWithdrawal(initial, DateTime.Now, concept);
                    Console.WriteLine($"{initial} ha sido añadida a la cuenta {number}");
                }
                else
                {
                    Console.WriteLine("Número de cuenta incorrecto");
                }
                break;
            case 4:
                Console.WriteLine("Introduce el número de cuenta");
                number = Console.ReadLine();
                account = allBankAccounts.Find(x => x.Number == number);
                if (account != null)
                {
                    Console.WriteLine(account.GetAccountHistory());
                }
                else
                {
                    Console.WriteLine("Número de cuenta incorrecto");
                }
                break;

            default:
                condition = false;
                break;
        }
    }
    catch (System.FormatException e)
    {
        Console.WriteLine("FormatException: " + e.ToString());
    }
} while (condition);

/*try
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

    var savings = new InterestEarningAccount("University savings account", 1000);
    savings.MakeDeposit(750, DateTime.Now, "save some money");
    savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
    savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
    savings.PerformMonthEndTransactions();
    Console.WriteLine(savings.GetAccountHistory());

    var giftCard = new GiftCardAccount("gift card", 100, 50);
    giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
    giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
    giftCard.PerformMonthEndTransactions();
    // can make additional deposits:
    giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
    Console.WriteLine(giftCard.GetAccountHistory());

    var lineOfCredit = new LineOfCreditAccount("line of credit", -1000, 5000);
    lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
    lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
    lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
    lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
    lineOfCredit.PerformMonthEndTransactions();
    Console.WriteLine(lineOfCredit.GetAccountHistory());
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
*/


