using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreainBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainRoute_Train_TrainId",
                table: "TrainRoute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainRoute",
                table: "TrainRoute");

            migrationBuilder.RenameTable(
                name: "TrainRoute",
                newName: "TrainSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_TrainRoute_TrainId",
                table: "TrainSchedule",
                newName: "IX_TrainSchedule_TrainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainSchedule",
                table: "TrainSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainSchedule_Train_TrainId",
                table: "TrainSchedule",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainSchedule_Train_TrainId",
                table: "TrainSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainSchedule",
                table: "TrainSchedule");

            migrationBuilder.RenameTable(
                name: "TrainSchedule",
                newName: "TrainRoute");

            migrationBuilder.RenameIndex(
                name: "IX_TrainSchedule_TrainId",
                table: "TrainRoute",
                newName: "IX_TrainRoute_TrainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainRoute",
                table: "TrainRoute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainRoute_Train_TrainId",
                table: "TrainRoute",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
