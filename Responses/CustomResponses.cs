namespace BlazorAdminpanel.Responses
{
    public class CustomResponses
    {
        public record RegistrationResponse(bool Flag = false, string Message = null!);
        public record LoginResponse(bool Flag = false, string Message = null!, string JWTToken = null!);
        public record RequestTransportResponse(bool Flag = false, string Message = null!);
        public record DeleteUserResponse(bool Flag = false, string Message = null!);
        public record DeleteCoordinatesResponse(bool Flag = false, string Message = null!);
    }
}
