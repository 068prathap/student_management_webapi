using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedfoeginkeyforstudentlistschoolid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentAccess",
                table: "SchoolDetails");

            migrationBuilder.AddColumn<int>(
                name: "schoolId",
                table: "StudentList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "studentPassword",
                table: "SchoolDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "StudentList");

            migrationBuilder.AlterColumn<string>(
                name: "studentPassword",
                table: "SchoolDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "studentAccess",
                table: "SchoolDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
