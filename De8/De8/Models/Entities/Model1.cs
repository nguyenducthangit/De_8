using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De8.Models.Entities
{
	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=QuanLiBanHangModel1")
		{
		}

		public virtual DbSet<AnhChiTietSP> AnhChiTietSP { get; set; }
		public virtual DbSet<ChiTietSPBan> ChiTietSPBan { get; set; }
		public virtual DbSet<DonHang> DonHang { get; set; }
		public virtual DbSet<MauSac> MauSac { get; set; }
		public virtual DbSet<NguoiDung> NguoiDung { get; set; }
		public virtual DbSet<PhanLoai> PhanLoai { get; set; }
		public virtual DbSet<PhanLoaiPhu> PhanLoaiPhu { get; set; }
		public virtual DbSet<SanPham> SanPham { get; set; }
		public virtual DbSet<SPtheoMau> SPtheoMau { get; set; }
		public virtual DbSet<ChiTietDH> ChiTietDH { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ChiTietSPBan>()
				.HasMany(e => e.ChiTietDH)
				.WithRequired(e => e.ChiTietSPBan)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<DonHang>()
				.Property(e => e.PTThanhToan)
				.IsFixedLength();

			modelBuilder.Entity<DonHang>()
				.HasMany(e => e.ChiTietDH)
				.WithRequired(e => e.DonHang)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<MauSac>()
				.HasMany(e => e.SPtheoMau)
				.WithRequired(e => e.MauSac)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NguoiDung>()
				.HasMany(e => e.DonHang)
				.WithRequired(e => e.NguoiDung)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PhanLoai>()
				.HasMany(e => e.SanPham)
				.WithRequired(e => e.PhanLoai)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PhanLoaiPhu>()
				.HasMany(e => e.SanPham)
				.WithRequired(e => e.PhanLoaiPhu)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SanPham>()
				.HasMany(e => e.SPtheoMau)
				.WithRequired(e => e.SanPham)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SPtheoMau>()
				.HasMany(e => e.ChiTietSPBan)
				.WithRequired(e => e.SPtheoMau)
				.WillCascadeOnDelete(false);
		}
	}
}
