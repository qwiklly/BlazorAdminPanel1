using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Services
{
    public class AccountService(HttpClient httpClient) : IAccountService
    {
        private readonly HttpClient httpClient = httpClient;

        public async Task<GetUsersResponse> GetUsersAsync()
        {
            var response = await httpClient.GetAsync("api/account/getUsers");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetUsersResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}"); //request not completed
        }

        public async Task<GetUserResponse> GetUserAsync(string email)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/GetUser", email);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetUserResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<GetCoordinatesResponse> GetCoordinatesAsync()
        {
            var response = await httpClient.GetAsync("api/account/getCoordinates");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetCoordinatesResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<GetCoordinateResponse> GetCoordinateAsync(int id)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/GetCoordinate", id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetCoordinateResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/login", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<DeleteUserResponse> DeleteUserAsync(string email)
        {
            var response = await httpClient.DeleteAsync($"api/account/delete/{email}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<DeleteUserResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<DeleteCoordinatesResponse> DeleteCoordinatesAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/deleteCoordinates/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<DeleteCoordinatesResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<UpdateCoordinatesResponse> UpdateCoordinatesAsync(RequestTransportDTO model)
        {
            var response = await httpClient.PutAsJsonAsync("api/updateRequestTransport", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<UpdateCoordinatesResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(RegisterDTO model)
        {
            var response = await httpClient.PutAsJsonAsync("api/account/updateRegister", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<UpdateUserResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }

        public async Task<RequestTransportResponse> Confirm_pointAsync(RequestTransportDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/requestTransport", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RequestTransportResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }
        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/register", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
                return result!;
            }
            else
                throw new HttpRequestException($"Запрос не удался: {response.ReasonPhrase}");
        }
    }
}
