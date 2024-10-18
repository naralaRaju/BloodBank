using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bbmscore.Migrations.AuthDbcontextMigrations
{
    /// <inheritdoc />
    public partial class AddAdmin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c1d563a-ee7c-438f-a540-5d7fe8168c33",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHvIJdYj3wK3hrdt66KNEaB7wSVzKE3XsUD8GJU//R77oyY28lbvEISSLjxAvFlSCg==", "69cb4160-742b-4389-8ea6-13f54354929f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "79804520-6822-4ff6-aa99-17de99098494", 0, "232f275e-2ed5-49bf-8fd3-a9a21834108c", "sowmya@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKaJ34RDD0orPjTANwgRiLYUtOULPwC88nyBS8RSV4gCYGA3kNT1AcL2gvh4e0HZEw==", "9347096598", false, "f87e3b0a-eda9-49a8-8b89-9e1c52a84d61", false, "Sowmya" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "09b9bf41-6be4-413f-871a-747a1752e166", "79804520-6822-4ff6-aa99-17de99098494" },
                    { "a4e80ba7-cfde-4767-89d0-993a833acf5f", "79804520-6822-4ff6-aa99-17de99098494" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09b9bf41-6be4-413f-871a-747a1752e166", "79804520-6822-4ff6-aa99-17de99098494" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a4e80ba7-cfde-4767-89d0-993a833acf5f", "79804520-6822-4ff6-aa99-17de99098494" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79804520-6822-4ff6-aa99-17de99098494");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c1d563a-ee7c-438f-a540-5d7fe8168c33",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEGqffuRMzyiLfyoG99SpNmQox8Q0VGqXWQO7AZ+aLTC2+uyIhNxyxhd4z5peVkjpig==", "97834ec0-7a91-404b-a19a-af8564e85104" });
        }
    }
}
