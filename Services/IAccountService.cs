using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<RequestTransportResponse> Confirm_pointAsync(RequestTransportDTO model);
		Task<DeleteUserResponse> DeleteUserAsync(string email);
        Task<DeleteCoordinatesResponse> DeleteCoordinatesAsync(int id);
    }
}
