using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenHash",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenRevokedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { "$2a$11$loJPts1GJU38t9..BZwfbO1J6BuATa/9JuB2dvqu2nfpXubK1Br5K", null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { "$2a$11$B.s8.YuEZrufNrZXXqX4Eehwp3emVlW02uyObWqOMcJoKvt.r.K2q", null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { "$2a$11$MnT8R.4l.txKBL8hlAqUUuqFpSekrBpkQy38ipxuO288DGKu6OPc.", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RefreshTokenHash",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RefreshTokenRevokedAt",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kBVqJIocpmmTXx2zdtn9IO4dCPc3Uv6x7IAiLJ9xdijTmktSQvWKu");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$b25j/M9MfEP5FJaXDHOxGOUJOc84qhadMWzw75m4rN7o9hZu1fEpC");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$PpUhzo3uokrgzEQDdceQTe.VZXR8WvrVQdjvaxccchZMps4KhzbVa");
        }
    }
}
