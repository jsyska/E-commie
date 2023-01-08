using Microsoft.AspNetCore.Identity;

namespace E_commie.Repository
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}