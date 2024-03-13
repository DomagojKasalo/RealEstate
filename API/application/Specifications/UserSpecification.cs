using domain.Entities.users;

namespace application.Specifications
{
    public sealed class UserSpecification : BaseSpecification<UserWrapper>
    {
        public UserSpecification(string identityId) 
        {
            Criteria = i => i.User.IdentityId == identityId;
            //AddInclude(u => u.User.Company);
        }
    }
}
