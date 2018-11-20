
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 11/20/2018 12:08:25
-- Generated from EDMX file: D:\Visual Studio 2015\BlockChainAPI\BlocjChainApi\BlockChainAPI\APIPersist\ModelBCDB.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Registro'
CREATE TABLE [Registro] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Direccion] nvarchar(250)  NULL,
    [Cuenta] nvarchar(14)  NOT NULL,
    [Documento] nvarchar(14)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Registro'
ALTER TABLE [Registro]
ADD CONSTRAINT [PK_Registro]
    PRIMARY KEY ([Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------