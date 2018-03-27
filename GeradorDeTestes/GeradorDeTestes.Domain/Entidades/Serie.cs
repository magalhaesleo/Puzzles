using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
   public class Serie
    {
        private int _id;

        private int _numero;


        public int Id { get { return _id; } set { _id = value; } }
        
        public int Numero { get {return _numero; } set {_numero = value; } }

        public Serie(int numero)
        {
            this.Numero = numero;
        }
        
    }
}
