using Bank.Data.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Bank.Data.TDGW;

public class UserTableDataGateway
{
    public UserDTO GetUser(string email)
    {
        // **** Get User ****
        DataTable result = new DataTable();
        var query = "select * from user where email = @email";

        var connString = "TODO: ADD connection string";

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("email", email);

            using SqlDataReader reader = command.ExecuteReader();
            result.Load(reader);
        }

        return new UserDTO {
            Id = int.Parse(result.Rows[0]["user_id"].ToString()),
            Name = result.Rows[0]["name"].ToString(),
            Email = result.Rows[0]["email"].ToString(),
            PaswordHash = result.Rows[0]["password"].ToString()
        };
    }
}
