﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bbmscore.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bloodstocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    containerno = table.Column<int>(type: "int", nullable: false),
                    bloodtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bloodquantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloodstocks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloodstocks");
        }
    }
}
