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
                                                TBDESTINATARIO.ID[ID],
                                                TBDESTINATARIO.NOME[NOME],
                                                TBDESTINATARIO.DOCUMENTO[DOCUMENTO],
                                                TBDESTINATARIO.TIPODEDOCUMENTO[TIPODEDOCUMENTO],
                                                TBDESTINATARIO.INSCRICAOESTADUAL[INSCRICAOESTADUAL],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBDESTINATARIO
                                                JOIN TBENDERECO ON TBDESTINATARIO.ENDERECOID = TBENDERECO.ID
                                                WHERE TBDESTINATARIO.ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT 
                                                TBDESTINATARIO.ID[ID],
                                                TBDESTINATARIO.NOME[NOME],
                                                TBDESTINATARIO.DOCUMENTO[DOCUMENTO],
                                                TBDESTINATARIO.TIPODEDOCUMENTO[TIPODEDOCUMENTO],
                                                TBDESTINATARIO.INSCRICAOESTADUAL[INSCRICAOESTADUAL],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBDESTINATARIO
                                                JOIN TBENDERECO ON TBDESTINATARIO.ENDERECOID = TBENDERECO.ID";

        public const string _sqlAtualizar = @"UPDATE TBDESTINATARIO SET 
                                            NOME={0}NOME,
                                            INSCRICAOESTADUAL={0}INSCRICAOESTADUAL,
                                            TIPODEDOCUMENTO={0}TIPODEDOCUMENTO,
                                            DOCUMENTO={0}DOCUMENTO,
                                            ENDERECOID={0}ENDERECOID
                                            WHERE ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBDESTINATARIO
                                              WHERE ID = {0}ID";


        #endregion Scripts SQL
        public Transportador Adicionar(Transportador transportador)
        {
            transportador.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioDestinatario(transportador));
            return transportador;
        }

        public Transportador Atualizar(Transportador transportador)
        {
            throw new NotImplementedException();
        }

        public Transportador BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transportador> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Transportador transportador)
        {
            throw new NotImplementedException();
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioDestinatario(Transportador transportador)
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


        private static Transportador FormaObjetoDestinatario(IDataReader reader)
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

            Transportador transportador = new Transportador
            {
                Id = Convert.ToInt64(reader["ID"]),
                NomeRazaoSocial = Convert.ToString(reader["NOME"]),
                Documento = documento,
                Endereco = new Endereco
                {
                    Id = Convert.ToInt64(reader["IDENDERECO"]),
                    Logradouro = Convert.ToString(reader["LOGRADOURO_ENDERECO"]),
                    Numero = Convert.ToInt32(reader["NUMERO_ENDERECO"]),
                    Bairro = Convert.ToString(reader["BAIRRO_ENDERECO"]),
                    Municipio = Convert.ToString(reader["MUNICIPIO_ENDERECO"]),
                    Estado = Convert.ToString(reader["ESTADO_ENDERECO"]),
                    Pais = Convert.ToString(reader["PAIS_ENDERECO"])
                },
                InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]),
                ResponsabilidadeFrete = Convert.ToBoolean(reader["RESPONSABILIDADEFRETE"])
            };


            return transportador;
        }
        #endregion
    }
}
