using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addclasscoursetag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_CourseId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "CourseTag",
                columns: table => new
                {
                    CourseTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTag", x => x.CourseTagId);
                    table.ForeignKey(
                        name: "FK_CourseTag_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTag_CourseId",
                table: "CourseTag",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTag_TagId",
                table: "CourseTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTag");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_CourseId",
                table: "Tag",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");
        }
    }
}
