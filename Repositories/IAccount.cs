using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Repositories
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<List<ApplicationUserDTO>> GetUsersAsync();
        Task<Confirm_pointResponse> Confirm_pointAsync(Confirm_pointDTO model);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteDTO model);       
    }
}
