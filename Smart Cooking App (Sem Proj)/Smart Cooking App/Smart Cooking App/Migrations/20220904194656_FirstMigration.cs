using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Cooking_App.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Userr",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ConfirmPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Userr", x => x.Id);
            //    });
        }
    }
}
