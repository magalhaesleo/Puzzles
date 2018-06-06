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

        public const string _sqlBuscarPorId = @"SELECT
                                                TBEMITENTE.ID[IDEMITENTE],
                                                TBEMITENTE.NOMEFANTASIA[NOME_FANTASIA],
                                                TBEMITENTE.RAZAOSOCIAL[RAZAO_SOCIAL],
                                                TBEMITENTE.CNPJ[CNPJ_EMITENTE],
                                                TBEMITENTE.INSCRICAOESTADUAL[INSCRICAO_ESTADUAL],
                                                TBEMITENTE.INSCRICAOMUNICIPAL[INSCRICAO_MUNICIPAL],
                                                TBEMITENTE.ENDERECOID[ENDERECO_ID],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBEMITENTE
                                                JOIN TBENDERECO ON TBEMITENTE.ENDERECOID = TBENDERECO.ID
                                                WHERE TBEMITENTE.ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBEMITENTE
                                              WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT
                                                TBEMITENTE.ID[IDEMITENTE],
                                                TBEMITENTE.NOMEFANTASIA[NOME_FANTASIA],
                                                TBEMITENTE.RAZAOSOCIAL[RAZAO_SOCIAL],
                                                TBEMITENTE.CNPJ[CNPJ_EMITENTE],
                                                TBEMITENTE.INSCRICAOESTADUAL[INSCRICAO_ESTADUAL],
                                                TBEMITENTE.INSCRICAOMUNICIPAL[INSCRICAO_MUNICIPAL],
                                                TBEMITENTE.ENDERECOID[ENDERECO_ID],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBEMITENTE
                                                JOIN TBENDERECO ON TBEMITENTE.ENDERECOID = TBENDERECO.ID";

        #endregion Scripts SQL
        public Emitente Adicionar(Emitente emitente)
        {
            emitente.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioEmitente(emitente));

            return emitente;
        }

        public Emitente Atualizar(Emitente emitente)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioEmitente(emitente));
            return emitente;
        }

        public Emitente BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoEmitente, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Emitente> BuscarTodos()
        {
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoEmitente);
        }

        public void Excluir(Emitente emitente)
        {
            Db.Excluir(_sqlExcluir, new Dictionary<string, object> { { "ID", emitente.Id } });
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

        private static Emitente FormaObjetoEmitente(IDataReader reader)
        {
            Emitente emitente = new Emitente();

            emitente.Id = Convert.ToInt64(reader["IDEMITENTE"]);
            emitente.NomeFantasia = Convert.ToString(reader["NOME_FANTASIA"]);
            emitente.RazaoSocial = Convert.ToString(reader["RAZAO_SOCIAL"]);
            emitente.CNPJ = new CNPJ { NumeroComPontuacao = Convert.ToString(reader["CNPJ_EMITENTE"]) };
            emitente.InscricaoEstadual = Convert.ToString(reader["INSCRICAO_ESTADUAL"]);
            emitente.InscricaoMunicipal = Convert.ToString(reader["INSCRICAO_MUNICIPAL"]);
            emitente.Endereco = new Endereco
            {   
                Id = Convert.ToInt64(reader["IDENDERECO"]),
                Logradouro = Convert.ToString(reader["LOGRADOURO_ENDERECO"]),
                Numero = Convert.ToInt32(reader["NUMERO_ENDERECO"]),
                Bairro = Convert.ToString(reader["BAIRRO_ENDERECO"]),
                Municipio = Convert.ToString(reader["MUNICIPIO_ENDERECO"]),
                Estado = Convert.ToString(reader["ESTADO_ENDERECO"]),
                Pais = Convert.ToString(reader["PAIS_ENDERECO"])
            };

            return emitente;
        }
        #endregion
    }
}
