using Microsoft.EntityFrameworkCore.Migrations;

namespace AdomanyRaktar.Data.Migrations
{
    public partial class elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adomany = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Kategoria = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Csomegyseg = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Mennyiseg = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adat");
        }
    }
}
