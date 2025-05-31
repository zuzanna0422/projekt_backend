using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projekt_backend.Core.Entities;


namespace projekt_backend.Infrastructure.Persistence;

public partial class SnacksContext : DbContext
{
    public virtual DbSet<Snack> Snacks { get; set; }
    public virtual DbSet<User> Users { get; set; }


    public SnacksContext()
    {
    }

    public SnacksContext(DbContextOptions<SnacksContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source=data/halloween_candies_data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Snack>().ToTable("candy_data");

        modelBuilder.Entity<Snack>().Property(s => s.Id).HasColumnName("id");
        modelBuilder.Entity<Snack>().Property(s => s.CompetitorName).HasColumnName("competitorname");
        modelBuilder.Entity<Snack>().Property(s => s.Chocolate).HasColumnName("chocolate");
        modelBuilder.Entity<Snack>().Property(s => s.Fruity).HasColumnName("fruity");
        modelBuilder.Entity<Snack>().Property(s => s.Caramel).HasColumnName("caramel");
        modelBuilder.Entity<Snack>().Property(s => s.PeanutyAlmondy).HasColumnName("peanutyalmondy");
        modelBuilder.Entity<Snack>().Property(s => s.Nougat).HasColumnName("nougat");
        modelBuilder.Entity<Snack>().Property(s => s.CrispedRiceWafer).HasColumnName("crispedricewafer");
        modelBuilder.Entity<Snack>().Property(s => s.Hard).HasColumnName("hard");
        modelBuilder.Entity<Snack>().Property(s => s.Bar).HasColumnName("bar");
        modelBuilder.Entity<Snack>().Property(s => s.Pluribus).HasColumnName("pluribus");
        modelBuilder.Entity<Snack>().Property(s => s.SugarPercent).HasColumnName("sugarpercent");
        modelBuilder.Entity<Snack>().Property(s => s.PricePercent).HasColumnName("pricepercent");
        modelBuilder.Entity<Snack>().Property(s => s.WinPercent).HasColumnName("winpercent");

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
