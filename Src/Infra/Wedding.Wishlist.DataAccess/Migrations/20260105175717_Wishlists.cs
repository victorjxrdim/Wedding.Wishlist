using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Wishlist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Wishlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Create Table WISHLISTS

            migrationBuilder.CreateTable(
                name: "WISHLISTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 256, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 1000, nullable: false),
                    CATEGORY = table.Column<int>(nullable: false),
                    URL = table.Column<string>(maxLength: 2000, nullable: false),
                    IMAGE_URL = table.Column<string>(nullable: false),
                    IS_ACTIVE = table.Column<int>(maxLength: 10, nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISHLISTS", x => x.ID);
                });

            #endregion

            #region Create Index

            #endregion
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            #region Drop Table WISHLISTS

            migrationBuilder.DropTable(
                name: "WISHLISTS");

            #endregion
        }
    }
}
