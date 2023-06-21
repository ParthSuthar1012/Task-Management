using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Management.Migrations
{
    public partial class changeintask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Users_AssignedTo",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_AssignedTo",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToUser",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AssignedToUser",
                table: "Users",
                column: "AssignedToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_tasks_AssignedToUser",
                table: "Users",
                column: "AssignedToUser",
                principalTable: "tasks",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_tasks_AssignedToUser",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AssignedToUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AssignedToUser",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_AssignedTo",
                table: "tasks",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Users_AssignedTo",
                table: "tasks",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
