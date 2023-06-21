using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Management.Migrations
{
    public partial class changeintask1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_tasks_AssignedToUser",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AssignedToUser",
                table: "Users",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AssignedToUser",
                table: "Users",
                newName: "IX_Users_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_tasks_TaskId",
                table: "Users",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_tasks_TaskId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Users",
                newName: "AssignedToUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TaskId",
                table: "Users",
                newName: "IX_Users_AssignedToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_tasks_AssignedToUser",
                table: "Users",
                column: "AssignedToUser",
                principalTable: "tasks",
                principalColumn: "TaskId");
        }
    }
}
