using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 10, 54, 72, DateTimeKind.Utc).AddTicks(1923), new DateTime(2025, 11, 25, 13, 10, 54, 72, DateTimeKind.Utc).AddTicks(1926) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 10, 54, 77, DateTimeKind.Utc).AddTicks(4737), new DateTime(2025, 11, 25, 13, 10, 54, 77, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 10, 54, 77, DateTimeKind.Utc).AddTicks(4810), new DateTime(2025, 11, 25, 13, 10, 54, 77, DateTimeKind.Utc).AddTicks(4811) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 9, 14, 246, DateTimeKind.Utc).AddTicks(4613), new DateTime(2025, 11, 25, 13, 9, 14, 246, DateTimeKind.Utc).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6630), new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6632) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6671), new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6671) });
        }
    }
}
