using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedcolumnInschooldetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "SchoolDetails",
                newName: "adminPassword");

            migrationBuilder.AddColumn<string>(
                name: "studentPassword",
                table: "SchoolDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentPassword",
                table: "SchoolDetails");

            migrationBuilder.RenameColumn(
                name: "adminPassword",
                table: "SchoolDetails",
                newName: "password");
        }
    }
}
