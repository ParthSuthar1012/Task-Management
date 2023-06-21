using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Management.Migrations
{
    public partial class changeintask4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignedto_tasks_TaskId",
                table: "Assignedto");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignedto_Users_UserId",
                table: "Assignedto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignedto",
                table: "Assignedto");

            migrationBuilder.RenameTable(
                name: "Assignedto",
                newName: "assignedto");

            migrationBuilder.RenameIndex(
                name: "IX_Assignedto_UserId",
                table: "assignedto",
                newName: "IX_assignedto_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignedto_TaskId",
                table: "assignedto",
                newName: "IX_assignedto_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignedto",
                table: "assignedto",
                column: "AsTId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Assignedto");

            migrationBuilder.RenameIndex(
                name: "IX_assignedto_UserId",
                table: "Assignedto",
                newName: "IX_Assignedto_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignedto_TaskId",
                table: "Assignedto",
                newName: "IX_Assignedto_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignedto",
                table: "Assignedto",
                column: "AsTId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignedto_tasks_TaskId",
                table: "Assignedto",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignedto_Users_UserId",
                table: "Assignedto",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
