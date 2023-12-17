using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VVPSMSV1.API.SSO.Domain.Models
{
    public partial class VVPSMSDBV1Context : DbContext
    {
        public VVPSMSDBV1Context()
        {
        }

        public VVPSMSDBV1Context(DbContextOptions<VVPSMSDBV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AzureBlobConfiguration> AzureBlobConfigurations { get; set; } = null!;
        public virtual DbSet<GoogleConfiguration> GoogleConfigurations { get; set; } = null!;
        public virtual DbSet<MicroSoftConfiguration> MicroSoftConfigurations { get; set; } = null!;
        public virtual DbSet<MstPermission> MstPermissions { get; set; } = null!;
        public virtual DbSet<MstRoleType> MstRoleTypes { get; set; } = null!;
        public virtual DbSet<MstUser> MstUsers { get; set; } = null!;
        public virtual DbSet<MstUserRole> MstUserRoles { get; set; } = null!;
        public virtual DbSet<RolePermissionsMapping> RolePermissionsMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Initial Catalog=VVPSMSDBV1;User Id=sa;Password=1992;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AzureBlobConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AzureBlobConfiguration");

                entity.Property(e => e.BlobContainerName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DomainCode).HasMaxLength(200);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GoogleConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GoogleConfiguration");

                entity.Property(e => e.ActiveYn).HasColumnName("ActiveYN");

                entity.Property(e => e.ApplicationName).HasMaxLength(500);

                entity.Property(e => e.ClientId).HasMaxLength(500);

                entity.Property(e => e.ClientSecretCode).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DomainCode).HasMaxLength(200);

                entity.Property(e => e.GrantType).HasMaxLength(100);

                entity.Property(e => e.GraphUrl).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Oauthurl).HasMaxLength(500);

                entity.Property(e => e.RedirectUrl).HasMaxLength(500);

                entity.Property(e => e.Scopes).HasMaxLength(500);

                entity.Property(e => e.TokenUrl).HasMaxLength(500);

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MicroSoftConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MicroSoftConfiguration");

                entity.Property(e => e.ActiveYn).HasColumnName("ActiveYN");

                entity.Property(e => e.ClientId).HasMaxLength(500);

                entity.Property(e => e.ClientSecretCode).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DomainCode).HasMaxLength(200);

                entity.Property(e => e.GrantType).HasMaxLength(100);

                entity.Property(e => e.GraphUrl).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RedirectUrl).HasMaxLength(500);

                entity.Property(e => e.ScopeUrl).HasMaxLength(500);

                entity.Property(e => e.TokenUrl).HasMaxLength(500);

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK__MstPermi__E5331AFA87F2D13F");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.ActiveYn).HasColumnName("activeYN");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.PermissionDetails)
                    .HasMaxLength(255)
                    .HasColumnName("permission_details");

                entity.Property(e => e.PermissionName)
                    .HasMaxLength(255)
                    .HasColumnName("permission_name");
            });

            modelBuilder.Entity<MstRoleType>(entity =>
            {
                entity.HasKey(e => e.RoletypeId)
                    .HasName("PK__MstRoleT__5C2E375A873A410D");

                entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");

                entity.Property(e => e.ActiveYn).HasColumnName("activeYN");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.RoletypeName)
                    .HasMaxLength(255)
                    .HasColumnName("roletype_name");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__MstUsers__B9BE370F73CA664F");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Enforce2Fa).HasColumnName("enforce2FA");

                entity.Property(e => e.LastloginAt)
                    .HasColumnType("datetime")
                    .HasColumnName("lastlogin_at");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserGivenName)
                    .HasMaxLength(255)
                    .HasColumnName("user_givenName");

                entity.Property(e => e.UserLoginType)
                    .HasMaxLength(255)
                    .HasColumnName("user_loginType");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .HasColumnName("user_phone");

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(255)
                    .HasColumnName("user_surname");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(255)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(255)
                    .HasColumnName("userpassword");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MstUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MstUsers__role_i__3B75D760");
            });

            modelBuilder.Entity<MstUserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__MstUserR__760965CC23E7FCD0");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ActiveYn).HasColumnName("activeYN");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");

                entity.HasOne(d => d.Roletype)
                    .WithMany(p => p.MstUserRoles)
                    .HasForeignKey(d => d.RoletypeId)
                    .HasConstraintName("FK__MstUserRo__rolet__46E78A0C");
            });

            modelBuilder.Entity<RolePermissionsMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__RolePerm__5AE900459CFBC7D1");

                entity.ToTable("RolePermissionsMapping");

                entity.Property(e => e.MappingId).HasColumnName("mapping_id");

                entity.Property(e => e.ActiveYn).HasColumnName("activeYN");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissionsMappings)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolePermi__permi__45F365D3");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissionsMappings)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolePermi__role___44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
