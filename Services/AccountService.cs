using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Responses;
using System.Net.Http.Json;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient; 
        public AccountService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

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

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/register", model);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
            return result!;
        }
    }
}
