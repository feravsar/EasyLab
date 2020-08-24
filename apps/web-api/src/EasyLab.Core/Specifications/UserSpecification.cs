using EasyLab.Core.Entities;
using EasyLab.Core.Specifications;

namespace EasyLab.Core.Specifications
{
    public sealed class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(string id) : base(u => u.Id==id)
        {
            AddInclude(t=>t.RefreshTokens);
        }
    }
}
