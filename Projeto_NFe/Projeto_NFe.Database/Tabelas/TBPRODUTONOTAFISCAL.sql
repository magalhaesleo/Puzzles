﻿CREATE TABLE [dbo].[TBPRODUTONOTAFISCAL]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProdutoId] INT NOT NULL, 
    [NotaFiscalId] INT NOT NULL, 
    [Quantidade] INT NOT NULL, 
    CONSTRAINT [FK_TBPRODUTONOTAFISCAL_TBPRODUTO] FOREIGN KEY ([ProdutoId]) REFERENCES [TBPRODUTO]([Id]), 
    CONSTRAINT [FK_TBPRODUTONOTAFISCAL_TBNOTAFISCAL] FOREIGN KEY ([NotaFiscalId]) REFERENCES [TBNOTAFISCAL]([Id])
)