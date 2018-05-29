CREATE TABLE [dbo].[TBENDERECO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Logradouro] NCHAR(80) NOT NULL, 
    [Numero] INT NOT NULL, 
    [Bairro] NCHAR(80) NOT NULL, 
    [Municipio] VARCHAR(80) NOT NULL, 
    [Estado] VARCHAR(80) NOT NULL, 
    [Pais] VARCHAR(80) NOT NULL
)
