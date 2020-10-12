using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 0);
        }
    }
}
