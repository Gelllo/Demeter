using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demeter.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Changednameoftablesmanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryProductGroceryProductRecord");

            migrationBuilder.DropTable(
                name: "IngredientIngredientRecord");

            migrationBuilder.DropColumn(
                name: "GroceryProductId",
                table: "FoodRecord");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "FoodRecord");

            migrationBuilder.CreateTable(
                name: "GroceryProductToRecord",
                columns: table => new
                {
                    GroceryProductRecordsId = table.Column<int>(type: "int", nullable: false),
                    GroceryProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProductToRecord", x => new { x.GroceryProductRecordsId, x.GroceryProductsId });
                    table.ForeignKey(
                        name: "FK_GroceryProductToRecord_FoodRecord_GroceryProductRecordsId",
                        column: x => x.GroceryProductRecordsId,
                        principalTable: "FoodRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryProductToRecord_GroceryProducts_GroceryProductsId",
                        column: x => x.GroceryProductsId,
                        principalTable: "GroceryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientToIngredientRecord",
                columns: table => new
                {
                    IngredientRecordsId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientToIngredientRecord", x => new { x.IngredientRecordsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientToIngredientRecord_FoodRecord_IngredientRecordsId",
                        column: x => x.IngredientRecordsId,
                        principalTable: "FoodRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientToIngredientRecord_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductToRecord_GroceryProductsId",
                table: "GroceryProductToRecord",
                column: "GroceryProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientToIngredientRecord_IngredientsId",
                table: "IngredientToIngredientRecord",
                column: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryProductToRecord");

            migrationBuilder.DropTable(
                name: "IngredientToIngredientRecord");

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductId",
                table: "FoodRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "FoodRecord",
                type: "int",
                nullable: true);

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
    }
}
