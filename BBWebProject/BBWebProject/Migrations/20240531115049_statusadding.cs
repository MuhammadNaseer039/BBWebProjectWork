using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBWebProject.Migrations
{
    public partial class statusadding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "tbl_category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tbl_category");
        }
    }
}
