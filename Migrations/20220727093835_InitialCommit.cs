using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptWriterApp.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    LineNum = table.Column<int>(type: "INTEGER", nullable: true),
                    Origin = table.Column<string>(type: "TEXT", nullable: true),
                    Modified = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<char>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeHistories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PagesDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    Texts = table.Column<string>(type: "TEXT", nullable: true),
                    pTexts = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesDatas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TextsData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    LineNum = table.Column<int>(type: "INTEGER", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextsData", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "PagesDatas",
                columns: new[] { "ID", "Path", "Texts", "pTexts" },
                values: new object[] { 1, "/", "my mom is beautiful", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistories");

            migrationBuilder.DropTable(
                name: "PagesDatas");

            migrationBuilder.DropTable(
                name: "TextsData");
        }
    }
}
