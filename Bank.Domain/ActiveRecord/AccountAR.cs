using System.Data.SqlClient;
using System.Data;
using Bank.Data.TDGW;

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

    private static IAccountGateway CreateGatewazy()
    {
        return new StubAccountTGW();
    }

    // Logic
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

    // DATA Access
    public static AccountAR Find(int id)
    {
        // **** Get Account ****
        var gateway = CreateGatewazy();
        var result = gateway.GetAccount(id.ToString());
        return Map(result);
    }

    private static AccountAR Map(DataTable result)
    {
        return new AccountAR()
        {
            Id = result.Rows[0]["account_id"].ToString(),
            HolderName = result.Rows[0]["holder_name"].ToString(),
            Ammount = double.Parse(result.Rows[0]["ammount"].ToString())
        };
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
