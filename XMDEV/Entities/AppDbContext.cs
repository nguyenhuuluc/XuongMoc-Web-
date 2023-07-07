using Microsoft.EntityFrameworkCore;

namespace XMDEV.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
