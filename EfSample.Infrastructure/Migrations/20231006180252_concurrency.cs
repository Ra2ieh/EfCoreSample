using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class concurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbt",
                table: "Course",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbt",
                table: "Course");
        }
    }
}
