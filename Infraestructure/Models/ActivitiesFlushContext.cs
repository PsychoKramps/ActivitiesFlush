using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Models;

public partial class ActivitiesFlushContext : DbContext
{
    public ActivitiesFlushContext()
    {
    }

    public ActivitiesFlushContext(DbContextOptions<ActivitiesFlushContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PSYCHOKRAMPS\\SQLEXPRESS;Database=ActivitiesFlush;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Date>(entity =>
        {
            entity.HasKey(e => e.DateId).HasName("PK__Date__A426F23300FA0DC2");

            entity.ToTable("Date");

            entity.Property(e => e.DateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949B1A5BB3261");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CB0EBC208");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
