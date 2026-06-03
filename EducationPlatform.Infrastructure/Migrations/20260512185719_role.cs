using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$kBVqJIocpmmTXx2zdtn9IO4dCPc3Uv6x7IAiLJ9xdijTmktSQvWKu", "student" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$b25j/M9MfEP5FJaXDHOxGOUJOc84qhadMWzw75m4rN7o9hZu1fEpC", "student" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$PpUhzo3uokrgzEQDdceQTe.VZXR8WvrVQdjvaxccchZMps4KhzbVa", "student" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$gxEO9aZi8g75VMbo6yHd3eJ.nUwJce0xmCLjcGA9cLcWMs11KRuY6");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$NKHfMaYg/eCdbEUvZW2eNOyMYqU9QAQC/qocpoGnUN7fPQkPEKvDa");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$7lbSYCC2rbl76iJ704UwiOp619PFWzNt5KEEwmKGlZM.0PXNP9nUi");
        }
    }
}
