﻿using BlazorAdminpanel.DTOs;
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
        public async Task<DeleteCoordinatesResponse> DeleteCoordinatesAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/deleteCoordinates/{id}");
            var result = await response.Content.ReadFromJsonAsync<DeleteCoordinatesResponse>();
            return result!;
        }

        public async Task<RequestTransportResponse> Confirm_pointAsync(RequestTransportDTO model)
		{
			var response = await httpClient.PostAsJsonAsync("api/requestTransport", model);
			var result = await response.Content.ReadFromJsonAsync<RequestTransportResponse>();
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
