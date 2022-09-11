using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Cooking_App.Migrations
{
    public partial class AddingRoleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Userr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "User");
        }
    }
}
