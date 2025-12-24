using Microsoft.EntityFrameworkCore;

namespace API_CRUD_Operation.Models
{
    public partial class MytestdbContext : DbContext
    {
        public MytestdbContext(DbContextOptions<MytestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                // ✅ PRIMARY KEY DEFINED
                entity.HasKey(e => e.StdId);

                entity.ToTable("STUDENT");

                entity.Property(e => e.StdId)
                      .HasColumnName("STD_ID")
                      .ValueGeneratedOnAdd(); // agar identity hai

                entity.Property(e => e.StdName)
                      .HasMaxLength(150)
                      .IsUnicode(false)
                      .HasColumnName("STD_NAME");

                entity.Property(e => e.StdFatherName)
                      .HasMaxLength(150)
                      .IsUnicode(false)
                      .HasColumnName("STD_FATHER_NAME");

                entity.Property(e => e.StdRollNo)
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .HasColumnName("STD_ROLL_NO");

                entity.Property(e => e.StdContact)
                      .HasMaxLength(11)
                      .IsUnicode(false)
                      .HasColumnName("STD_CONTACT");

                entity.Property(e => e.StdCnic)
                      .HasMaxLength(15)
                      .IsUnicode(false)
                      .HasColumnName("STD_CNIC");
            });
        }
    }
}
