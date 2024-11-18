using System.Data;
using System.Data.SqlClient;

namespace Bank.Data.TDGW;

public interface IAccountGateway
{
    void CreateAccount(string holderName, double ammount);
    DataTable GetAccount(string accountId);
}
public class StubAccountTGW : IAccountGateway
{
    public DataTable GetAccount(string accountId)
    {
        // **** Get Account ****
        DataTable result = new DataTable();
        result.Columns.Add("account_id", typeof(string));
        result.Columns.Add("holder_name", typeof(string));
        result.Columns.Add("ammount", typeof(double));

        result.Rows.Add("1", "John Doe", 1000.0);

        return result;
    }

    public void CreateAccount(string holderName, double ammount)
    {
        // **** Create Account ****
    }
}

public class AccountTGW : IAccountGateway
{
    public DataTable GetAccount(string accountId)
    {
        // **** Get Account ****
        DataTable result = new DataTable();
        var query = "select * from account where account_id = @accountId";

        var connString = "TODO: ADD connection string";

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("accountId", accountId);

            using SqlDataReader reader = command.ExecuteReader();
            result.Load(reader);
        }

        return result;
    }

    public void CreateAccount(string holderName, double ammount)
    {
        // **** Create Account ****
    }
}
