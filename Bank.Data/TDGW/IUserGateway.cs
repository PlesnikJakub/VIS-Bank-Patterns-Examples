using Bank.Data.DTO;

namespace Bank.Data.TDGW
{
    public interface IUserGateway
    {
        public UserDTO GetUser(string email);
    }
}