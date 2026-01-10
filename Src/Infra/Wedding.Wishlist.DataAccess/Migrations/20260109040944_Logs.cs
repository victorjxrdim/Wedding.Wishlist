using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wedding.Wishlist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Create Table LOGS

            migrationBuilder.CreateTable(
                name: "LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TYPE = table.Column<int>(nullable: false),
                    REQUEST_ID = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    MESSAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TRACE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TARGET_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    REFERENCE_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    REFERENCE_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    USERS_ID = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGS", x => x.ID);
                });

            #endregion

            #region Create Index

            #endregion
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            #region Drop Table LOGS
            
            migrationBuilder.DropTable(
                name: "LOGS");

            #endregion
        }
    }
}
