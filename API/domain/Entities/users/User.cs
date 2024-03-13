using domain.Dto.crm;
using domain.Entities.crm;
using Microsoft.AspNetCore.Identity;

namespace domain.Entities.users
{
    public class User : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? IdentityId { get; private set; }
        public int? CompanyId { get; set; }
        public int? PictureId { get; set; }
        public virtual Company? Company { get; set; }
        //public virtual Multimedia UserPictureMultimedia { get; set; }
    }
}
