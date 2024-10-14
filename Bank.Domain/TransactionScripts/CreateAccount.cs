namespace Bank.Domain.TransactionScripts;

public class CreateAccount : ITransactionScript<bool>
{
    public CreateAccount(string holderName, double ammount)
    {
            
    }

    public bool Output { get; private set; }

    public void Execute()
    {
        // **** Create Account ****
    }
}
