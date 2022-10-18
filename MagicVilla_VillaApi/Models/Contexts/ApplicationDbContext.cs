using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Models.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }    
    }
}
