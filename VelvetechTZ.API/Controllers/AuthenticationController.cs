using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Core.Authentication;

namespace VelvetechTZ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn() //just singin everyone for now
        {
            var (token, expirationTime) = await authenticationService.SignIn(0, "VeryH@rdP@ssw0rd155");

            return Ok(new
            {
                Token = token,
                ValidTo = expirationTime
            }
            );
        }
    }
}