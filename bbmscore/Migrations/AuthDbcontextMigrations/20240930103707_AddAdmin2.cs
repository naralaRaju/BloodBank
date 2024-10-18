using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bbmscore.Migrations.AuthDbcontextMigrations
{
    /// <inheritdoc />
    public partial class AddAdmin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a4e80ba7-cfde-4767-89d0-993a833acf5f", "79804520-6822-4ff6-aa99-17de99098494" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c1d563a-ee7c-438f-a540-5d7fe8168c33",
                columns: new[] { "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEI2Kg72LG6wuwpTNzYVjVmWZ3Mrs3/gk81tgYJ39UasRylteR27N+xHVP5WbdoyofQ==", "7601067244", "20574731-0ef2-41f8-a47f-acc0102cdc04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79804520-6822-4ff6-aa99-17de99098494",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312675f9-4e66-40aa-ad79-1533b9cfcc26", "AQAAAAIAAYagAAAAEJUTTv41HIg0Vrkfqrfh7u1jk1Lpmr/KakIeAHHpTI9AMIWtcj2T0avuEOx+EbkJcQ==", "c860fcbf-02ca-480a-91e6-ff322cc7c927" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a4e80ba7-cfde-4767-89d0-993a833acf5f", "79804520-6822-4ff6-aa99-17de99098494" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c1d563a-ee7c-438f-a540-5d7fe8168c33",
                columns: new[] { "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHvIJdYj3wK3hrdt66KNEaB7wSVzKE3XsUD8GJU//R77oyY28lbvEISSLjxAvFlSCg==", null, "69cb4160-742b-4389-8ea6-13f54354929f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79804520-6822-4ff6-aa99-17de99098494",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "232f275e-2ed5-49bf-8fd3-a9a21834108c", "AQAAAAIAAYagAAAAEKaJ34RDD0orPjTANwgRiLYUtOULPwC88nyBS8RSV4gCYGA3kNT1AcL2gvh4e0HZEw==", "f87e3b0a-eda9-49a8-8b89-9e1c52a84d61" });
        }
    }
}
