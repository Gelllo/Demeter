using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demeter.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class ChangedrelationandaddeduserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Foods_FoodID",
                table: "MealFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Meals_MealID",
                table: "MealFoods");

            migrationBuilder.RenameColumn(
                name: "MealID",
                table: "MealFoods",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "FoodID",
                table: "MealFoods",
                newName: "Food");

            migrationBuilder.RenameIndex(
                name: "IX_MealFoods_MealID",
                table: "MealFoods",
                newName: "IX_MealFoods_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealFoods_FoodID",
                table: "MealFoods",
                newName: "IX_MealFoods_Food");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Meals",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "MealFoods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Meal",
                table: "MealFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Foods_Title",
                table: "Foods",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_Meal",
                table: "MealFoods",
                column: "Meal");

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Foods_Food",
                table: "MealFoods",
                column: "Food",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Meals_Meal",
                table: "MealFoods",
                column: "Meal",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Meals_MealId",
                table: "MealFoods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Foods_Food",
                table: "MealFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Meals_Meal",
                table: "MealFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Meals_MealId",
                table: "MealFoods");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_Meal",
                table: "MealFoods");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Foods_Title",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Meal",
                table: "MealFoods");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "MealFoods",
                newName: "MealID");

            migrationBuilder.RenameColumn(
                name: "Food",
                table: "MealFoods",
                newName: "FoodID");

            migrationBuilder.RenameIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                newName: "IX_MealFoods_MealID");

            migrationBuilder.RenameIndex(
                name: "IX_MealFoods_Food",
                table: "MealFoods",
                newName: "IX_MealFoods_FoodID");

            migrationBuilder.AlterColumn<int>(
                name: "MealID",
                table: "MealFoods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Foods_FoodID",
                table: "MealFoods",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Meals_MealID",
                table: "MealFoods",
                column: "MealID",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
