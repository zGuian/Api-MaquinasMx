﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMaquinasMx_Data.Migrations
{
    public partial class Relacao1pN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ondeso = table.Column<bool>(type: "bit", nullable: false),
                    Criticidade = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PacotesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeKb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaquinasId = table.Column<int>(type: "int", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacotes_Maquinas_MaquinasId",
                        column: x => x.MaquinasId,
                        principalTable: "Maquinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_MaquinasId",
                table: "Pacotes",
                column: "MaquinasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Maquinas");
        }
    }
}
