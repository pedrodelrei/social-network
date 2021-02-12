using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Family>().Property(p => p.Name).HasMaxLength(40);
            
            builder.Entity<FamilyPersonRelationship>()
                .HasOne(e => e.PrimaryPerson)
                .WithMany(p => p.PrimaryRelationships)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FamilyPersonRelationship>()
                .HasOne(e => e.ForeignPerson)
                .WithMany(p => p.ForeignRelationships)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Gender>().Property(p => p.Pronum).HasMaxLength(4);

            builder.Entity<Person>().Property(p => p.Name).HasMaxLength(40);

            builder.Entity<RelationshipGender>()
                .HasKey(g => new { g.GenderId, g.RelationshipId });
            builder.Entity<RelationshipGender>().Property(p => p.Name).HasMaxLength(20);
            builder.Entity<RelationshipGender>().Property(p => p.InverseName).HasMaxLength(20);

            builder.Entity<Family>().ToTable("Family");
            builder.Entity<FamilyPersonRelationship>().ToTable("FamilyPersonRelationship");
            builder.Entity<Gender>().ToTable("Gender");
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Relationship>().ToTable("Relationship");
            builder.Entity<RelationshipGender>().ToTable("RelationshipGender");
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyPersonRelationship> FamilyPersonRelationships { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<RelationshipGender> RelationshipGenders { get; set; }
    }
}