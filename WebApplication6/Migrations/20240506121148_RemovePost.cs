using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class RemovePost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Posts_PostId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Posts_PostId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Stores_PostId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Items_PostId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catagory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PostId",
                table: "Stores",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PostId",
                table: "Items",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Posts_PostId",
                table: "Items",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Posts_PostId",
                table: "Stores",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
