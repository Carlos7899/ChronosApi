IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CANDIDATURA] (
    [idCandidatura] int NOT NULL IDENTITY,
    [idEgresso] int NOT NULL,
    [idVaga] int NOT NULL,
    [dataIncricao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_CANDIDATURA] PRIMARY KEY ([idCandidatura])
);
GO

CREATE TABLE [TB_COMENTARIOS] (
    [idComentario] int NOT NULL IDENTITY,
    [idPublicacao] int NOT NULL,
    [idEgresso] int NOT NULL,
    [comentarioPublicacao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_COMENTARIOS] PRIMARY KEY ([idComentario])
);
GO

CREATE TABLE [TB_CORPORACAO] (
    [idCorporacao] int NOT NULL IDENTITY,
    [idCorporacaoEndereco] int NOT NULL,
    [tipoCorporacao] int NOT NULL,
    [nomeCorporacao] nvarchar(max) NOT NULL,
    [emailCorporacao] nvarchar(max) NOT NULL,
    [numeroCorporacao] nvarchar(max) NOT NULL,
    [descricaoCorporacao] nvarchar(max) NOT NULL,
    [cnpjCorporacao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CORPORACAO] PRIMARY KEY ([idCorporacao])
);
GO

CREATE TABLE [TB_CORPORACAO_ENDERECO] (
    [idCorporacaoEndereco] int NOT NULL IDENTITY,
    [idLogradouro] int NOT NULL,
    [numeroCorporacaoEndereco] nvarchar(max) NOT NULL,
    [complementoCorporacaoEndereco] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CORPORACAO_ENDERECO] PRIMARY KEY ([idCorporacaoEndereco])
);
GO

CREATE TABLE [TB_CURSO] (
    [idCurso] int NOT NULL IDENTITY,
    [idCorporacao] int NOT NULL,
    [idCorporacaoEndereco] int NOT NULL,
    [nomeCurso] nvarchar(max) NOT NULL,
    [descricaoCurso] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CURSO] PRIMARY KEY ([idCurso])
);
GO

CREATE TABLE [TB_CURSO_ENDERECO] (
    [idCursoEndereco] int NOT NULL IDENTITY,
    [idLogradouro] int NOT NULL,
    [numeroCursoEndereco] nvarchar(max) NOT NULL,
    [complementoCursoEndereco] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CURSO_ENDERECO] PRIMARY KEY ([idCursoEndereco])
);
GO

CREATE TABLE [TB_EGRESSO] (
    [idEgresso] int NOT NULL IDENTITY,
    [tipoPessoaEgresso] int NOT NULL,
    [nomeEgresso] nvarchar(max) NOT NULL,
    [email] nvarchar(max) NOT NULL,
    [numeroEgresso] nvarchar(max) NOT NULL,
    [cpfEgresso] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_EGRESSO] PRIMARY KEY ([idEgresso])
);
GO

CREATE TABLE [TB_EGRESSO_ENDERECO] (
    [idEgressoEndereco] int NOT NULL IDENTITY,
    [idLogradouro] int NOT NULL,
    [numeroEgressoEndereco] nvarchar(max) NOT NULL,
    [complementoEgressoEndereco] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_EGRESSO_ENDERECO] PRIMARY KEY ([idEgressoEndereco])
);
GO

CREATE TABLE [TB_LOGRADOURO] (
    [idLogradouro] int NOT NULL IDENTITY,
    [cepLogradouro] nvarchar(max) NOT NULL,
    [tipoLogradouro] int NOT NULL,
    [bairroLogradouro] nvarchar(max) NOT NULL,
    [cidadeLogradouro] nvarchar(max) NOT NULL,
    [ufLogradouro] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_LOGRADOURO] PRIMARY KEY ([idLogradouro])
);
GO

CREATE TABLE [TB_PUBLICACAO] (
    [idPublicacao] int NOT NULL IDENTITY,
    [idCorporacao] int NOT NULL,
    [títuloPublicacao] nvarchar(max) NOT NULL,
    [conteudoPublicacao] nvarchar(max) NOT NULL,
    [avaliacaoPublicacao] int NOT NULL,
    CONSTRAINT [PK_TB_PUBLICACAO] PRIMARY KEY ([idPublicacao])
);
GO

CREATE TABLE [TB_VAGA] (
    [idVaga] int NOT NULL IDENTITY,
    [idVagaEndereco] int NOT NULL,
    [idCorporacao] int NOT NULL,
    [tipoVaga] int NOT NULL,
    [nomeVaga] nvarchar(max) NOT NULL,
    [descricaoVaga] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_VAGA] PRIMARY KEY ([idVaga])
);
GO

CREATE TABLE [TB_VAGA_ENDERECO] (
    [idVagaEndereco] int NOT NULL IDENTITY,
    [idLogradouro] int NOT NULL,
    [numeroVagaEndereco] nvarchar(max) NOT NULL,
    [complementoVagaEndereco] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_VAGA_ENDERECO] PRIMARY KEY ([idVagaEndereco])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCandidatura', N'dataIncricao', N'idEgresso', N'idVaga') AND [object_id] = OBJECT_ID(N'[TB_CANDIDATURA]'))
    SET IDENTITY_INSERT [TB_CANDIDATURA] ON;
