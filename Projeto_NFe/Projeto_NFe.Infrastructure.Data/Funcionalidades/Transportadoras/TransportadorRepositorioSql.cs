using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Database;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras
{
    public class TransportadorRepositorioSql : ITransportadorRepositorio
    {
        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBTRANSPORTADOR
                                            (Nome, Documento, TipoDocumento, InscricaoEstadual, ResponsabilidadeFrete, EnderecoId) 
                                            VALUES 
                                            ({0}Nome, {0}Documento, {0}TipoDocumento, {0}InscricaoEstadual, {0}ResponsabilidadeFrete, {0}EnderecoId);
                                            SELECT SCOPE_IDENTITY();";

        public const string _sqlBuscarPorId = @"SELECT 
                                                TBTRANSPORTADOR.ID[ID],
                                                TBTRANSPORTADOR.NOME[NOME],
                                                TBTRANSPORTADOR.DOCUMENTO[DOCUMENTO],
                                                TBTRANSPORTADOR.TIPODOCUMENTO[TIPODOCUMENTO],
                                                TBTRANSPORTADOR.INSCRICAOESTADUAL[INSCRICAOESTADUAL],
                                                TBTRANSPORTADOR.RESPONSABILIDADEFRETE[RESPONSABILIDADEFRETE],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBTRANSPORTADOR
                                                JOIN TBENDERECO ON TBTRANSPORTADOR.ENDERECOID = TBENDERECO.ID
                                                WHERE TBTRANSPORTADOR.ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT 
                                                TBTRANSPORTADOR.ID[ID],
                                                TBTRANSPORTADOR.NOME[NOME],
                                                TBTRANSPORTADOR.DOCUMENTO[DOCUMENTO],
                                                TBTRANSPORTADOR.TIPODOCUMENTO[TIPODOCUMENTO],
                                                TBTRANSPORTADOR.INSCRICAOESTADUAL[INSCRICAOESTADUAL],
                                                TBTRANSPORTADOR.RESPONSABILIDADEFRETE[RESPONSABILIDADEFRETE],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBTRANSPORTADOR
                                                JOIN TBENDERECO ON TBTRANSPORTADOR.ENDERECOID = TBENDERECO.ID";

        public const string _sqlAtualizar = @"UPDATE TBTRANSPORTADOR SET 
                                            NOME={0}NOME,
                                            INSCRICAOESTADUAL={0}INSCRICAOESTADUAL,
                                            TIPODOCUMENTO={0}TIPODOCUMENTO,
                                            DOCUMENTO={0}DOCUMENTO,
                                            ENDERECOID={0}ENDERECOID,
                                            RESPONSABILIDADEFRETE={0}RESPONSABILIDADEFRETE
                                            WHERE ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBTRANSPORTADOR
                                              WHERE ID = {0}ID";


        #endregion Scripts SQL
        public Transportador Adicionar(Transportador transportador)
        {
            transportador.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioTransportador(transportador));
            return transportador;
        }

        public Transportador Atualizar(Transportador transportador)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioTransportador(transportador));
            return transportador;
        }

        public Transportador BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoTransportador, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Transportador> BuscarTodos()
        {
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoTransportador);
        }

        public void Excluir(Transportador transportador)
        {
            Db.Excluir(_sqlExcluir, ObterDicionarioTransportador(transportador));
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioTransportador(Transportador transportador)
        {
            Dictionary<string, object> dicionario = new Dictionary<string, object>
            {
                { "ID", transportador.Id },
                { "NOME", transportador.NomeRazaoSocial},
                { "DOCUMENTO",transportador.Documento.NumeroComPontuacao },
                { "TIPODOCUMENTO", transportador.Documento.ObterTipo() },
                { "InscricaoEstadual", transportador.InscricaoEstadual },
                { "RESPONSABILIDADEFRETE", transportador.ResponsabilidadeFrete },
                { "ENDERECOID", transportador.Endereco.Id }
            };

            return dicionario;
        }


        private static Transportador FormaObjetoTransportador(IDataReader reader)
        {
            IDocumento documento;
            if (Convert.ToString(reader["TIPODOCUMENTO"]) == "CPF")
            {
                documento = new CPF
                {
                    NumeroComPontuacao = Convert.ToString(reader["DOCUMENTO"])
                };
            }
            else
            {
                documento = new CNPJ
                {
                    NumeroComPontuacao = Convert.ToString(reader["DOCUMENTO"])
                };
            }

            Transportador transportador = new Transportador();
            transportador.Id = Convert.ToInt64(reader["ID"]);
            transportador.NomeRazaoSocial = Convert.ToString(reader["NOME"]);
            transportador.Documento = documento;
            transportador.Endereco = new Endereco();
            transportador.InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]);
            transportador.ResponsabilidadeFrete = Convert.ToBoolean(reader["RESPONSABILIDADEFRETE"]);

            transportador.Endereco.Id = Convert.ToInt64(reader["IDENDERECO"]);
            transportador.Endereco.Logradouro = Convert.ToString(reader["LOGRADOURO_ENDERECO"]);
            transportador.Endereco.Numero = Convert.ToInt32(reader["NUMERO_ENDERECO"]);
            transportador.Endereco.Bairro = Convert.ToString(reader["BAIRRO_ENDERECO"]);
            transportador.Endereco.Municipio = Convert.ToString(reader["MUNICIPIO_ENDERECO"]);
            transportador.Endereco.Estado = Convert.ToString(reader["ESTADO_ENDERECO"]);
            transportador.Endereco.Pais = Convert.ToString(reader["PAIS_ENDERECO"]);

            return transportador;
        }
        #endregion
    }
}
