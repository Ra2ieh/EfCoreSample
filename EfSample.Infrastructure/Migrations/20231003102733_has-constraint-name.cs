using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class hasconstraintname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Course_CourseId",
                schema: "dbt",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "CourseINrelWithComment",
                schema: "dbt",
                table: "Comment",
                column: "CourseId",
                principalSchema: "dbt",
                principalTable: "Course",
                principalColumn: "CourseSerie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CourseINrelWithComment",
                schema: "dbt",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Course_CourseId",
                schema: "dbt",
                table: "Comment",
                column: "CourseId",
                principalSchema: "dbt",
                principalTable: "Course",
                principalColumn: "CourseSerie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
