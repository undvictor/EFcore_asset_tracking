using Microsoft.EntityFrameworkCore.Migrations;

namespace EFassets.Data.Migrations
{
    public partial class what : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Assets_AssetId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AssetId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryObjectId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryObjectId",
                table: "Assets",
                column: "CategoryObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories_CategoryObjectId",
                table: "Assets",
                column: "CategoryObjectId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories_CategoryObjectId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CategoryObjectId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CategoryObjectId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AssetId",
                table: "Categories",
                column: "AssetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Assets_AssetId",
                table: "Categories",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
