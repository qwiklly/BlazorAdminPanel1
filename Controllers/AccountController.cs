using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount _accountrepo) : ControllerBase
    {
		[HttpPost("Register")]
        [SwaggerOperation(
            Summary = "Create new user",
            Description = "Create a user with role, email and password."
        )]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await _accountrepo.RegisterAsync(model);
            return Ok(result);
        }
        [HttpPost("Login")]
        [SwaggerOperation(
            Summary = "Login a user",
            Description = "Authenticate a user with email and password."
        )]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await _accountrepo.LoginAsync(model);
            return Ok(result);
        }
		[HttpPost("RequestTransport")]
        [SwaggerOperation(
            Summary = "Request a transport",
            Description = "Request a special transport to x and y coordinates. Current data is created automatically."
        )]
        public async Task<ActionResult<RequestTransportResponse>> RequestTransportAsync(RequestTransportDTO model)
		{
			var result = await _accountrepo.RequestTransportAsync(model);
			return Ok(result);
		}
		// Service method
		[HttpDelete("DeleteUser")]
        [SwaggerOperation(
            Summary = "Delete a user",
            Description = "Delete a user."
        )]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteUserDTO model)
        {   
            var result = await _accountrepo.DeleteUserAsync(model);
            return Ok(result);
        }

        [HttpDelete("DeleteCoordinates")]
        [SwaggerOperation(
            Summary = "Delete transport coordinates.",
            Description = "Delete transport coordinates."
        )]
        public async Task<ActionResult<DeleteCoordinatesResponse>> DeleteCoordinates(DeleteCoordinatesDTO model)
        {
            var result = await _accountrepo.DeleteCoordinatesAsync(model);
            return Ok(result);
        }
    }
}
