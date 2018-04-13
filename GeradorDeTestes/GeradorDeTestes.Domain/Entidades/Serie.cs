using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Serie : Entidade
    {
      

        private int _numero;

        public override string ToString()
        {
            return string.Format("{0}º Série", Numero);
        }

       
        public int Numero { get { return _numero; } set { _numero = value; } }
        public Serie()
        {

        }
        public Serie(int numero)
        {
            this.Numero = numero;
        }

    }
}