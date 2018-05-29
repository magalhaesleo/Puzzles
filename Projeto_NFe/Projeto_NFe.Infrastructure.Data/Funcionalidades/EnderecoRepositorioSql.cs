using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Interfaces;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades
{
    public class EnderecoRepositorioSql : IEnderecoRepositorio
    {
        public Endereco Adicionar(Endereco endereco)
        {
            if (endereco.Id == 0)
            {
                endereco.Id = Db.Adicionar(endereco);
                return endereco;
            }
            else
                throw new ExcecaoIdentificadorIndefinido();

        }

        public Endereco Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Endereco BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        #region montar e ler objetos
        //private Dictionary<string, object> RetornaDictionaryDeAlternativa(Alternativa alternativa)
        //{
        //    return new Dictionary<string, object>
        //    {
        //        {"ID", alternativa.Id },
        //        { "ENUNCIADO", alternativa.Enunciado},
        //        { "CORRETA", alternativa.Correta },
        //        { "IDQUESTAO", alternativa.IdQuestao },
        //        { "LETRA", alternativa.Letra},
        //    };
        //}

        //Dictionary<string, object> IAlternativaRepository.RetornaDictionaryDeAlternativa(Alternativa alternativa)
        //{
        //    throw new NotImplementedException();
        //}

        //Func<IDataReader, Alternativa> IAlternativaRepository.FormaObjetoAlternativa(IDataReader reader)
        //{
        //    throw new NotImplementedException();
        //}

        //private static Func<IDataReader, Alternativa> FormaObjetoAlternativa = reader =>

        //    new Alternativa
        //    {
        //        Id = Convert.ToInt32(reader["Id"]),
        //        Enunciado = Convert.ToString(reader["ENUNCIADO"]),
        //        Correta = Convert.ToBoolean(reader["CORRETA"]),
        //        IdQuestao = Convert.ToInt32(reader["IDQUESTAO"]),
        //        Letra = Convert.ToChar(reader["LETRA"])
        //    };

        #endregion

    }
}
