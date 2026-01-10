using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Wishlist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Create Table USERS

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 256, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 256, nullable: false),
                    HASH_PASSWORD = table.Column<string>(maxLength: 256, nullable: false),
                    HASH_VERSION = table.Column<string>(maxLength: 10, nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            #endregion

            #region Create Index

            #endregion
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            #region Drop Table USERS

            migrationBuilder.DropTable(
                name: "USERS");

            #endregion
        }
    }
}
