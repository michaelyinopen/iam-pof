using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IamPof.Models
{
    public class IamPofDbContext : DbContext
    {
        public IamPofDbContext(DbContextOptions<IamPofDbContext> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Sub);

            base.OnModelCreating(modelBuilder);
        }
    }
}
