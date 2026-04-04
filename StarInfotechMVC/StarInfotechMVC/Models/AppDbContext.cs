using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StarInfotechMVC.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=StarInfotech;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Role_Id");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "uk_Role_Name").IsUnique();

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_User_Id");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "uk_User_Username").IsUnique();

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AddedBy).WithMany(p => p.InverseAddedBy)
                .HasForeignKey(d => d.AddedById)
                .HasConstraintName("fk_User_AddedById");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.InverseModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("fk_User_ModifiedById");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_User_RoleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
