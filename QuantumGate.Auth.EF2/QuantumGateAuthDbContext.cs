using Microsoft.EntityFrameworkCore;
using QuantumGate.Auth.Models;

namespace QuantumGate.Auth.EF2
{
    public class QuantumGateAuthDbContext : DbContext
    {
        public QuantumGateAuthDbContext(DbContextOptions<QuantumGateAuthDbContext> options) : base(options) { }
        public DbSet<UserData> UserData { get; set; } = null!;
        public DbSet<UserCred> UserCreds { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>(entity => 
            {
                entity.ToTable("User.Data");

                // BaseEntity properties
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                // Entity properties
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Email)
                    .IsUnique();
            });

            modelBuilder.Entity<UserCred>(entity =>
            {
                entity.ToTable("User.Cred");

                // BaseEntity properties
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                // Entity properties
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AuthenticationHash)
                    .IsRequired()
                    .HasMaxLength(int.MaxValue);

                entity.Property(e => e.LastUsedDT)
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPassword)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                entity.Property(e => e.PasswordChangeDT)
                    .HasColumnType("datetime");

                // Foreign key to UserData
                entity.HasOne(e => e.UserData)
                    .WithMany(u => u.UserCreds)
                    .HasForeignKey(e => e.UserDataId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User.Cred_User.Data");
            });
        }
    }
}
