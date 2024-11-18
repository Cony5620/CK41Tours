using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CK41Tours.Migrations
{
    /// <inheritdoc />
    public partial class DD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DD",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DD01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD02 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD03 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD04 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DD06 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD07 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD08 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD09 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DD11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DD", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DD");
        }
    }
}
