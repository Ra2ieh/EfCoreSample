using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSample.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sqlfunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE FUNCTION GetCourseCommentsCount (@id int) RETURNS int AS BEGIN return (select count(*) from[dbt].[Comment] where CourseId = @id ) END");
            migrationBuilder.Sql("CREATE FUNCTION GetCourseTagsCount (@id int) RETURNS int AS BEGIN return(select count(*) from [dbt].[CourseTag] where CourseId=@id) END");       
            migrationBuilder.Sql("CREATE FUNCTION GetCourseComments (@id int) RETURNS table AS return( select * from [dbt].[Comment] where CourseId=@id)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop function GetCourseCommentsCount ");
            migrationBuilder.Sql("drop function GetCourseTagsCount ");
            migrationBuilder.Sql("drop function GetCourseComments ");
        }
    }
}
