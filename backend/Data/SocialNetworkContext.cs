using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().Property(p => p.Name).HasMaxLength(40);
        
            builder.Entity<Person>().ToTable("Person");
        }

        public DbSet<Person> People { get; set; }
    }
}