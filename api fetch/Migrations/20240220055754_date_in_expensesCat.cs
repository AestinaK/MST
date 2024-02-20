using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_fetch.Migrations
{
    public partial class date_in_expensesCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "setup",
                table: "expenses_category",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "setup",
                table: "expenses_category");
        }
    }
}
