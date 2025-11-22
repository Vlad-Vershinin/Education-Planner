using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Skills_SkillId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledCourses_Courses_CourseId",
                table: "LeveledCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledCourses_User_UserId",
                table: "LeveledCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_Courses_CourseId",
                table: "LeveledSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_Skills_SkillId",
                table: "LeveledSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Professions_ProfessionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfessionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeveledSkill",
                table: "LeveledSkill");

            migrationBuilder.DropIndex(
                name: "IX_LeveledSkill_CourseId",
                table: "LeveledSkill");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SkillId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeveledCourses",
                table: "LeveledCourses");

            migrationBuilder.DropIndex(
                name: "IX_LeveledCourses_UserId",
                table: "LeveledCourses");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LeveledSkill");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LeveledCourses");

            migrationBuilder.RenameTable(
                name: "LeveledCourses",
                newName: "LeveledCourse");

            migrationBuilder.RenameIndex(
                name: "IX_LeveledCourses_CourseId",
                table: "LeveledCourse",
                newName: "IX_LeveledCourse_CourseId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionChosenId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeveledSkillCourseId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeveledSkillSkillId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeveledSkill",
                table: "LeveledSkill",
                columns: new[] { "CourseId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeveledCourse",
                table: "LeveledCourse",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CourseTaken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Progress = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTaken", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseTaken_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTaken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfessionChosenId",
                table: "User",
                column: "ProfessionChosenId");

            migrationBuilder.CreateIndex(
                name: "IX_LeveledSkill_LeveledSkillCourseId_LeveledSkillSkillId",
                table: "LeveledSkill",
                columns: new[] { "LeveledSkillCourseId", "LeveledSkillSkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTaken_CourseId",
                table: "CourseTaken",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledCourse_Courses_CourseId",
                table: "LeveledCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_Courses_CourseId",
                table: "LeveledSkill",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_LeveledSkill_LeveledSkillCourseId_LeveledSkill~",
                table: "LeveledSkill",
                columns: new[] { "LeveledSkillCourseId", "LeveledSkillSkillId" },
                principalTable: "LeveledSkill",
                principalColumns: new[] { "CourseId", "SkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_Skills_SkillId",
                table: "LeveledSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Professions_ProfessionChosenId",
                table: "User",
                column: "ProfessionChosenId",
                principalTable: "Professions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeveledCourse_Courses_CourseId",
                table: "LeveledCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_Courses_CourseId",
                table: "LeveledSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_LeveledSkill_LeveledSkillCourseId_LeveledSkill~",
                table: "LeveledSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_Skills_SkillId",
                table: "LeveledSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Professions_ProfessionChosenId",
                table: "User");

            migrationBuilder.DropTable(
                name: "CourseTaken");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfessionChosenId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeveledSkill",
                table: "LeveledSkill");

            migrationBuilder.DropIndex(
                name: "IX_LeveledSkill_LeveledSkillCourseId_LeveledSkillSkillId",
                table: "LeveledSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeveledCourse",
                table: "LeveledCourse");

            migrationBuilder.DropColumn(
                name: "ProfessionChosenId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LeveledSkillCourseId",
                table: "LeveledSkill");

            migrationBuilder.DropColumn(
                name: "LeveledSkillSkillId",
                table: "LeveledSkill");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "LeveledCourse",
                newName: "LeveledCourses");

            migrationBuilder.RenameIndex(
                name: "IX_LeveledCourse_CourseId",
                table: "LeveledCourses",
                newName: "IX_LeveledCourses_CourseId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "LeveledSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LeveledCourses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeveledSkill",
                table: "LeveledSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeveledCourses",
                table: "LeveledCourses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfessionId",
                table: "User",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeveledSkill_CourseId",
                table: "LeveledSkill",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SkillId",
                table: "Courses",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_LeveledCourses_UserId",
                table: "LeveledCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Skills_SkillId",
                table: "Courses",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledCourses_Courses_CourseId",
                table: "LeveledCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledCourses_User_UserId",
                table: "LeveledCourses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_Courses_CourseId",
                table: "LeveledSkill",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_Skills_SkillId",
                table: "LeveledSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Professions_ProfessionId",
                table: "User",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
