using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Repositories
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<List<ApplicationUserDTO>> GetUsersAsync();
        Task<List<RequestTransportDTO>> GetCoordinatesAsync();
        Task<RequestTransportResponse> RequestTransportAsync(RequestTransportDTO model);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO model);
        Task<DeleteCoordinatesResponse> DeleteCoordinatesAsync(DeleteCoordinatesDTO model);
    }
}
