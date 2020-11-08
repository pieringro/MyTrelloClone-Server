using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTrelloClone.DataAccess.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Board",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Descrizione board 1", "Nome board 1" });

            migrationBuilder.InsertData(
                table: "Board",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Descrizione board 2", "Nome board 2" });

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "Id", "BoardId", "Description", "Name" },
                values: new object[] { 1, 1, "Descrizione lista task 1", "Lista di task 1" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Name", "TaskListId" },
                values: new object[] { 1, "Descrizione task 1", "task 1", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Board",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Board",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
