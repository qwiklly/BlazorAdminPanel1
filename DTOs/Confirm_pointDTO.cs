using System.ComponentModel.DataAnnotations;

namespace BlazorAdminpanel.DTOs
{
	public class Confirm_pointDTO
	{
		[Required, DataType(DataType.EmailAddress), EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public double? Coordinate_x { get; set; } 

		[Required]
		public double? Coordinate_y { get; set; }

		[Required]
		public string Comment { get; set; } = string.Empty;
	}
}
