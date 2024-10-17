using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_Luna_Project.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormModels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    FormModelsId = table.Column<int>(type: "int", nullable: false),
                    FieldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => new { x.FormModelsId, x.FieldsId });
                    table.ForeignKey(
                        name: "FK_FormField_Fields_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormField_FormModels_FormModelsId",
                        column: x => x.FormModelsId,
                        principalTable: "FormModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    FormModelsId = table.Column<int>(type: "int", nullable: false),
                    FormModelId = table.Column<int>(type: "int", nullable: false),
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FormFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormFields_FormModels_FormModelId",
                        column: x => x.FormModelId,
                        principalTable: "FormModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "DataType", "Name", "Required" },
                values: new object[,]
                {
                    { 1, "STRING", "Ad", true },
                    { 2, "STRING", "Soyad", true },
                    { 3, "NUMBER", "Yaş", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, null, "1234", "Admin", "Admin" },
                    { 2, null, "1234", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "FormModels",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UserId" },
                values: new object[] { 1, new DateTime(2024, 7, 15, 15, 34, 15, 465, DateTimeKind.Local).AddTicks(3218), "First Form Description", "FormName theFirst", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FieldsId",
                table: "FormField",
                column: "FieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FieldId",
                table: "FormFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_FormModelId",
                table: "FormFields",
                column: "FormModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModels_UserId",
                table: "FormModels",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "FormModels");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
