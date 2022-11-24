using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class FixIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePizza_Ingredienti_TagsId",
                table: "IngredientePizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientePizza",
                table: "IngredientePizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientePizza_TagsId",
                table: "IngredientePizza");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "IngredientePizza",
                newName: "IngredienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientePizza",
                table: "IngredientePizza",
                columns: new[] { "IngredienteId", "PizzasId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_PizzasId",
                table: "IngredientePizza",
                column: "PizzasId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePizza_Ingredienti_IngredienteId",
                table: "IngredientePizza",
                column: "IngredienteId",
                principalTable: "Ingredienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientePizza_Ingredienti_IngredienteId",
                table: "IngredientePizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientePizza",
                table: "IngredientePizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientePizza_PizzasId",
                table: "IngredientePizza");

            migrationBuilder.RenameColumn(
                name: "IngredienteId",
                table: "IngredientePizza",
                newName: "TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientePizza",
                table: "IngredientePizza",
                columns: new[] { "PizzasId", "TagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_TagsId",
                table: "IngredientePizza",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientePizza_Ingredienti_TagsId",
                table: "IngredientePizza",
                column: "TagsId",
                principalTable: "Ingredienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
