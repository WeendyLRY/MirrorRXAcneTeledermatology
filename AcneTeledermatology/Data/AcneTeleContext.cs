using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Models;
using System.Diagnostics;

namespace AcneTeledermatology.Data
{
    public class AcneTeleContext : DbContext
    {
        public AcneTeleContext (DbContextOptions<AcneTeleContext> options)
            : base(options)
        {
        }
        // DbSet properties for your models
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserSupplementalAcneProfile> UserSupplementalAcneProfiles { get; set; }
        public DbSet<UserAssessment> UserAssessments { get; set; }
        public DbSet<UserAssessmentHistory> UserAssessmentHistories { get; set; }
        public DbSet<UserDermRequest> UserDermRequests { get; set; }
        public DbSet<UserDermRequestResponse> UserDermRequestResponses { get; set; }
        public DbSet<Derm> Derms { get; set; }
        public DbSet<DermProfile> DermProfiles { get; set; }
        public DbSet<DermPatientHistory> DermPatientHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names if needed (optional)
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserProfile>().ToTable("UserProfile");
            modelBuilder.Entity<UserSupplementalAcneProfile>().ToTable("UserSupplementalAcneProfile");
            modelBuilder.Entity<UserAssessment>().ToTable("UserAssessment");
            modelBuilder.Entity<UserAssessmentHistory>().ToTable("UserAssessmentHistory");
            modelBuilder.Entity<UserDermRequest>().ToTable("UserDermRequest");
            modelBuilder.Entity<UserDermRequestResponse>().ToTable("UserDermRequestResponse");
            modelBuilder.Entity<Derm>().ToTable("Derm");
            modelBuilder.Entity<DermProfile>().ToTable("DermProfile");
            modelBuilder.Entity<DermPatientHistory>().ToTable("DermPatientHistory");
        }
    }

   
}
