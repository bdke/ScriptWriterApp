using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptWriterApp.Migrations
{
    public partial class init : Migration
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
                name: "FolderDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderName = table.Column<string>(type: "TEXT", nullable: true),
                    FoldersDataID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderDatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FolderDatas_FolderDatas_FoldersDataID",
                        column: x => x.FoldersDataID,
                        principalTable: "FolderDatas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PagesDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    Texts = table.Column<string>(type: "TEXT", nullable: true),
                    pTexts = table.Column<string>(type: "TEXT", nullable: true),
                    FoldersDataID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesDatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PagesDatas_FolderDatas_FoldersDataID",
                        column: x => x.FoldersDataID,
                        principalTable: "FolderDatas",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "FolderDatas",
                columns: new[] { "ID", "FolderName", "FoldersDataID" },
                values: new object[] { 1, "idk", null });

            migrationBuilder.InsertData(
                table: "PagesDatas",
                columns: new[] { "ID", "FoldersDataID", "Path", "Texts", "pTexts" },
                values: new object[] { 1, null, "/", "my mom is beautiful", "" });

            migrationBuilder.CreateIndex(
                name: "IX_FolderDatas_FoldersDataID",
                table: "FolderDatas",
                column: "FoldersDataID");

            migrationBuilder.CreateIndex(
                name: "IX_PagesDatas_FoldersDataID",
                table: "PagesDatas",
                column: "FoldersDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistories");

            migrationBuilder.DropTable(
                name: "PagesDatas");

            migrationBuilder.DropTable(
                name: "FolderDatas");
        }
    }
}
