USE [PizzariaBD_Puzzles]
GO
INSERT INTO TBAdicional
			(Descricao, ValorPequena, ValorMedia, ValorGrande)
		VALUES
			('Borda de Catupiry', 1.25, 1.75, 2.5),
			('Borda de Cheddar', 1, 1.5, 2)
GO
INSERT INTO TBEndereco
           (CEP, Cidade, Bairro, Rua, Numero, Complemento)
     VALUES
           ('88503-590', 'Lages', 'Centro', 'Rua', 1, 'Casa')
GO
INSERT INTO TBCliente
           (Nome, Telefone, DataNascimento, TipoDocumento, NumeroDocumento, Endereco_Id)
     VALUES
           ('Cliente', '999999999', '2000-01-01', null, null, 1)
GO
INSERT INTO TBProdutoGenerico
           (Descricao, Valor)
     VALUES
           ('Água 250mL',2),
		   ('Coca-cola 350mL',3),
		   ('Coca-cola 2L', 10)
GO
INSERT INTO TBSabor
           (Descricao, ValorPequena, ValorMedia, ValorGrande, ValorCalzone)
     VALUES
           ('Quatro Queijos',20,30,40,35),
		   ('Calabresa',25,35,45,40),
		   ('Bacon',30,40,50,45)