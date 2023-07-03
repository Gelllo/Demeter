using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demeter.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Changedmanytomanytoonetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFoods");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NrOfPortions",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealId",
                table: "Foods",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MealId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "NrOfPortions",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "MealFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    NrOfPortions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealFoods_Foods_Food",
                        column: x => x.Food,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFoods_Meals_Meal",
                        column: x => x.Meal,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFoods_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_Food",
                table: "MealFoods",
                column: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_Meal",
                table: "MealFoods",
                column: "Meal");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                column: "MealId");
        }
    }
}
