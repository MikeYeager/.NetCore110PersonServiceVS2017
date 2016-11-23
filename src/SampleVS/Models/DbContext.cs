using Microsoft.EntityFrameworkCore;

namespace Sample.Models
{
    public partial class DemoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=mauidell;Database=SSWUGDemo;User Id=devuser;Password=devuser;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });
        }

        public virtual DbSet<Person> Person { get; set; }
    }
}