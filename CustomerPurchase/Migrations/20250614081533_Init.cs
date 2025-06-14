﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerPurchase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "WashingMachines",
                columns: table => new
                {
                    WashingMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashingMachines", x => x.WashingMachineId);
                });

            migrationBuilder.CreateTable(
                name: "WashPrograms",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashPrograms", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "AvailablePrograms",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WashingMachineId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailablePrograms", x => x.AvailableProgramId);
                    table.ForeignKey(
                        name: "FK_AvailablePrograms_WashPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "WashPrograms",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailablePrograms_WashingMachines_WashingMachineId",
                        column: x => x.WashingMachineId,
                        principalTable: "WashingMachines",
                        principalColumn: "WashingMachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistories",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistories", x => new { x.AvailableProgramId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_PurchaseHistories_AvailablePrograms_AvailableProgramId",
                        column: x => x.AvailableProgramId,
                        principalTable: "AvailablePrograms",
                        principalColumn: "AvailableProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Smith", "234243242" },
                    { 2, "Ana", "Lala", "412411" },
                    { 3, "Eva", "Bebe", "21412313" }
                });

            migrationBuilder.InsertData(
                table: "WashPrograms",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 10, "Program 1", 30 },
                    { 2, 10, "Program 2", 30 },
                    { 3, 10, "Program 3", 30 }
                });

            migrationBuilder.InsertData(
                table: "WashingMachines",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 10m, "2374192381" },
                    { 2, 10m, "81734124" },
                    { 3, 10m, "13741923421" }
                });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 1, 55m, 1, 1 },
                    { 2, 65m, 2, 2 },
                    { 3, 78m, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseHistories",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailablePrograms_ProgramId",
                table: "AvailablePrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailablePrograms_WashingMachineId",
                table: "AvailablePrograms",
                column: "WashingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistories_CustomerId",
                table: "PurchaseHistories",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseHistories");

            migrationBuilder.DropTable(
                name: "AvailablePrograms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "WashPrograms");

            migrationBuilder.DropTable(
                name: "WashingMachines");
        }
    }
}
