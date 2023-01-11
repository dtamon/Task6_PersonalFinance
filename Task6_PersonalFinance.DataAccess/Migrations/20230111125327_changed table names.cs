using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task6PersonalFinance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedtablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outcomes_UserOutcomeCategories_CategoryId",
                table: "Outcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOutcomeCategories_Users_UserId",
                table: "UserOutcomeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOutcomeCategories",
                table: "UserOutcomeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outcomes",
                table: "Outcomes");

            migrationBuilder.RenameTable(
                name: "UserOutcomeCategories",
                newName: "UserExpenseCategories");

            migrationBuilder.RenameTable(
                name: "Outcomes",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_UserOutcomeCategories_UserId",
                table: "UserExpenseCategories",
                newName: "IX_UserExpenseCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Outcomes_CategoryId",
                table: "Expenses",
                newName: "IX_Expenses_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExpenseCategories",
                table: "UserExpenseCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserExpenseCategories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "UserExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExpenseCategories_Users_UserId",
                table: "UserExpenseCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserExpenseCategories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExpenseCategories_Users_UserId",
                table: "UserExpenseCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExpenseCategories",
                table: "UserExpenseCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "UserExpenseCategories",
                newName: "UserOutcomeCategories");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Outcomes");

            migrationBuilder.RenameIndex(
                name: "IX_UserExpenseCategories_UserId",
                table: "UserOutcomeCategories",
                newName: "IX_UserOutcomeCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CategoryId",
                table: "Outcomes",
                newName: "IX_Outcomes_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOutcomeCategories",
                table: "UserOutcomeCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outcomes",
                table: "Outcomes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Outcomes_UserOutcomeCategories_CategoryId",
                table: "Outcomes",
                column: "CategoryId",
                principalTable: "UserOutcomeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOutcomeCategories_Users_UserId",
                table: "UserOutcomeCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
