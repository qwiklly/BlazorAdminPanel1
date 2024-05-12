using BlazorAdminpanel.Data;
using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Models;
using BlazorAdminpanel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BlazorAdminpanel.Responses.CustomResponses;



namespace BlazorAdminpanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AppDbContext appDbContext;
        private readonly IAccount accountrepo;

        public AccountController(IAccount accountrepo)
        {
            this.accountrepo = accountrepo;
        }

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
        // Service method
        [HttpDelete("delete")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteDTO model)
        {   
            var result = await accountrepo.DeleteUserAsync(model);
            return Ok(result);
        }

    }
}
