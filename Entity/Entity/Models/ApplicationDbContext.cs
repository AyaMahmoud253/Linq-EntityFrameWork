using Microsoft.EntityFrameworkCore;

namespace Entity.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        //DbContextOptions->Dependency Injection
        public DbSet<User> Users {  get; set; }
        
    }
}
