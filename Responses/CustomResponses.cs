namespace BlazorAdminpanel.Responses
{
    public class CustomResponses
    {
        public record GetUsersResponse(bool Flag = false, string Message = null!);
        public record GetUserResponse(bool Flag = false, string Message = null!);
        public record GetCoordinatesResponse(bool Flag = false, string Message = null!);
        public record GetCoordinateResponse(bool Flag = false, string Message = null!);
        public record RegistrationResponse(bool Flag = false, string Message = null!);
        public record LoginResponse(bool Flag = false, string Message = null!, string JWTToken = null!);
        public record RequestTransportResponse(bool Flag = false, string Message = null!);
        public record DeleteUserResponse(bool Flag = false, string Message = null!);
        public record DeleteCoordinatesResponse(bool Flag = false, string Message = null!);
        public record UpdateUserResponse(bool Flag = false, string Message = null!);
        public record UpdateCoordinatesResponse(bool Flag = false, string Message = null!);
    }
}
