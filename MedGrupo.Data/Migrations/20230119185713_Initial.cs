using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedGrupo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Nome_FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nome_LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX__User_Email",
                table: "_User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__User_Login",
                table: "_User",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_User");
        }
    }
}
