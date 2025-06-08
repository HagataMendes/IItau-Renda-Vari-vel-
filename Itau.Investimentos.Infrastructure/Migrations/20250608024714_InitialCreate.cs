using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itau.Investimentos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    AtiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AtiCodigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AtiNome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.AtiId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuNome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuPercentualCorretagem = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cotacoes",
                columns: table => new
                {
                    CotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CotAtiId = table.Column<int>(type: "int", nullable: false),
                    CotPrecoUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CotDataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtivoAtiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacoes", x => x.CotId);
                    table.ForeignKey(
                        name: "FK_Cotacoes_Ativos_AtivoAtiId",
                        column: x => x.AtivoAtiId,
                        principalTable: "Ativos",
                        principalColumn: "AtiId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    OprId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OprUsuId = table.Column<int>(type: "int", nullable: false),
                    OprAtiId = table.Column<int>(type: "int", nullable: false),
                    OprQuantidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OprPrecoUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OprTipoOperacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OprCorretagem = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OprDataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioUsuId = table.Column<int>(type: "int", nullable: true),
                    AtivoAtiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.OprId);
                    table.ForeignKey(
                        name: "FK_Operacoes_Ativos_AtivoAtiId",
                        column: x => x.AtivoAtiId,
                        principalTable: "Ativos",
                        principalColumn: "AtiId");
                    table.ForeignKey(
                        name: "FK_Operacoes_Usuarios_UsuarioUsuId",
                        column: x => x.UsuarioUsuId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posicoes",
                columns: table => new
                {
                    PosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PosUsuId = table.Column<int>(type: "int", nullable: false),
                    PosAtiId = table.Column<int>(type: "int", nullable: false),
                    PosQuantidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PosPrecoMedio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PosDataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioUsuId = table.Column<int>(type: "int", nullable: true),
                    AtivoAtiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicoes", x => x.PosId);
                    table.ForeignKey(
                        name: "FK_Posicoes_Ativos_AtivoAtiId",
                        column: x => x.AtivoAtiId,
                        principalTable: "Ativos",
                        principalColumn: "AtiId");
                    table.ForeignKey(
                        name: "FK_Posicoes_Usuarios_UsuarioUsuId",
                        column: x => x.UsuarioUsuId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_AtivoAtiId",
                table: "Cotacoes",
                column: "AtivoAtiId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_AtivoAtiId",
                table: "Operacoes",
                column: "AtivoAtiId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_UsuarioUsuId",
                table: "Operacoes",
                column: "UsuarioUsuId");

            migrationBuilder.CreateIndex(
                name: "IX_Posicoes_AtivoAtiId",
                table: "Posicoes",
                column: "AtivoAtiId");

            migrationBuilder.CreateIndex(
                name: "IX_Posicoes_UsuarioUsuId",
                table: "Posicoes",
                column: "UsuarioUsuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacoes");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "Posicoes");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
