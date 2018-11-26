
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2018 15:00:14
-- Generated from EDMX file: D:\Visual Studio 2015\BlockChainAPI\BlocjChainApi\BlockChainAPI\BlockChainFront\BlockChainModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlockChainTX];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cuentas'
CREATE TABLE [dbo].[Cuentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(300)  NOT NULL,
    [Cuenta] nvarchar(10)  NOT NULL,
    [CuentaBC] nvarchar(max)  NOT NULL,
    [NumeroDoc] int  NOT NULL
);
GO

-- Creating table 'Transacciones'
CREATE TABLE [dbo].[Transacciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdTxBC] nvarchar(max)  NOT NULL,
    [Monto] nvarchar(max)  NOT NULL,
    [CuentasId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [PK_Cuentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transacciones'
ALTER TABLE [dbo].[Transacciones]
ADD CONSTRAINT [PK_Transacciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CuentasId] in table 'Transacciones'
ALTER TABLE [dbo].[Transacciones]
ADD CONSTRAINT [FK_CuentasTransacciones]
    FOREIGN KEY ([CuentasId])
    REFERENCES [dbo].[Cuentas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentasTransacciones'
CREATE INDEX [IX_FK_CuentasTransacciones]
ON [dbo].[Transacciones]
    ([CuentasId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------