using System.Text.Json;

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
    private readonly decimal _minimumBalance;

/*
    public BankAccount(string nameOwner, decimal initialBalance)
    {
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        this.Owner = nameOwner;
        //this.Balance = initialBalance;
        this.MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }
*/
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
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

    public void MakeWithdrawalNoCheckLimit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (this.Balance - amount < _minimumBalance)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            allTransactions.Add(overdraftTransaction);
        writeJson();
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
    }

    public string GetAccountHistory()
    {
        string fileName = $@"C:\Users\guill\OneDrive\Escritorio\Programación\2DAW\Desarrollo_entorno_servidor\C#\EjerciciosC#\JsonEjercicio\{Owner}_{Number}.json";
        string jsonString = File.ReadAllText(fileName);
        List<Transaction>? lista = JsonSerializer.Deserialize<List<Transaction>>(jsonString)!;
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in lista)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

    private void writeJson()
    {
        string fileName = $@"C:\Users\guill\OneDrive\Escritorio\Programación\2DAW\Desarrollo_entorno_servidor\C#\EjerciciosC#\JsonEjercicio\{Owner}_{Number}.json";
        string jsonString = JsonSerializer.Serialize(allTransactions);
        File.WriteAllText(fileName, jsonString);
        //File.WriteAllText("../../../jsons/" + fileName, jsonString); //Guardar en raiz en vez de en bin\Debug\netcoreapp3.1
    }

    public virtual void PerformMonthEndTransactions() { }
}