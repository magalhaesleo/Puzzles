using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Interfaces.Adicionais;
using projeto_pizzaria.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Adicionais
{

    public class AdicionalRepositorioSQL : IAdicionalRepositorio
    {
        PizzariaContexto _pizzariaContexto;

        public AdicionalRepositorioSQL(PizzariaContexto pizzariaContexto)
        {
            _pizzariaContexto = pizzariaContexto;
        }

        public long Adicionar(Adicional adicional)
        {
            throw new NotImplementedException();
        }

        public List<Adicional> BuscarTodos()
        {
            return _pizzariaContexto.Adicionais.ToList();
        }

        public void Editar(Adicional adicional)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Adicional adicional)
        {
            throw new NotImplementedException();
        }
    }
}
