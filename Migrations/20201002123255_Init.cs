using Microsoft.EntityFrameworkCore.Migrations;

namespace UppgiftenSTSAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dorms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dorms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentmethods",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentmethodname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentmethods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    dormid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_dorms_dormid",
                        column: x => x.dormid,
                        principalTable: "dorms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seminars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seminarname = table.Column<string>(nullable: true),
                    SeminarOfPaymentmethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seminars", x => x.id);
                    table.ForeignKey(
                        name: "FK_seminars_paymentmethods_SeminarOfPaymentmethodId",
                        column: x => x.SeminarOfPaymentmethodId,
                        principalTable: "paymentmethods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_students_dormid",
                table: "students",
                column: "dormid");

            migrationBuilder.CreateIndex(
                name: "IX_studentSeminars_seminarId",
                table: "studentSeminars",
                column: "seminarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentSeminars");

            migrationBuilder.DropTable(
                name: "seminars");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "paymentmethods");

            migrationBuilder.DropTable(
                name: "dorms");
        }
    }
}
