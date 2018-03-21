using Microsoft.EntityFrameworkCore;
using Conectt.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class ConecttContext : DbContext
    {
        public ConecttContext(DbContextOptions<ConecttContext> options)
            : base(options)
        { }

        public DbSet<Conectt.Models.Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Conectt.Models.Cliente.Setup(modelBuilder);
        }
    }
}