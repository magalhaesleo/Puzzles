using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Interfaces;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades
{
    public class EnderecoRepositorioSql : IEnderecoRepositorio
    {

        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBENDERECO 
                                            (LOGRADOURO, NUMERO, BAIRRO, MUNICIPIO, ESTADO, PAIS) 
                                            VALUES 
                                            ({0}LOGRADOURO,
                                             {0}NUMERO,
                                             {0}BAIRRO,
                                             {0}MUNICIPIO,
                                             {0}ESTADO,
                                             {0}PAIS
                                            ); SELECT SCOPE_IDENTITY();";

        #endregion Scripts SQL

        public Endereco Adicionar(Endereco endereco)
        {
            if (endereco.Id == 0)
            {
                endereco.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioEndereco(endereco));
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

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioEndereco(Endereco endereco)
        {
            return new Dictionary<string, object>
            {
                { "ID", endereco.Id },
                { "LOGRADOURO", endereco.Logradouro},
                { "NUMERO", endereco.Numero },
                { "BAIRRO", endereco.Bairro },
                { "MUNICIPIO", endereco.Municipio},
                { "ESTADO", endereco.Estado },
                { "PAIS", endereco.Pais},
            };
        }

        private static Func<IDataReader, Endereco> FormaObjetoEndereco = reader =>

            new Endereco
            {
                Id = Convert.ToInt32(reader["Id"]),
                Logradouro = Convert.ToString(reader["LOGRADOURO"]),
                Numero = Convert.ToInt32(reader["NUMERO"]),
                Bairro = Convert.ToString(reader["BAIRRO"]),
                Municipio = Convert.ToString(reader["MUNICIPIO"]),
                Estado = Convert.ToString(reader["ESTADO"]),
                Pais = Convert.ToString(reader["PAIS"])
            };

        #endregion

    }
}
