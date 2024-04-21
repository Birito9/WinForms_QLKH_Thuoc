﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_QLKH.Models;

public partial class QLKH_ThuocContext : DbContext
{
    public QLKH_ThuocContext(DbContextOptions<QLKH_ThuocContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("YourConnectionString");
        }
    }

    public virtual DbSet<ChiNhanh> ChiNhanh { get; set; }

    public virtual DbSet<ChiTietDonNhap> ChiTietDonNhap { get; set; }

    public virtual DbSet<ChiTietDonXuat> ChiTietDonXuat { get; set; }

    public virtual DbSet<ChiTietThuoc> ChiTietThuoc { get; set; }

    public virtual DbSet<DonNhap> DonNhap { get; set; }

    public virtual DbSet<DonXuat> DonXuat { get; set; }

    public virtual DbSet<Kho> Kho { get; set; }

    public virtual DbSet<Lo> Lo { get; set; }

    public virtual DbSet<NCC> NCC { get; set; }

    public virtual DbSet<NhanVien> NhanVien { get; set; }

    public virtual DbSet<NhomThuoc> NhomThuoc { get; set; }

    public virtual DbSet<Permission> Permission { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<Role_Permission> Role_Permission { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

    public virtual DbSet<Thuoc> Thuoc { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.CN_ID);

            entity.Property(e => e.CN_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CN_Address).HasMaxLength(50);
            entity.Property(e => e.CN_Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiTietDonNhap>(entity =>
        {
            entity.HasKey(e => e.DNhap_ID);

            entity.Property(e => e.DNhap_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Lo_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Thuoc_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.DNhap).WithOne(p => p.ChiTietDonNhap)
                .HasForeignKey<ChiTietDonNhap>(d => d.DNhap_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonNhap_DonNhap");

            entity.HasOne(d => d.Lo).WithMany(p => p.ChiTietDonNhap)
                .HasForeignKey(d => d.Lo_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonNhap_Lo");

            entity.HasOne(d => d.Thuoc).WithMany(p => p.ChiTietDonNhap)
                .HasForeignKey(d => d.Thuoc_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonNhap_Thuoc");
        });

        modelBuilder.Entity<ChiTietDonXuat>(entity =>
        {
            entity.HasKey(e => e.DXuat_ID);

            entity.Property(e => e.DXuat_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Thuoc_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.DXuat).WithOne(p => p.ChiTietDonXuat)
                .HasForeignKey<ChiTietDonXuat>(d => d.DXuat_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonXuat_DonXuat");

            entity.HasOne(d => d.Thuoc).WithMany(p => p.ChiTietDonXuat)
                .HasForeignKey(d => d.Thuoc_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonXuat_Thuoc");
        });

        modelBuilder.Entity<ChiTietThuoc>(entity =>
        {
            entity.HasKey(e => e.Thuoc_ID).HasName("PK_ChiTietThuoc_1");

            entity.Property(e => e.Thuoc_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Lo_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Lo).WithMany(p => p.ChiTietThuoc)
                .HasForeignKey(d => d.Lo_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietThuoc_Lo");

            entity.HasOne(d => d.Thuoc).WithOne(p => p.ChiTietThuoc)
                .HasForeignKey<ChiTietThuoc>(d => d.Thuoc_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietThuoc_Thuoc");
        });

        modelBuilder.Entity<DonNhap>(entity =>
        {
            entity.HasKey(e => e.DNhap_ID);

            entity.Property(e => e.DNhap_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DN_Datetime).HasColumnType("datetime");
            entity.Property(e => e.DN_Name).HasMaxLength(50);
            entity.Property(e => e.NCC_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NV_ID)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.NCC).WithMany(p => p.DonNhap)
                .HasForeignKey(d => d.NCC_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonNhap_NCC");

            entity.HasOne(d => d.NV).WithMany(p => p.DonNhap)
                .HasForeignKey(d => d.NV_ID)
                .HasConstraintName("FK_DonNhap_NhanVien");
        });

        modelBuilder.Entity<DonXuat>(entity =>
        {
            entity.HasKey(e => e.DXuat_ID);

            entity.Property(e => e.DXuat_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DX_Datetime).HasColumnType("datetime");
            entity.Property(e => e.DX_Name).HasMaxLength(50);
            entity.Property(e => e.NV_ID)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.NV).WithMany(p => p.DonXuat)
                .HasForeignKey(d => d.NV_ID)
                .HasConstraintName("FK_DonXuat_NhanVien");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.Kho_ID);

            entity.Property(e => e.Kho_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CN_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Kho_Address).HasMaxLength(50);
            entity.Property(e => e.Kho_Name).HasMaxLength(50);

            entity.HasOne(d => d.CN).WithMany(p => p.Kho)
                .HasForeignKey(d => d.CN_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kho_ChiNhanh");
        });

        modelBuilder.Entity<Lo>(entity =>
        {
            entity.HasKey(e => e.Lo_ID);

            entity.Property(e => e.Lo_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Kho_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Lo_Name).HasMaxLength(50);
            entity.Property(e => e.Lo_Position).HasMaxLength(50);

            entity.HasOne(d => d.Kho).WithMany(p => p.Lo)
                .HasForeignKey(d => d.Kho_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lo_Kho");
        });

        modelBuilder.Entity<NCC>(entity =>
        {
            entity.HasKey(e => e.NCC_ID);

            entity.Property(e => e.NCC_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NCC_Address).HasMaxLength(50);
            entity.Property(e => e.NCC_Name).HasMaxLength(50);
            entity.Property(e => e.NCC_Phone).HasMaxLength(15);
            entity.Property(e => e.NCC_Status).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.NV_ID);

            entity.Property(e => e.NV_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.CN_ID)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NV_Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Sex).HasMaxLength(20);
            entity.Property(e => e.UserID)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.CN).WithMany(p => p.NhanVien)
                .HasForeignKey(d => d.CN_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_ChiNhanh1");

            entity.HasOne(d => d.User).WithMany(p => p.NhanVien)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK_NhanVien_TaiKhoan");
        });

        modelBuilder.Entity<NhomThuoc>(entity =>
        {
            entity.HasKey(e => e.Nhom_ID);

            entity.Property(e => e.Nhom_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nhom_Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.PermissionID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role_Permission>(entity =>
        {
            entity.HasKey(e => new { e.RoleID, e.PermissionID });

            entity.Property(e => e.RoleID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PermissionID)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Permission).WithMany(p => p.Role_Permission)
                .HasForeignKey(d => d.PermissionID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Permission_Permission1");

            entity.HasOne(d => d.Role).WithMany(p => p.Role_Permission)
                .HasForeignKey(d => d.RoleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Permission_Role1");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK_User");

            entity.Property(e => e.UserID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.RoleID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TaiKhoan)
                .HasForeignKey(d => d.RoleID)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.Thuoc_ID);

            entity.Property(e => e.Thuoc_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nhom_ID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Thuoc_Name).HasMaxLength(50);

            entity.HasOne(d => d.Nhom).WithMany(p => p.Thuoc)
                .HasForeignKey(d => d.Nhom_ID)
                .HasConstraintName("FK_Thuoc_NhomThuoc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}