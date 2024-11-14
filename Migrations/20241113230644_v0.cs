using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AutorNome = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    AutorDataNascimento = table.Column<DateOnly>(type: "date", nullable: true, defaultValue: new DateOnly(2024, 11, 13)),
                    AutorEmail = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    EditoraID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EditoraNome = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    EditoraLogradouro = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    EditoraNumero = table.Column<int>(type: "integer", nullable: true),
                    EditoraComplemento = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    EditoraCidade = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    EditoraUF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    EditoraPais = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    EditoraCEP = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    EditoraTelefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.EditoraID);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivroTituloOriginal = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    LivroTituloNacional = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    LivroPaginas = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LivroISBN = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    LivroAnoPublicacao = table.Column<int>(type: "integer", nullable: false),
                    LivroCapa = table.Column<byte[]>(type: "bytea", nullable: false),
                    EditoraID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroID);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraID",
                        column: x => x.EditoraID,
                        principalTable: "Editoras",
                        principalColumn: "EditoraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresLivros",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "integer", nullable: false),
                    AutorID = table.Column<int>(type: "integer", nullable: false),
                    OrdemAutoria = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresLivros", x => new { x.AutorID, x.LivroID });
                    table.ForeignKey(
                        name: "FK_AutoresLivros_Autores_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autores",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoresLivros_Livros_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livros",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperacoesCompraVenda",
                columns: table => new
                {
                    OperacaoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperacaoQuantidade = table.Column<short>(type: "smallint", nullable: false),
                    OperacaoData = table.Column<DateOnly>(type: "date", nullable: false),
                    LivroID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacoesCompraVenda", x => x.OperacaoID);
                    table.ForeignKey(
                        name: "FK_OperacoesCompraVenda_Livros_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livros",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_AutorNome",
                table: "Autores",
                column: "AutorNome");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresLivros_LivroID",
                table: "AutoresLivros",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_Editoras_EditoraNome",
                table: "Editoras",
                column: "EditoraNome");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraID",
                table: "Livros",
                column: "EditoraID");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LivroTituloNacional",
                table: "Livros",
                column: "LivroTituloNacional");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LivroTituloOriginal",
                table: "Livros",
                column: "LivroTituloOriginal");

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesCompraVenda_LivroID",
                table: "OperacoesCompraVenda",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesCompraVenda_OperacaoData",
                table: "OperacoesCompraVenda",
                column: "OperacaoData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoresLivros");

            migrationBuilder.DropTable(
                name: "OperacoesCompraVenda");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
