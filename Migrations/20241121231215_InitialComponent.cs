using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChronosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialComponent : Migration
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
                    fotoPerfilCorporacao = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CORPORACAO", x => x.idCorporacao);
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
                    fotoPerfilEgresso = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    avaliacaoPublicacao = table.Column<int>(type: "int", nullable: false),
                    dataCriacaoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagemPublicacao = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    numeroVisualizacoes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PUBLICACAO", x => x.idPublicacao);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    idCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    nomeCurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricaoCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargaHorariaCurso = table.Column<int>(type: "int", nullable: false),
                    dataInicioCurso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataFimCurso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    limiteVagas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.idCurso);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TB_CORPORACAO_idCorporacao",
                        column: x => x.idCorporacao,
                        principalTable: "TB_CORPORACAO",
                        principalColumn: "idCorporacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VAGA",
                columns: table => new
                {
                    idVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
                    nomeVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responsabilidadesVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beneficiosVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salarioVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidadeVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "TB_CURRICULO",
                columns: table => new
                {
                    idCurriculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEgresso = table.Column<int>(type: "int", nullable: false),
                    emailCurriculo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    telefoneCurriculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    habilidadesCurriculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoCurriculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURRICULO", x => x.idCurriculo);
                    table.ForeignKey(
                        name: "FK_TB_CURRICULO_TB_EGRESSO_idEgresso",
                        column: x => x.idEgresso,
                        principalTable: "TB_EGRESSO",
                        principalColumn: "idEgresso",
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
                    comentarioPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacaoModelidPublicacao = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_TB_COMENTARIOS_TB_PUBLICACAO_PublicacaoModelidPublicacao",
                        column: x => x.PublicacaoModelidPublicacao,
                        principalTable: "TB_PUBLICACAO",
                        principalColumn: "idPublicacao");
                    table.ForeignKey(
                        name: "FK_TB_COMENTARIOS_TB_PUBLICACAO_idPublicacao",
                        column: x => x.idPublicacao,
                        principalTable: "TB_PUBLICACAO",
                        principalColumn: "idPublicacao",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_TB_CURSO_ENDERECO_TB_CURSO_idCurso",
                        column: x => x.idCurso,
                        principalTable: "TB_CURSO",
                        principalColumn: "idCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_ENDERECO_TB_LOGRADOURO_idLogradouro",
                        column: x => x.idLogradouro,
                        principalTable: "TB_LOGRADOURO",
                        principalColumn: "idLogradouro",
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
                    idCorporacao = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TB_CANDIDATURA_TB_CORPORACAO_idCorporacao",
                        column: x => x.idCorporacao,
                        principalTable: "TB_CORPORACAO",
                        principalColumn: "idCorporacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CANDIDATURA_TB_EGRESSO_idEgresso",
                        column: x => x.idEgresso,
                        principalTable: "TB_EGRESSO",
                        principalColumn: "idEgresso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CANDIDATURA_TB_VAGA_idVaga",
                        column: x => x.idVaga,
                        principalTable: "TB_VAGA",
                        principalColumn: "idVaga",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "TB_EXPERIENCIA",
                columns: table => new
                {
                    idExperiencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCurriculo = table.Column<int>(type: "int", nullable: false),
                    cargoExperiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empresaExperiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataInicioExperiencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataFimExperiencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurriculoidCurriculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXPERIENCIA", x => x.idExperiencia);
                    table.ForeignKey(
                        name: "FK_TB_EXPERIENCIA_TB_CURRICULO_CurriculoidCurriculo",
                        column: x => x.CurriculoidCurriculo,
                        principalTable: "TB_CURRICULO",
                        principalColumn: "idCurriculo");
                    table.ForeignKey(
                        name: "FK_TB_EXPERIENCIA_TB_CURRICULO_idCurriculo",
                        column: x => x.idCurriculo,
                        principalTable: "TB_CURRICULO",
                        principalColumn: "idCurriculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORMACAO",
                columns: table => new
                {
                    idFormacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCurriculo = table.Column<int>(type: "int", nullable: false),
                    cursoFormacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instituicaoFormacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataConclusaoFormacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurriculoidCurriculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORMACAO", x => x.idFormacao);
                    table.ForeignKey(
                        name: "FK_TB_FORMACAO_TB_CURRICULO_CurriculoidCurriculo",
                        column: x => x.CurriculoidCurriculo,
                        principalTable: "TB_CURRICULO",
                        principalColumn: "idCurriculo");
                    table.ForeignKey(
                        name: "FK_TB_FORMACAO_TB_CURRICULO_idCurriculo",
                        column: x => x.idCurriculo,
                        principalTable: "TB_CURRICULO",
                        principalColumn: "idCurriculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO",
                columns: new[] { "idCorporacao", "DataAcesso", "PasswordHash", "PasswordSalt", "cnpjCorporacao", "descricaoCorporacao", "emailCorporacao", "fotoPerfilCorporacao", "nomeCorporacao", "numeroCorporacao", "tipoCorporacao" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 20, 12, 15, 482, DateTimeKind.Local).AddTicks(9064), new byte[] { 87, 44, 255, 159, 30, 197, 178, 158, 19, 145, 129, 199, 174, 255, 133, 198, 71, 63, 109, 142, 122, 197, 48, 65, 34, 203, 18, 107, 6, 123, 15, 185, 88, 47, 222, 208, 85, 89, 42, 173, 174, 133, 198, 9, 114, 204, 119, 255, 152, 133, 205, 43, 109, 35, 199, 33, 61, 164, 178, 52, 25, 216, 152, 81 }, new byte[] { 162, 227, 239, 142, 7, 239, 64, 130, 235, 8, 229, 117, 189, 145, 108, 49, 52, 218, 131, 105, 46, 163, 236, 234, 136, 226, 101, 35, 26, 105, 11, 88, 254, 39, 216, 35, 89, 95, 130, 26, 191, 200, 11, 77, 180, 72, 233, 155, 122, 14, 145, 46, 108, 119, 150, 16, 144, 34, 105, 207, 124, 121, 70, 247, 24, 10, 194, 147, 118, 152, 44, 247, 186, 243, 204, 131, 146, 84, 150, 95, 79, 57, 217, 142, 81, 225, 117, 66, 146, 86, 130, 41, 237, 61, 75, 48, 246, 51, 171, 205, 189, 30, 136, 237, 59, 145, 107, 160, 184, 134, 160, 46, 132, 90, 34, 171, 96, 229, 245, 107, 39, 123, 62, 131, 220, 1, 157, 38 }, "12.345.678/0001-99", "Exemplo de corporação", "contato@exemplo.com", null, "Corporação Exemplo", "12345678", 0 });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO",
                columns: new[] { "idEgresso", "DataAcesso", "PasswordHash", "PasswordSalt", "cpfEgresso", "emailEgresso", "fotoPerfilEgresso", "nomeEgresso", "numeroEgresso", "tipoEgresso" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 21, 20, 12, 15, 482, DateTimeKind.Local).AddTicks(9015), new byte[] { 87, 44, 255, 159, 30, 197, 178, 158, 19, 145, 129, 199, 174, 255, 133, 198, 71, 63, 109, 142, 122, 197, 48, 65, 34, 203, 18, 107, 6, 123, 15, 185, 88, 47, 222, 208, 85, 89, 42, 173, 174, 133, 198, 9, 114, 204, 119, 255, 152, 133, 205, 43, 109, 35, 199, 33, 61, 164, 178, 52, 25, 216, 152, 81 }, new byte[] { 162, 227, 239, 142, 7, 239, 64, 130, 235, 8, 229, 117, 189, 145, 108, 49, 52, 218, 131, 105, 46, 163, 236, 234, 136, 226, 101, 35, 26, 105, 11, 88, 254, 39, 216, 35, 89, 95, 130, 26, 191, 200, 11, 77, 180, 72, 233, 155, 122, 14, 145, 46, 108, 119, 150, 16, 144, 34, 105, 207, 124, 121, 70, 247, 24, 10, 194, 147, 118, 152, 44, 247, 186, 243, 204, 131, 146, 84, 150, 95, 79, 57, 217, 142, 81, 225, 117, 66, 146, 86, 130, 41, 237, 61, 75, 48, 246, 51, 171, 205, 189, 30, 136, 237, 59, 145, 107, 160, 184, 134, 160, 46, 132, 90, 34, 171, 96, 229, 245, 107, 39, 123, 62, 131, 220, 1, 157, 38 }, "222", "ops.gmail", null, "Pedro", "8922", 1 },
                    { 3, new DateTime(2024, 11, 21, 20, 12, 15, 482, DateTimeKind.Local).AddTicks(8759), new byte[] { 87, 44, 255, 159, 30, 197, 178, 158, 19, 145, 129, 199, 174, 255, 133, 198, 71, 63, 109, 142, 122, 197, 48, 65, 34, 203, 18, 107, 6, 123, 15, 185, 88, 47, 222, 208, 85, 89, 42, 173, 174, 133, 198, 9, 114, 204, 119, 255, 152, 133, 205, 43, 109, 35, 199, 33, 61, 164, 178, 52, 25, 216, 152, 81 }, new byte[] { 162, 227, 239, 142, 7, 239, 64, 130, 235, 8, 229, 117, 189, 145, 108, 49, 52, 218, 131, 105, 46, 163, 236, 234, 136, 226, 101, 35, 26, 105, 11, 88, 254, 39, 216, 35, 89, 95, 130, 26, 191, 200, 11, 77, 180, 72, 233, 155, 122, 14, 145, 46, 108, 119, 150, 16, 144, 34, 105, 207, 124, 121, 70, 247, 24, 10, 194, 147, 118, 152, 44, 247, 186, 243, 204, 131, 146, 84, 150, 95, 79, 57, 217, 142, 81, 225, 117, 66, 146, 86, 130, 41, 237, 61, 75, 48, 246, 51, 171, 205, 189, 30, 136, 237, 59, 145, 107, 160, 184, 134, 160, 46, 132, 90, 34, 171, 96, 229, 245, 107, 39, 123, 62, 131, 220, 1, 157, 38 }, "22222222222", "admin@example.com", null, "Admin", "40028922", 0 }
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
                columns: new[] { "idPublicacao", "avaliacaoPublicacao", "conteudoPublicacao", "dataCriacaoPublicacao", "idCorporacao", "imagemPublicacao", "numeroVisualizacoes", "títuloPublicacao" },
                values: new object[] { 1, 1, "Conteúdo top", new DateTime(2024, 11, 21, 23, 12, 15, 490, DateTimeKind.Utc).AddTicks(725), 1, null, null, "Publicação" });

            migrationBuilder.InsertData(
                table: "TB_COMENTARIOS",
                columns: new[] { "idComentario", "PublicacaoModelidPublicacao", "comentarioPublicacao", "idEgresso", "idPublicacao" },
                values: new object[] { 1, null, "Minha empresa está contratando auxiliares na cozinha para trabalharem.", 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CORPORACAO_ENDERECO",
                columns: new[] { "idCorporacaoEndereco", "complementoCorporacaoEndereco", "idCorporacao", "idLogradouro", "numeroCorporacaoEndereco" },
                values: new object[] { 1, "bloco", 1, 1, "443" });

            migrationBuilder.InsertData(
                table: "TB_CURRICULO",
                columns: new[] { "idCurriculo", "descricaoCurriculo", "emailCurriculo", "habilidadesCurriculo", "idEgresso", "telefoneCurriculo" },
                values: new object[] { 1, "Desenvolvedor de software com experiência em .NET.", "curriculo1@example.com", "C#, ASP.NET Core, SQL Server", 1, "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "idCurso", "cargaHorariaCurso", "dataFimCurso", "dataInicioCurso", "descricaoCurso", "idCorporacao", "limiteVagas", "nomeCurso" },
                values: new object[] { 1, 40, new DateTime(2025, 2, 21, 20, 12, 15, 489, DateTimeKind.Local).AddTicks(501), new DateTime(2024, 11, 21, 20, 12, 15, 489, DateTimeKind.Local).AddTicks(423), "Curso especializado no aprendizado de hardwares e códigos", 1, null, "Desenvolvimento de Sistemas" });

            migrationBuilder.InsertData(
                table: "TB_EGRESSO_ENDERECO",
                columns: new[] { "idEgressoEndereco", "complementoEgressoEndereco", "idEgresso", "idLogradouro", "numeroEgressoEndereco" },
                values: new object[] { 1, "", 1, 4, "787" });

            migrationBuilder.InsertData(
                table: "TB_VAGA",
                columns: new[] { "idVaga", "DataCriacao", "DataVencimento", "beneficiosVaga", "cidadeVaga", "descricaoVaga", "idCorporacao", "nomeVaga", "responsabilidadesVaga", "salarioVaga" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 23, 12, 15, 490, DateTimeKind.Utc).AddTicks(771), new DateTime(2024, 12, 21, 23, 12, 15, 490, DateTimeKind.Utc).AddTicks(771), "", "", "Vaga júnior desenvolvedor", 1, "Desenvolvedor Júnior", "", "" });

            migrationBuilder.InsertData(
                table: "TB_CANDIDATURA",
                columns: new[] { "idCandidatura", "DataAtualizacao", "Feedback", "Notas", "Status", "dataIncricao", "idCorporacao", "idEgresso", "idVaga" },
                values: new object[] { 1, null, null, null, 3, new DateTime(2024, 11, 21, 20, 12, 15, 482, DateTimeKind.Local).AddTicks(9103), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TB_CURSO_ENDERECO",
                columns: new[] { "idCursoEndereco", "complementoCursoEndereco", "idCurso", "idLogradouro", "numeroCursoEndereco" },
                values: new object[] { 1, "", 1, 2, "221" });

            migrationBuilder.InsertData(
                table: "TB_EXPERIENCIA",
                columns: new[] { "idExperiencia", "CurriculoidCurriculo", "cargoExperiencia", "dataFimExperiencia", "dataInicioExperiencia", "descricao", "empresaExperiencia", "idCurriculo" },
                values: new object[] { 1, null, "Desenvolvedor Júnior", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolvimento de aplicações WEB.", "Empresa XYZ", 1 });

            migrationBuilder.InsertData(
                table: "TB_FORMACAO",
                columns: new[] { "idFormacao", "CurriculoidCurriculo", "cursoFormacao", "dataConclusaoFormacao", "idCurriculo", "instituicaoFormacao" },
                values: new object[] { 1, null, "Análise e Desenvolvimento de Sistemas", new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Universidade ABC" });

            migrationBuilder.InsertData(
                table: "TB_VAGA_ENDERECO",
                columns: new[] { "idVagaEndereco", "complementoVagaEndereco", "idLogradouro", "idVaga", "numeroVagaEndereco" },
                values: new object[] { 1, "", 3, 1, "899" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CANDIDATURA_idCorporacao",
                table: "TB_CANDIDATURA",
                column: "idCorporacao");

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
                name: "IX_TB_COMENTARIOS_PublicacaoModelidPublicacao",
                table: "TB_COMENTARIOS",
                column: "PublicacaoModelidPublicacao");

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
                name: "IX_TB_CURRICULO_idEgresso",
                table: "TB_CURRICULO",
                column: "idEgresso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_idCorporacao",
                table: "TB_CURSO",
                column: "idCorporacao");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_ENDERECO_idCurso",
                table: "TB_CURSO_ENDERECO",
                column: "idCurso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_ENDERECO_idLogradouro",
                table: "TB_CURSO_ENDERECO",
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
                name: "IX_TB_EXPERIENCIA_CurriculoidCurriculo",
                table: "TB_EXPERIENCIA",
                column: "CurriculoidCurriculo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EXPERIENCIA_idCurriculo",
                table: "TB_EXPERIENCIA",
                column: "idCurriculo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORMACAO_CurriculoidCurriculo",
                table: "TB_FORMACAO",
                column: "CurriculoidCurriculo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORMACAO_idCurriculo",
                table: "TB_FORMACAO",
                column: "idCurriculo");

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
                name: "TB_CURSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_EXPERIENCIA");

            migrationBuilder.DropTable(
                name: "TB_FORMACAO");

            migrationBuilder.DropTable(
                name: "TB_VAGA_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_CURRICULO");

            migrationBuilder.DropTable(
                name: "TB_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "TB_VAGA");

            migrationBuilder.DropTable(
                name: "TB_EGRESSO");

            migrationBuilder.DropTable(
                name: "TB_CORPORACAO");
        }
    }
}
