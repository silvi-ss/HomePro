using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomePro.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Country of the address"),
                    City = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false, comment: "City of the address"),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "District or region of the address"),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Street name of the address (if applicable)"),
                    StreetNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Street number of the address"),
                    BuildingNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Building number (if applicable)"),
                    Floor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Floor number (if applicable)"),
                    Entry = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Entry number (if applicable)"),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Postal code of the address"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag"),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name of the user"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name of the user"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the notification was created"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the notification was last modified"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Title of the notification"),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Message content of the notification"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The ID of the user who will receive the notification"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the notification is read"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of the notification"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the notification is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCatalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of service"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the service"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Detailed description of the service"),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, defaultValue: "default.jpg", comment: "Service image file name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Display name of the property"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SquareMeters = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false, comment: "Property area in square meters"),
                    Rooms = table.Column<int>(type: "int", nullable: false, comment: "Number of rooms in the property"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Additional description for the property"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 12, 15, 11, 36, 59, 18, DateTimeKind.Utc).AddTicks(7802), comment: "Date and time of property creation"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of property (Apartment, House, etc.)"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag"),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, defaultValue: "default.jpg", comment: "Property image file name"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_ApplicationUser_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteServices",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date when service was added to favorites"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteServices", x => new { x.UserId, x.ServiceCatalogId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteServices_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFavoriteServices_ServiceCatalogs_ServiceCatalogId",
                        column: x => x.ServiceCatalogId,
                        principalTable: "ServiceCatalogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false, comment: "Frequency of the service request"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the service request was created"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if the service request is completed"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Additional description for the service request"),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Preferred date for the service"),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Final price of the service request"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "Current status of the service request"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.CheckConstraint("CK_ServiceRequest_FinalPrice", "FinalPrice >= 0.0 AND FinalPrice <= 10000.0");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ApplicationUser_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ServiceCatalogs_ServiceCatalogId",
                        column: x => x.ServiceCatalogId,
                        principalTable: "ServiceCatalogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Review comment"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Rating from 1 to 5"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of review creation"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag"),
                    ServiceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReviews_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceReviews_ApplicationUser_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceReviews_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_IsDeleted",
                table: "ApplicationUser",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ApplicationUserId",
                table: "Properties",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ClientId",
                table: "Properties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_IsDeleted",
                table: "Properties",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_IsDeleted",
                table: "ServiceCatalogs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ApplicationUserId",
                table: "ServiceRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ClientId",
                table: "ServiceRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_PropertyId",
                table: "ServiceRequests",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceCatalogId",
                table: "ServiceRequests",
                column: "ServiceCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_ApplicationUserId",
                table: "ServiceReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_ClientId",
                table: "ServiceReviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_IsDeleted",
                table: "ServiceReviews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_ServiceRequestId",
                table: "ServiceReviews",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteServices_IsDeleted",
                table: "UserFavoriteServices",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteServices_ServiceCatalogId",
                table: "UserFavoriteServices",
                column: "ServiceCatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ServiceReviews");

            migrationBuilder.DropTable(
                name: "UserFavoriteServices");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "ServiceCatalogs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
