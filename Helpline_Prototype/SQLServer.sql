CREATE DATABASE HelpDeskDB;
GO

USE HelpDeskDB;

CREATE TABLE Usuarios (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Senha NVARCHAR(100),
    DataCriacao DATETIME
);

CREATE TABLE Chamados (
    Id INT IDENTITY PRIMARY KEY,
    Titulo NVARCHAR(200),
    Descricao NVARCHAR(MAX),
    DataAbertura DATETIME,
    DataFechamento DATETIME NULL,
    Status NVARCHAR(50),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id)
);

CREATE TABLE Interacoes (
    Id INT IDENTITY PRIMARY KEY,
    ChamadoId INT FOREIGN KEY REFERENCES Chamados(Id),
    Texto NVARCHAR(MAX),
    Data DATETIME,
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id)
);