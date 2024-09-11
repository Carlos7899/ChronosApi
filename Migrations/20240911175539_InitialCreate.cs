using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CANDIDATURA",
                columns: table => new
                {
                    idCandidatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEgresso = table.Column<int>(type: "int", nullable: false),
                    idVaga = table.Column<int>(type: "int", nullable: false),
                    dataIncricao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CANDIDATURA", x => x.idCandidatura);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMENTARIOS",
                columns: table => new
                {
                    idComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPublicacao = table.Column<int>(type: "int", nullable: false),
                    idEgresso = table.Column<int>(type: "int", nullable: false),
                    comentarioPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMENTARIOS", x => x.idComentario);
                });

            migrationBuilder.CreateTable(
                name: "TB_CORPORACAO",
                columns: table => new
                {
                    idCorporacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCorporacaoEndereco = table.Column<int>(type: "int", nullable: false),
                    tipoCorporacao = table.Column<int>(type: "int", nullable: false),
                    nomeCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpjCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CORPORACAO", x => x.idCorporacao);
                });

            migrationBuilder.CreateTable(
                name: "TB_CORPORACAO_ENDERECO",
                columns: table => new
                {
                    idCorporacaoEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    numeroCorporacaoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoCorporacaoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CORPORACAO_ENDERECO", x => x.idCorporacaoEndereco);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    idCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    idCorporacaoEndereco = table.Column<int>(type: "int", nullable: false),
                    nomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoCurso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.idCurso);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO_ENDERECO",
                columns: table => new
                {
                    idCursoEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    numeroCursoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoCursoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO_ENDERECO", x => x.idCursoEndereco);
                });

            migrationBuilder.CreateTable(
                name: "TB_EGRESSO",
                columns: table => new
                {
                    idEgresso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoPessoaEgresso = table.Column<int>(type: "int", nullable: false),
                    nomeEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpfEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EGRESSO", x => x.idEgresso);
                });

            migrationBuilder.CreateTable(
                name: "TB_EGRESSO_ENDERECO",
                columns: table => new
                {
                    idEgressoEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    numeroEgressoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoEgressoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EGRESSO_ENDERECO", x => x.idEgressoEndereco);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOGRADOURO",
                columns: table => new
                {
                    idLogradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cepLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoLogradouro = table.Column<int>(type: "int", nullable: false),
                    bairroLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidadeLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ufLogradouro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOGRADOURO", x => x.idLogradouro);
                });

            migrationBuilder.CreateTable(
                name: "TB_PUBLICACAO",
                columns: table => new
                {
                    idPublicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    títuloPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    conteudoPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avaliacaoPublicacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PUBLICACAO", x => x.idPublicacao);
                });

            migrationBuilder.CreateTable(
                name: "TB_VAGA",
                columns: table => new
                {
                    idVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVagaEndereco = table.Column<int>(type: "int", nullable: false),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    tipoVaga = table.Column<int>(type: "int", nullable: false),
                    nomeVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VAGA", x => x.idVaga);
                });

            migrationBuilder.CreateTable(
                name: "TB_VAGA_ENDERECO",
                columns: table => new
                {
                    idVagaEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    numeroVagaEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoVagaEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VAGA_ENDERECO", x => x.idVagaEndereco);
                });

            migrationBuilder.InsertData(
                table: "TB_CANDIDATURA",
                columns: new[] { "idCandidatura", "dataIncricao", "idEgresso", "idVaga" },
                values: new object[] { 1, new DateTime(2024, 9, 11, 14, 55, 38, 846, DateTimeKind.Local).AddTicks(6425), 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_COMENTARIOS",
                columns: new[] { "idComentario", "comentarioPublicacao", "idEgresso", "idPublicacao" },
                values: new object[] { 1, "Minha empresa esta contratando PCD para trabalharem", 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO",
                columns: new[] { "idCorporacao", "cnpjCorporacao", "descricaoCorporacao", "emailCorporacao", "idCorporacaoEndereco", "nomeCorporacao", "numeroCorporacao", "tipoCorporacao" },
                values: new object[] { 1, "12.345.678/0001-99", "Exemplo de corporação", "contato@exemplo.com", 1, "Corporação Exemplo", "12345678", 0 });

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "idCurso", "descricaoCurso", "idCorporacao", "idCorporacaoEndereco", "nomeCurso" },
                values: new object[] { 1, "Curso especializado no aprendizado de hardwares e códigos", 1, 1, "Desenvolvimento de Sistemas" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO",
                columns: new[] { "idEgresso", "cpfEgresso", "email", "nomeEgresso", "numeroEgresso", "tipoPessoaEgresso" },
                values: new object[] { 1, "222", "ops.gmail", "Pedro", "8922", 1 });

            migrationBuilder.InsertData(
                table: "TB_PUBLICACAO",
                columns: new[] { "idPublicacao", "avaliacaoPublicacao", "conteudoPublicacao", "idCorporacao", "títuloPublicacao" },
                values: new object[] { 1, 1, "Conteúdo top", 1, "Teste top" });

            migrationBuilder.InsertData(
                table: "TB_VAGA",
                columns: new[] { "idVaga", "descricaoVaga", "idCorporacao", "idVagaEndereco", "nomeVaga", "tipoVaga" },
                values: new object[] { 1, "Vaga júnior desenvolvedor", 1, 1, "Desenvolvedor Júnior", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CANDIDATURA");

            migrationBuilder.DropTable(
                name: "TB_COMENTARIOS");

            migrationBuilder.DropTable(
                name: "TB_CORPORACAO");

            migrationBuilder.DropTable(
                name: "TB_CORPORACAO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_CURSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_VAGA");

            migrationBuilder.DropTable(
                name: "TB_VAGA_ENDERECO");
        }
    }
}
