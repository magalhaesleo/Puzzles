using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
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
                                            (NOME,DOCUMENTO,TIPODEDOCUMENTO,INSCRICAOESTADUAL,ENDERECOID) 
                                            VALUES 
                                            ({0}NOME,{0}DOCUMENTO,{0}TIPODEDOCUMENTO,{0}INSCRICAOESTADUAL,{0}ENDERECOID);SELECT SCOPE_IDENTITY();";

      
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
            return new Dictionary<string, object>
            {
                { "ID", destinatario.Id },
                { "NOME", destinatario.NomeRazaoSocial},
                { "DOCUMENTO", destinatario.Documento.NumeroComPontuacao },
                { "INSCRICAOESTADUAL", destinatario.InscricaoEstadual},
                { "TIPODEDOCUMENTO", destinatario.TipoDeDocumento},
                { "ENDERECOID", destinatario.Endereco.Id}
            };
        }


        //private static Emitente FormaObjetoEmitente(IDataReader reader)
        //{
        //    Emitente emitente = new Emitente();

        //    emitente.Id = Convert.ToInt64(reader["Id"]);
        //    emitente.NomeFantasia = Convert.ToString(reader["NOMEFANTASIA"]);
        //    emitente.RazaoSocial = Convert.ToString(reader["RAZAOSOCIAL"]);
        //    emitente.CNPJ = new CNPJ { NumeroComPontuacao = Convert.ToString(reader["CNPJ"]) };
        //    emitente.InscricaoEstadual = Convert.ToString(reader["INSCRICAOESTADUAL"]);
        //    emitente.InscricaoMunicipal = Convert.ToString(reader["INSCRICAOMUNICIPAL"]);
        //    emitente.Endereco = new Endereco { Id = Convert.ToInt64(reader["ENDERECOID"]) };

        //    return emitente;
        //}
        #endregion
    }
}
