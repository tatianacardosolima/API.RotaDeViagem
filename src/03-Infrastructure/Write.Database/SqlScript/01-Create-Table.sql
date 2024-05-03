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

CREATE TABLE [dbo].[Rota] (
    [Id] bigint NOT NULL IDENTITY,
    [Origem] varchar(3) NOT NULL,
    [Destino] varchar(3) NOT NULL,
    [Valor] decimal(8,2) NOT NULL,
    [UniqueId] uniqueidentifier NOT NULL,
    [CreatedBy] varchar(45) NOT NULL,
    [ModifiedBy] varchar(45) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Rota] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240503105852_01-create-table', N'8.0.4');
GO

COMMIT;
GO

