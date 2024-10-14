namespace Bank.Domain.DomainModel;

public class AccountDomainModel
{
    public int Id { get; set; }
    public string HolderName { get; set; }
    public double Ammount { get; set; }

    public static AccountDomainModel NewAccount(string holderName, double ammount)
    {
        return new AccountDomainModel();
    }

    public void Deposit(double ammount)
    {
       // TODO
    }

    public void Withdraw(double ammount)
    {
        // TODO
    }
}
