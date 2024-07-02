using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testlah.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
