IF NOT EXISTS (SELECT *
               FROM sys.databases
               WHERE name = 'SampleDb')
    BEGIN
        CREATE DATABASE SampleDb;
    END;
GO

USE SampleDb
GO

IF NOT EXISTS (SELECT *
               FROM sys.sysobjects
               WHERE id = OBJECT_ID(N'[dbo].[EndTable]')
                 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN
        CREATE TABLE EndTable
        (
            EndId   INT IDENTITY
                CONSTRAINT EndTable_pk
                    PRIMARY KEY NONCLUSTERED,
            EndData NVARCHAR(100)
        )
    END
GO

IF NOT EXISTS (SELECT *
               FROM sys.sysobjects
               WHERE id = OBJECT_ID(N'[dbo].[SubTable]')
                 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN
        CREATE TABLE SubTable
        (
            SubId   INT IDENTITY
                CONSTRAINT SubTable_pk
                    PRIMARY KEY NONCLUSTERED,
            SubData NVARCHAR(100),
            EndId   INT
                CONSTRAINT SubTable_EndTalbe_EndId_fk
                    REFERENCES EndTable
        )
    END
GO

IF NOT EXISTS (SELECT *
               FROM sys.sysobjects
               WHERE id = OBJECT_ID(N'[dbo].[DataTreeRoot]')
                 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN
        CREATE TABLE DataTreeRoot
        (
            MainId        INT IDENTITY
                CONSTRAINT DataTreeRoot_pk
                    PRIMARY KEY NONCLUSTERED,
            MainData      NVARCHAR(100),
            AmountField   DECIMAL,
            DateTimeField DATETIME2,
            SubId         INT
                CONSTRAINT DataTreeRoot_SubTable_SubId_fk
                    REFERENCES SubTable
        )
    END
GO

IF NOT EXISTS (SELECT *
               FROM sys.sysobjects
               WHERE id = OBJECT_ID(N'[dbo].[SubListTable]')
                 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN
        CREATE TABLE SubListTable
        (
            SubId   INT IDENTITY
                CONSTRAINT SubListTable_pk
                    PRIMARY KEY NONCLUSTERED,
            SubData NVARCHAR(100),
            MainId  INT
                CONSTRAINT SubListTable_MainTable_MainId_fk
                    REFERENCES DataTreeRoot
        )
    END
GO

IF NOT EXISTS (SELECT *
               FROM sys.sysobjects
               WHERE id = OBJECT_ID(N'[dbo].[EndListTable]')
                 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    BEGIN
        CREATE TABLE EndListTable
        (
            EndId   INT IDENTITY
                CONSTRAINT EndListTable_pk
                    PRIMARY KEY NONCLUSTERED,
            EndData NVARCHAR(100),
            SubId   INT
                CONSTRAINT EndListTable_SubTable_SubId_fk
                    REFERENCES SubListTable
        )
    END
GO
