using BlazorAdminpanel.Components.Pages;
using BlazorAdminpanel.Data;
using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BlazorAdminpanel.Responses.CustomResponses;



namespace BlazorAdminpanel.Repositories
{
    public class Account : IAccount
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration config;
        public Account(AppDbContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }
        //Login logic
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser == null) return new LoginResponse(false, "User not found");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email or Pass incorrect");

            string jwtToken = GenerateToken(findUser);
            return new LoginResponse(true, "Login successfully", jwtToken);
        }
        //Getting Users
        public async Task<List<ApplicationUserDTO>> GetUsersAsync()
        {
            var users = await appDbContext.Users
                .Select(u => new ApplicationUserDTO
                {
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();

            return users;
        }
        //deleting 
        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteDTO model)
        {
            var user = await GetUser(model.Email) ;
            if (user != null)
            {
                appDbContext.Users.Remove(user);
                await appDbContext.SaveChangesAsync();
                return new DeleteUserResponse(true, "User deleted successfully");
            }
            else
            {
                return new DeleteUserResponse(false, "User not found");
            }
        }

        //Cheaking did user registrate
        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser != null) return new RegistrationResponse(false, "User already exist");

            appDbContext.Users.Add(
                 new ApplicationUser()
                 {
                     Name = model.Name,
                     Email = model.Email,
                     Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                 });

            await appDbContext.SaveChangesAsync();
            return new RegistrationResponse(true, "Success");
        }

            private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!),
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"]!,
                audience: config["Jwt:Audience"]!,
                claims: userClaims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
            private async Task<ApplicationUser> GetUser(string email)
                => await appDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
            
        
    }
}
