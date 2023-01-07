using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeAdsApi.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandingTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandingLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeltaMediaConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeltaMediaConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaMediaConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdAccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramBusinessPageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookBusinessPageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaMediaConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetailDataProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FetchPropertyDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatePropertyDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FetchUserDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUserDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailDataProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnapChatMediaConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdAccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapChatMediaConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeltaUiTemplateConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeltaMediaConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeltaUiTemplateConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeltaUiTemplateConfigs_DeltaMediaConfigs_DeltaMediaConfigId",
                        column: x => x.DeltaMediaConfigId,
                        principalTable: "DeltaMediaConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetailDataProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Branding_BrandingId",
                        column: x => x.BrandingId,
                        principalTable: "Branding",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_RetailDataProviders_RetailDataProviderId",
                        column: x => x.RetailDataProviderId,
                        principalTable: "RetailDataProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAutoCreationConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdCaption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadiusInKm = table.Column<int>(type: "int", nullable: false),
                    AvailableSocialMedias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAutoCreationConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAutoCreationConfigs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeltaMediaConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MetaMediaConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SnapChatMediaConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Branding_BrandingId",
                        column: x => x.BrandingId,
                        principalTable: "Branding",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offices_DeltaMediaConfigs_DeltaMediaConfigId",
                        column: x => x.DeltaMediaConfigId,
                        principalTable: "DeltaMediaConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offices_MetaMediaConfigs_MetaMediaConfigId",
                        column: x => x.MetaMediaConfigId,
                        principalTable: "MetaMediaConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offices_SnapChatMediaConfigs_SnapChatMediaConfigId",
                        column: x => x.SnapChatMediaConfigId,
                        principalTable: "SnapChatMediaConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseMediaLibraryFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseMediaLibraryFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseMediaLibraryFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaLibraryImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLibraryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLibraryImages_BaseMediaLibraryFiles_Id",
                        column: x => x.Id,
                        principalTable: "BaseMediaLibraryFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaLibraryVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLibraryVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLibraryVideos_BaseMediaLibraryFiles_Id",
                        column: x => x.Id,
                        principalTable: "BaseMediaLibraryFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "OfficeId", "Password", "UpdatedAt" },
                values: new object[] { new Guid("49508398-5e83-4ef5-9774-24f8e6f0d4ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin-nordic.com", null, "$2a$12$IUOkuRW8ou18F.9ub6YUYeOsVxAgbiCBjfo6ztjVGg03zZfgdr0X2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_BaseMediaLibraryFiles_UserId",
                table: "BaseMediaLibraryFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BrandingId",
                table: "Companies",
                column: "BrandingId",
                unique: true,
                filter: "[BrandingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RetailDataProviderId",
                table: "Companies",
                column: "RetailDataProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAutoCreationConfigs_CompanyId",
                table: "CompanyAutoCreationConfigs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeltaUiTemplateConfigs_DeltaMediaConfigId",
                table: "DeltaUiTemplateConfigs",
                column: "DeltaMediaConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_BrandingId",
                table: "Offices",
                column: "BrandingId",
                unique: true,
                filter: "[BrandingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyId",
                table: "Offices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_DeltaMediaConfigId",
                table: "Offices",
                column: "DeltaMediaConfigId",
                unique: true,
                filter: "[DeltaMediaConfigId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_MetaMediaConfigId",
                table: "Offices",
                column: "MetaMediaConfigId",
                unique: true,
                filter: "[MetaMediaConfigId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_SnapChatMediaConfigId",
                table: "Offices",
                column: "SnapChatMediaConfigId",
                unique: true,
                filter: "[SnapChatMediaConfigId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OfficeId",
                table: "Users",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAutoCreationConfigs");

            migrationBuilder.DropTable(
                name: "DeltaUiTemplateConfigs");

            migrationBuilder.DropTable(
                name: "MediaLibraryImages");

            migrationBuilder.DropTable(
                name: "MediaLibraryVideos");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "BaseMediaLibraryFiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "DeltaMediaConfigs");

            migrationBuilder.DropTable(
                name: "MetaMediaConfigs");

            migrationBuilder.DropTable(
                name: "SnapChatMediaConfigs");

            migrationBuilder.DropTable(
                name: "Branding");

            migrationBuilder.DropTable(
                name: "RetailDataProviders");
        }
    }
}
