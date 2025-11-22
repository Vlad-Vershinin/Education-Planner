using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LeveledSkill",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LeveledCourses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Fullname = table.Column<string>(type: "text", nullable: true),
                    ProfessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeveledSkill_UserId",
                table: "LeveledSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeveledCourses_UserId",
                table: "LeveledCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfessionId",
                table: "User",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledCourses_User_UserId",
                table: "LeveledCourses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeveledSkill_User_UserId",
                table: "LeveledSkill",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeveledCourses_User_UserId",
                table: "LeveledCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeveledSkill_User_UserId",
                table: "LeveledSkill");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_LeveledSkill_UserId",
                table: "LeveledSkill");

            migrationBuilder.DropIndex(
                name: "IX_LeveledCourses_UserId",
                table: "LeveledCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LeveledSkill");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LeveledCourses");
        }
    }
}
