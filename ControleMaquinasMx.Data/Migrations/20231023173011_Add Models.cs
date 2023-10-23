using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMaquinasMx_Data.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Criticidade",
                table: "Maquinas",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Maquinas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hostname",
                table: "Maquinas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Inventario",
                table: "Maquinas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ondeso",
                table: "Maquinas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Maquinas",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criticidade",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "Hostname",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "Inventario",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "Ondeso",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Maquinas");
        }
    }
}
