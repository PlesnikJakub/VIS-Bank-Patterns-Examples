using System.Data;
using System.Data.SqlClient;

namespace Bank.Data.TDGW;

public class AccountTGW
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
