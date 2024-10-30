using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB102App.Migrations
{
    public partial class CreateCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_CategoryId",
                table: "Works",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Categories_CategoryId",
                table: "Works",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Categories_CategoryId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Works_CategoryId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Works");
        }
    }
}
