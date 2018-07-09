using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao : ExcecaoDeNegocio
    {
        public PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao() : base("Pedidos para empresas devem possuir tanto Departamento quanto Responsável.")
        {
        }
    }
}
