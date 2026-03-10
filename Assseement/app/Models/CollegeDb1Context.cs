using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace app.Models;

public partial class CollegeDb1Context : DbContext
{
    public CollegeDb1Context()
    {
    }

    public CollegeDb1Context(DbContextOptions<CollegeDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CollegeDB1;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostels__677EEB285824B244");

            entity.Property(e => e.HostelName).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99E87D64B0");

            entity.HasIndex(e => e.HostelId, "UQ__Students__677EEB2992AB526C").IsUnique();

            entity.Property(e => e.StudentName).HasMaxLength(100);

            entity.HasOne(d => d.Hostel).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.HostelId)
                .HasConstraintName("FK__Students__Hostel__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
