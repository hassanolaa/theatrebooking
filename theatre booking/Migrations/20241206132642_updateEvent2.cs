using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theatre_booking.Migrations
{
    /// <inheritdoc />
    public partial class updateEvent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageBase64",
                table: "Events",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Events",
                newName: "ImageBase64");
        }
    }
}
