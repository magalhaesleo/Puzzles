using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Database;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{


    public class NotaFiscalRepositorioSql : INotaFiscalRepositorio
    {

        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBNOTAFISCAL 
                                                (TransportadorId, DestinatarioId, EmitenteId, NaturezaDaOperacao, DataEntrada) 
                                                VALUES 
                                                ({0}IDTRANSPORTADOR, {0}IDDESTINATARIO, {0}IDEMITENTE, {0}NATUREZA_OPERACAO, {0}DATA_ENTRADA);SELECT SCOPE_IDENTITY();";

        public const string _sqlAtualizar = @"UPDATE TBNOTAFISCAL SET
                                                TRANSPORTADORID={0}IDTRANSPORTADOR,
                                                DESTINATARIOID={0}IDDESTINATARIO,
                                                EMITENTEID={0}IDEMITENTE,
                                                NATUREZADAOPERACAO={0}NATUREZA_OPERACAO,
                                                DATAENTRADA={0}DATA_ENTRADA
                                                WHERE ID = {0}ID";

        public const string _sqlBuscarPorId = @"SELECT 
                                    TBNOTAFISCAL.Id[ID],
                                    TBNOTAFISCAL.DataEntrada[DATA_ENTRADA],
                                    TBNOTAFISCAL.NaturezaDaOperacao[NATUREZA_OPERACAO],

                                    TBTRANSPORTADOR.Id[IDTRANSPORTADOR],
                                    TBTRANSPORTADOR.Documento[DOCUMENTO_TRANSPORTADOR],
                                    TBTRANSPORTADOR.InscricaoEstadual[INSCRICAOESTADUAL_TRANSPORTADOR],
                                    TBTRANSPORTADOR.Nome[NOME_TRANSPORTADOR],
                                    TBTRANSPORTADOR.ResponsabilidadeFrete[RESPONSABILIDADEFRETE_TRANSPORTADOR],
                                    TBTRANSPORTADOR.TipoDocumento[TIPODEDOCUMENTO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Bairro[BAIRRO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Estado[ESTADO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Logradouro[LOGRADOURO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Municipio[MUNICIPIO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Numero[NUMERO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Pais[PAIS_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Id[ID_ENDERECO_TRANSPORTADOR],

                                    TBDESTINATARIO.Id[IDDESTINATARIO],
                                    TBDESTINATARIO.Documento[DOCUMENTO_DESTINATARIO],
                                    TBDESTINATARIO.InscricaoEstadual[INSCRICAOESTADUAL_TBDESTINATARIO],
                                    TBDESTINATARIO.Nome[NOME_DESTINATARIO],
                                    TBDESTINATARIO.TipoDeDocumento[TIPODEDOCUMENTO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Id[ID_ENDERECO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Bairro[BAIRRO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Estado[ESTADO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Logradouro[LOGRADOURO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Municipio[MUNICIPIO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Numero[NUMERO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Pais[PAIS_DESTINATARIO],

                                    TBEMITENTE.Id[IDEMITENTE],
                                    TBEMITENTE.CNPJ[CNPJ_EMITENTE],
                                    TBEMITENTE.InscricaoEstadual[INSCRICAOESTADUAL_EMITENTE],
                                    TBEMITENTE.InscricaoMunicipal[INSCRICAOMUNICIPAL_EMITENTE],
                                    TBEMITENTE.NomeFantasia[NOMEFANTASIA_EMITENTE],
                                    TBEMITENTE.RazaoSocial[RAZAOSOCIAL_EMITENTE],
                                    TBENDERECO_EMITENTE.Id[ID_ENDERECO_EMITENTE],
                                    TBENDERECO_EMITENTE.Bairro[BAIRRO_EMITENTE],
                                    TBENDERECO_EMITENTE.Estado[ESTADO_EMITENTE],
                                    TBENDERECO_EMITENTE.Logradouro[LOGRADOURO_EMITENTE],
                                    TBENDERECO_EMITENTE.Municipio[MUNICIPIO_EMITENTE],
                                    TBENDERECO_EMITENTE.Numero[NUMERO_EMITENTE],
                                    TBENDERECO_EMITENTE.Pais[PAIS_EMITENTE]

                                    FROM TBNOTAFISCAL
                                    JOIN TBTRANSPORTADOR ON TBNOTAFISCAL.TransportadorId = TBTRANSPORTADOR.Id
                                    JOIN TBDESTINATARIO ON TBNOTAFISCAL.DestinatarioId = TBDESTINATARIO.Id
                                    JOIN TBEMITENTE  ON TBNOTAFISCAL.EmitenteId = TBEMITENTE.Id
                                    JOIN TBENDERECO [TBENDERECO_DESTINATARIO] ON TBDESTINATARIO.EnderecoId = [TBENDERECO_DESTINATARIO].Id
                                    JOIN TBENDERECO [TBENDERECO_EMITENTE] ON TBEMITENTE.EnderecoId = [TBENDERECO_EMITENTE].Id
                                    JOIN TBENDERECO [TBENDERECO_TRANSPORTADOR] ON TBTRANSPORTADOR.EnderecoId = [TBENDERECO_TRANSPORTADOR].Id

                                    WHERE TBNOTAFISCAL.ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBNOTAFISCAL
                                              WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT 
                                    TBNOTAFISCAL.Id[ID],
                                    TBNOTAFISCAL.DataEntrada[DATA_ENTRADA],
                                    TBNOTAFISCAL.NaturezaDaOperacao[NATUREZA_OPERACAO],

                                    TBTRANSPORTADOR.Id[IDTRANSPORTADOR],
                                    TBTRANSPORTADOR.Documento[DOCUMENTO_TRANSPORTADOR],
                                    TBTRANSPORTADOR.InscricaoEstadual[INSCRICAOESTADUAL_TRANSPORTADOR],
                                    TBTRANSPORTADOR.Nome[NOME_TRANSPORTADOR],
                                    TBTRANSPORTADOR.ResponsabilidadeFrete[RESPONSABILIDADEFRETE_TRANSPORTADOR],
                                    TBTRANSPORTADOR.TipoDocumento[TIPODEDOCUMENTO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Bairro[BAIRRO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Estado[ESTADO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Logradouro[LOGRADOURO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Municipio[MUNICIPIO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Numero[NUMERO_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Pais[PAIS_TRANSPORTADOR],
                                    TBENDERECO_TRANSPORTADOR.Id[ID_ENDERECO_TRANSPORTADOR],

                                    TBDESTINATARIO.Id[IDDESTINATARIO],
                                    TBDESTINATARIO.Documento[DOCUMENTO_DESTINATARIO],
                                    TBDESTINATARIO.InscricaoEstadual[INSCRICAOESTADUAL_TBDESTINATARIO],
                                    TBDESTINATARIO.Nome[NOME_DESTINATARIO],
                                    TBDESTINATARIO.TipoDeDocumento[TIPODEDOCUMENTO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Id[ID_ENDERECO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Bairro[BAIRRO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Estado[ESTADO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Logradouro[LOGRADOURO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Municipio[MUNICIPIO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Numero[NUMERO_DESTINATARIO],
                                    [TBENDERECO_DESTINATARIO].Pais[PAIS_DESTINATARIO],

                                    TBEMITENTE.Id[IDEMITENTE],
                                    TBEMITENTE.CNPJ[CNPJ_EMITENTE],
                                    TBEMITENTE.InscricaoEstadual[INSCRICAOESTADUAL_EMITENTE],
                                    TBEMITENTE.InscricaoMunicipal[INSCRICAOMUNICIPAL_EMITENTE],
                                    TBEMITENTE.NomeFantasia[NOMEFANTASIA_EMITENTE],
                                    TBEMITENTE.RazaoSocial[RAZAOSOCIAL_EMITENTE],
                                    TBENDERECO_EMITENTE.Id[ID_ENDERECO_EMITENTE],
                                    TBENDERECO_EMITENTE.Bairro[BAIRRO_EMITENTE],
                                    TBENDERECO_EMITENTE.Estado[ESTADO_EMITENTE],
                                    TBENDERECO_EMITENTE.Logradouro[LOGRADOURO_EMITENTE],
                                    TBENDERECO_EMITENTE.Municipio[MUNICIPIO_EMITENTE],
                                    TBENDERECO_EMITENTE.Numero[NUMERO_EMITENTE],
                                    TBENDERECO_EMITENTE.Pais[PAIS_EMITENTE]

                                    FROM TBNOTAFISCAL
                                    JOIN TBTRANSPORTADOR ON TBNOTAFISCAL.TransportadorId = TBTRANSPORTADOR.Id
                                    JOIN TBDESTINATARIO ON TBNOTAFISCAL.DestinatarioId = TBDESTINATARIO.Id
                                    JOIN TBEMITENTE  ON TBNOTAFISCAL.EmitenteId = TBEMITENTE.Id
                                    JOIN TBENDERECO [TBENDERECO_DESTINATARIO] ON TBDESTINATARIO.EnderecoId = [TBENDERECO_DESTINATARIO].Id
                                    JOIN TBENDERECO [TBENDERECO_EMITENTE] ON TBEMITENTE.EnderecoId = [TBENDERECO_EMITENTE].Id
                                    JOIN TBENDERECO [TBENDERECO_TRANSPORTADOR] ON TBTRANSPORTADOR.EnderecoId = [TBENDERECO_TRANSPORTADOR].Id
";

        #endregion Scripts SQL

        public NotaFiscal Adicionar(NotaFiscal notaFiscal)
        {
            notaFiscal.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioNotaFiscal(notaFiscal));
            return notaFiscal;
        }

        public NotaFiscal Atualizar(NotaFiscal notaFiscal)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioNotaFiscal(notaFiscal));
            return notaFiscal;
        }

        public NotaFiscal BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoNotaFiscal, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<NotaFiscal> BuscarTodos()
        {
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoNotaFiscal);
        }

        public void Excluir(NotaFiscal notaFiscal)
        {
            Db.Excluir(_sqlExcluir, new Dictionary<string, object> { { "ID", notaFiscal.Id } });
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioNotaFiscal(NotaFiscal notaFiscal)
        {
            return new Dictionary<string, object>
            {
                { "ID", notaFiscal.Id },
                { "IDDESTINATARIO", notaFiscal.Destinatario.Id},
                { "IDEMITENTE", notaFiscal.Emitente.Id},
                { "IDTRANSPORTADOR", notaFiscal.Transportador.Id},
                { "NATUREZA_OPERACAO", notaFiscal.NaturezaOperacao},
                { "DATA_ENTRADA", notaFiscal.DataEntrada}
            };
        }

        private static NotaFiscal FormaObjetoNotaFiscal(IDataReader reader)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            notaFiscal.Id = Convert.ToInt64(reader["ID"]);
            notaFiscal.DataEntrada = Convert.ToDateTime(reader["DATA_ENTRADA"]);
            notaFiscal.NaturezaOperacao = Convert.ToString(reader["NATUREZA_OPERACAO"]);

            //Transportador

            notaFiscal.Transportador = new Transportador()
            {
                Id = Convert.ToInt64(reader["IDTRANSPORTADOR"]),
                InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL_TRANSPORTADOR"]),
                NomeRazaoSocial = Convert.ToString(reader["NOME_TRANSPORTADOR"]),
                ResponsabilidadeFrete = Convert.ToBoolean(reader["RESPONSABILIDADEFRETE_TRANSPORTADOR"]),
                Endereco = new Endereco()
                {
                    Id = Convert.ToInt64(reader["ID_ENDERECO_TRANSPORTADOR"]),
                    Bairro = Convert.ToString(reader["BAIRRO_TRANSPORTADOR"]),
                    Estado = Convert.ToString(reader["ESTADO_TRANSPORTADOR"]),
                    Logradouro = Convert.ToString(reader["LOGRADOURO_TRANSPORTADOR"]),
                    Municipio = Convert.ToString(reader["MUNICIPIO_TRANSPORTADOR"]),
                    Numero = Convert.ToInt32(reader["NUMERO_TRANSPORTADOR"]),
                    Pais = Convert.ToString(reader["PAIS_TRANSPORTADOR"])
                }
            };

            if (Convert.ToString(reader["TIPODEDOCUMENTO_TRANSPORTADOR"]).Equals("CPF"))
            {
                notaFiscal.Transportador.Documento = new CPF()
                {
                    NumeroComPontuacao = Convert.ToString("DOCUMENTO_TRANSPORTADOR")
                };
            }
            else
            {
                notaFiscal.Transportador.Documento = new CNPJ()
                {
                    NumeroComPontuacao = Convert.ToString("DOCUMENTO_TRANSPORTADOR")
                };
            }



            //Destinatario

            notaFiscal.Destinatario = new Destinatario
            {
                Id = Convert.ToInt64(reader["IDDESTINATARIO"]),
                InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL_TBDESTINATARIO"]),
                NomeRazaoSocial = Convert.ToString(reader["NOME_DESTINATARIO"]),
                Endereco = new Endereco
                {
                    Id = Convert.ToInt64(reader["ID_ENDERECO_DESTINATARIO"]),
                    Bairro = Convert.ToString(reader["BAIRRO_DESTINATARIO"]),
                    Estado = Convert.ToString(reader["ESTADO_DESTINATARIO"]),
                    Logradouro = Convert.ToString(reader["LOGRADOURO_DESTINATARIO"]),
                    Municipio = Convert.ToString(reader["MUNICIPIO_DESTINATARIO"]),
                    Numero = Convert.ToInt32(reader["NUMERO_DESTINATARIO"]),
                    Pais = Convert.ToString(reader["PAIS_DESTINATARIO"])
                }
            };


            if (Convert.ToString(reader["TIPODEDOCUMENTO_DESTINATARIO"]).Equals("CPF"))
            {
                notaFiscal.Destinatario.Documento = new CPF()
                {
                    NumeroComPontuacao = Convert.ToString("DOCUMENTO_DESTINATARIO")
                };
            }
            else
            {
                notaFiscal.Destinatario.Documento = new CNPJ()
                {
                    NumeroComPontuacao = Convert.ToString("DOCUMENTO_DESTINATARIO")
                };
            }

            // Emitente
            notaFiscal.Emitente = new Emitente
            {
                Id = Convert.ToInt64(reader["IDEMITENTE"]),
                InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL_EMITENTE"]),
                InscricaoMunicipal = Convert.ToString(reader["INSCRICAOMUNICIPAL_EMITENTE"]),
                NomeFantasia = Convert.ToString(reader["NOMEFANTASIA_EMITENTE"]),
                RazaoSocial = Convert.ToString(reader["RAZAOSOCIAL_EMITENTE"]),

                CNPJ = new CNPJ() { NumeroComPontuacao = Convert.ToString("CNPJ_EMITENTE") },

                Endereco = new Endereco
                {
                    Id = Convert.ToInt64(reader["ID_ENDERECO_EMITENTE"]),
                    Bairro = Convert.ToString(reader["BAIRRO_EMITENTE"]),
                    Estado = Convert.ToString(reader["ESTADO_EMITENTE"]),
                    Logradouro = Convert.ToString(reader["LOGRADOURO_EMITENTE"]),
                    Municipio = Convert.ToString(reader["MUNICIPIO_EMITENTE"]),
                    Numero = Convert.ToInt32(reader["NUMERO_EMITENTE"]),
                    Pais = Convert.ToString(reader["PAIS_EMITENTE"])
                }
            };

            return notaFiscal;
        }
        #endregion

    }
}
