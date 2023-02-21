using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Store_Management.Data.Migrations
{
    public partial class SeedRolesIntoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "AspNetRoles",
           columns: new[] { "Id", "Name" },
           values: new object[,]
           {
                { "1","admin" },
                { "2","employee" },
                { "3","customer" }
       });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
