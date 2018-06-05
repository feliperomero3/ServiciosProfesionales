using Microsoft.AspNet.Identity.EntityFramework;

namespace ServiciosProfesionales.DataAccess.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}