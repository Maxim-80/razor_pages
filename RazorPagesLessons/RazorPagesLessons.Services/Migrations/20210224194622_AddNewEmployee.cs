using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLessons.Services.Migrations
{
    public partial class AddNewEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                @"create procedure spAddNewEmployee
                @Name nvarchar(50),
                @Email nvarchar(50),
                @PhotoPath nvarchar(50),
                @Dept int
                as
                begin
                    insert into Employees (Name, Email, PhotoPath, Department)
                    values (@Name, @Email, @PhotoPath, @Dept)
                end";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spAddNewEmployee";
            migrationBuilder.Sql(procedure);
        }
    }
}
