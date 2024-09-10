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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729082657_AddEmpoyeesTable')
BEGIN
    CREATE TABLE [employees] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_employees] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729082657_AddEmpoyeesTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240729082657_AddEmpoyeesTable', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729092502_phoneNumertoEmployees')
BEGIN
    ALTER TABLE [employees] ADD [Phone] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729092502_phoneNumertoEmployees')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240729092502_phoneNumertoEmployees', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729093114_postalcodeEmployees')
BEGIN
    ALTER TABLE [employees] ADD [PostalCode] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240729093114_postalcodeEmployees')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240729093114_postalcodeEmployees', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803070902_AddProjectTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[employees]') AND [c].[name] = N'PostalCode');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [employees] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [employees] DROP COLUMN [PostalCode];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803070902_AddProjectTable')
BEGIN
    CREATE TABLE [Projects] (
        [Id] int NOT NULL IDENTITY,
        [ProjectName] nvarchar(max) NOT NULL,
        [Budget] nvarchar(max) NOT NULL,
        [Hours] float NOT NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803070902_AddProjectTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240803070902_AddProjectTable', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803090302_AddEmployeesProjectsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240803090302_AddEmployeesProjectsTable', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803091151_AddIcollectionProjects')
BEGIN
    CREATE TABLE [EmployeeProjects] (
        [EmployeeID] int NOT NULL,
        [ProjectID] int NOT NULL,
        CONSTRAINT [PK_EmployeeProjects] PRIMARY KEY ([ProjectID], [EmployeeID]),
        CONSTRAINT [FK_EmployeeProjects_Projects_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_EmployeeProjects_employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [employees] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803091151_AddIcollectionProjects')
BEGIN
    CREATE INDEX [IX_EmployeeProjects_EmployeeID] ON [EmployeeProjects] ([EmployeeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803091151_AddIcollectionProjects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240803091151_AddIcollectionProjects', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803091824_AddIcollectionEmployee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240803091824_AddIcollectionEmployee', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803092844_AddSeededEmployeeDataTest')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[employees]'))
        SET IDENTITY_INSERT [employees] ON;
    EXEC(N'INSERT INTO [employees] ([Id], [Email], [FirstName], [LastName], [Phone])
    VALUES (6, N''Anymail@gmail.com'', N''Ahmad'', N''Mohsen'', N''022555554''),
    (7, N''Anymail@gmail.com'', N''Essa'', N''Mohsen'', N''022555554'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[employees]'))
        SET IDENTITY_INSERT [employees] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240803092844_AddSeededEmployeeDataTest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240803092844_AddSeededEmployeeDataTest', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814075422_seedingProjectsData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Budget', N'Hours', N'ProjectName') AND [object_id] = OBJECT_ID(N'[Projects]'))
        SET IDENTITY_INSERT [Projects] ON;
    EXEC(N'INSERT INTO [Projects] ([Id], [Budget], [Hours], [ProjectName])
    VALUES (1, N''8000 JD'', 120.0E0, N''Project A''),
    (2, N''12000 JD'', 180.0E0, N''Project B''),
    (3, N''15000 JD'', 160.0E0, N''Project C'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Budget', N'Hours', N'ProjectName') AND [object_id] = OBJECT_ID(N'[Projects]'))
        SET IDENTITY_INSERT [Projects] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814075422_seedingProjectsData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240814075422_seedingProjectsData', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814080009_seedingProjectsData2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240814080009_seedingProjectsData2', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjects] DROP CONSTRAINT [FK_EmployeeProjects_Projects_ProjectID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjects] DROP CONSTRAINT [FK_EmployeeProjects_employees_EmployeeID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjects] DROP CONSTRAINT [PK_EmployeeProjects];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    EXEC sp_rename N'[EmployeeProjects]', N'EmployeeProjectsDBset';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    EXEC sp_rename N'[EmployeeProjectsDBset].[IX_EmployeeProjects_EmployeeID]', N'IX_EmployeeProjectsDBset_EmployeeID', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjectsDBset] ADD CONSTRAINT [PK_EmployeeProjectsDBset] PRIMARY KEY ([ProjectID], [EmployeeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjectsDBset] ADD CONSTRAINT [FK_EmployeeProjectsDBset_Projects_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    ALTER TABLE [EmployeeProjectsDBset] ADD CONSTRAINT [FK_EmployeeProjectsDBset_employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [employees] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814081721_addedEmployeeDbset')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240814081721_addedEmployeeDbset', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814082354_makeEmployeeProjectsRelations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240814082354_makeEmployeeProjectsRelations', N'7.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814083641_addedSeedDataforEmployeeProjects')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeID', N'ProjectID') AND [object_id] = OBJECT_ID(N'[EmployeeProjectsDBset]'))
        SET IDENTITY_INSERT [EmployeeProjectsDBset] ON;
    EXEC(N'INSERT INTO [EmployeeProjectsDBset] ([EmployeeID], [ProjectID])
    VALUES (6, 1),
    (7, 1),
    (6, 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeID', N'ProjectID') AND [object_id] = OBJECT_ID(N'[EmployeeProjectsDBset]'))
        SET IDENTITY_INSERT [EmployeeProjectsDBset] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240814083641_addedSeedDataforEmployeeProjects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240814083641_addedSeedDataforEmployeeProjects', N'7.0.20');
END;
GO

COMMIT;
GO

