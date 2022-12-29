using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDona.SimpleAuth.Infra.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "903d67fb-019c-4f9c-9754-d9db3386aead", "b9964963-b483-47ed-bfb9-829ea6950a23", "InitialAdmin", "INITIALADMIN" });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a521141-3f8e-4a1f-ae59-893445b475b8", 0, "6782a2c9-7a2b-4d39-b515-abdb87434366", "admin@system", true, "System", "Owner", false, null, "ADMIN@SYSTEM", "ADMIN@SYSTEM", "AQAAAAEAACcQAAAAENJGDIq9GK82OoALxALrkOmfDlHRRB2hJLz/EClT8cJm4HdmunK715o279IaznS2PQ==", null, false, "95020a1e-d947-4b4f-b3ba-2e5feaa89639", false, "admin@system" });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "903d67fb-019c-4f9c-9754-d9db3386aead", "8a521141-3f8e-4a1f-ae59-893445b475b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "903d67fb-019c-4f9c-9754-d9db3386aead", "8a521141-3f8e-4a1f-ae59-893445b475b8" });

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8");
        }
    }
}
