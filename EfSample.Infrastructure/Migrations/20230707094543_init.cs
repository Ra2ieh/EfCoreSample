

#nullable disable

namespace EfSample.Infrastructure.Migrations;

/// <inheritdoc />
public partial class init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Course",
            columns: table => new
            {
                CourseId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Course", x => x.CourseId);
            });

        migrationBuilder.CreateTable(
            name: "Teacher",
            columns: table => new
            {
                TeacherId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Teacher", x => x.TeacherId);
            });

        migrationBuilder.CreateTable(
            name: "Comment",
            columns: table => new
            {
                CommentId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CouseId = table.Column<int>(type: "int", nullable: false),
                CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CourseId = table.Column<int>(type: "int", nullable: false),
                CommentBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                StarCount = table.Column<int>(type: "int", nullable: false),
                IsApproved = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comment", x => x.CommentId);
                table.ForeignKey(
                    name: "FK_Comment_Course_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Course",
                    principalColumn: "CourseId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Discount",
            columns: table => new
            {
                DiscountId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CourseId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Discount", x => x.DiscountId);
                table.ForeignKey(
                    name: "FK_Discount_Course_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Course",
                    principalColumn: "CourseId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tag",
            columns: table => new
            {
                TagId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CourseId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tag", x => x.TagId);
                table.ForeignKey(
                    name: "FK_Tag_Course_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Course",
                    principalColumn: "CourseId");
            });

        migrationBuilder.CreateTable(
            name: "CourseTeachers",
            columns: table => new
            {
                CourseTeachersId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TeacherId = table.Column<int>(type: "int", nullable: false),
                CourseId = table.Column<int>(type: "int", nullable: false),
                SortOrder = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CourseTeachers", x => x.CourseTeachersId);
                table.ForeignKey(
                    name: "FK_CourseTeachers_Course_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Course",
                    principalColumn: "CourseId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CourseTeachers_Teacher_TeacherId",
                    column: x => x.TeacherId,
                    principalTable: "Teacher",
                    principalColumn: "TeacherId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Comment_CourseId",
            table: "Comment",
            column: "CourseId");

        migrationBuilder.CreateIndex(
            name: "IX_CourseTeachers_CourseId",
            table: "CourseTeachers",
            column: "CourseId");

        migrationBuilder.CreateIndex(
            name: "IX_CourseTeachers_TeacherId",
            table: "CourseTeachers",
            column: "TeacherId");

        migrationBuilder.CreateIndex(
            name: "IX_Discount_CourseId",
            table: "Discount",
            column: "CourseId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Tag_CourseId",
            table: "Tag",
            column: "CourseId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Comment");

        migrationBuilder.DropTable(
            name: "CourseTeachers");

        migrationBuilder.DropTable(
            name: "Discount");

        migrationBuilder.DropTable(
            name: "Tag");

        migrationBuilder.DropTable(
            name: "Teacher");

        migrationBuilder.DropTable(
            name: "Course");
    }
}
