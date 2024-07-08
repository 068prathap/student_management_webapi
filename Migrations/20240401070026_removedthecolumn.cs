using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removedthecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentList_SchoolDetails_schoolId",
                table: "StudentList");

            migrationBuilder.DropIndex(
                name: "IX_StudentList_schoolId",
                table: "StudentList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentList_schoolId",
                table: "StudentList",
                column: "schoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentList_SchoolDetails_schoolId",
                table: "StudentList",
                column: "schoolId",
                principalTable: "SchoolDetails",
                principalColumn: "schoolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
