using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContaPagar.Infra.Data.Migrations
{
    public partial class CreateDatabaseContaPagar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasPagar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ValorOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeDiasEmAtraso = table.Column<int>(type: "int", nullable: false),
                    ValorCorrigido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegrasContaPagarJurosMulta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRegra = table.Column<byte>(type: "tinyint", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JurosAoDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasContaPagarJurosMulta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasPagar");

            migrationBuilder.DropTable(
                name: "RegrasContaPagarJurosMulta");
        }
    }
}
