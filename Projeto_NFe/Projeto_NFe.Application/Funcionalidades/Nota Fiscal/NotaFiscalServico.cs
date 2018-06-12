using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais
{
    public class NotaFiscalServico : INotaFiscalServico
    {
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private INotaFiscalEmitidaRepositorio _notaFiscalEmitidaRepositorio;

        public NotaFiscalServico(INotaFiscalRepositorio notaFiscalRepositorio, INotaFiscalEmitidaRepositorio notaFiscalEmitidaRepositorio)
        {
            this._notaFiscalRepositorio = notaFiscalRepositorio;
            this._notaFiscalEmitidaRepositorio = notaFiscalEmitidaRepositorio;
        }

        public NotaFiscal Adicionar(NotaFiscal notaFiscal)
        {
            notaFiscal.ValidarGeracao();

            return _notaFiscalRepositorio.Adicionar(notaFiscal);
        }

        public NotaFiscal Atualizar(NotaFiscal notaFiscal)
        {
            if (notaFiscal.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            notaFiscal.ValidarGeracao();

            return _notaFiscalRepositorio.Atualizar(notaFiscal);
        }

        public NotaFiscal BuscarPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            return _notaFiscalRepositorio.BuscarPorId(id);
        }

        public bool ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso)
        {
            int quantidadeDenotasFiscaisEncontrada = _notaFiscalEmitidaRepositorio.ConsultarExistenciaDeNotaEmitida(chaveDeAcesso);

            if (quantidadeDenotasFiscaisEncontrada > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<NotaFiscal> BuscarTodos()
        {
            return _notaFiscalRepositorio.BuscarTodos();
        }

        public void Excluir(NotaFiscal notaFiscal)
        {
            if (notaFiscal.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _notaFiscalRepositorio.Excluir(notaFiscal);
        }

        public NotaFiscal Emitir(NotaFiscal notaFiscal, Random sorteador)
        {
            //notaFiscal.CalcularValoresTotais();

            notaFiscal.ValidarParaEmitir();

            notaFiscal.GerarChaveDeAcesso(sorteador);

            while (ConsultarExistenciaDeNotaEmitida(notaFiscal.ChaveAcesso))
            {
                notaFiscal.GerarChaveDeAcesso(sorteador);
            }

            //Gerar XML

            NotaFiscal notaFiscalEmitida = _notaFiscalEmitidaRepositorio.Adicionar(notaFiscal);

            if (notaFiscalEmitida.Id != 0)
                _notaFiscalRepositorio.Excluir(notaFiscal);

            return notaFiscal;

        }

        public NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso)
        {
           NotaFiscal notaFiscalEmitidaBuscada = _notaFiscalEmitidaRepositorio.BuscarNotaFiscalEmitidaPorChave(chaveDeAcesso);

            //XML DESERIALIZE

            return notaFiscalEmitidaBuscada;
        }
    }
}
