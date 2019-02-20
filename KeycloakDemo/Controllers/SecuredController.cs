using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakDemo.Controllers
{
    [Authorize]
    [Route("/secured")]
    [ApiController]
    public class SecuredController : ControllerBase
    {

        [HttpGet]
        public IActionResult Secured()
        {
            return Ok($"You are authenticated as : {User.FindFirst("preferred_username")?.Value}");
        }
        
        [HttpGet("dumb")]
        [Authorize(Roles = "ROLE_DUMB")]
        public IActionResult Dumb()
        {
            return Ok("You should not be able to access this ...");
        }
        
        [HttpGet("role")]
        [Authorize(Roles = "yes_we_can")]
        public IActionResult Role()
        {
            return Ok("That's right, you can");
        }
    }
}