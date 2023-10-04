﻿// <auto-generated />
using System;
using AcneTeledermatology.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    [DbContext(typeof(AcneTeleContext))]
    [Migration("20231004164057_FifthMigration")]
    partial class FifthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcneTeledermatology.Models.Derm", b =>
                {
                    b.Property<int>("IDDerm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDerm"));

                    b.HasKey("IDDerm");

                    b.ToTable("Derm", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.DermPatientHistory", b =>
                {
                    b.Property<int>("IDDermPatientHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDermPatientHistory"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IDUserDermRequestResponse")
                        .HasColumnType("int");

                    b.HasKey("IDDermPatientHistory");

                    b.ToTable("DermPatientHistory", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.DermProfile", b =>
                {
                    b.Property<int>("IDDermProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDermProfile"));

                    b.Property<DateTime>("DermDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DermEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DermName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DermPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDDerm")
                        .HasColumnType("int");

                    b.HasKey("IDDermProfile");

                    b.ToTable("DermProfile", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.User", b =>
                {
                    b.Property<int>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUser"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("IDUser");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserAssessment", b =>
                {
                    b.Property<int>("IDUserAssessment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserAssessment"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<string>("ImageToTestPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Score_In_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("image_to_test_path")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IDUserAssessment");

                    b.ToTable("UserAssessment", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserAssessmentHistory", b =>
                {
                    b.Property<int>("IDUserAssessmentHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserAssessmentHistory"));

                    b.Property<int>("IDUserAssessment")
                        .HasColumnType("int");

                    b.HasKey("IDUserAssessmentHistory");

                    b.ToTable("UserAssessmentHistory", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserDermRequest", b =>
                {
                    b.Property<int>("IDUserDermRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserDermRequest"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<int?>("IDUserSupplementalAcneProfile")
                        .HasColumnType("int");

                    b.HasKey("IDUserDermRequest");

                    b.ToTable("UserDermRequest", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserDermRequestResponse", b =>
                {
                    b.Property<int>("IDUserDermRequestResponse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserDermRequestResponse"));

                    b.Property<string>("DermComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DermPrescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DermSuggestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDDerm")
                        .HasColumnType("int");

                    b.Property<int?>("IDUserDermRequest")
                        .HasColumnType("int");

                    b.HasKey("IDUserDermRequestResponse");

                    b.ToTable("UserDermRequestResponse", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserProfile", b =>
                {
                    b.Property<int>("IDUserProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserProfile"));

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProfileImagePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IDUserProfile");

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("AcneTeledermatology.Models.UserSupplementalAcneProfile", b =>
                {
                    b.Property<int>("IDUserSupplementalAcneProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUserSupplementalAcneProfile"));

                    b.Property<int>("DietHabit")
                        .HasColumnType("int");

                    b.Property<int>("IDUser")
                        .HasColumnType("int");

                    b.Property<string>("SkincareProducts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SleepingPattern")
                        .HasColumnType("int");

                    b.Property<int>("SunExposure")
                        .HasColumnType("int");

                    b.Property<int>("SunblockHabit")
                        .HasColumnType("int");

                    b.HasKey("IDUserSupplementalAcneProfile");

                    b.ToTable("UserSupplementalAcneProfile", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
