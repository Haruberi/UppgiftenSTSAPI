using Microsoft.EntityFrameworkCore.Migrations;

namespace UppgiftenSTSAPI.Migrations
{
    public partial class AddStudentSeminar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeminarOfPaymentmethodId",
                table: "seminars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "studentSeminars",
                columns: table => new
                {
                    studentId = table.Column<int>(nullable: false),
                    seminarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSeminars", x => new { x.studentId, x.seminarId });
                    table.ForeignKey(
                        name: "FK_studentSeminars_seminars_seminarId",
                        column: x => x.seminarId,
                        principalTable: "seminars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSeminars_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_seminars_SeminarOfPaymentmethodId",
                table: "seminars",
                column: "SeminarOfPaymentmethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentSeminars_seminarId",
                table: "studentSeminars",
                column: "seminarId");

            migrationBuilder.AddForeignKey(
                name: "FK_seminars_paymentmethods_SeminarOfPaymentmethodId",
                table: "seminars",
                column: "SeminarOfPaymentmethodId",
                principalTable: "paymentmethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seminars_paymentmethods_SeminarOfPaymentmethodId",
                table: "seminars");

            migrationBuilder.DropTable(
                name: "studentSeminars");

            migrationBuilder.DropIndex(
                name: "IX_seminars_SeminarOfPaymentmethodId",
                table: "seminars");

            migrationBuilder.DropColumn(
                name: "SeminarOfPaymentmethodId",
                table: "seminars");
        }
    }
}
