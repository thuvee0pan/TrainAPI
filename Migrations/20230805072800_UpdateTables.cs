using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreainBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_RailroadCar_RailroadCarId",
                table: "Train");

            migrationBuilder.DropTable(
                name: "Locomotive");

            migrationBuilder.DropTable(
                name: "Purchese");

            migrationBuilder.DropTable(
                name: "RailroadCar");

            migrationBuilder.DropIndex(
                name: "IX_Train_RailroadCarId",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "PricePerSeat",
                table: "TrainRoute");

            migrationBuilder.DropColumn(
                name: "WayStationsArray",
                table: "TrainRoute");

            migrationBuilder.DropColumn(
                name: "Locomotive",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "RailroadCarAmount",
                table: "Train");

            migrationBuilder.RenameColumn(
                name: "RailroadCarId",
                table: "Train",
                newName: "TotalSeats");

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerSeat",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    ClassType = table.Column<int>(type: "int", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: false),
                    TrainScheduleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropColumn(
                name: "ClassType",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "PricePerSeat",
                table: "Train");

            migrationBuilder.RenameColumn(
                name: "TotalSeats",
                table: "Train",
                newName: "RailroadCarId");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerSeat",
                table: "TrainRoute",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "WayStationsArray",
                table: "TrainRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Locomotive",
                table: "Train",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RailroadCarAmount",
                table: "Train",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Locomotive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locomotive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainRouteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeatsArray = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    railroadCarNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchese_TrainRoute_TrainRouteId",
                        column: x => x.TrainRouteId,
                        principalTable: "TrainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchese_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RailroadCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfColums = table.Column<int>(type: "int", nullable: false),
                    NumberOfRows = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailroadCar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Train_RailroadCarId",
                table: "Train",
                column: "RailroadCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchese_TrainRouteId",
                table: "Purchese",
                column: "TrainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchese_UserId",
                table: "Purchese",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Train_RailroadCar_RailroadCarId",
                table: "Train",
                column: "RailroadCarId",
                principalTable: "RailroadCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
