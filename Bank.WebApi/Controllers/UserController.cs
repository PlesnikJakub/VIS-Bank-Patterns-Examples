using Bank.Domain.TransactionScripts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class UserLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

            [HttpPost]
        public IActionResult Post(UserLogin loginAttempt)
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
    }
}
