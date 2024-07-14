using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PAsswordRepos.Services.DbModels;

namespace PAsswordRepos.Services
{
    public partial class PasswordsDirectoryContext : DbContext
    {
        public PasswordsDirectoryContext()
        {
        }

        public PasswordsDirectoryContext(DbContextOptions<PasswordsDirectoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<TypePassword> TypePasswords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=PasswordDirectory.mssql.somee.com;packet size=4096;user id=tested_SQLLogin_1;pwd=mjmbddqsqh;data source=PasswordDirectory.mssql.somee.com;persist security info=False;initial catalog=PasswordDirectory;TrustServerCertificate=True");
                //
                //Server = IGA; Database = PasswordsDirectory; Trusted_Connection = True;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Password__3214EC070E900275");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Password1)

                    .HasColumnName("Password");

                entity.HasOne(d => d.TypePasswordNavigation)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.TypePassword)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passwords__TypeP__1273C1CD");
            });

            modelBuilder.Entity<TypePassword>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TypePass__3214EC07465E70DA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
