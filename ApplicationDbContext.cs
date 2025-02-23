using Microsoft.EntityFrameworkCore;
using SupermercadoAPI.Models;

namespace SupermercadoAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        // DbSets para tus entidades
        public DbSet<Producto> Productos { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<User> Users { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                        .Property(p => p.Precio)
                        .HasColumnType("decimal(18,2)"); // O alternativamente, HasPrecision(18, 2)
        }
    }
}
