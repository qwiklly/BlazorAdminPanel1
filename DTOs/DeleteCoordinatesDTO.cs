using System.ComponentModel.DataAnnotations;

namespace BlazorAdminpanel.DTOs
{
    public class DeleteCoordinatesDTO
    {
        [Required]
        public int Id { get; set; }
    }
}


