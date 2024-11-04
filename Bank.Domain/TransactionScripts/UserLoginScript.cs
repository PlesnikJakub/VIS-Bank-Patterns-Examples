using Bank.Data.TDGW;
using System.Security.Cryptography;

namespace Bank.Domain.TransactionScripts;
public class UserLoginScript : ITransactionScript<bool>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public bool Output { get; set; }

    public void Execute()
    {
        var gateway = new UserTableDataGateway();
        var user = gateway.GetUser(Email);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        Output = user.PaswordHash == Hash(Password);
    }

    private string Hash(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(inputBytes);
        return Convert.ToBase64String(hash);
    }
}