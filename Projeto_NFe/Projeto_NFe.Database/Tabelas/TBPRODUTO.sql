﻿CREATE TABLE [dbo].[TBPRODUTO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Codigo] VARCHAR(50) NOT NULL, 
    [Descricao] VARCHAR(100) NOT NULL, 
    [Valor] FLOAT NOT NULL
)