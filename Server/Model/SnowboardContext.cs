using Microsoft.EntityFrameworkCore;
using MySnowboardApp.Shared.Models;

namespace MySnowboardApp.Server.Model
{
  public class SnowboardContext : DbContext
  {
    public SnowboardContext()
    {
    }

    public SnowboardContext(DbContextOptions<SnowboardContext> options) : base(options)
    {
    }

    public virtual DbSet<BoardInfo> Board { get; set; } = null!;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<BoardInfo>(entity =>
    //  {
    //    entity.ToTable("info");
    //    entity.Property(e => e.BoardId).HasColumnName("BoardId");
    //    entity.Property(e => e.BoardName).HasMaxLength(100).IsUnicode(false);
    //    entity.Property(e => e.Brand).HasMaxLength(50).IsUnicode(false);
    //    entity.Property(e => e.RiderLevel).HasMaxLength(100).IsUnicode(false);
    //    entity.Property(e => e.BoardType).HasMaxLength(50).IsUnicode(false);
    //    entity.Property(e => e.Flex).HasMaxLength(100).IsUnicode(false);
    //    entity.Property(e => e.Terrain).HasMaxLength(100).IsUnicode(false);
    //    entity.Property(e => e.YearDesign).HasMaxLength(20).IsUnicode(false);
    //  });
    //  OnModelCreatingPartial(modelBuilder);
    //}
    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
