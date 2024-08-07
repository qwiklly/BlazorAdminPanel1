using BlazorAdminpanel.DTOs;
using BlazorAdminpanel.Models;
using Microsoft.AspNetCore.Mvc;
using static BlazorAdminpanel.Responses.CustomResponses;

namespace BlazorAdminpanel.Repositories
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<List<ApplicationUserDTO>> GetUsersAsync();
        Task<List<RequestTransportDTO>> GetCoordinatesAsync();
        Task<ApplicationUser?> GetUserAsync(string email);
        Task<UsersCoordinates?> GetCoordinateAsync(int id);
        Task<RequestTransportResponse> RequestTransportAsync(RequestTransportDTO model);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO model);
        Task<DeleteCoordinatesResponse> DeleteCoordinatesAsync(DeleteCoordinatesDTO model);
        Task<ActionResult<RequestTransportResponse>> UpdateCoordinatesAsync(int id, RequestTransportDTO model);
        Task<ActionResult<RegistrationResponse>> UpdateUserAsync(string email, RegisterDTO model);
    }
}
