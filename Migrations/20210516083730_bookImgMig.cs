using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMania.Migrations
{
    public partial class bookImgMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bookImg",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookImg",
                table: "Books");
        }
    }
}
