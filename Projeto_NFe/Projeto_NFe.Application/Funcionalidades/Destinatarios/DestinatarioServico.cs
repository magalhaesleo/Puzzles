using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios
{
    public class DestinatarioServico : IDestinatarioServico
    {
        IEnderecoRepositorio _enderecoRepositorio;
        IDestinatarioRepositorio _destinatarioRepositorio;
        public DestinatarioServico(IEnderecoRepositorio enderecoRepositorio, IDestinatarioRepositorio destionatarioRepositorio)
        {
            this._enderecoRepositorio = enderecoRepositorio;
            this._destinatarioRepositorio = destionatarioRepositorio;

        }
        public Destinatario Adicionar(Destinatario destinatario)
        {
            destinatario.Validar();

            destinatario.Endereco =  _enderecoRepositorio.Adicionar(destinatario.Endereco);

            return _destinatarioRepositorio.Adicionar(destinatario);
        }

        public Destinatario Atualizar(Destinatario destinatario)
        {
            if (destinatario.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            destinatario.Validar();

            _enderecoRepositorio.Atualizar(destinatario.Endereco);

            return _destinatarioRepositorio.Atualizar(destinatario);
        }

        public Destinatario BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Destinatario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Destinatario destinatario)
        {
            if (destinatario.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _destinatarioRepositorio.Excluir(destinatario);

            _enderecoRepositorio.Excluir(destinatario.Endereco);
        }
    }
}
