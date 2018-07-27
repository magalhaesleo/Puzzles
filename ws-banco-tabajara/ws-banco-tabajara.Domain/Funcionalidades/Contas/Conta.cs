using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Domain.Funcionalidades.Contas
{
    public class Conta : Entidade
    {
        public Conta()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public virtual Cliente Titular { get; set; }

        public virtual string Numero { get; set; }

        public bool Ativa { get; set; }

        public double Saldo { get; set; }

        public double Limite { get; set; }

        //SaldoTotal é composto por Saldo + Limite
        public double SaldoTotal
        {
            get
            {
                return Limite + Saldo;
            }
            set { }
        }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
