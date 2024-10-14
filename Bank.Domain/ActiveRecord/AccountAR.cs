namespace Bank.Domain.DomainModel;

public class AccountAR
{
    public string Id { get; set; }
    public string HolderName { get; set; }
    public double Ammount { get; set; }

    public static AccountAR NewAccount(string holderName, double ammount)
    {
        var account = new AccountAR { Id = Guid.NewGuid().ToString(), Ammount = ammount, HolderName = holderName };
        account.Save();
        return account;
    }

    public void Deposit(double deposit)
    {
        Ammount += deposit;
        Save();
    }

    public void Withdraw(double ammount)
    {
        Ammount -= ammount;
        Save();
    }

    public static AccountAR Find(int id)
    {
        // TODO
        return new AccountAR();
    }

    public void Save()
    {
        // TODO
    }

    public void Delete()
    {
        // TODO
    }
}
