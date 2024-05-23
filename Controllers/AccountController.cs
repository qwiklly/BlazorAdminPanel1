using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Repositories;
using Microsoft.AspNetCore.Mvc;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount accountrepo) : ControllerBase
    {
        private readonly IAccount accountrepo = accountrepo;

		[HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountrepo.RegisterAsync(model);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountrepo.LoginAsync(model);
            return Ok(result);
        }
		[HttpPost("Confirm_point")]
		public async Task<ActionResult<Confirm_pointResponse>> Confirm_point(Confirm_pointDTO model)
		{
			var result = await accountrepo.Confirm_pointAsync(model);
			return Ok(result);
		}
		// Service method
		[HttpDelete("delete")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteDTO model)
        {   
            var result = await accountrepo.DeleteUserAsync(model);
            return Ok(result);
        }

    }
}
