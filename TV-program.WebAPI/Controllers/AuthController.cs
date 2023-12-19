using TV_program.BL.Auth;
using Microsoft.AspNetCore.Mvc;

namespace TV_program.WebAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;

        public AuthController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
            var tokens = await _authProvider.AuthorizeUser(email, password);
            return Ok(tokens);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(string email, string password)
        {
            await _authProvider.RegisterUser(email, password);
            return Ok();
        }
    }
}
