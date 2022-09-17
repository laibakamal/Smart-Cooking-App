using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Cooking_App.Migrations
{
    public partial class ThumbnailTextColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailText",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

    }
}
