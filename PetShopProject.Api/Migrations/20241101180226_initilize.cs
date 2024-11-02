using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductDataApi.Migrations
{
    /// <inheritdoc />
    public partial class initilize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "datetime", "description", "name", "price", "productType" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 21, 32, 26, 746, DateTimeKind.Local).AddTicks(4125), "cdcd", "P1", 300m, 1 },
                    { 2, new DateTime(2024, 11, 1, 21, 32, 26, 746, DateTimeKind.Local).AddTicks(4142), "cdcdsef", "P2", 400m, 0 },
                    { 3, new DateTime(2024, 11, 1, 21, 32, 26, 746, DateTimeKind.Local).AddTicks(4143), "cdfcd", "P3", 500m, 2 },
                    { 4, new DateTime(2024, 11, 1, 21, 32, 26, 746, DateTimeKind.Local).AddTicks(4145), "cdsfsfcd", "P4", 600m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
