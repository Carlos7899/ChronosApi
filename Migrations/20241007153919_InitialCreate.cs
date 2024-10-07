using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    tipoEgresso = table.Column<int>(type: "int", nullable: false),
                    nomeEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpfEgresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EGRESSO", x => x.idEgresso);
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

            migrationBuilder.CreateTable(
                name: "TB_EGRESSO_ENDERECO",
                columns: table => new
                {
                    idEgressoEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    idEgresso = table.Column<int>(type: "int", nullable: false),
                    numeroEgressoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoEgressoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EGRESSO_ENDERECO", x => x.idEgressoEndereco);
                    table.ForeignKey(
                        name: "FK_TB_EGRESSO_ENDERECO_TB_EGRESSO_idEgresso",
                        column: x => x.idEgresso,
                        principalTable: "TB_EGRESSO",
                        principalColumn: "idEgresso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_CANDIDATURA",
                columns: new[] { "idCandidatura", "dataIncricao", "idEgresso", "idVaga" },
                values: new object[] { 1, new DateTime(2024, 10, 7, 12, 39, 18, 342, DateTimeKind.Local).AddTicks(9202), 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_COMENTARIOS",
                columns: new[] { "idComentario", "comentarioPublicacao", "idEgresso", "idPublicacao" },
                values: new object[] { 1, "Minha empresa esta contratando PCD para trabalharem", 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO",
                columns: new[] { "idCorporacao", "cnpjCorporacao", "descricaoCorporacao", "emailCorporacao", "idCorporacaoEndereco", "nomeCorporacao", "numeroCorporacao", "tipoCorporacao" },
                values: new object[] { 1, "12.345.678/0001-99", "Exemplo de corporação", "contato@exemplo.com", 1, "Corporação Exemplo", "12345678", 0 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO_ENDERECO",
                columns: new[] { "idCorporacaoEndereco", "complementoCorporacaoEndereco", "idLogradouro", "numeroCorporacaoEndereco" },
                values: new object[] { 1, "", 1, "443" });

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "idCurso", "descricaoCurso", "idCorporacao", "idCorporacaoEndereco", "nomeCurso" },
                values: new object[] { 1, "Curso especializado no aprendizado de hardwares e códigos", 1, 1, "Desenvolvimento de Sistemas" });

            migrationBuilder.InsertData(
                table: "TB_CURSO_ENDERECO",
                columns: new[] { "idCursoEndereco", "complementoCursoEndereco", "idLogradouro", "numeroCursoEndereco" },
                values: new object[] { 1, "", 2, "221" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO",
                columns: new[] { "idEgresso", "DataAcesso", "PasswordHash", "PasswordSalt", "cpfEgresso", "emailEgresso", "nomeEgresso", "numeroEgresso", "tipoEgresso" },
                values: new object[,]
                {
                    { 1, null, new byte[] { 138, 164, 232, 183, 173, 251, 42, 66, 20, 156, 204, 43, 189, 7, 81, 32, 26, 145, 8, 196, 172, 120, 49, 146, 31, 179, 255, 199, 254, 149, 254, 115, 214, 125, 167, 174, 84, 180, 200, 189, 46, 186, 169, 186, 83, 197, 207, 224, 123, 253, 33, 201, 52, 253, 205, 110, 71, 216, 32, 224, 121, 169, 123, 50 }, new byte[] { 7, 166, 247, 30, 197, 121, 172, 53, 227, 51, 98, 82, 6, 31, 212, 72, 40, 64, 99, 174, 161, 69, 44, 14, 83, 11, 152, 59, 234, 127, 233, 105, 236, 146, 119, 219, 22, 56, 183, 80, 114, 121, 62, 115, 195, 108, 123, 102, 137, 174, 7, 255, 236, 198, 106, 205, 56, 229, 169, 23, 89, 173, 188, 69, 208, 195, 158, 176, 248, 22, 67, 112, 39, 234, 214, 54, 198, 25, 8, 49, 16, 124, 157, 42, 133, 45, 133, 142, 159, 80, 67, 84, 75, 14, 195, 211, 115, 120, 211, 17, 115, 43, 103, 132, 64, 3, 75, 191, 186, 72, 233, 225, 161, 11, 249, 121, 112, 187, 197, 230, 25, 214, 13, 206, 94, 63, 107, 150 }, "222", "ops.gmail", "Pedro", "8922", 1 },
                    { 3, new DateTime(2024, 10, 7, 12, 39, 18, 342, DateTimeKind.Local).AddTicks(8456), new byte[] { 138, 164, 232, 183, 173, 251, 42, 66, 20, 156, 204, 43, 189, 7, 81, 32, 26, 145, 8, 196, 172, 120, 49, 146, 31, 179, 255, 199, 254, 149, 254, 115, 214, 125, 167, 174, 84, 180, 200, 189, 46, 186, 169, 186, 83, 197, 207, 224, 123, 253, 33, 201, 52, 253, 205, 110, 71, 216, 32, 224, 121, 169, 123, 50 }, new byte[] { 7, 166, 247, 30, 197, 121, 172, 53, 227, 51, 98, 82, 6, 31, 212, 72, 40, 64, 99, 174, 161, 69, 44, 14, 83, 11, 152, 59, 234, 127, 233, 105, 236, 146, 119, 219, 22, 56, 183, 80, 114, 121, 62, 115, 195, 108, 123, 102, 137, 174, 7, 255, 236, 198, 106, 205, 56, 229, 169, 23, 89, 173, 188, 69, 208, 195, 158, 176, 248, 22, 67, 112, 39, 234, 214, 54, 198, 25, 8, 49, 16, 124, 157, 42, 133, 45, 133, 142, 159, 80, 67, 84, 75, 14, 195, 211, 115, 120, 211, 17, 115, 43, 103, 132, 64, 3, 75, 191, 186, 72, 233, 225, 161, 11, 249, 121, 112, 187, 197, 230, 25, 214, 13, 206, 94, 63, 107, 150 }, "22222222222", "admin@example.com", "Admin", "40028922", 0 }
                });

            migrationBuilder.InsertData(
                table: "TB_LOGRADOURO",
                columns: new[] { "idLogradouro", "bairroLogradouro", "cepLogradouro", "cidadeLogradouro", "tipoLogradouro", "ufLogradouro" },
                values: new object[,]
                {
                    { 1, "Pimentas", "332432", "Guarulhos", 0, "34" },
                    { 2, "Vila Maria", "33244232", "Sao Paulo", 0, "44" },
                    { 3, "Pimentas", "332432", "Guarulhos", 0, "34" },
                    { 4, "Pimentas", "332432", "Guarulhos", 0, "364" }
                });

            migrationBuilder.InsertData(
                table: "TB_PUBLICACAO",
                columns: new[] { "idPublicacao", "avaliacaoPublicacao", "conteudoPublicacao", "idCorporacao", "títuloPublicacao" },
                values: new object[] { 1, 1, "Conteúdo top", 1, "Publicacao" });

            migrationBuilder.InsertData(
                table: "TB_VAGA",
                columns: new[] { "idVaga", "descricaoVaga", "idCorporacao", "idVagaEndereco", "nomeVaga", "tipoVaga" },
                values: new object[] { 1, "Vaga júnior desenvolvedor", 1, 1, "Desenvolvedor Júnior", 1 });

            migrationBuilder.InsertData(
                table: "TB_VAGA_ENDERECO",
                columns: new[] { "idVagaEndereco", "complementoVagaEndereco", "idLogradouro", "numeroVagaEndereco" },
                values: new object[] { 1, "", 3, "899" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO_ENDERECO",
                columns: new[] { "idEgressoEndereco", "complementoEgressoEndereco", "idEgresso", "idLogradouro", "numeroEgressoEndereco" },
                values: new object[] { 1, "", 1, 4, "787" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_EGRESSO_ENDERECO_idEgresso",
                table: "TB_EGRESSO_ENDERECO",
                column: "idEgresso",
                unique: true);
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
                name: "TB_EGRESSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_VAGA");

            migrationBuilder.DropTable(
                name: "TB_VAGA_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO");
        }
    }
}
