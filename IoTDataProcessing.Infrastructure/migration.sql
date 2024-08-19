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

CREATE TABLE [DeviceData] (
    [Id] uniqueidentifier NOT NULL,
    [DeviceId] nvarchar(50) NOT NULL,
    [Timestamp] datetime2 NOT NULL,
    [Temperature] float NOT NULL,
    [Humidity] float NOT NULL,
    CONSTRAINT [PK_DeviceData] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240818224132_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

