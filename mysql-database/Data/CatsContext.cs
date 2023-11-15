using Microsoft.EntityFrameworkCore;
using mysql_database.Models;
using mysql_database.sakila;

namespace mysql_database.Data
{
    public class CatsContext : DbContext
    {
        public CatsContext()
        {
        }

        public CatsContext(DbContextOptions<CatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("PRIMARY");

                entity.ToTable("cats");

                entity.HasIndex(c => c.Name, "idx_cat_name");

                entity.Property(c => c.Name)
                    .HasMaxLength(45);
                entity.Property(e => e.BirthDate)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("birthday");
            });
        }
    }
}
