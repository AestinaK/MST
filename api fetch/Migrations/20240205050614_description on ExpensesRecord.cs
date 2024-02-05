using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_fetch.Migrations
{
    public partial class descriptiononExpensesRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Root",
                table: "Expenses_Record",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Root",
                table: "Expenses_Record");
        }
    }
}
