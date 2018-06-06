using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Database;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios
{
    public class DestinatarioRepositorioSql : IDestinatarioRepositorio
    {
        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBDESTINATARIO 
                                            (Nome, Documento, TipoDeDocumento, InscricaoEstadual, EnderecoId) 
                                            VALUES 
                                            ({0}Nome, {0}Documento, {0}TipoDeDocumento, {0}InscricaoEstadual, {0}EnderecoId);
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


        public Destinatario Adicionar(Destinatario destinatario)
        {
            destinatario.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioDestinatario(destinatario));
            return destinatario;
        }

        public Destinatario Atualizar(Destinatario destinatario)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioDestinatario(destinatario));
            return destinatario;
        }

        public Destinatario BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoDestinatario, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Destinatario> BuscarTodos()
        {
           
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoDestinatario);
        }

        public void Excluir(Destinatario destinatario)
        {
            Db.Excluir(_sqlExcluir, new Dictionary<string, object> { { "ID", destinatario.Id } });
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioDestinatario(Destinatario destinatario)
        {
            var dicionario = new Dictionary<string, object>();

            dicionario.Add("ID", destinatario.Id);
            dicionario.Add("NOME", destinatario.NomeRazaoSocial);
            dicionario.Add("DOCUMENTO", destinatario.Documento.NumeroComPontuacao);

            if (destinatario.InscricaoEstadual == null)
                dicionario.Add("INSCRICAOESTADUAL", DBNull.Value);
            else
                dicionario.Add("INSCRICAOESTADUAL", destinatario.InscricaoEstadual);

            dicionario.Add("TIPODEDOCUMENTO", destinatario.Documento.ObterTipo());
            dicionario.Add("ENDERECOID", destinatario.Endereco.Id);

            return dicionario;
        }


        private static Destinatario FormaObjetoDestinatario(IDataReader reader)
        {
            Destinatario destinatario = new Destinatario();

            destinatario.Id = Convert.ToInt64(reader["ID"]);
            destinatario.NomeRazaoSocial = Convert.ToString(reader["NOME"]);
            if (Convert.ToString(reader["INSCRICAOESTADUAL"]).Equals(""))
            {
                destinatario.InscricaoEstadual = null;
            }
            else
            {
                destinatario.InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL"]);
            }
            destinatario.Endereco = new Endereco
            {
                Id = Convert.ToInt64(reader["IDENDERECO"]),
                Logradouro = Convert.ToString(reader["LOGRADOURO_ENDERECO"]),
                Numero = Convert.ToInt32(reader["NUMERO_ENDERECO"]),
                Bairro = Convert.ToString(reader["BAIRRO_ENDERECO"]),
                Municipio = Convert.ToString(reader["MUNICIPIO_ENDERECO"]),
                Estado = Convert.ToString(reader["ESTADO_ENDERECO"]),
                Pais = Convert.ToString(reader["PAIS_ENDERECO"])
            };

            if (Convert.ToString(reader["TIPODEDOCUMENTO"]).Equals("CPF"))
            {
                destinatario.Documento = new CPF
                {
                    NumeroComPontuacao = Convert.ToString(reader["DOCUMENTO"])
                };
            }
            else
            {
                destinatario.Documento = new CNPJ
                {
                    NumeroComPontuacao = Convert.ToString(reader["DOCUMENTO"])
                };
            }


            return destinatario;
        }
        #endregion
    }
}
