using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Migrations
{
    /// <inheritdoc />
    public partial class event1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration1_AspNetUsers_UserId",
                table: "EventRegistration1");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration1_Events_EventId",
                table: "EventRegistration1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRegistration1",
                table: "EventRegistration1");

            migrationBuilder.RenameTable(
                name: "EventRegistration1",
                newName: "EventRegistrations");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistration1_UserId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistration1_EventId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRegistrations",
                table: "EventRegistrations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_UserId",
                table: "EventRegistrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_AspNetUsers_UserId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRegistrations",
                table: "EventRegistrations");

            migrationBuilder.RenameTable(
                name: "EventRegistrations",
                newName: "EventRegistration1");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_UserId",
                table: "EventRegistration1",
                newName: "IX_EventRegistration1_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistration1",
                newName: "IX_EventRegistration1_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRegistration1",
                table: "EventRegistration1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration1_AspNetUsers_UserId",
                table: "EventRegistration1",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration1_Events_EventId",
                table: "EventRegistration1",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
