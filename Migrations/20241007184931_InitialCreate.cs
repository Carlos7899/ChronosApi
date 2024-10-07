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
                    tipoCorporacao = table.Column<int>(type: "int", nullable: false),
                    nomeCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpjCorporacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                values: new object[] { 1, new DateTime(2024, 10, 7, 15, 49, 30, 764, DateTimeKind.Local).AddTicks(4152), 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_COMENTARIOS",
                columns: new[] { "idComentario", "comentarioPublicacao", "idEgresso", "idPublicacao" },
                values: new object[] { 1, "Minha empresa esta contratando PCD para trabalharem", 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO",
                columns: new[] { "idCorporacao", "DataAcesso", "PasswordHash", "PasswordSalt", "cnpjCorporacao", "descricaoCorporacao", "emailCorporacao", "nomeCorporacao", "numeroCorporacao", "tipoCorporacao" },
                values: new object[] { 1, new DateTime(2024, 10, 7, 15, 49, 30, 764, DateTimeKind.Local).AddTicks(4093), new byte[] { 3, 166, 0, 70, 85, 111, 22, 48, 239, 173, 25, 132, 98, 142, 210, 183, 201, 201, 88, 236, 30, 67, 156, 206, 201, 115, 138, 1, 102, 111, 135, 244, 219, 50, 184, 250, 213, 168, 10, 150, 153, 188, 185, 247, 253, 9, 198, 192, 216, 93, 114, 127, 52, 238, 84, 5, 98, 170, 128, 31, 74, 112, 90, 61 }, new byte[] { 149, 253, 175, 93, 241, 146, 205, 174, 176, 104, 64, 172, 153, 236, 82, 62, 31, 108, 169, 126, 161, 229, 133, 78, 61, 162, 103, 242, 157, 229, 227, 253, 60, 220, 107, 243, 77, 202, 162, 225, 29, 236, 10, 139, 35, 75, 90, 193, 59, 103, 199, 150, 31, 17, 102, 252, 148, 196, 125, 72, 119, 151, 97, 28, 118, 194, 95, 40, 173, 52, 64, 83, 69, 69, 117, 231, 195, 119, 217, 159, 13, 15, 37, 156, 103, 21, 107, 186, 228, 24, 148, 187, 86, 122, 134, 112, 164, 177, 41, 174, 131, 29, 203, 247, 67, 95, 148, 98, 25, 238, 119, 160, 95, 159, 13, 182, 55, 119, 163, 32, 21, 53, 158, 228, 149, 187, 8, 82 }, "12.345.678/0001-99", "Exemplo de corporação", "contato@exemplo.com", "Corporação Exemplo", "12345678", 0 });

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
                    { 1, new DateTime(2024, 10, 7, 15, 49, 30, 764, DateTimeKind.Local).AddTicks(4042), new byte[] { 3, 166, 0, 70, 85, 111, 22, 48, 239, 173, 25, 132, 98, 142, 210, 183, 201, 201, 88, 236, 30, 67, 156, 206, 201, 115, 138, 1, 102, 111, 135, 244, 219, 50, 184, 250, 213, 168, 10, 150, 153, 188, 185, 247, 253, 9, 198, 192, 216, 93, 114, 127, 52, 238, 84, 5, 98, 170, 128, 31, 74, 112, 90, 61 }, new byte[] { 149, 253, 175, 93, 241, 146, 205, 174, 176, 104, 64, 172, 153, 236, 82, 62, 31, 108, 169, 126, 161, 229, 133, 78, 61, 162, 103, 242, 157, 229, 227, 253, 60, 220, 107, 243, 77, 202, 162, 225, 29, 236, 10, 139, 35, 75, 90, 193, 59, 103, 199, 150, 31, 17, 102, 252, 148, 196, 125, 72, 119, 151, 97, 28, 118, 194, 95, 40, 173, 52, 64, 83, 69, 69, 117, 231, 195, 119, 217, 159, 13, 15, 37, 156, 103, 21, 107, 186, 228, 24, 148, 187, 86, 122, 134, 112, 164, 177, 41, 174, 131, 29, 203, 247, 67, 95, 148, 98, 25, 238, 119, 160, 95, 159, 13, 182, 55, 119, 163, 32, 21, 53, 158, 228, 149, 187, 8, 82 }, "222", "ops.gmail", "Pedro", "8922", 1 },
                    { 3, new DateTime(2024, 10, 7, 15, 49, 30, 764, DateTimeKind.Local).AddTicks(3731), new byte[] { 3, 166, 0, 70, 85, 111, 22, 48, 239, 173, 25, 132, 98, 142, 210, 183, 201, 201, 88, 236, 30, 67, 156, 206, 201, 115, 138, 1, 102, 111, 135, 244, 219, 50, 184, 250, 213, 168, 10, 150, 153, 188, 185, 247, 253, 9, 198, 192, 216, 93, 114, 127, 52, 238, 84, 5, 98, 170, 128, 31, 74, 112, 90, 61 }, new byte[] { 149, 253, 175, 93, 241, 146, 205, 174, 176, 104, 64, 172, 153, 236, 82, 62, 31, 108, 169, 126, 161, 229, 133, 78, 61, 162, 103, 242, 157, 229, 227, 253, 60, 220, 107, 243, 77, 202, 162, 225, 29, 236, 10, 139, 35, 75, 90, 193, 59, 103, 199, 150, 31, 17, 102, 252, 148, 196, 125, 72, 119, 151, 97, 28, 118, 194, 95, 40, 173, 52, 64, 83, 69, 69, 117, 231, 195, 119, 217, 159, 13, 15, 37, 156, 103, 21, 107, 186, 228, 24, 148, 187, 86, 122, 134, 112, 164, 177, 41, 174, 131, 29, 203, 247, 67, 95, 148, 98, 25, 238, 119, 160, 95, 159, 13, 182, 55, 119, 163, 32, 21, 53, 158, 228, 149, 187, 8, 82 }, "22222222222", "admin@example.com", "Admin", "40028922", 0 }
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
