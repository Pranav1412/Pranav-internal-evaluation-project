using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsComputerCentre.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "studentes",
                columns: table => new
                {
                    iRoll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentes", x => x.iRoll);
                });

            migrationBuilder.CreateTable(
                name: "teacherses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseDetailsCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherses", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_teacherses_courses_CourseDetailsCourseId",
                        column: x => x.CourseDetailsCourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentDetails",
                columns: table => new
                {
                    iRoll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FeesPaid = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentsiRoll = table.Column<int>(type: "int", nullable: false),
                    CourseDetailsCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDetails", x => x.iRoll);
                    table.ForeignKey(
                        name: "FK_studentDetails_courses_CourseDetailsCourseId",
                        column: x => x.CourseDetailsCourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentDetails_studentes_StudentsiRoll",
                        column: x => x.StudentsiRoll,
                        principalTable: "studentes",
                        principalColumn: "iRoll",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_CourseDetailsCourseId",
                table: "studentDetails",
                column: "CourseDetailsCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_StudentsiRoll",
                table: "studentDetails",
                column: "StudentsiRoll");

            migrationBuilder.CreateIndex(
                name: "IX_teacherses_CourseDetailsCourseId",
                table: "teacherses",
                column: "CourseDetailsCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentDetails");

            migrationBuilder.DropTable(
                name: "teacherses");

            migrationBuilder.DropTable(
                name: "studentes");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
