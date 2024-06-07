CREATE DATABASE DapperExample;
GO

USE DapperExample;
GO

CREATE TABLE States (
    Id INT PRIMARY KEY IDENTITY,
    StateName NVARCHAR(MAX) NOT NULL
);
GO

USE [DapperExample]
GO

INSERT INTO [dbo].[States]
           ([StateName])
     VALUES
           ('Kerala')
GO

SELECT * FROM States

