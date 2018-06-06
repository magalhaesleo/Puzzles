using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Database;
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


        #endregion Scripts SQL


        public Destinatario Adicionar(Destinatario destinatario)
        {
            destinatario.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioDestinatario(destinatario));
            return destinatario;
        }

        public Destinatario Atualizar(Destinatario destinatario)
        {
            throw new NotImplementedException();
        }

        public Destinatario BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Destinatario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Destinatario destinatario)
        {
            throw new NotImplementedException();
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioDestinatario(Destinatario destinatario)
        {
            var dicionario = new Dictionary<string, object>();

            dicionario.Add("Id", destinatario.Id);
            dicionario.Add("Nome", destinatario.NomeRazaoSocial);
            dicionario.Add("Documento", destinatario.Documento.NumeroComPontuacao);

            if (destinatario.InscricaoEstadual == null)
                dicionario.Add("InscricaoEstadual", DBNull.Value);
            else
            dicionario.Add("InscricaoEstadual", destinatario.InscricaoEstadual);

            dicionario.Add("TipoDeDocumento", destinatario.Documento.ObterTipo());
            dicionario.Add("EnderecoId", destinatario.Endereco.Id);

            return dicionario;
        }


        private static Destinatario FormaObjetoDestinatario(IDataReader reader)
        {
            Destinatario destinatario = new Destinatario();

            destinatario.Id = Convert.ToInt64(reader["Id"]);
            destinatario.NomeRazaoSocial = Convert.ToString(reader["Nome"]);
            destinatario.Documento.NumeroComPontuacao = Convert.ToString(reader["Documento"]);
            destinatario.InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]);
            destinatario.Endereco = new Endereco
            {
                Id = Convert.ToInt64(reader["EnderecoId"])
                //continuar
            };
            
            return destinatario;
        }
        #endregion
    }
}
