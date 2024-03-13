
namespace domain.Entities.email
{
    public class Invitation
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Email { get; set; }
        public int CompanyId { get; set; }
    }
}
