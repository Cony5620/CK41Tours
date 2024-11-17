using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CK41Tours.Migrations
{
    /// <inheritdoc />
    public partial class TM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TM",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TM01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM02 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM03 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM04 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TM");
        }
    }
}
