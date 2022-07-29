using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace ScriptWriterApp
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("google-login")]
        public async Task<ActionResult> Google()
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = $"/auth/google-login-success"
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }
    }
}
