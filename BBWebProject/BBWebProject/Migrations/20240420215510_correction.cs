using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBWebProject.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "review",
                table: "tbl_testimonials",
                newName: "Review");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Review",
                table: "tbl_testimonials",
                newName: "review");
        }
    }
}
