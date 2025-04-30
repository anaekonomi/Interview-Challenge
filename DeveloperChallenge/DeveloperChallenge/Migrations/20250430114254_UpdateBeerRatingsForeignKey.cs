using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperChallenge.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBeerRatingsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings",
                column: "BeerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings",
                column: "BeerId",
                unique: true);
        }
    }
}
