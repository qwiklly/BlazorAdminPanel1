
namespace BlazorAdminpanel.Models
{
	public class UsersCoordinates
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;

		public double? Coordinate_x { get; set; }

		public double? Coordinate_y { get; set; }

		public string Comment { get; set; } = string.Empty;

		public DateTime Timestamp { get; set; }
	}
}
