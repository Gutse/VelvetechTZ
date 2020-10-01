using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetechTZ.API.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IAuthContext authContext;
        private readonly AuthenticationSingInRequestValidator authenticationSingInRequestValidator;
        private readonly AuthenticationSingUpRequestValidator authenticationSingUpRequestValidator;

        public AuthenticationController(IAuthenticationService authenticationService, IAuthContext authContext, AuthenticationSingInRequestValidator authenticationSingInRequestValidator, AuthenticationSingUpRequestValidator authenticationSingUpRequestValidator)
        {
            this.authenticationService = authenticationService;
            this.authContext = authContext;
            this.authenticationSingInRequestValidator = authenticationSingInRequestValidator;
            this.authenticationSingUpRequestValidator = authenticationSingUpRequestValidator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Authentication.SignIn)]
        public async Task<ActionResult<AuthenticationSignInResponse>> SignIn([FromBody] AuthenticationSingInRequest request)
        {
            await authenticationSingInRequestValidator.ValidateAndThrowAsync(request);

            var (token, expirationTime) = await authenticationService.SignIn(request.UserIdentityId, request.Password!);

            return new AuthenticationSignInResponse
            {
                Token = token,
                ValidTo = expirationTime
            };
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Authentication.SignUp)]
        public async Task<ActionResult<AuthenticationSignInResponse>> SignUp([FromBody] AuthenticationSingUpRequest request)
        {
            await authenticationSingUpRequestValidator.ValidateAndThrowAsync(request);

            var userIdentityId = await authenticationService.SignUp(request.Name!, request.Email!, request.Password!);

            var (token, expirationTime) = await authenticationService.SignIn(userIdentityId, request.Password!);

            return new AuthenticationSignInResponse
            {
                Token = token,
                ValidTo = expirationTime
            };
        }

        [HttpPost(ApiRoutes.Authentication.SignOut)]
        public async Task<ActionResult> SignOut()
        {
            var accessToken = await authContext.GetAuthToken();
            await authenticationService.SignOut(accessToken);
            return Ok();
        }

        [HttpPost(ApiRoutes.Authentication.SignOutAll)]
        public async Task<ActionResult> SignOutAll()
        {
            var accessToken = await authContext.GetAuthToken();
            await authenticationService.SignOutAll(accessToken);
            return Ok();
        }
    }
}