
namespace domain.Dto.users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
