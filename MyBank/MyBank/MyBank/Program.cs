using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyBank
{
    class Program
    {
        public static List<BankAccount> allBankAccounts2 = new List<BankAccount>();
        static void Main(string[] args)
        {

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
                                } else 
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
                                        if(account.Balance >= initial)
                                        {
                                            initialAmount = true;
                                        } else
                                        {
                                            Console.WriteLine("¡Error, no puedes retirar tanto dinero, es lo que hay. It is what it is!" + account.Balance + ">="+initial);
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
                var account = new BankAccount("Alex", 1000);
                Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
                account.MakeDeposit(500, DateTime.Now, "Bizum");
                account.MakeWithdrawal(100, DateTime.Now, "Gasofa");
                Console.WriteLine(account.GetAccountHistory());
                Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} actual balance.");
                var accountV = new BankAccount("Vanessa", 5000);
                Console.WriteLine($"Account {accountV.Number} was created for {accountV.Owner} with {accountV.Balance} initial balance.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }*/

        }
    }
}
