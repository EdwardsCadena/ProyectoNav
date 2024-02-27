using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Proyecto.Core.Entities;

namespace Proyecto.Infrastructure.Data;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tickets");

            entity.Property(e => e.ArrivalLocation).HasMaxLength(50);
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.DepartureLocation).HasMaxLength(50);
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.DateCreation).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("User")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
