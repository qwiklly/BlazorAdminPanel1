using System.ComponentModel.DataAnnotations;

namespace BlazorAdminpanel.DTOs
{
    public class DeleteDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}