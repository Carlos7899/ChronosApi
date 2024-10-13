using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChronosApi.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    idCurso = table.Column<int>(type: "int", nullable: false),
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
                    emailEgresso = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    tipoVaga = table.Column<int>(type: "int", nullable: false),
                    nomeVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VAGA", x => x.idVaga);
                    table.ForeignKey(
                        name: "FK_TB_VAGA_TB_CORPORACAO_idCorporacao",
                        column: x => x.idCorporacao,
                        principalTable: "TB_CORPORACAO",
                        principalColumn: "idCorporacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CORPORACAO_ENDERECO",
                columns: table => new
                {
                    idCorporacaoEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    numeroCorporacaoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoCorporacaoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CORPORACAO_ENDERECO", x => x.idCorporacaoEndereco);
                    table.ForeignKey(
                        name: "FK_TB_CORPORACAO_ENDERECO_TB_CORPORACAO_idCorporacao",
                        column: x => x.idCorporacao,
                        principalTable: "TB_CORPORACAO",
                        principalColumn: "idCorporacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CORPORACAO_ENDERECO_TB_LOGRADOURO_idLogradouro",
                        column: x => x.idLogradouro,
                        principalTable: "TB_LOGRADOURO",
                        principalColumn: "idLogradouro",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_TB_EGRESSO_ENDERECO_TB_LOGRADOURO_idLogradouro",
                        column: x => x.idLogradouro,
                        principalTable: "TB_LOGRADOURO",
                        principalColumn: "idLogradouro",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_TB_COMENTARIOS_TB_EGRESSO_idEgresso",
                        column: x => x.idEgresso,
                        principalTable: "TB_EGRESSO",
                        principalColumn: "idEgresso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_COMENTARIOS_TB_PUBLICACAO_idPublicacao",
                        column: x => x.idPublicacao,
                        principalTable: "TB_PUBLICACAO",
                        principalColumn: "idPublicacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CANDIDATURA",
                columns: table => new
                {
                    idCandidatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEgresso = table.Column<int>(type: "int", nullable: false),
                    idVaga = table.Column<int>(type: "int", nullable: false),
                    dataIncricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CANDIDATURA", x => x.idCandidatura);
                    table.ForeignKey(
                        name: "FK_TB_CANDIDATURA_TB_EGRESSO_idEgresso",
                        column: x => x.idEgresso,
                        principalTable: "TB_EGRESSO",
                        principalColumn: "idEgresso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CANDIDATURA_TB_VAGA_idVaga",
                        column: x => x.idVaga,
                        principalTable: "TB_VAGA",
                        principalColumn: "idVaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VAGA_ENDERECO",
                columns: table => new
                {
                    idVagaEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogradouro = table.Column<int>(type: "int", nullable: false),
                    idVaga = table.Column<int>(type: "int", nullable: false),
                    numeroVagaEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complementoVagaEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VAGA_ENDERECO", x => x.idVagaEndereco);
                    table.ForeignKey(
                        name: "FK_TB_VAGA_ENDERECO_TB_LOGRADOURO_idLogradouro",
                        column: x => x.idLogradouro,
                        principalTable: "TB_LOGRADOURO",
                        principalColumn: "idLogradouro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VAGA_ENDERECO_TB_VAGA_idVaga",
                        column: x => x.idVaga,
                        principalTable: "TB_VAGA",
                        principalColumn: "idVaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO",
                columns: new[] { "idCorporacao", "DataAcesso", "PasswordHash", "PasswordSalt", "cnpjCorporacao", "descricaoCorporacao", "emailCorporacao", "nomeCorporacao", "numeroCorporacao", "tipoCorporacao" },
                values: new object[] { 1, new DateTime(2024, 10, 13, 17, 24, 45, 431, DateTimeKind.Local).AddTicks(8261), new byte[] { 73, 232, 213, 220, 123, 89, 109, 79, 14, 66, 45, 104, 137, 131, 221, 213, 29, 64, 79, 195, 71, 228, 132, 127, 84, 20, 33, 161, 156, 37, 24, 242, 223, 9, 48, 48, 18, 216, 158, 48, 80, 34, 171, 34, 235, 162, 200, 76, 115, 254, 43, 156, 56, 165, 25, 220, 206, 141, 89, 52, 15, 75, 10, 253 }, new byte[] { 100, 157, 162, 92, 241, 40, 89, 153, 149, 198, 163, 62, 145, 13, 140, 210, 148, 199, 144, 156, 81, 240, 98, 117, 74, 52, 255, 240, 11, 246, 104, 226, 255, 54, 199, 6, 11, 14, 77, 8, 81, 29, 171, 94, 220, 86, 119, 89, 24, 94, 201, 231, 39, 177, 37, 162, 22, 107, 43, 203, 207, 153, 133, 48, 71, 139, 204, 249, 61, 23, 6, 61, 172, 18, 5, 145, 146, 182, 139, 205, 211, 42, 60, 180, 55, 183, 132, 150, 155, 136, 250, 93, 157, 32, 112, 72, 191, 175, 213, 125, 95, 178, 113, 32, 36, 215, 187, 136, 165, 63, 231, 15, 35, 46, 62, 175, 105, 248, 196, 66, 182, 2, 45, 37, 114, 217, 183, 152 }, "12.345.678/0001-99", "Exemplo de corporação", "contato@exemplo.com", "Corporação Exemplo", "12345678", 0 });

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "idCurso", "descricaoCurso", "idCorporacao", "idCorporacaoEndereco", "nomeCurso" },
                values: new object[] { 1, "Curso especializado no aprendizado de hardwares e códigos", 1, 1, "Desenvolvimento de Sistemas" });

            migrationBuilder.InsertData(
                table: "TB_CURSO_ENDERECO",
                columns: new[] { "idCursoEndereco", "complementoCursoEndereco", "idCurso", "idLogradouro", "numeroCursoEndereco" },
                values: new object[] { 1, "", 0, 2, "221" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO",
                columns: new[] { "idEgresso", "DataAcesso", "PasswordHash", "PasswordSalt", "cpfEgresso", "emailEgresso", "nomeEgresso", "numeroEgresso", "tipoEgresso" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 13, 17, 24, 45, 431, DateTimeKind.Local).AddTicks(8225), new byte[] { 73, 232, 213, 220, 123, 89, 109, 79, 14, 66, 45, 104, 137, 131, 221, 213, 29, 64, 79, 195, 71, 228, 132, 127, 84, 20, 33, 161, 156, 37, 24, 242, 223, 9, 48, 48, 18, 216, 158, 48, 80, 34, 171, 34, 235, 162, 200, 76, 115, 254, 43, 156, 56, 165, 25, 220, 206, 141, 89, 52, 15, 75, 10, 253 }, new byte[] { 100, 157, 162, 92, 241, 40, 89, 153, 149, 198, 163, 62, 145, 13, 140, 210, 148, 199, 144, 156, 81, 240, 98, 117, 74, 52, 255, 240, 11, 246, 104, 226, 255, 54, 199, 6, 11, 14, 77, 8, 81, 29, 171, 94, 220, 86, 119, 89, 24, 94, 201, 231, 39, 177, 37, 162, 22, 107, 43, 203, 207, 153, 133, 48, 71, 139, 204, 249, 61, 23, 6, 61, 172, 18, 5, 145, 146, 182, 139, 205, 211, 42, 60, 180, 55, 183, 132, 150, 155, 136, 250, 93, 157, 32, 112, 72, 191, 175, 213, 125, 95, 178, 113, 32, 36, 215, 187, 136, 165, 63, 231, 15, 35, 46, 62, 175, 105, 248, 196, 66, 182, 2, 45, 37, 114, 217, 183, 152 }, "222", "ops.gmail", "Pedro", "8922", 1 },
                    { 3, new DateTime(2024, 10, 13, 17, 24, 45, 431, DateTimeKind.Local).AddTicks(8060), new byte[] { 73, 232, 213, 220, 123, 89, 109, 79, 14, 66, 45, 104, 137, 131, 221, 213, 29, 64, 79, 195, 71, 228, 132, 127, 84, 20, 33, 161, 156, 37, 24, 242, 223, 9, 48, 48, 18, 216, 158, 48, 80, 34, 171, 34, 235, 162, 200, 76, 115, 254, 43, 156, 56, 165, 25, 220, 206, 141, 89, 52, 15, 75, 10, 253 }, new byte[] { 100, 157, 162, 92, 241, 40, 89, 153, 149, 198, 163, 62, 145, 13, 140, 210, 148, 199, 144, 156, 81, 240, 98, 117, 74, 52, 255, 240, 11, 246, 104, 226, 255, 54, 199, 6, 11, 14, 77, 8, 81, 29, 171, 94, 220, 86, 119, 89, 24, 94, 201, 231, 39, 177, 37, 162, 22, 107, 43, 203, 207, 153, 133, 48, 71, 139, 204, 249, 61, 23, 6, 61, 172, 18, 5, 145, 146, 182, 139, 205, 211, 42, 60, 180, 55, 183, 132, 150, 155, 136, 250, 93, 157, 32, 112, 72, 191, 175, 213, 125, 95, 178, 113, 32, 36, 215, 187, 136, 165, 63, 231, 15, 35, 46, 62, 175, 105, 248, 196, 66, 182, 2, 45, 37, 114, 217, 183, 152 }, "22222222222", "admin@example.com", "Admin", "40028922", 0 }
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
                table: "TB_COMENTARIOS",
                columns: new[] { "idComentario", "comentarioPublicacao", "idEgresso", "idPublicacao" },
                values: new object[] { 1, "Minha empresa esta contratando auxiliares na cozinha para trabalharem", 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO_ENDERECO",
                columns: new[] { "idCorporacaoEndereco", "complementoCorporacaoEndereco", "idCorporacao", "idLogradouro", "numeroCorporacaoEndereco" },
                values: new object[] { 1, "bloco", 1, 1, "443" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO_ENDERECO",
                columns: new[] { "idEgressoEndereco", "complementoEgressoEndereco", "idEgresso", "idLogradouro", "numeroEgressoEndereco" },
                values: new object[] { 1, "", 1, 4, "787" });

            migrationBuilder.InsertData(
                table: "TB_VAGA",
                columns: new[] { "idVaga", "DataCriacao", "DataVencimento", "descricaoVaga", "idCorporacao", "nomeVaga", "tipoVaga" },
                values: new object[] { 1, new DateTime(2024, 10, 13, 20, 24, 45, 433, DateTimeKind.Utc).AddTicks(6547), new DateTime(2024, 11, 12, 20, 24, 45, 433, DateTimeKind.Utc).AddTicks(6547), "Vaga júnior desenvolvedor", 1, "Desenvolvedor Júnior", 1 });

            migrationBuilder.InsertData(
                table: "TB_CANDIDATURA",
                columns: new[] { "idCandidatura", "DataAtualizacao", "Feedback", "Notas", "Status", "dataIncricao", "idEgresso", "idVaga" },
                values: new object[] { 1, null, null, null, 3, new DateTime(2024, 10, 13, 17, 24, 45, 431, DateTimeKind.Local).AddTicks(8283), 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_VAGA_ENDERECO",
                columns: new[] { "idVagaEndereco", "complementoVagaEndereco", "idLogradouro", "idVaga", "numeroVagaEndereco" },
                values: new object[] { 1, "", 3, 1, "899" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CANDIDATURA_idEgresso",
                table: "TB_CANDIDATURA",
                column: "idEgresso");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CANDIDATURA_idVaga",
                table: "TB_CANDIDATURA",
                column: "idVaga");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMENTARIOS_idEgresso",
                table: "TB_COMENTARIOS",
                column: "idEgresso");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMENTARIOS_idPublicacao",
                table: "TB_COMENTARIOS",
                column: "idPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CORPORACAO_ENDERECO_idCorporacao",
                table: "TB_CORPORACAO_ENDERECO",
                column: "idCorporacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CORPORACAO_ENDERECO_idLogradouro",
                table: "TB_CORPORACAO_ENDERECO",
                column: "idLogradouro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_EGRESSO_ENDERECO_idEgresso",
                table: "TB_EGRESSO_ENDERECO",
                column: "idEgresso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_EGRESSO_ENDERECO_idLogradouro",
                table: "TB_EGRESSO_ENDERECO",
                column: "idLogradouro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VAGA_idCorporacao",
                table: "TB_VAGA",
                column: "idCorporacao");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VAGA_ENDERECO_idLogradouro",
                table: "TB_VAGA_ENDERECO",
                column: "idLogradouro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VAGA_ENDERECO_idVaga",
                table: "TB_VAGA_ENDERECO",
                column: "idVaga",
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
                name: "TB_CORPORACAO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_CURSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_VAGA_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO");

            migrationBuilder.DropTable(
                name: "TB_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "TB_VAGA");

            migrationBuilder.DropTable(
                name: "TB_CORPORACAO");
        }
    }
}
