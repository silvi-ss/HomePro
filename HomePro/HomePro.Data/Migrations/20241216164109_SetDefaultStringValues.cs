using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomePro.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetDefaultStringValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 16, 41, 8, 20, DateTimeKind.Utc).AddTicks(9514),
                comment: "Date and time of property creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 15, 43, 53, 158, DateTimeKind.Utc).AddTicks(7991),
                oldComment: "Date and time of property creation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 15, 43, 53, 158, DateTimeKind.Utc).AddTicks(7991),
                comment: "Date and time of property creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 16, 41, 8, 20, DateTimeKind.Utc).AddTicks(9514),
                oldComment: "Date and time of property creation");
        }
    }
}
