using Bank.Data.TDGW;
using Bank.Domain;
using Bank.Domain.TransactionScripts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;   

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public class UserLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }


        [HttpGet]
        public IActionResult Get()
        {
            _userService.GetUsers();

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public IActionResult Login(UserLogin loginAttempt)
        {
            // TODO
            var command = new UserLoginScript
            {
                Email = loginAttempt.Email,
                Password = loginAttempt.Password
            };

            command.Execute();

            if(command.Output is false)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("Simple")]
        public IActionResult Example(UserLogin loginAttempt)
        {
            var script = new SimpleUserLoginTransactionScript(new UserTableDataGateway());


            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
