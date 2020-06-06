using Microsoft.AspNet.Identity.EntityFramework;

namespace Eventos.Infra.CrossCutting.Identity.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
