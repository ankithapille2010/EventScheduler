using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Migrations
{
    /// <inheritdoc />
    public partial class changeColumn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_date",
                table: "Events",
                newName: "Date");
        }
    }
}
