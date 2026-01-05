using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Wishlist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WishlistUserItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Create Table WISHLIST_USER_ITEM

            migrationBuilder.CreateTable(
                name: "WISHLIST_USER_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID = table.Column<Guid>(nullable: false),
                    WISHLIST_ID = table.Column<Guid>(nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(nullable: false),
                    UPDATED_AT = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISHLIST_USER_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WISHLIST_USER_ITEM_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WISHLIST_USER_ITEM_WISHLISTS_WISHLIST_ID",
                        column: x => x.WISHLIST_ID,
                        principalTable: "WISHLISTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            #endregion

            #region Create Index

            migrationBuilder.CreateIndex(
                name: "IX_WISHLIST_USER_ITEM_USER_ID",
                table: "WISHLIST_USER_ITEM",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WISHLIST_USER_ITEM_WISHLIST_ID",
                table: "WISHLIST_USER_ITEM",
                column: "WISHLIST_ID");

            #endregion
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            #region Drop Table WISHLIST_USER_ITEM

            migrationBuilder.DropTable(
                name: "WISHLIST_USER_ITEM");

            #endregion
        }
    }
}
