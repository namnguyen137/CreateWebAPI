using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        { }
        #region DbSet 
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<PhuongTien> PhuongTiens {get;set;}
        public DbSet<School> Schools { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(dh => new { 
                    dh.MaDh, dh.MaHh
                });
                e.HasOne(dh => dh.DonHang)
                    .WithMany(dh => dh.DonHangChiTiets)
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_DonHangCT_DonHang");

                e.HasOne(dh => dh.HangHoa)
                    .WithMany(dh => dh.DonHangChiTiets)
                    .HasForeignKey(e => e.MaHh)
                    .HasConstraintName("FK_DonHangCT_HangHoa");

            });
            modelBuilder.Entity<NguoiDung>(entity => {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
        }


    }
}
