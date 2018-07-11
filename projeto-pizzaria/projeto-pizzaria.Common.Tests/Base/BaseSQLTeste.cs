using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
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

            pizzariaContexto.Clientes.Add(cliente);

            AdicionarSabores(pizzariaContexto);

            base.Seed(pizzariaContexto);
        }

        private void AdicionarSabores(PizzariaContexto pizzariaContexto)
        {
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborValido_Calabresa());
            pizzariaContexto.Sabores.Add(ObjectMother.ObterSaborValidoMaisCaro_Coracao());

            pizzariaContexto.SaveChanges();
        }
    }
}
