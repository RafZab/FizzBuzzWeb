using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzBetter.Data.Migrations
{
    public partial class AddingCreatedByInFizzbuzz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Fizzbuzz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Fizzbuzz");
        }
    }
}
