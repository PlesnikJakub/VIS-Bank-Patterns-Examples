using Bank.Data.TDGW;
using Bank.Domain.DTO;
using System.Data;

namespace Bank.Domain.TableModule;

public class AccountTableModule
{
    private readonly IAccountGateway _accountTDGW = new AccountTGW();

    public AccountDTO NewAccount(string holderName, double ammount)
    {
        _accountTDGW.CreateAccount(holderName, ammount);

        // NOTE: In real world, we would do more complex logic, eg. secuity checks

        var accountData = _accountTDGW.GetAccount("TODO: ADD account id");

        return Map(accountData);
    }

    public void Deposit(string id,double ammount)
    {
        // TODO
    }

    public void Withdraw(string id, double ammount)
    {
        // TODO
    }
    private AccountDTO Map(DataTable accountData)
    {
        throw new NotImplementedException();
    }
}