INSERT INTO [TB_CANDIDATURA] ([idCandidatura], [dataIncricao], [idEgresso], [idVaga])
VALUES (1, '2024-09-11T14:55:38.8466425-03:00', 1, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCandidatura', N'dataIncricao', N'idEgresso', N'idVaga') AND [object_id] = OBJECT_ID(N'[TB_CANDIDATURA]'))
    SET IDENTITY_INSERT [TB_CANDIDATURA] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idComentario', N'comentarioPublicacao', N'idEgresso', N'idPublicacao') AND [object_id] = OBJECT_ID(N'[TB_COMENTARIOS]'))
    SET IDENTITY_INSERT [TB_COMENTARIOS] ON;
INSERT INTO [TB_COMENTARIOS] ([idComentario], [comentarioPublicacao], [idEgresso], [idPublicacao])
VALUES (1, N'Minha empresa esta contratando PCD para trabalharem', 1, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idComentario', N'comentarioPublicacao', N'idEgresso', N'idPublicacao') AND [object_id] = OBJECT_ID(N'[TB_COMENTARIOS]'))
    SET IDENTITY_INSERT [TB_COMENTARIOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCorporacao', N'cnpjCorporacao', N'descricaoCorporacao', N'emailCorporacao', N'idCorporacaoEndereco', N'nomeCorporacao', N'numeroCorporacao', N'tipoCorporacao') AND [object_id] = OBJECT_ID(N'[TB_CORPORACAO]'))
    SET IDENTITY_INSERT [TB_CORPORACAO] ON;
INSERT INTO [TB_CORPORACAO] ([idCorporacao], [cnpjCorporacao], [descricaoCorporacao], [emailCorporacao], [idCorporacaoEndereco], [nomeCorporacao], [numeroCorporacao], [tipoCorporacao])
VALUES (1, N'12.345.678/0001-99', N'Exemplo de corporação', N'contato@exemplo.com', 1, N'Corporação Exemplo', N'12345678', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCorporacao', N'cnpjCorporacao', N'descricaoCorporacao', N'emailCorporacao', N'idCorporacaoEndereco', N'nomeCorporacao', N'numeroCorporacao', N'tipoCorporacao') AND [object_id] = OBJECT_ID(N'[TB_CORPORACAO]'))
    SET IDENTITY_INSERT [TB_CORPORACAO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCurso', N'descricaoCurso', N'idCorporacao', N'idCorporacaoEndereco', N'nomeCurso') AND [object_id] = OBJECT_ID(N'[TB_CURSO]'))
    SET IDENTITY_INSERT [TB_CURSO] ON;
INSERT INTO [TB_CURSO] ([idCurso], [descricaoCurso], [idCorporacao], [idCorporacaoEndereco], [nomeCurso])
VALUES (1, N'Curso especializado no aprendizado de hardwares e códigos', 1, 1, N'Desenvolvimento de Sistemas');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCurso', N'descricaoCurso', N'idCorporacao', N'idCorporacaoEndereco', N'nomeCurso') AND [object_id] = OBJECT_ID(N'[TB_CURSO]'))
    SET IDENTITY_INSERT [TB_CURSO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idEgresso', N'cpfEgresso', N'email', N'nomeEgresso', N'numeroEgresso', N'tipoPessoaEgresso') AND [object_id] = OBJECT_ID(N'[TB_EGRESSO]'))
    SET IDENTITY_INSERT [TB_EGRESSO] ON;
INSERT INTO [TB_EGRESSO] ([idEgresso], [cpfEgresso], [email], [nomeEgresso], [numeroEgresso], [tipoPessoaEgresso])
VALUES (1, N'222', N'ops.gmail', N'Pedro', N'8922', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idEgresso', N'cpfEgresso', N'email', N'nomeEgresso', N'numeroEgresso', N'tipoPessoaEgresso') AND [object_id] = OBJECT_ID(N'[TB_EGRESSO]'))
    SET IDENTITY_INSERT [TB_EGRESSO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idPublicacao', N'avaliacaoPublicacao', N'conteudoPublicacao', N'idCorporacao', N'títuloPublicacao') AND [object_id] = OBJECT_ID(N'[TB_PUBLICACAO]'))
    SET IDENTITY_INSERT [TB_PUBLICACAO] ON;
INSERT INTO [TB_PUBLICACAO] ([idPublicacao], [avaliacaoPublicacao], [conteudoPublicacao], [idCorporacao], [títuloPublicacao])
VALUES (1, 1, N'Conteúdo top', 1, N'Teste top');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idPublicacao', N'avaliacaoPublicacao', N'conteudoPublicacao', N'idCorporacao', N'títuloPublicacao') AND [object_id] = OBJECT_ID(N'[TB_PUBLICACAO]'))
    SET IDENTITY_INSERT [TB_PUBLICACAO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idVaga', N'descricaoVaga', N'idCorporacao', N'idVagaEndereco', N'nomeVaga', N'tipoVaga') AND [object_id] = OBJECT_ID(N'[TB_VAGA]'))
    SET IDENTITY_INSERT [TB_VAGA] ON;
INSERT INTO [TB_VAGA] ([idVaga], [descricaoVaga], [idCorporacao], [idVagaEndereco], [nomeVaga], [tipoVaga])
VALUES (1, N'Vaga júnior desenvolvedor', 1, 1, N'Desenvolvedor Júnior', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idVaga', N'descricaoVaga', N'idCorporacao', N'idVagaEndereco', N'nomeVaga', N'tipoVaga') AND [object_id] = OBJECT_ID(N'[TB_VAGA]'))
    SET IDENTITY_INSERT [TB_VAGA] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240911175539_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

