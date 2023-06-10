using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace physics_webserver.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Theory",
                columns: table => new
                {
                    TheoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheoryTheme = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TheorySection = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TheoryText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryKey", x => x.TheoryId);
                });

            migrationBuilder.CreateTable(
                name: "_User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserLogin = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKey", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "_Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    AdminFullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminKey", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_AdminUserKey",
                        column: x => x.AdminId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "_Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageKey", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_MessageUserKey",
                        column: x => x.MessageUserId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "_Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentFullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    StudentGroup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentKey", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentUserKey",
                        column: x => x.StudentId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "_Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    TeacherFullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherKey", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_TeacherUserKey",
                        column: x => x.TeacherId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "_Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupLabel = table.Column<int>(type: "int", nullable: true),
                    GroupStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupKey", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_GroupStudentKey",
                        column: x => x.GroupStudentId,
                        principalTable: "_Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "_Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskTheoryId = table.Column<int>(type: "int", nullable: true),
                    TaskTeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskKey", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskTeacherKey",
                        column: x => x.TaskTeacherId,
                        principalTable: "_Teacher",
                        principalColumn: "TeacherId");
                    table.ForeignKey(
                        name: "FK_TaskTheoryKey",
                        column: x => x.TaskTheoryId,
                        principalTable: "_Theory",
                        principalColumn: "TheoryId");
                });

            migrationBuilder.CreateTable(
                name: "_Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerCorrect = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AnswerStudent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AnswerStudentId = table.Column<int>(type: "int", nullable: true),
                    AnswerTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerKey", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_AnswerStudentKey",
                        column: x => x.AnswerStudentId,
                        principalTable: "_Student",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_AnswerTaskKey",
                        column: x => x.AnswerTaskId,
                        principalTable: "_Task",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Answers_AnswerStudentId",
                table: "_Answers",
                column: "AnswerStudentId");

            migrationBuilder.CreateIndex(
                name: "IX__Answers_AnswerTaskId",
                table: "_Answers",
                column: "AnswerTaskId");

            migrationBuilder.CreateIndex(
                name: "IX__Group_GroupStudentId",
                table: "_Group",
                column: "GroupStudentId");

            migrationBuilder.CreateIndex(
                name: "IX__Message_MessageUserId",
                table: "_Message",
                column: "MessageUserId");

            migrationBuilder.CreateIndex(
                name: "IX__Task_TaskTeacherId",
                table: "_Task",
                column: "TaskTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX__Task_TaskTheoryId",
                table: "_Task",
                column: "TaskTheoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Admin");

            migrationBuilder.DropTable(
                name: "_Answers");

            migrationBuilder.DropTable(
                name: "_Group");

            migrationBuilder.DropTable(
                name: "_Message");

            migrationBuilder.DropTable(
                name: "_Task");

            migrationBuilder.DropTable(
                name: "_Student");

            migrationBuilder.DropTable(
                name: "_Teacher");

            migrationBuilder.DropTable(
                name: "_Theory");

            migrationBuilder.DropTable(
                name: "_User");
        }
    }
}
