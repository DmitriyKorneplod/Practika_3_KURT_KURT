using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TomaToma.Models;

public partial class SssrContext : DbContext
{
    public SssrContext()
    {
    }

    public SssrContext(DbContextOptions<SssrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=192.168.2.108;User=root;Database=SSSR;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients", "SSSR");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clients)
                .HasMaxLength(100)
                .HasColumnName("clients");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services", "SSSR");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Services)
                .HasMaxLength(100)
                .HasColumnName("services");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
