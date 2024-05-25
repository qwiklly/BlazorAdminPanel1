using System.ComponentModel.DataAnnotations;

namespace BlazorAdminpanel.DTOs
{
    public class DeleteUserDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}