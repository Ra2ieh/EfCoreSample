using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbt");

            migrationBuilder.EnsureSchema(
                name: "view");

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "dbt",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseSerie = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.UniqueConstraint("AK_Course_CourseSerie", x => x.CourseSerie);
                });

            migrationBuilder.CreateTable(
                name: "CourseIncludingDiscount",
                schema: "view",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NewPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyCourses",
                schema: "view",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "dbt",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "dbt",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Profile_ProfileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Profile_ProfileId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Profile_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbt",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Age = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UserShipAge = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => new { x.UserId, x.UserName });
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "dbt",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CommentBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "CourseINrelWithComment",
                        column: x => x.CourseId,
                        principalSchema: "dbt",
                        principalTable: "Course",
                        principalColumn: "CourseSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "dbt",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                    table.ForeignKey(
                        name: "FK_Discount_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbt",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTag",
                schema: "dbt",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_CourseTag_Course_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbt",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbt",
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbt",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Teacher_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbt",
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                    table.ForeignKey(
                        name: "FK_Account_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "dbt",
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbt",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.TeacherId, x.Id });
                    table.ForeignKey(
                        name: "FK_Address_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "dbt",
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeachers",
                schema: "dbt",
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
                        principalSchema: "dbt",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeachers_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "dbt",
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                schema: "dbt",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => new { x.TeacherId, x.Id });
                    table.ForeignKey(
                        name: "FK_Phone_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "dbt",
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_TeacherId",
                schema: "dbt",
                table: "Account",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CourseId",
                schema: "dbt",
                table: "Comment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Title",
                schema: "dbt",
                table: "Course",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeachers_CourseId",
                schema: "dbt",
                table: "CourseTeachers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeachers_TeacherId",
                schema: "dbt",
                table: "CourseTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CourseId",
                schema: "dbt",
                table: "Discount",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LastName",
                schema: "dbt",
                table: "Teacher",
                column: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "CourseIncludingDiscount",
                schema: "view");

            migrationBuilder.DropTable(
                name: "CourseTag",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "CourseTeachers",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "MyCourses",
                schema: "view");

            migrationBuilder.DropTable(
                name: "Phone",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "dbt");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "dbt");
        }
    }
}
