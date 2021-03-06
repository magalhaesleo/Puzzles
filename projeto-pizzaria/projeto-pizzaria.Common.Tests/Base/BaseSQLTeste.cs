﻿using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Base
{
    public class BaseSQLTeste : DropCreateDatabaseAlways<PizzariaContexto>
    {
        protected override void Seed(PizzariaContexto pizzariaContexto)
        {
            Endereco endereco = ObjectMother.ObterEnderecoValido();
            CPF cpf = ObjectMother.ObterCPFValido();
            Cliente cliente = ObjectMother.ObterClienteValido(endereco, cpf);
            Bebida bebida = new Bebida();
            bebida.Descricao = "Agua";
            bebida.Valor = 1;

            pizzariaContexto.Clientes.Add(cliente);
            pizzariaContexto.ProdutosGenericos.Add(bebida);

            AdicionarSabores(pizzariaContexto);

            AdicionarBordas(pizzariaContexto);

            base.Seed(pizzariaContexto);
        }

        private void AdicionarSabores(PizzariaContexto pizzariaContexto)
        {
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborValido_Calabresa());
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborValidoMaisCaro_Coracao());
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborSomente_Pizza());
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborSomente_Calzone());

            pizzariaContexto.SaveChanges();
        }

        private void AdicionarBordas(PizzariaContexto pizzariaContexto)
        {
            pizzariaContexto.Adicionais.Add(ObjectMother.ObterAdicional_BordaCatupiry());
            pizzariaContexto.Adicionais.Add(ObjectMother.ObterAdicional_BordaCheddar());

            pizzariaContexto.SaveChanges();
        }
    }
}
