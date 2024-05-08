using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCatStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_DesignPosts_DesignPostId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_DesignPostId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Catagory",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DesignPostId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Catagory",
                table: "DesignPosts");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesignCatagoryCategoryId",
                table: "DesignPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "DesignPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.StyleId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Living Room" },
                    { 2, "Bedroom" },
                    { 3, "Office" },
                    { 4, "Bathroom" },
                    { 5, "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ItemTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Chair" },
                    { 2, "Table" },
                    { 3, "Closet" },
                    { 4, "Sofa/Couch" },
                    { 5, "Carpet" },
                    { 6, "Curtain" },
                    { 7, "Cabinet" },
                    { 8, "Shelves" },
                    { 9, "Shoe Closet" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "StyleId", "Name" },
                values: new object[,]
                {
                    { 1, "Modern" },
                    { 2, "Rustic" },
                    { 3, "Classic" },
                    { 4, "Cosy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PostId",
                table: "Items",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StyleId",
                table: "Items",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignPosts_DesignCatagoryCategoryId",
                table: "DesignPosts",
                column: "DesignCatagoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignPosts_Categories_DesignCatagoryCategoryId",
                table: "DesignPosts",
                column: "DesignCatagoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_DesignPosts_PostId",
                table: "Items",
                column: "PostId",
                principalTable: "DesignPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Styles_StyleId",
                table: "Items",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignPosts_Categories_DesignCatagoryCategoryId",
                table: "DesignPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_DesignPosts_PostId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Styles_StyleId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PostId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StyleId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_DesignPosts_DesignCatagoryCategoryId",
                table: "DesignPosts");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DesignCatagoryCategoryId",
                table: "DesignPosts");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "DesignPosts");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Catagory",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DesignPostId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Catagory",
                table: "DesignPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DesignPostId",
                table: "Items",
                column: "DesignPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_DesignPosts_DesignPostId",
                table: "Items",
                column: "DesignPostId",
                principalTable: "DesignPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }
    }
}
