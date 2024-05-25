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

		[HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountrepo.RegisterAsync(model);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountrepo.LoginAsync(model);
            return Ok(result);
        }
		[HttpPost("RequestTransport")]
		public async Task<ActionResult<RequestTransportResponse>> RequestTransportAsync(RequestTransportDTO model)
		{
			var result = await accountrepo.RequestTransportAsync(model);
			return Ok(result);
		}
		// Service method
		[HttpDelete("DeleteUser")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteUserDTO model)
        {   
            var result = await accountrepo.DeleteUserAsync(model);
            return Ok(result);
        }

        [HttpDelete("DeleteCoordinates")]
        public async Task<ActionResult<DeleteCoordinatesResponse>> DeleteCoordinates(DeleteCoordinatesDTO model)
        {
            var result = await accountrepo.DeleteCoordinatesAsync(model);
            return Ok(result);
        }
    }
}
