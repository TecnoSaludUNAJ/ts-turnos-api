using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class defaultDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dias",
                columns: new[] {"nombre"},
                values: new object[,] {
                    {"Lunes"},
                    {"Martes"},
                    {"Miercoles"},
                    {"Jueves"},
                    {"Viernes"},
                    {"Sabado"},
                    {"Domingo"}
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
