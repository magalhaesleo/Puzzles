using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Database;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes
{
    public class EmitenteRepositorioSql : IEmitenteRepositorio
    {
        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBEMITENTE 
                                            (NOMEFANTASIA,RAZAOSOCIAL,CNPJ,INSCRICAOESTADUAL,INSCRICAOMUNICIPAL,ENDERECOID) 
                                            VALUES 
                                            ({0}NOMEFANTASIA,{0}RAZAOSOCIAL,{0}CNPJ,{0}INSCRICAOESTADUAL,{0}INSCRICAOMUNICIPAL,{0}ENDERECOID);SELECT SCOPE_IDENTITY();";

        public const string _sqlAtualizar = @"UPDATE TBEMITENTE SET 
                                            NOMEFANTASIA={0}NOMEFANTASIA,
                                            RAZAOSOCIAL={0}RAZAOSOCIAL,
                                            CNPJ={0}CNPJ,
                                            INSCRICAOESTADUAL={0}INSCRICAOESTADUAL,
                                            INSCRICAOMUNICIPAL={0}INSCRICAOMUNICIPAL,
                                            ENDERECOID={0}ENDERECOID
                                            WHERE ID = {0}ID";

        public const string _sqlBuscarPorId = @"SELECT * FROM TBEMITENTE 
                                              WHERE ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBENDERECO
                                              WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT * FROM TBENDERECO";

        #endregion Scripts SQL
        public Emitente Adicionar(Emitente emitente)
        {
            emitente.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioEmitente(emitente));

            return emitente;
        }

        public Emitente Atualizar(Emitente emitente)
        {
            emitente.Id = Db.Atualizar(_sqlAtualizar, ObterDicionarioEmitente(emitente));
            return emitente;
        }

        public Emitente BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoEmitente, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Emitente> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Emitente emitente)
        {
            throw new NotImplementedException();
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioEmitente(Emitente emitente)
        {
            return new Dictionary<string, object>
            {
                { "ID", emitente.Id },
                { "NOMEFANTASIA", emitente.NomeFantasia},
                { "RAZAOSOCIAL", emitente.RazaoSocial },
                { "CNPJ", emitente.CNPJ.NumeroComPontuacao},
                { "INSCRICAOESTADUAL", emitente.InscricaoEstadual},
                { "INSCRICAOMUNICIPAL", emitente.InscricaoMunicipal},
                { "ENDERECOID", emitente.Endereco.Id}
            };
        }

        private static Func<IDataReader, Emitente> FormaObjetoEmitente = reader =>

            new Emitente
            {
                Id = Convert.ToInt64(reader["Id"]),
                NomeFantasia = Convert.ToString(reader["NOMEFANTASIA"]),
                RazaoSocial = Convert.ToString(reader["RAZAOSOCIAL"]),
                CNPJ = new CNPJ { NumeroComPontuacao = Convert.ToString(reader["CNPJ"]) },
                InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL"]),
                InscricaoMunicipal = Convert.ToString(reader["INSCRICAOMUNICIPAL"]),
                Endereco = new Endereco { Id = Convert.ToInt64(reader["ENDERECOID"]) }
            };

        #endregion
    }
}
