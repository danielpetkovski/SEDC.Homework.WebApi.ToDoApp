using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels.Migrations
{
    public partial class init_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 100, nullable: true),
                    Color = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ToDoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTask_ToDo_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "Bob", "Bobsky", "bob123", "bob007" });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "Color", "Text", "UserId" },
                values: new object[] { 1, "yellow", "Create ToDo App", 1 });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "Color", "Text", "UserId" },
                values: new object[] { 2, "red", "Refactor Video rental Store app", 1 });

            migrationBuilder.InsertData(
                table: "SubTask",
                columns: new[] { "Id", "Status", "Text", "ToDoId" },
                values: new object[,]
                {
                    { 1, 2, "Research and consult with client", 1 },
                    { 2, 1, "Create the application", 1 },
                    { 3, 0, "Add swagger", 1 },
                    { 4, 2, "Consult with client about changes", 2 },
                    { 5, 1, "Make a team meeting", 2 },
                    { 6, 0, "Code the app", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_ToDoId",
                table: "SubTask",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTask");

            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
