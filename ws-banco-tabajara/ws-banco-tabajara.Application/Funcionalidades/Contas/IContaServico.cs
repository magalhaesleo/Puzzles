using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Interfaces;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Extratos;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public interface IContaServico : IServico<Conta>
    {
        bool AlterarStatusConta(long idConta);
        IQueryable<Conta> BuscarListaPorQuantidadeDefinida(int quantidade);
        Conta Depositar(long idConta, double valor);
        Conta Sacar(long idConta, double valor);
        Conta Transferir(long idConta, long idContaMovimentada, double valor);
        Extrato GerarExtrato(long idConta);
    }
}
