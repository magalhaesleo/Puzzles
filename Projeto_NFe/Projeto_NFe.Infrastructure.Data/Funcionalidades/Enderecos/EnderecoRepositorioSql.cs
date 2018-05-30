using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos
{
    public class EnderecoRepositorioSql : IEnderecoRepositorio
    {

        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBENDERECO 
                                            (LOGRADOURO,NUMERO,BAIRRO,MUNICIPIO,ESTADO,PAIS) 
                                            VALUES 
                                            ({0}LOGRADOURO,{0}NUMERO,{0}BAIRRO,{0}MUNICIPIO,{0}ESTADO,{0}PAIS);SELECT SCOPE_IDENTITY();";

        public const string _sqlAtualizar = @"UPDATE TBENDERECO SET 
                                            LOGRADOURO={0}LOGRADOURO,
                                            PAIS={0}PAIS,
                                            MUNICIPIO={0}MUNICIPIO,
                                            BAIRRO={0}BAIRRO,
                                            ESTADO={0}ESTADO,
                                            NUMERO={0}NUMERO
                                            WHERE ID = {0}ID";

        public const string _sqlBuscarPorId = @"SELECT * FROM TBENDERECO 
                                              WHERE ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBENDERECO
                                              WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT * FROM TBENDERECO";

        #endregion Scripts SQL

        public Endereco Adicionar(Endereco endereco)
        {
            endereco.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioEndereco(endereco));
            return endereco;
        }

        public Endereco Atualizar(Endereco endereco)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioEndereco(endereco));
            return endereco;
        }

        public Endereco BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoEndereco, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Endereco> BuscarTodos()
        {
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoEndereco);
        }

        public void Excluir(Endereco endereco)
        {
            Db.Excluir(_sqlExcluir, new Dictionary<string, object> { { "ID", endereco.Id } });
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
