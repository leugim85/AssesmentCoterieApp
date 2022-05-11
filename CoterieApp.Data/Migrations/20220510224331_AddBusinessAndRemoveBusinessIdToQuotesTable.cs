using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    public partial class AddBusinessAndRemoveBusinessIdToQuotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Business_BussinessId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_BussinessId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "BussinessId",
                table: "Quotes",
                newName: "Business");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Business",
                table: "Quotes",
                newName: "BussinessId");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_BussinessId",
                table: "Quotes",
                column: "BussinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Business_BussinessId",
                table: "Quotes",
                column: "BussinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
