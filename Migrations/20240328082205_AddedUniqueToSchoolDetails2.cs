using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueToSchoolDetails2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolDetails_userName",
                table: "SchoolDetails");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SchoolDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolDetails_userName_email",
                table: "SchoolDetails",
                columns: new[] { "userName", "email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolDetails_userName_email",
                table: "SchoolDetails");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SchoolDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolDetails_userName",
                table: "SchoolDetails",
                column: "userName",
                unique: true);
        }
    }
}
