using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB102App.Migrations
{
    public partial class CreatedWorkImagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Works");

            migrationBuilder.CreateTable(
                name: "WorkImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkImages_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkImages_WorkId",
                table: "WorkImages",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkImages");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
