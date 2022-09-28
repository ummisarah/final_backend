using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations
{
    public partial class ChangeNameWishlistItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "WishlistItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "WishlistItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "WishlistItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "WishlistItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
