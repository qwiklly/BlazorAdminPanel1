namespace BlazorAdminpanel.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty; //Empty string

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
