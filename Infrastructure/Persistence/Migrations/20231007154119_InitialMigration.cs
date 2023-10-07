using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoordinatesId = table.Column<int>(type: "int", nullable: false),
                    DestinationLongitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DestinationLatitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DeliveredQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationLongitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DestinationLatitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WeatherType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitCount = table.Column<int>(type: "int", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDelivery_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Active", "CreatedDate", "IsDeleted", "Latitude", "Longitude", "UpdateDate" },
                values: new object[] { 1, true, new DateTime(2023, 10, 7, 10, 41, 19, 370, DateTimeKind.Local).AddTicks(882), false, 45.678901m, 123.456789m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_CoordinatesId",
                table: "Deliveries",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDelivery_DeliveryId",
                table: "RequestDelivery",
                column: "DeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDelivery");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
