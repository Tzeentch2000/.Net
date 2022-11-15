namespace Classes;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    //public decimal Balance { get; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
            }

            return balance;
        }
    }

    private static int accountNumberSeed = 1;
    private List<Transaction> allTransactions = new List<Transaction>();

    public BankAccount(string nameOwner, decimal initialBalance)
    {
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        this.Owner = nameOwner;
        //this.Balance = initialBalance;
        this.MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (this.Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }
   
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

}