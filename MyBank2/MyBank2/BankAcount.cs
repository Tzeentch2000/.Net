using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank2
{
    internal class BankAcount
    {
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountId = 1;
        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAcount(string owner, decimal amount)
        {
            Number = accountId.ToString();
            Owner = owner;
            accountId++;
            MakeDeposit(amount, DateTime.Now,"Iniitial Value");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0) 
            { 
                throw new ArgumentOutOfRangeException("Valor incorrecto");
            }
            var transaction = new Transaction(amount, date, note);
            allTransactions.Add(transaction);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Valor incorrecto");
            }

            if(Balance-amount < 0)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            var transaction = new Transaction(-amount,date,note);
            allTransactions.Add(transaction);
            
        }

        public string history()
        {
            var cadena = new StringBuilder();
            foreach(var item in allTransactions)
            {
                cadena.AppendLine($"Cantidad:{item.Amount} Fecha:{item.Date} Concepto:{item.Notes}\n");
            }
            return cadena.ToString();
        }
    }
}
