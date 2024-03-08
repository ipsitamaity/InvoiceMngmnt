using INVOICE_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;
        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Post([FromBody] Users model)
        {
            var user = _authService.Authenticate(model.UserName, model.Password);
            Console.WriteLine("inlogin");
            Console.WriteLine(user.UserName);
            if (user == null || user.UserName=="")
                return Unauthorized();
            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
