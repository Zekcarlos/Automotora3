using Microsoft.EntityFrameworkCore.Migrations;

namespace Automotora3.Data.Migrations
{
    public partial class automotora44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Correo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from = table.Column<string>(nullable: true),
                    to = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correo", x => x.Id);
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                    name: "Correo");
        }
    }
}
