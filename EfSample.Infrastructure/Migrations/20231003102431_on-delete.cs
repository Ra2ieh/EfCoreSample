using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ondelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Teacher_AccountId",
                schema: "dbt",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Course_CourseId",
                schema: "dbt",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CourseSerie",
                schema: "dbt",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Course_CourseSerie",
                schema: "dbt",
                table: "Course",
                column: "CourseSerie");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Teacher_AccountId",
                schema: "dbt",
                table: "Account",
                column: "AccountId",
                principalSchema: "dbt",
                principalTable: "Teacher",
                principalColumn: "TeacherId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Teacher_AccountId",
                schema: "dbt",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Course_CourseId",
                schema: "dbt",
                table: "Comment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Course_CourseSerie",
                schema: "dbt",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseSerie",
                schema: "dbt",
                table: "Course");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Teacher_AccountId",
                schema: "dbt",
                table: "Account",
                column: "AccountId",
                principalSchema: "dbt",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Course_CourseId",
                schema: "dbt",
                table: "Comment",
                column: "CourseId",
                principalSchema: "dbt",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
