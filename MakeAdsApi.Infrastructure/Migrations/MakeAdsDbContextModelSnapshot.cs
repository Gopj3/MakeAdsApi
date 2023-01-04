﻿// <auto-generated />
using System;
using MakeAdsApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakeAdsApi.Infrastructure.Migrations
{
    [DbContext(typeof(MakeAdsDbContext))]
    partial class MakeAdsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Brandings.Branding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandingLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandingTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RetailDataProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandingId")
                        .IsUnique()
                        .HasFilter("[BrandingId] IS NOT NULL");

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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RadiusInKm")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAutoCreationConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BaseMediaLibraryFiles", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeltaMediaConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MetaMediaConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SnapChatMediaConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandingId")
                        .IsUnique()
                        .HasFilter("[BrandingId] IS NOT NULL");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DeltaMediaConfigId")
                        .IsUnique()
                        .HasFilter("[DeltaMediaConfigId] IS NOT NULL");

                    b.HasIndex("MetaMediaConfigId")
                        .IsUnique()
                        .HasFilter("[MetaMediaConfigId] IS NOT NULL");

                    b.HasIndex("SnapChatMediaConfigId")
                        .IsUnique()
                        .HasFilter("[SnapChatMediaConfigId] IS NOT NULL");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FetchPropertyDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FetchUserDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatePropertyDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateUserDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RetailDataProviders");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DeltaMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaUiTemplateConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeltaMediaConfigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TemplateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeltaMediaConfigId");

                    b.ToTable("DeltaUiTemplateConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.MetaMediaConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacebookBusinessPageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramBusinessPageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MetaMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.SnapChatMediaConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SnapChatMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HasPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryImage", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile");

                    b.ToTable("MediaLibraryImages", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryVideo", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile");

                    b.Property<string>("FacebookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MediaLibraryVideos", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Brandings.Branding", "Branding")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Companies.Company", "BrandingId");

                    b.HasOne("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", "RetailDataProvider")
                        .WithMany("Companies")
                        .HasForeignKey("RetailDataProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branding");

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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Brandings.Branding", "Branding")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Offices.Office", "BrandingId");

                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", null)
                        .WithMany("Offices")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", "DeltaMediaConfig")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Offices.Office", "DeltaMediaConfigId");

                    b.HasOne("MakeAdsApi.Domain.Entities.SocialMedias.MetaMediaConfig", "MetaMediaConfig")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Offices.Office", "MetaMediaConfigId");

                    b.HasOne("MakeAdsApi.Domain.Entities.SocialMedias.SnapChatMediaConfig", "SnapChatMediaConfig")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Offices.Office", "SnapChatMediaConfigId");

                    b.Navigation("Branding");

                    b.Navigation("DeltaMediaConfig");

                    b.Navigation("MetaMediaConfig");

                    b.Navigation("SnapChatMediaConfig");
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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithMany("Users")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserProfile", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Users.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Users.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserRole", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Users.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakeAdsApi.Domain.Entities.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryImage", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryImage", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryVideo", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.MediaLibrary.BaseMediaLibraryFile", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.MediaLibrary.MediaLibraryVideo", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
