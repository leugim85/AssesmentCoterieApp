using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BusinessFactor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BussinessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Revenue = table.Column<double>(type: "REAL", nullable: false),
                    IsSuccesful = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Quotes_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    FactorState = table.Column<double>(type: "REAL", nullable: false),
                    QuoteTransactionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Quotes_QuoteTransactionId",
                        column: x => x.QuoteTransactionId,
                        principalTable: "Quotes",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_BussinessId",
                table: "Quotes",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_States_QuoteTransactionId",
                table: "States",
                column: "QuoteTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
