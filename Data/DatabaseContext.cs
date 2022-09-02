using API_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() : base() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseMySql("server=localhost;user=root;database=api_demo", ServerVersion.Parse("10.4.24-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("utf8mb4_general_ci").HasCharSet("utf8mb4");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("customer");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(50).HasColumnName("fname");
                entity.Property(e => e.LastName).HasMaxLength(50).HasColumnName("lname");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}