using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RESTAPI25032101.Models;

public partial class KaktuszokDbContext : DbContext
{
    public KaktuszokDbContext()
    {
    }

    public KaktuszokDbContext(DbContextOptions<KaktuszokDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kaktuszok> Kaktuszoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=kakt;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kaktuszok>(entity =>
        {
            entity.Property(e => e.Fenyigeny).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.KoznapiNev).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TermesztesiNehezseg).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TudomanyosNev).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Vizigeny).HasDefaultValueSql("(NULL)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
