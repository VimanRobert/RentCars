using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCars.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    carId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.carId);
                });
            
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerDrivingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerCounty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerDrivingId);
                });

            migrationBuilder.CreateTable(
                name: "Made",
                columns: table => new
                {
                    carId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carEngine = table.Column<double>(type: "float", nullable: false),
                    carMadeYear = table.Column<double>(type: "float", nullable: false),
                    carFuelType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Made", x => x.carId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carId = table.Column<int>(type: "int", nullable: false),
                    carBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isRented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Store_Car_carId",
                        column: x => x.carId,
                        principalTable: "Car",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerDrivingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Order_Car_carId",
                        column: x => x.carId,
                        principalTable: "Car",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_customerDrivingId",
                        column: x => x.customerDrivingId,
                        principalTable: "Customer",
                        principalColumn: "customerDrivingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_carId",
                table: "Order",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_customerDrivingId",
                table: "Order",
                column: "customerDrivingId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_carId",
                table: "Store",
                column: "carId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Made");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}