using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Migrations
{
    /// <inheritdoc />
    public partial class changetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "_title");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_title",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "_date",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Events",
                newName: "Id");
        }
    }
}
