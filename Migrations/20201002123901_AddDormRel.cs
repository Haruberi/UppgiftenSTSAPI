using Microsoft.EntityFrameworkCore.Migrations;

namespace UppgiftenSTSAPI.Migrations
{
    public partial class AddDormRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_dorms_dormid",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_dormid",
                table: "students");

            migrationBuilder.DropColumn(
                name: "dormid",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "currentDormId",
                table: "students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_currentDormId",
                table: "students",
                column: "currentDormId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_dorms_currentDormId",
                table: "students",
                column: "currentDormId",
                principalTable: "dorms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_dorms_currentDormId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_currentDormId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "currentDormId",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "dormid",
                table: "students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_dormid",
                table: "students",
                column: "dormid");

            migrationBuilder.AddForeignKey(
                name: "FK_students_dorms_dormid",
                table: "students",
                column: "dormid",
                principalTable: "dorms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
