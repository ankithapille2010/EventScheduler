using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Migrations
{
    /// <inheritdoc />
    public partial class changeColumName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_date",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "_title",
                table: "Events",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "_title");

            migrationBuilder.AddColumn<DateTime>(
                name: "_date",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
