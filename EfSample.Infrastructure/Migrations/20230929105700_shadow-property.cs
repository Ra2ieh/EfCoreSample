using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shadowproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbt",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                schema: "dbt",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbt",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbt",
                table: "Course");
        }
    }
}
