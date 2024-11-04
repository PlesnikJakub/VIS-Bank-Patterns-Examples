using Bank.Domain.DomainModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("{id}")]
        public AccountAR Get(int id)
        {
            var account = AccountAR.Find(id);
            return account;
        }

        [HttpGet("{id}/{ammount}")]
        public double Deposit(int id, double ammount)
        {
            var account = AccountAR.Find(id);
            account.Deposit(ammount);
            return account.Ammount;   
        }
    }
}
