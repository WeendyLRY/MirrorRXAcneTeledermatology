using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace AcneTeledermatology.Data
{
    public class AcneTeleContext : IdentityDbContext<IdentityUser>

    //public class AcneTeleContext : DbContext
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
            base.OnModelCreating(modelBuilder);
           

            modelBuilder.Entity<UserSupplementalAcneProfile>().HasKey(e => e.IDUserSupplementalAcneProfile);

            //        modelBuilder.Entity<UserSupplementalAcneProfile>()
            //.HasOne(up => up.User)
            //.WithMany(u => u.UserSupplementalAcneProfiles)
            //.HasForeignKey(up => up.Id)
            //.OnDelete(DeleteBehavior.Cascade);


            //        modelBuilder.Entity<User>()
            //  .HasMany(e => e.UserSupplementalAcneProfiles)
            //  .WithOne(e => e.User)
            //  .HasForeignKey(e => e.Id)
            //        .IsRequired(false);

            //        //modelBuilder.Entity<User>()
            //        //  .HasOne(e => e.UserProfile)
            //        //.WithOne(e => e.User)
            //        //  .HasForeignKey<UserProfile>(e => e.Id)
            //        //  .IsRequired()
            //        //  .OnDelete(DeleteBehavior.Cascade);


            //        modelBuilder.Entity<UserSupplementalAcneProfile>()
            //   .HasMany(e => e.UserDermRequests)
            //   .WithOne(e => e.UserSupplementalAcneProfile)
            //   .HasForeignKey(e => e.IDUserSupplementalAcneProfile)
            //   .IsRequired(false)
            //   .OnDelete(DeleteBehavior.Cascade);

            //        modelBuilder.Entity<User>()
            //   .HasMany(e => e.UserAssessments)
            //   .WithOne(e => e.User)
            //   .HasForeignKey(e => e.Id)
            //   .IsRequired(false)
            //   .OnDelete(DeleteBehavior.Cascade);


            //        modelBuilder.Entity<User>()
            //  .HasMany(e => e.UserDermRequests)
            //  .WithOne(e => e.User)
            //  .HasForeignKey(e => e.Id)
            //  .IsRequired(false)
            //  .OnDelete(DeleteBehavior.Cascade);



            //        modelBuilder.Entity<UserProfile>()
            //.HasMany(e => e.UserDermRequests)
            //.WithOne(e => e.UserProfile)
            //.HasForeignKey(e => e.IDUserProfile)
            //.IsRequired(false)
            //.OnDelete(DeleteBehavior.Cascade);


            //       modelBuilder.Entity<UserDermRequestResponse>()
            //.HasOne(udrr => udrr.DermProfile)
            //.WithMany(dp => dp.UserDermRequestResponses)
            //.HasForeignKey(udrr => udrr.IDDermProfile)
            //.OnDelete(DeleteBehavior.Cascade);


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
