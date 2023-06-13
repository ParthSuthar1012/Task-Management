using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Management.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Users_UserId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesRoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesRoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CratedBy",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "RolesRoleID",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tasks",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_UserId",
                table: "tasks",
                newName: "IX_tasks_CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Users_CreatedBy",
                table: "tasks",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Users_AssignedTo",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Users_CreatedBy",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_tasks_AssignedTo",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "RolesRoleID");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "tasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_CreatedBy",
                table: "tasks",
                newName: "IX_tasks_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CratedBy",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleID",
                table: "Users",
                column: "RolesRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Users_UserId",
                table: "tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesRoleID",
                table: "Users",
                column: "RolesRoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
