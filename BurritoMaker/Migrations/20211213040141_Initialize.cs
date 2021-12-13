using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurritoMaker.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    BurritoName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Tortilla = table.Column<string>(nullable: true),
                    Sauce = table.Column<string>(nullable: true),
                    Rice = table.Column<string>(nullable: true),
                    Beans = table.Column<string>(nullable: true),
                    Meat = table.Column<string>(nullable: true),
                    Cheese = table.Column<string>(nullable: true),
                    Veg1 = table.Column<string>(nullable: true),
                    Veg2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
