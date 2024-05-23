using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Services
{
    public class AccountService(HttpClient httpClient) : IAccountService
    {
        private readonly HttpClient httpClient = httpClient;

		public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/account.login", model);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }
        public async Task<DeleteUserResponse> DeleteUserAsync(string email)
        {
            var response = await httpClient.DeleteAsync($"api/account/delete/{email}");
            var result = await response.Content.ReadFromJsonAsync<DeleteUserResponse>();
            return result!;
        }
		public async Task<Confirm_pointResponse> Confirm_pointAsync(Confirm_pointDTO model)
		{
			var response = await httpClient.PostAsJsonAsync("api/account/confirm_point", model);
			var result = await response.Content.ReadFromJsonAsync<Confirm_pointResponse>();
			return result!;
		}
		public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/register", model);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }
    }
}
