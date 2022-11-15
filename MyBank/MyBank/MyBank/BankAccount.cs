
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Linq;

namespace MyBank
{
    class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial deposit");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

            writeJson();
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            writeJson();
        }

        public string GetAccountHistory()
        {

            string fileName = $@"C:\Users\guill\OneDrive\Escritorio\Programación\2DAW\Desarrollo_entorno_servidor\C#\EjerciciosC#\JsonEjercicio\{Owner}_{Number}.json";
            string jsonString = File.ReadAllText(fileName);
            List<Transaction>? lista = JsonSerializer.Deserialize<List<Transaction>>(jsonString);
            var report = new StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in lista)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        private void writeJson()
        {
            string fileName = $@"C:\Users\guill\OneDrive\Escritorio\Programación\2DAW\Desarrollo_entorno_servidor\C#\EjerciciosC#\JsonEjercicio\{Owner}_{Number}.json";
            string jsonString = JsonSerializer.Serialize(allTransactions);
            File.WriteAllText(fileName, jsonString);
        }
    }
}