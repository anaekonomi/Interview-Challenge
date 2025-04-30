using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings",
                column: "BeerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Beer_BeerId",
                table: "Ratings",
                column: "BeerId",
                principalTable: "Beer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Beer_BeerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings");
        }
    }
}
