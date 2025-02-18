using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WillAttend = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Phone", "RegisterDate", "Surname", "WillAttend" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "lale@gmail.com", "Lale", "1234567890", new DateTime(2025, 2, 14, 15, 56, 10, 406, DateTimeKind.Local).AddTicks(7081), "Bozkurt", 1 },
                    { 2, new DateTime(2002, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nihal@gmail.com", "Nihal", "0987654321", new DateTime(2025, 2, 14, 15, 56, 10, 408, DateTimeKind.Local).AddTicks(1147), "Sengul", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
