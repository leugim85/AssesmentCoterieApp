using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    public partial class AddBusinessIdToQuotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Quotes_QuoteTransactionId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_QuoteTransactionId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "QuoteTransactionId",
                table: "States");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Quotes");

            migrationBuilder.AddColumn<Guid>(
                name: "QuoteTransactionId",
                table: "States",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_QuoteTransactionId",
                table: "States",
                column: "QuoteTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Quotes_QuoteTransactionId",
                table: "States",
                column: "QuoteTransactionId",
                principalTable: "Quotes",
                principalColumn: "TransactionId");
        }
    }
}
