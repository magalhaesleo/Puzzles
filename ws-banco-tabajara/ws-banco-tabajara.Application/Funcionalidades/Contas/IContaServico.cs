using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Interfaces;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public interface IContaServico : IServico<Conta>
    {
        void AlterarStatusConta(long idConta);
        Conta Depositar(long idConta, double valor);
        Conta Sacar(long idConta, double valor);
        Conta Transferir(long idConta, long idContaMovimentada, double valor);
    }
}
