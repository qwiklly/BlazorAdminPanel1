using System.ComponentModel.DataAnnotations;

namespace BlazorAdminpanel.DTOs
{
	public class RequestTransportDTO
    {

        [Required, DataType(DataType.EmailAddress), EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public double? Coordinate_x { get; set; } 

		[Required]
		public double? Coordinate_y { get; set; }

		[Required]
		public string Comment { get; set; } = string.Empty;

		public int? Id { get; set; }

		public DateTime Timestamp { get; set; }
    }
}
