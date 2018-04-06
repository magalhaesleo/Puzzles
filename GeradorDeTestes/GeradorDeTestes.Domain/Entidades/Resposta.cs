using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Resposta
    {
       private int _numero;
       private char _letra;

       public int Numero {get {return this._numero;} set {this._numero = value;}}
       public char Letra {get {return this._letra;} set {this._letra = value;}}
   }

   
}