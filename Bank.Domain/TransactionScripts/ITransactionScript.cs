namespace Bank.Domain.TransactionScripts;

// Command Design Pattern
public interface ITransactionScript<T>  
{
    public T Output { get; }

    public void Execute();
}
