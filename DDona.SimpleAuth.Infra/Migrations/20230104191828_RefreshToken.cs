using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDona.SimpleAuth.Infra.Migrations
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUserRefreshTokens",
                schema: "identity",
                columns: table => new
                {
                    AspNetUserId = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Token = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRefreshTokens", x => new { x.AspNetUserId, x.Token });
                    table.ForeignKey(
                        name: "FK_AspNetUserRefreshTokens_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead",
                column: "ConcurrencyStamp",
                value: "5a5a1af1-70e3-4540-b259-a4656d9cb70a");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0834507-4edb-40c9-9f91-71e20fcca003",
                column: "ConcurrencyStamp",
                value: "9ac634f4-bdf9-41bf-a3e4-142259de1a1c");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b1d97bf-6365-43ab-8266-9cd39ec30b78", "AQAAAAEAACcQAAAAEP0Lw8w8VX1FbS/3hTPAYjH8gr7s/2J+PP7/N9g2x9625IuR0HZqaPt2tzwTaRhzVw==", "96d1c03e-0c51-49b0-b581-49c0c84bd198" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserRefreshTokens",
                schema: "identity");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead",
                column: "ConcurrencyStamp",
                value: "5d2e2f90-8691-43b2-9502-02803e6a4f8f");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0834507-4edb-40c9-9f91-71e20fcca003",
                column: "ConcurrencyStamp",
                value: "f8da8331-224b-48ff-a643-00ba1c50ece3");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eef37b7-639f-4865-a820-5202428ec22c", "AQAAAAEAACcQAAAAEFEGWVqzd0E6Gz2IQs9mpYCqd/ZeNXkpZiVDCVJQ9+owLXHT0xFa3mS20xveNfblvw==", "4cf81806-6e1a-49c3-b17c-6ada37f19ec9" });
        }
    }
}
