using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBroker.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 350, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "Datetime", nullable: false),
                    TipoPessoa = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    CpfCnpj = table.Column<string>(type: "string", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoAcao",
                columns: table => new
                {
                    IdCotacaoAcao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoAcao = table.Column<string>(maxLength: 10, nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    ValorCotacao = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoAcao", x => x.IdCotacaoAcao);
                });

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    IdOrdem = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoOrdem = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    DataOrdem = table.Column<DateTime>(type: "Datetime", nullable: false),
                    CodigoAcao = table.Column<string>(type: "string", nullable: false),
                    QuantidadeAcoes = table.Column<int>(type: "int", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "Datetime", nullable: true),
                    ValorOrdem = table.Column<decimal>(type: "decimal", nullable: false),
                    TaxaCorretagem = table.Column<decimal>(type: "decimal", nullable: false),
                    IR = table.Column<decimal>(type: "decimal", nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.IdOrdem);
                    table.ForeignKey(
                        name: "FK_Ordem_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_IdCliente",
                table: "Ordem",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoAcao");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
