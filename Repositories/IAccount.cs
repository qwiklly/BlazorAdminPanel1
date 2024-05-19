using BlazorAdminpanel.DTOs;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Repositories
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<List<ApplicationUserDTO>> GetUsersAsync();
        Task<DeleteUserResponse> DeleteUserAsync(DeleteDTO model);       
    }
}
