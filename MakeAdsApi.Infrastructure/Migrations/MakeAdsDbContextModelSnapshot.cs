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

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Budgets.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Budgets", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Budgets.BudgetItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetItems", (string)null);
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

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<DateTime?>("DeletedAt")
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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreSignedUrl")
                        .HasColumnType("varchar(768)");

                    b.Property<DateTime?>("PreSignedUrlCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Files", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.RetailDataProviders.RetailDataProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FetchPropertyDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FetchUserDataUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
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

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique();

                    b.ToTable("DeltaMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaUiTemplateConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacebookBusinessPageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramBusinessPageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique();

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

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique();

                    b.ToTable("SnapChatMediaConfigs");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Admin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("69508328-5e83-4ef5-9774-24f8e6f0d4ec"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "User",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                            CreatedAt = new DateTime(2023, 1, 31, 21, 27, 28, 835, DateTimeKind.Utc).AddTicks(9690),
                            Email = "admin@admin-nordic.com",
                            Password = "$2a$12$h2M8uB7ZMd3.wn3JHv4TcujBEs3HRy7rQ2eX1LS4GxKq1JPVm9C16",
                            UpdatedAt = new DateTime(2023, 1, 31, 21, 27, 28, 835, DateTimeKind.Utc).AddTicks(9770)
                        });
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
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

                    b.Property<DateTime?>("DeletedAt")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("85231998-5e83-4ef5-9774-24f8e6f0d4ec"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("59508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("49508398-5e83-4ef5-9774-24f8e6f0d4ec")
                        });
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.Files.File");

                    b.Property<string>("RetailPropertyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.ToTable("BaseMediaLibraryFiles", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.UserProfileAvatar", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.Files.File");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserProfileId")
                        .IsUnique()
                        .HasFilter("[UserProfileId] IS NOT NULL");

                    b.ToTable("UserProfileAvatars", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryImage", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile");

                    b.ToTable("MediaLibraryImages", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryVideo", b =>
                {
                    b.HasBaseType("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile");

                    b.Property<string>("FacebookId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SnapChatId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MediaLibraryVideos", (string)null);
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Budgets.Budget", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", "Company")
                        .WithMany("Budgets")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Budgets.BudgetItem", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Budgets.Budget", "Budget")
                        .WithMany("BudgetItems")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Brandings.Branding", "Branding")
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Offices.Office", "BrandingId");

                    b.HasOne("MakeAdsApi.Domain.Entities.Companies.Company", "Company")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branding");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithOne("DeltaMediaConfig")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.DeltaMediaConfig", "OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.MetaMediaConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithOne("MetaMediaConfig")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.MetaMediaConfig", "OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.SocialMedias.SnapChatMediaConfig", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithOne("SnapChatMediaConfig")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.SocialMedias.SnapChatMediaConfig", "OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Offices.Office", "Office")
                        .WithMany("Users")
                        .HasForeignKey("OfficeId");

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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Files.File", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MakeAdsApi.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.UserProfileAvatar", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Files.File", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Files.UserProfileAvatar", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MakeAdsApi.Domain.Entities.Users.UserProfile", "UserProfile")
                        .WithOne("Avatar")
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Files.UserProfileAvatar", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryImage", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryImage", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryVideo", b =>
                {
                    b.HasOne("MakeAdsApi.Domain.Entities.Files.MediaLibrary.BaseMediaLibraryFile", null)
                        .WithOne()
                        .HasForeignKey("MakeAdsApi.Domain.Entities.Files.MediaLibrary.MediaLibraryVideo", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Budgets.Budget", b =>
                {
                    b.Navigation("BudgetItems");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Companies.Company", b =>
                {
                    b.Navigation("AutoCreationConfigs");

                    b.Navigation("Budgets");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Offices.Office", b =>
                {
                    b.Navigation("DeltaMediaConfig");

                    b.Navigation("MetaMediaConfig");

                    b.Navigation("SnapChatMediaConfig");

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

            modelBuilder.Entity("MakeAdsApi.Domain.Entities.Users.UserProfile", b =>
                {
                    b.Navigation("Avatar");
                });
#pragma warning restore 612, 618
        }
    }
}
