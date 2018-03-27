﻿CREATE TABLE [dbo].[TBMATERIA]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NOME] VARCHAR(50) NOT NULL, 
    [SERIE] INT NOT NULL, 
    [IDDISCIPLINA] INT NOT NULL, 
    [IDSERIE] INT NOT NULL, 
    CONSTRAINT [FK_TBMATERIA_TO_DISCIPLINA_ID] FOREIGN KEY ([IDDISCIPLINA]) REFERENCES [TBDISCIPLINA]([ID]), 
    CONSTRAINT [FK_TBMATERIA_TO_SERIE_ID] FOREIGN KEY ([IDSERIE]) REFERENCES [TBSERIE]([ID])
)
