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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCorporacao', N'cnpjCorporacao', N'descricaoCorporacao', N'emailCorporacao', N'idCorporacaoEndereco', N'nomeCorporacao', N'numeroCorporacao', N'tipoCorporacao') AND [object_id] = OBJECT_ID(N'[TB_CORPORACAO]'))
    SET IDENTITY_INSERT [TB_CORPORACAO] ON;
INSERT INTO [TB_CORPORACAO] ([idCorporacao], [cnpjCorporacao], [descricaoCorporacao], [emailCorporacao], [idCorporacaoEndereco], [nomeCorporacao], [numeroCorporacao], [tipoCorporacao])
VALUES (1, N'12.345.678/0001-99', N'Exemplo de corporação', N'contato@exemplo.com', 1, N'Corporação Exemplo', N'12345678', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCorporacao', N'cnpjCorporacao', N'descricaoCorporacao', N'emailCorporacao', N'idCorporacaoEndereco', N'nomeCorporacao', N'numeroCorporacao', N'tipoCorporacao') AND [object_id] = OBJECT_ID(N'[TB_CORPORACAO]'))
    SET IDENTITY_INSERT [TB_CORPORACAO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idEgresso', N'cpfEgresso', N'email', N'nomeEgresso', N'numeroEgresso', N'tipoPessoaEgresso') AND [object_id] = OBJECT_ID(N'[TB_EGRESSO]'))
    SET IDENTITY_INSERT [TB_EGRESSO] ON;
INSERT INTO [TB_EGRESSO] ([idEgresso], [cpfEgresso], [email], [nomeEgresso], [numeroEgresso], [tipoPessoaEgresso])
VALUES (1, N'222', N'ops.gmail', N'Pedro', N'8922', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idEgresso', N'cpfEgresso', N'email', N'nomeEgresso', N'numeroEgresso', N'tipoPessoaEgresso') AND [object_id] = OBJECT_ID(N'[TB_EGRESSO]'))
    SET IDENTITY_INSERT [TB_EGRESSO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240907205244_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

