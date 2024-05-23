using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<Confirm_pointResponse> Confirm_pointAsync(Confirm_pointDTO model);

		Task<DeleteUserResponse> DeleteUserAsync(string email);
    }
}
