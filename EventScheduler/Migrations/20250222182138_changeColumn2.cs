using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Migrations
{
    /// <inheritdoc />
    public partial class changeColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "_title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_title",
                table: "Events",
                newName: "Title");
        }
    }
}
