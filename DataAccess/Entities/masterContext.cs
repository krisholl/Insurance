using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claims");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Doctor).HasColumnName("doctor");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Policy).HasColumnName("policy");

                entity.Property(e => e.ReasonForVisit)
                    .IsUnicode(false)
                    .HasColumnName("reasonForVisit");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Pending')");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.ClaimDoctorNavigations)
                    .HasForeignKey(d => d.Doctor)
                    .HasConstraintName("FK__claims__doctor__2882FE7D");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.ClaimPatientNavigations)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK__claims__patient__278EDA44");

                entity.HasOne(d => d.PolicyNavigation)
                    .WithMany(p => p.ClaimPolicyNavigations)
                    .HasForeignKey(d => d.Policy)
                    .HasConstraintName("FK__claims__policy__297722B6");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.PoNumber).HasColumnName("poNumber");

                entity.Property(e => e.PoOrStreet).HasColumnName("PO_or_street");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("streetName");

                entity.Property(e => e.StreetNumber).HasColumnName("streetNumber");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coverage)
                    .IsUnicode(false)
                    .HasColumnName("coverage");

                entity.Property(e => e.Insurance).HasColumnName("insurance");

                entity.HasOne(d => d.InsuranceNavigation)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.Insurance)
                    .HasConstraintName("FK__policy__insuranc__24B26D99");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Claim).HasColumnName("claim");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.Patient).HasColumnName("patient");

                entity.Property(e => e.Policy).HasColumnName("policy");

                entity.HasOne(d => d.ClaimNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Claim)
                    .HasConstraintName("FK__ticket__claim__2D47B39A");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK__ticket__patient__2E3BD7D3");

                entity.HasOne(d => d.PolicyNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Policy)
                    .HasConstraintName("FK__ticket__policy__2F2FFC0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572AD844E7F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactIdFk).HasColumnName("contact_idFK");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleInit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("middleInit")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ContactIdFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactIdFk)
                    .HasConstraintName("FK__Users__contact_i__1EF99443");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
