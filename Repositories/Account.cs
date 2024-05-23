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
	public class Account(AppDbContext appDbContext, IConfiguration config) : IAccount
	{

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
					Role = u.Role,
					Name = u.Name,
					Email = u.Email
				})
				.ToListAsync();

			return users;
		}
		//deleting 
		public async Task<DeleteUserResponse> DeleteUserAsync(DeleteDTO model)
		{
			var user = await GetUser(model.Email);
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
					 Role = model.Role,
					 Name = model.Name,
					 Email = model.Email,
					 Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
				 });

			await appDbContext.SaveChangesAsync();
			return new RegistrationResponse(true, "Success");
		}
		public async Task<Confirm_pointResponse> Confirm_pointAsync(Confirm_pointDTO model)
		{
			appDbContext.Coordinates.Add(
				 new UsersCoordinates()
				 {
					 Email = model.Email,
					 Coordinate_x = model.Coordinate_x,
					 Coordinate_y = model.Coordinate_y,
					 Comment = model.Comment

				 });

			await appDbContext.SaveChangesAsync();
			return new Confirm_pointResponse(true, "Success");
		}
		public static async Task Create_Admin(AppDbContext context)
		{
			// Проверяем, есть ли администратор в базе данных
			if (!context.Users.Any(u => u.Role == "Admin"))
			{
				// Добавляем администратора
				var admin = new ApplicationUser
				{
					Role = "Admin",
					Name = "Admin",
					Email = "admin@example.com",
					Password = BCrypt.Net.BCrypt.HashPassword("Admin123")
				};

				context.Users.Add(admin);
				await context.SaveChangesAsync();
			}
		}

		private string GenerateToken(ApplicationUser user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var userClaims = new[]
			{
				new Claim(ClaimTypes.Name, user.Name!),
				new Claim(ClaimTypes.Email, user.Email!),
				new Claim(ClaimTypes.Role, user.Role!),
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
		private async Task<ApplicationUser?> GetUser(string email)
			=> await appDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);

	}
}
