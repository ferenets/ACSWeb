﻿// <auto-generated />
using ACSWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ACSWeb.Migrations
{
    [DbContext(typeof(GTSContext))]
    partial class GTSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("ACSWeb.Models.AOType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AOTableName");

                    b.Property<string>("ControllerName");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.ToTable("AOType");
                });

            modelBuilder.Entity("ACSWeb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ACSWeb.Models.GPA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AOTypeID");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("EngineName");

                    b.Property<string>("EngineType");

                    b.Property<int>("KSID");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<float>("Power");

                    b.Property<int?>("SAKID");

                    b.Property<int>("StationNumber");

                    b.Property<string>("VCNName");

                    b.HasKey("ID");

                    b.HasIndex("KSID");

                    b.HasIndex("SAKID");

                    b.ToTable("GPA");
                });

            modelBuilder.Entity("ACSWeb.Models.KS", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AOTypeID");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("LVUID");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("ID");

                    b.HasIndex("LVUID");

                    b.ToTable("KS");
                });

            modelBuilder.Entity("ACSWeb.Models.KSPipeline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("KSID");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<int>("PipelineID");

                    b.HasKey("ID");

                    b.HasIndex("KSID");

                    b.HasIndex("PipelineID");

                    b.ToTable("KSPipeline");
                });

            modelBuilder.Entity("ACSWeb.Models.LVU", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("UMGID");

                    b.HasKey("ID");

                    b.HasIndex("UMGID");

                    b.ToTable("LVU");
                });

            modelBuilder.Entity("ACSWeb.Models.Pipeline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.ToTable("Pipeline");
                });

            modelBuilder.Entity("ACSWeb.Models.PLC", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("ID");

                    b.ToTable("PLC");
                });

            modelBuilder.Entity("ACSWeb.Models.SAK", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AOID");

                    b.Property<int>("AOTypeID");

                    b.Property<DateTime>("CommisioningDate");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("PLCID");

                    b.Property<int>("SAKTypeID");

                    b.Property<string>("Seller");

                    b.HasKey("ID");

                    b.HasIndex("AOTypeID");

                    b.HasIndex("PLCID");

                    b.HasIndex("SAKTypeID");

                    b.ToTable("SAK");
                });

            modelBuilder.Entity("ACSWeb.Models.SAKType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("ID");

                    b.ToTable("SAKType");
                });

            modelBuilder.Entity("ACSWeb.Models.UMG", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastEditDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.ToTable("UMG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ACSWeb.Models.GPA", b =>
                {
                    b.HasOne("ACSWeb.Models.KS", "KS")
                        .WithMany("GPAList")
                        .HasForeignKey("KSID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACSWeb.Models.SAK", "SAK")
                        .WithMany()
                        .HasForeignKey("SAKID");
                });

            modelBuilder.Entity("ACSWeb.Models.KS", b =>
                {
                    b.HasOne("ACSWeb.Models.LVU", "LVU")
                        .WithMany("KSList")
                        .HasForeignKey("LVUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ACSWeb.Models.KSPipeline", b =>
                {
                    b.HasOne("ACSWeb.Models.KS", "KS")
                        .WithMany("PipelineList")
                        .HasForeignKey("KSID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACSWeb.Models.Pipeline", "Pipeline")
                        .WithMany("KSList")
                        .HasForeignKey("PipelineID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ACSWeb.Models.LVU", b =>
                {
                    b.HasOne("ACSWeb.Models.UMG", "UMG")
                        .WithMany("VLUList")
                        .HasForeignKey("UMGID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ACSWeb.Models.SAK", b =>
                {
                    b.HasOne("ACSWeb.Models.AOType", "AOType")
                        .WithMany()
                        .HasForeignKey("AOTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACSWeb.Models.PLC", "PLC")
                        .WithMany()
                        .HasForeignKey("PLCID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACSWeb.Models.SAKType", "SAKType")
                        .WithMany()
                        .HasForeignKey("SAKTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ACSWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ACSWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ACSWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ACSWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
