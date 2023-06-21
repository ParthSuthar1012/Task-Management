using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Management.Migrations
{
    public partial class first1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedto_tasks_TaskId",
                table: "assignedto");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedto_Users_UserId",
                table: "assignedto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignedto",
                table: "assignedto");

            migrationBuilder.RenameTable(
                name: "assignedto",
                newName: "AssignedUser");

            migrationBuilder.RenameIndex(
                name: "IX_assignedto_UserId",
                table: "AssignedUser",
                newName: "IX_AssignedUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignedto_TaskId",
                table: "AssignedUser",
                newName: "IX_AssignedUser_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedUser",
                table: "AssignedUser",
                column: "AssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedUser_tasks_TaskId",
                table: "AssignedUser",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedUser_Users_UserId",
                table: "AssignedUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedUser_tasks_TaskId",
                table: "AssignedUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedUser_Users_UserId",
                table: "AssignedUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedUser",
                table: "AssignedUser");

            migrationBuilder.RenameTable(
                name: "AssignedUser",
                newName: "assignedto");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedUser_UserId",
                table: "assignedto",
                newName: "IX_assignedto_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedUser_TaskId",
                table: "assignedto",
                newName: "IX_assignedto_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignedto",
                table: "assignedto",
                column: "AssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedto_tasks_TaskId",
                table: "assignedto",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignedto_Users_UserId",
                table: "assignedto",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
