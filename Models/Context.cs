using Microsoft.EntityFrameworkCore;
 
namespace CRUDelicious.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { } 
        public DbSet<User> User { get; set; }
    }
}
