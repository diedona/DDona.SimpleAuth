using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDona.SimpleAuth.Infra.Migrations
{
    public partial class NewRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd8974cc-490d-4421-9130-7d2d1d5b52bb", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0834507-4edb-40c9-9f91-71e20fcca003", "f2d3400b-f078-4914-91ff-ce1d8e10e8fb", "Worker", "WORKER" });

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc039422-e152-4c74-8bde-dde00e1eb5fa", "AQAAAAEAACcQAAAAEFrvYgL8W1mKlp3dK0HKNZ2Hd0uB7tua6gv+DuL2XhFBF9HsP3YnXvV3f0sGBu6iMg==", "68fcce71-17cb-4820-bb2f-c724f48f4860" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0834507-4edb-40c9-9f91-71e20fcca003");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903d67fb-019c-4f9c-9754-d9db3386aead",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9964963-b483-47ed-bfb9-829ea6950a23", "InitialAdmin", "INITIALADMIN" });

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a521141-3f8e-4a1f-ae59-893445b475b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6782a2c9-7a2b-4d39-b515-abdb87434366", "AQAAAAEAACcQAAAAENJGDIq9GK82OoALxALrkOmfDlHRRB2hJLz/EClT8cJm4HdmunK715o279IaznS2PQ==", "95020a1e-d947-4b4f-b3ba-2e5feaa89639" });
        }
    }
}
