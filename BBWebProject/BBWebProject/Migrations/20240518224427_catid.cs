using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBWebProject.Migrations
{
    public partial class catid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tbl_non_variated_items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tbl_non_variated_items");
        }
    }
}
