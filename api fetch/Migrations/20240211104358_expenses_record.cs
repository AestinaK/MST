using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_fetch.Migrations
{
    public partial class expenses_record : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "root");

            migrationBuilder.CreateTable(
                name: "expenses_Record",
                schema: "root",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TxnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpensesId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RecDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecStatus = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expenses_Record_expenses_category_ExpensesId",
                        column: x => x.ExpensesId,
                        principalSchema: "setup",
                        principalTable: "expenses_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expenses_Record_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expenses_Record_ExpensesId",
                schema: "root",
                table: "expenses_Record",
                column: "ExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_Record_UserId",
                schema: "root",
                table: "expenses_Record",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenses_Record",
                schema: "root");
        }
    }
}
