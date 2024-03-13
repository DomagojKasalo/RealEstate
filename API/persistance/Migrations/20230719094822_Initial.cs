using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "realestate");

            migrationBuilder.EnsureSchema(
                name: "crm");

            migrationBuilder.CreateTable(
                name: "CatalogItemStatuses",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemTypes",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                schema: "crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeploymentStatuses",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeploymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GVAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipingZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalSchema: "crm",
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "crm",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true),
                    UnitInsideTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOutsideTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false),
                    ListCatalogImageId = table.Column<int>(type: "int", nullable: true),
                    TitleImageId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "realestate",
                        principalTable: "CatalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "crm",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floors = table.Column<float>(type: "real", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    GaragePlaces = table.Column<int>(type: "int", nullable: false),
                    Lamella = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetArea = table.Column<float>(type: "real", nullable: false),
                    BruttoArea = table.Column<float>(type: "real", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    ModelImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleUrlAndroid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleUrlWindows = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleUrlIos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleUrlOsx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleUrlWebGl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogItemTypeId = table.Column<int>(type: "int", nullable: true),
                    CatalogItemStatusId = table.Column<int>(type: "int", nullable: true),
                    UnitIndex = table.Column<int>(type: "int", nullable: false),
                    UnitTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaySceneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NightSceneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailImageId = table.Column<int>(type: "int", nullable: true),
                    ListImageId = table.Column<int>(type: "int", nullable: true),
                    Disclaimer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisclamer = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeploymentStatusId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogId",
                        column: x => x.CatalogId,
                        principalSchema: "realestate",
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogItemStatusId",
                        column: x => x.CatalogItemStatusId,
                        principalSchema: "realestate",
                        principalTable: "CatalogItemStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogItemTypeId",
                        column: x => x.CatalogItemTypeId,
                        principalSchema: "realestate",
                        principalTable: "CatalogItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CdeploymentStatusId",
                        column: x => x.DeploymentStatusId,
                        principalSchema: "realestate",
                        principalTable: "DeploymentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogPeriods",
                schema: "realestate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogPeriod_CatalogId",
                        column: x => x.CatalogId,
                        principalSchema: "realestate",
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "CatalogItemStatuses",
                columns: new[] { "Id", "Color", "CreatedDate", "CreatedUser", "IsDeleted", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
                    { 1, "#00FF14", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Available" },
                    { 2, "#F2FF00", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Reserved" },
                    { 3, "#FF0000", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Sold Out" }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "CatalogItemTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "IsDeleted", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "House" },
                    { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Apartment" },
                    { 3, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Business Spaces" },
                    { 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Office Spaces" },
                    { 5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Building" }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "CatalogTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "IsDeleted", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "House" },
                    { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Building" }
                });

            migrationBuilder.InsertData(
                schema: "crm",
                table: "CompanyTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "IsDeleted", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Communications" },
                    { 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Technology" },
                    { 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Gowerment Military" },
                    { 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Manufacturing" },
                    { 5, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Financial Services" },
                    { 6, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "IT services" },
                    { 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Education" },
                    { 8, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Real Estate" },
                    { 9, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Consulting" },
                    { 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Management" },
                    { 11, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Other" }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "DeploymentStatuses",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "IsDeleted", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Under Construction (Development)" },
                    { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Request Approval (Staging)" },
                    { 3, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "Approved" }
                });

            migrationBuilder.InsertData(
                schema: "crm",
                table: "Company",
                columns: new[] { "Id", "BillingAddress", "BillingZip", "CompanyAcronym", "CompanyName", "CompanyTypeId", "CreatedDate", "CreatedUser", "Description", "Email", "Fax", "GID", "GVAT", "IsDeleted", "ModifiedDate", "ModifiedUser", "Phone", "RegistrationDate", "ShipingAddress", "ShipingZip", "Site", "WebSite" },
                values: new object[,]
                {
                    { 1, "Kralja Petra Kresimira 4", "88000", "COX4", "COX4", 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "", "info@cox4.eu", null, null, null, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "", null, "Blajburskih zrtava 19c", "88000", null, "cox4.eu" },
                    { 2, "Splitska 10", "88000", "MSS", "MSS", 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "", "info@cox4.eu", null, null, null, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d15b15be-0cdc-498d-817c-0b911da8d139", "", null, "Splitska10", "88000", null, "mss.eu" }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "Catalogs",
                columns: new[] { "Id", "BackgroundImage", "BackgroundImageURL", "CatalogTypeId", "CompanyId", "CreatedDate", "CreatedUser", "Description", "IsDeleted", "IsEnabled", "ListCatalogImageId", "ModifiedDate", "ModifiedUser", "Name", "Quote", "TitleImage", "TitleImageId", "TitleImageURL", "UnitInsideTag", "UnitOutsideTag" },
                values: new object[,]
                {
                    { 1, "This is background image", "", 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "This is catalog long description", false, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Wooden house", "Wait...", "Image123", null, "", null, null },
                    { 2, "This is background image", "", 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "This is catalog long description", false, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Winter house", "Wait...", "Image123", null, "", null, null },
                    { 3, "This is background image", "", 1, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "This is catalog long description", false, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Modern house", "Wait...", "Image123", null, "", null, null },
                    { 4, "This is background image", "", 2, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "This is catalog long description", false, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Buildings", "Wait...", "Image123", null, "", null, null }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "CatalogItems",
                columns: new[] { "Id", "ApprovedUser", "Bathrooms", "BruttoArea", "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "CatalogId", "CatalogItemStatusId", "CatalogItemTypeId", "CreatedDate", "CreatedUser", "DaySceneName", "DeploymentStatusId", "Description", "DetailImageId", "Dimensions", "Disclaimer", "Floor", "Floors", "GaragePlaces", "IsDeleted", "IsDisclamer", "IsEnabled", "IsFeatured", "Lamella", "ListImageId", "ModelImage", "ModelImageUrl", "ModifiedDate", "ModifiedUser", "Name", "NetArea", "NightSceneName", "Quote", "Rooms", "TitleImage", "UnitIndex", "UnitTag", "Units", "VersionIdentifier" },
                values: new object[,]
                {
                    { 1, null, 0, 0f, null, null, null, null, null, "", 1, null, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WoodenHouse1", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("c8248327-2c41-47f2-b09f-a198eb10f58b") },
                    { 2, null, 0, 0f, null, null, null, null, null, "", 1, null, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WoodenHouse2", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("c2c1c5ae-4433-4cbd-8a61-c4c67575b431") },
                    { 3, null, 0, 0f, null, null, null, null, null, "", 1, null, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WoodenHouse3", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("ff4c6d79-fdb7-4673-b850-a762bf3c5a4a") },
                    { 4, null, 0, 0f, null, null, null, null, null, "", 1, null, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WoodenHouse4", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("ee82569a-1410-4ec2-b499-ba16ecdb3fd4") },
                    { 5, null, 0, 0f, null, null, null, null, null, "", 2, null, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WinterHouse1", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("33d551e5-4886-4606-a5e1-8048bec6b6ba") },
                    { 6, null, 0, 0f, null, null, null, null, null, "", 2, null, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WinterHouse2", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("ea1fe074-c291-4c76-b921-62dfcd5c15a8") },
                    { 7, null, 0, 0f, null, null, null, null, null, "", 2, null, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WinterHouse3", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("4bacb9ce-8b8c-4cac-80ed-1ed0b84ea956") },
                    { 8, null, 0, 0f, null, null, null, null, null, "", 2, null, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-WinterHouse4", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("84fe72dc-948f-4b06-bc27-18ed8646029c") },
                    { 9, null, 0, 0f, null, null, null, null, null, "", 3, null, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-ModernHouse1", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("3b1cb6d5-31da-47b9-a0f5-1b81aebfb524") },
                    { 10, null, 0, 0f, null, null, null, null, null, "", 3, null, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-ModernHouse2", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("55fb6804-2cbf-496a-a1c0-3d9882d3794a") },
                    { 11, null, 0, 0f, null, null, null, null, null, "", 3, null, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-ModernHouse3", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("4d04a47b-128c-4b21-87df-f443cbf9d874") },
                    { 12, null, 0, 0f, null, null, null, null, null, "", 3, null, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-ModernHouse4", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("776f3702-31b9-43a4-b168-6e3f20a931f8") },
                    { 13, null, 0, 0f, null, null, null, null, null, "", 4, null, 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-Buildings1", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("1859b32e-f3d0-459a-912b-714e411db2f7") },
                    { 14, null, 0, 0f, null, null, null, null, null, "", 4, null, 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-Buildings2", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("7d8834f8-826b-42ec-b6df-4226a8e3b5eb") },
                    { 15, null, 0, 0f, null, null, null, null, null, "", 4, null, 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-Buildings3", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("95f45a7c-3fcf-4db4-a023-cd6ad40a1014") },
                    { 16, null, 0, 0f, null, null, null, null, null, "", 4, null, 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", null, null, "This is long description", null, null, null, 0, 0f, 0, false, false, false, false, null, null, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "CatalogItems-Buildings4", 0f, null, "Wait...", 0, "Image", 0, null, 0, new Guid("5674b573-b0de-4dd8-9507-85c875be5b65") }
                });

            migrationBuilder.InsertData(
                schema: "realestate",
                table: "CatalogPeriods",
                columns: new[] { "Id", "CatalogId", "CreatedDate", "CreatedUser", "DateFrom", "DateTo", "Enabled", "IsDeleted", "ModifiedDate", "ModifiedUser" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { 2, 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { 3, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { 4, 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogId",
                schema: "realestate",
                table: "CatalogItems",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogItemStatusId",
                schema: "realestate",
                table: "CatalogItems",
                column: "CatalogItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogItemTypeId",
                schema: "realestate",
                table: "CatalogItems",
                column: "CatalogItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_DeploymentStatusId",
                schema: "realestate",
                table: "CatalogItems",
                column: "DeploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_VersionIdentifier",
                schema: "realestate",
                table: "CatalogItems",
                column: "VersionIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogPeriods_CatalogId",
                schema: "realestate",
                table: "CatalogPeriods",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CatalogTypeId",
                schema: "realestate",
                table: "Catalogs",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CompanyId",
                schema: "realestate",
                table: "Catalogs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                schema: "crm",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "CatalogPeriods",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CatalogItemStatuses",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "CatalogItemTypes",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "DeploymentStatuses",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "Catalogs",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "CatalogTypes",
                schema: "realestate");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "crm");

            migrationBuilder.DropTable(
                name: "CompanyTypes",
                schema: "crm");
        }
    }
}
