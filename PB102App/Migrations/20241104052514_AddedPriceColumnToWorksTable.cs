using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB102App.Migrations
{
    public partial class AddedPriceColumnToWorksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Works",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Works");
        }
    }
}
