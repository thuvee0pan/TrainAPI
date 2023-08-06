using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreainBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class Addpassanger222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passanger_Booking_BookingId",
                table: "Passanger");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Passanger",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passanger_Booking_BookingId",
                table: "Passanger",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passanger_Booking_BookingId",
                table: "Passanger");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Passanger",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Passanger_Booking_BookingId",
                table: "Passanger",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }
    }
}
