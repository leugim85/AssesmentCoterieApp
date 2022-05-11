using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    public partial class implementNoCaseSensitive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "NOCASE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                oldCollation: "NOCASE");
        }
    }
}
