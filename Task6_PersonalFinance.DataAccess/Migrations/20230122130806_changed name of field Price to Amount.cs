using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task6PersonalFinance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changednameoffieldPricetoAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Incomes",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Expenses",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Incomes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "Price");
        }
    }
}
