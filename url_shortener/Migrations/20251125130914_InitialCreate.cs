using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role_Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Permissions = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmailConfirmationToken = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordResetTokenExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UrlCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxUrlsPerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPermanentlyBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    BlockedUntil = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BlockReason = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastActivityAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RegistrationIp = table.Column<string>(type: "TEXT", nullable: true),
                    LastLoginIp = table.Column<string>(type: "TEXT", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_PublicId", x => x.PublicId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OriginalUrl = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    ShortCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClickCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    MaxClicks = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    MostCommonCountry = table.Column<string>(type: "TEXT", nullable: true),
                    MostCommonCountryCount = table.Column<int>(type: "INTEGER", nullable: true),
                    MostCommonReferrer = table.Column<string>(type: "TEXT", nullable: true),
                    MostCommonReferrerCount = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstClickAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastClickAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PeakActivityHour = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urls_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clicks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UrlId = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Browser = table.Column<string>(type: "TEXT", nullable: true),
                    BrowserVersion = table.Column<string>(type: "TEXT", nullable: true),
                    Platform = table.Column<string>(type: "TEXT", nullable: true),
                    DeviceType = table.Column<string>(type: "TEXT", nullable: true),
                    Refferer = table.Column<string>(type: "TEXT", nullable: true),
                    ReferrerDomain = table.Column<string>(type: "TEXT", nullable: true),
                    IPAddress = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    ClickedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clicks_Urls_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Urls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "Permissions", "Role_Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 25, 13, 9, 14, 246, DateTimeKind.Utc).AddTicks(4613), "", "[]", "USER", new DateTime(2025, 11, 25, 13, 9, 14, 246, DateTimeKind.Utc).AddTicks(4615) },
                    { 2, new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6630), "", "[]", "USER_PREMIUM", new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6632) },
                    { 3, new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6671), "", "[]", "USER_ADMIN", new DateTime(2025, 11, 25, 13, 9, 14, 251, DateTimeKind.Utc).AddTicks(6671) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clicks_UrlId",
                table: "Clicks",
                column: "UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_CreatedAt",
                table: "Urls",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_CreatorId",
                table: "Urls",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_ExpiresAt",
                table: "Urls",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_IsActive",
                table: "Urls",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_ShortCode",
                table: "Urls",
                column: "ShortCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PublicId",
                table: "Users",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PublicId_Email",
                table: "Users",
                columns: new[] { "PublicId", "Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clicks");

            migrationBuilder.DropTable(
                name: "Urls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
