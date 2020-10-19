using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial.Car.DB.Schema.Migrations
{
    public partial class Update_Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Channels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Channels");
        }
    }
}
