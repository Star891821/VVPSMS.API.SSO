using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VVPSMSV1.API.SSO.Domain.Models;

public partial class VvpsmsSsoContext : DbContext
{
    public VvpsmsSsoContext()
    {
    }

    public VvpsmsSsoContext(DbContextOptions<VvpsmsSsoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<AzureBlobConfiguration> AzureBlobConfigurations { get; set; }

    public virtual DbSet<GoogleConfiguration> GoogleConfigurations { get; set; }

    public virtual DbSet<MicroSoftConfiguration> MicroSoftConfigurations { get; set; }

    public virtual DbSet<MstPermission> MstPermissions { get; set; }

    public virtual DbSet<MstRoleType> MstRoleTypes { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<MstUserRole> MstUserRoles { get; set; }

    public virtual DbSet<RolePermissionsMapping> RolePermissionsMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Dell;Initial Catalog=VVPSMS_SSO;User Id=sa;Password=sql2019;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;Column Encryption Setting=enabled;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__tmp_ms_x__F49C60C16DF00562");

            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.ApplicantGivenName)
                .HasMaxLength(255)
                .UseCollation("Latin1_General_BIN2")
                .HasColumnName("applicant_givenName");
            entity.Property(e => e.ApplicantLoginType)
                .HasMaxLength(255)
                .HasColumnName("applicant_loginType");
            entity.Property(e => e.ApplicantPhone)
                .HasMaxLength(15)
                .HasColumnName("applicant_phone");
            entity.Property(e => e.ApplicantSurname)
                .HasMaxLength(255)
                .HasColumnName("applicant_surname");
            entity.Property(e => e.Applicantemail)
                .HasMaxLength(255)
                .UseCollation("Latin1_General_BIN2")
                .HasColumnName("applicantemail");
            entity.Property(e => e.Applicantname)
                .HasMaxLength(255)
                .UseCollation("Latin1_General_BIN2")
                .HasColumnName("applicantname");
            entity.Property(e => e.Applicantpassword)
                .HasMaxLength(255)
                .UseCollation("Latin1_General_BIN2")
                .HasColumnName("applicantpassword");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
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

            entity.HasOne(d => d.Role).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicant__role___5535A963");
        });

        modelBuilder.Entity<AzureBlobConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AzureBlobConfiguration");

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
            entity
                .HasNoKey()
                .ToTable("GoogleConfiguration");

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
            entity
                .HasNoKey()
                .ToTable("MicroSoftConfiguration");

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
            entity.HasKey(e => e.PermissionId).HasName("PK__MstPermi__E5331AFAE2EF4F78");

            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
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
            entity.HasKey(e => e.RoletypeId).HasName("PK__MstRoleT__5C2E375A95DE9E20");

            entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
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
            entity.HasKey(e => e.UserId).HasName("PK__MstUsers__B9BE370FC6F1C060");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
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

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MstUsers__role_i__398D8EEE");
        });

        modelBuilder.Entity<MstUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__MstUserR__760965CC56DB04C3");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
            entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");

            entity.HasOne(d => d.Roletype).WithMany(p => p.MstUserRoles)
                .HasForeignKey(d => d.RoletypeId)
                .HasConstraintName("FK__MstUserRo__rolet__4CA06362");
        });

        modelBuilder.Entity<RolePermissionsMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__RolePerm__5AE9004551F6F1ED");

            entity.ToTable("RolePermissionsMapping");

            entity.Property(e => e.MappingId).HasColumnName("mapping_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissionsMappings)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__permi__4BAC3F29");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissionsMappings)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__role___4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
