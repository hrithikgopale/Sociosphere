using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sociosphere.Data.Entities;

public partial class SociosphereDbContext : DbContext
{
    public SociosphereDbContext()
    {
    }

    public SociosphereDbContext(DbContextOptions<SociosphereDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allotment> Allotments { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Flat> Flats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Leave empty for now; will configure via DI in Program.cs
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allotment>(entity =>
        {
            entity.HasIndex(e => e.AllotedTo, "IX_Allotments_AllotedTo");

            entity.HasIndex(e => e.FlatId, "IX_Allotments_FlatId");

            entity.HasOne(d => d.AllotedToNavigation).WithMany(p => p.Allotments).HasForeignKey(d => d.AllotedTo);

            entity.HasOne(d => d.Flat).WithMany(p => p.Allotments).HasForeignKey(d => d.FlatId);
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE445747F8A62E3");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PostedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Announcements_Users");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasIndex(e => e.FlatId, "IX_Bills_FlatId");

            entity.HasOne(d => d.Flat).WithMany(p => p.Bills).HasForeignKey(d => d.FlatId);
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasIndex(e => e.FlatId, "IX_Complaints_FlatId");

            entity.HasIndex(e => e.UserId, "IX_Complaints_UserId");

            entity.HasOne(d => d.Flat).WithMany(p => p.Complaints).HasForeignKey(d => d.FlatId);

            entity.HasOne(d => d.User).WithMany(p => p.Complaints).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Flat>(entity =>
        {
            entity.Property(e => e.BlockNumber).HasMaxLength(10);
            entity.Property(e => e.FlatNumber).HasMaxLength(10);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.Role).HasDefaultValue("");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasIndex(e => e.FlatId, "IX_Visitors_FlatId");

            entity.HasOne(d => d.Flat).WithMany(p => p.Visitors).HasForeignKey(d => d.FlatId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
