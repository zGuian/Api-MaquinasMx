using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMaquinasMx_Data.Migrations
{
    public partial class AddEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Criticidade",
                table: "Maquinas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Criticidade",
                table: "Maquinas",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
