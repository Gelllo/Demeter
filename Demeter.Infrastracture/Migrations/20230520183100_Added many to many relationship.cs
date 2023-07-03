using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demeter.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Addedmanytomanyrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryProductGroceryProductRecord",
                columns: table => new
                {
                    GroceryProductRecordsId = table.Column<int>(type: "int", nullable: false),
                    GroceryProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProductGroceryProductRecord", x => new { x.GroceryProductRecordsId, x.GroceryProductsId });
                    table.ForeignKey(
                        name: "FK_GroceryProductGroceryProductRecord_FoodRecord_GroceryProductRecordsId",
                        column: x => x.GroceryProductRecordsId,
                        principalTable: "FoodRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryProductGroceryProductRecord_GroceryProducts_GroceryProductsId",
                        column: x => x.GroceryProductsId,
                        principalTable: "GroceryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientIngredientRecord",
                columns: table => new
                {
                    IngredientRecordsId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIngredientRecord", x => new { x.IngredientRecordsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientIngredientRecord_FoodRecord_IngredientRecordsId",
                        column: x => x.IngredientRecordsId,
                        principalTable: "FoodRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIngredientRecord_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductGroceryProductRecord_GroceryProductsId",
                table: "GroceryProductGroceryProductRecord",
                column: "GroceryProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIngredientRecord_IngredientsId",
                table: "IngredientIngredientRecord",
                column: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryProductGroceryProductRecord");

            migrationBuilder.DropTable(
                name: "IngredientIngredientRecord");
        }
    }
}
