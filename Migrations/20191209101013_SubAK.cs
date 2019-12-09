using Microsoft.EntityFrameworkCore.Migrations;

namespace IamPof.Migrations
{
    public partial class SubAK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Id_Sub",
                table: "User");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Sub",
                table: "User",
                column: "Sub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Sub",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id_Sub",
                table: "User",
                columns: new[] { "Id", "Sub" });
        }
    }
}
