using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LastName",
                table: "Teacher",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Title",
                table: "Course",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teacher_LastName",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Course_Title",
                table: "Course");
        }
    }
}
