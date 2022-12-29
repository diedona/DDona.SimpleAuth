using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDona.SimpleAuth.Infra.Migrations
{
    public partial class InactiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                schema: "identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                schema: "identity",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead",
                column: "ConcurrencyStamp",
                value: "fd8974cc-490d-4421-9130-7d2d1d5b52bb");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0834507-4edb-40c9-9f91-71e20fcca003",
                column: "ConcurrencyStamp",
                value: "f2d3400b-f078-4914-91ff-ce1d8e10e8fb");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc039422-e152-4c74-8bde-dde00e1eb5fa", "AQAAAAEAACcQAAAAEFrvYgL8W1mKlp3dK0HKNZ2Hd0uB7tua6gv+DuL2XhFBF9HsP3YnXvV3f0sGBu6iMg==", "68fcce71-17cb-4820-bb2f-c724f48f4860" });
        }
    }
}
