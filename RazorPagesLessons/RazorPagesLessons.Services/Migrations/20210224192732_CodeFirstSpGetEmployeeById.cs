using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLessons.Services.Migrations
{
    public partial class CodeFirstSpGetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure CodeFirstSpGetEmployeeById
                                 @Id int
                                 as
                                 begin
                                 select * from Employees
                                 where Id = @Id
                                 end";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure CodeFirstSpGetEmployeeById";

            migrationBuilder.Sql(procedure);
        }
    }
}
