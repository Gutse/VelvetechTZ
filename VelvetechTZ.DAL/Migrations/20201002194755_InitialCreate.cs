using Microsoft.EntityFrameworkCore.Migrations;

namespace VelvetechTZ.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_groups", x => x.Id));

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<int>(nullable: false),
                    Family = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SureName = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_students", x => x.Id));

            migrationBuilder.CreateTable(
                name: "StudentGroup",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false),
                    GroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroup", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentGroup_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroup_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroup_StudentId",
                table: "StudentGroup",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGroup");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
