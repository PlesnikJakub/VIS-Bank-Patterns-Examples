using Bank.Data.TDGW;
using System.Security.Cryptography;

namespace Bank.Domain.TransactionScripts;

public class SimpleUserLoginTransactionScript
{
    private readonly IUserGateway _gateway;

    public SimpleUserLoginTransactionScript(IUserGateway gateway)
    {
        _gateway = gateway;
    }

    public bool Execute(string email, string password)
    {
        var user = _gateway.GetUser(email) ?? throw new Exception("User not found");
        return user.PaswordHash == Hash(password);
    }

    private string Hash(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(inputBytes);
        return Convert.ToBase64String(hash);
    }
}