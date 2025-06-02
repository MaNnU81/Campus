using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Campus.Migrations
{
    /// <inheritdoc />
    public partial class campus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    IdSchool_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    SiteName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.IdSchool_code);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent_code = table.Column<string>(type: "text", nullable: false),
                    IdSchool_code = table.Column<string>(type: "character varying(10)", nullable: false),
                    FiscalCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent_code);
                    table.ForeignKey(
                        name: "FK_Students_Schools_IdSchool_code",
                        column: x => x.IdSchool_code,
                        principalTable: "Schools",
                        principalColumn: "IdSchool_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IdTeacher_code = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    IdSchool_code = table.Column<string>(type: "character varying(10)", nullable: false),
                    FiscalCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IdTeacher_code);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_IdSchool_code",
                        column: x => x.IdSchool_code,
                        principalTable: "Schools",
                        principalColumn: "IdSchool_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourse_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Course_Name = table.Column<string>(type: "text", nullable: false),
                    MaxCapacity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IdTeacher_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourse_code);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_IdTeacher_code",
                        column: x => x.IdTeacher_code,
                        principalTable: "Teachers",
                        principalColumn: "IdTeacher_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "character varying(10)", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "IdCourse_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "IdStudent_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdTeacher_code",
                table: "Courses",
                column: "IdTeacher_code");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdSchool_code",
                table: "Students",
                column: "IdSchool_code");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IdSchool_code",
                table: "Teachers",
                column: "IdSchool_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
