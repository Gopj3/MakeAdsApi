﻿// <auto-generated />
using System;
using MakeAdsApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakeAdsApi.Infrastructure.Migrations
{
    [DbContext(typeof(MakeAdsDbContext))]
    [Migration("20221226113301_TestInit004")]
    partial class TestInit004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RetailDataProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RetailDataProviderId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.CompanyAutoCreationConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdCaption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailableSocialMedias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RadiusInKm")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAutoCreationConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FetchPropertyDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FetchUserDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatePropertyDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateUserDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RetailDataProviders");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasFilter("[CompanyId] IS NOT NULL");

                    b.HasIndex("OfficeId")
                        .IsUnique()
                        .HasFilter("[OfficeId] IS NOT NULL");

                    b.ToTable("DeltaMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaUiTemplateConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeltaMediaConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TemplateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeltaMediaConfigId");

                    b.ToTable("DeltaUiTemplateConfig");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.MetaSocialMediaConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FacebookBusinessPageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasFilter("[CompanyId] IS NOT NULL");

                    b.HasIndex("OfficeId")
                        .IsUnique()
                        .HasFilter("[OfficeId] IS NOT NULL");

                    b.ToTable("MetaSocialMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", "RetailDataProvider")
                        .WithMany("Companies")
                        .HasForeignKey("RetailDataProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RetailDataProvider");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.CompanyAutoCreationConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", "Company")
                        .WithMany("AutoCreationConfigs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", null)
                        .WithMany("Offices")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", "Company")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", "CompanyId");

                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", "OfficeId");

                    b.Navigation("Company");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaUiTemplateConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", "DeltaMediaConfig")
                        .WithMany("DeltaUiTemplateConfigs")
                        .HasForeignKey("DeltaMediaConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeltaMediaConfig");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.MetaSocialMediaConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", "Company")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.MetaSocialMediaConfig", "CompanyId");

                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.MetaSocialMediaConfig", "OfficeId");

                    b.Navigation("Company");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.User", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithMany("Users")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.UserProfile", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakeAdsApi.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.Navigation("AutoCreationConfigs");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", b =>
                {
                    b.Navigation("DeltaUiTemplateConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}