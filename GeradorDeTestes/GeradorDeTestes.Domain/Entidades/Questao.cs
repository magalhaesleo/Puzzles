﻿using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Questao :Entidade
    {
        private string _enunciado;
        private List<Alternativa> _alternativas = new List<Alternativa>();
        private int _bimestre;
        private Materia _materia;

        public string Enunciado { get => this._enunciado;  set => this._enunciado = value;  }
        public List<Alternativa> Alternativas { get => this._alternativas;  set => this._alternativas = value; } 

        public Materia Materia { get => this._materia;  set => this._materia = value; } 
        public int Bimestre { get => this._bimestre;  set => this._bimestre =value; } 

        public Questao()
        {
        }
        
        public void Validar()
        {
            if(this._enunciado == null)
            {
                throw new Exception("A descrição do enúnciado não pode estar vazia");
            }

            if (this._enunciado.Length > 100)
            {
                throw new Exception("O enunciado não pode ultrapassar 100 caracateres");
            }

            if (Regex.IsMatch(char.ToString(this._enunciado[0]), (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                throw new Exception("A descrição do enúnciado não deve iniciar com caracteres especiais");
            }

            if(this._materia==null)
            {
                throw new Exception("A matéria não pode estar vazia");
            }
            if(this._bimestre==null)
            {
                throw new Exception("O bimestre deve ser preenchido");
            }
            if(this._enunciado.Contains("  "))
            {
                throw new Exception("Não pode haver dois espaços consecutivos no enúnciado");
            }

            if (Regex.IsMatch(char.ToString(this._enunciado[0]), (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                throw new Exception("A descrição do enúnciado não deve iniciar com caracteres especiais");
            }
            //if(!Regex.IsMatch(this._enunciado, (@"\w)(\w{ 1,}\W *\w{ 1,})| (\w)")))
            //{
            //    throw new Exception("O enunciado não pode conter apenas caracateres especiais");
            //}
        }

        public override string ToString()
        {
            return String.Format("Enunciado: {0} - Materia: {1} - Disciplina: {2}", Enunciado,Materia.Nome,Materia.Disciplina.Nome);
        }
    }
}
