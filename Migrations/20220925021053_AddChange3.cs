using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations
{
    public partial class AddChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_Wishlistid",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_userId",
                table: "Wishlists");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Wishlists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Wishlists",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_userId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserId");

            migrationBuilder.RenameColumn(
                name: "Wishlistid",
                table: "WishlistItems",
                newName: "WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_Wishlistid",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_UserId",
                table: "Wishlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_UserId",
                table: "Wishlists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Wishlists",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wishlists",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                newName: "IX_Wishlists_userId");

            migrationBuilder.RenameColumn(
                name: "WishlistId",
                table: "WishlistItems",
                newName: "Wishlistid");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_Wishlistid");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_Wishlistid",
                table: "WishlistItems",
                column: "Wishlistid",
                principalTable: "Wishlists",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_userId",
                table: "Wishlists",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
