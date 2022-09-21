using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_cartid",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_userId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_productId",
                table: "WishlistItems");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "WishlistItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WishlistItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_productId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_ProductId");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Products",
                newName: "ImageURL");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryid",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Categories",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_userId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "CartItems",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "cartid",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CartItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_productId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_cartid",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "WishlistItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WishlistItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_ProductId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_productId");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "categoryid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "image_url");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_categoryid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Categories",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carts",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                newName: "IX_Carts_userId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "CartItems",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "cartid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_cartid",
                table: "CartItems",
                column: "cartid",
                principalTable: "Carts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_userId",
                table: "Carts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryid",
                table: "Products",
                column: "categoryid",
                principalTable: "Categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_productId",
                table: "WishlistItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
