using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into AspNetRoles(Name, NormalizedName) values(\"Manager\" \"Manager\")");
            migrationBuilder.Sql("insert into AspNetRoles(Name, NormalizedName) values(\"Buyer\" \"Buyer\")");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetRoles where Name=\"Manager\"");
            migrationBuilder.Sql("delete from AspNetRoles where Name=\"Buyer\"");
        }
    }
}
