using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades.Tests
{
    [TestClass()]
    public class DisciplinaTests
    {
        Disciplina disciplina;

        [TestInitialize()]
        public void Initialize()
        {
            disciplina = new Disciplina();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "O nome deve ter pelo menos quatro caracteres.")]
        public void ValidarNomeMenorQueQuatroCaracteres()
        {
            disciplina.Nome = "abc";
            disciplina.Validate();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "O nome deve ter pelo menos quatro caracteres.")]
        public void ValidarNomeMenorQueQuatroCaracteresCorreto()
        {
            disciplina.Nome = "abc";
            disciplina.Validate();
            //TERMINAR
            //Assert.Equals;
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "O nome não deve possuir mais que um espaço consecutivos.")]
        public void ValidarEspacosConsecutivos()
        {
            disciplina.Nome = "Ana  Raquel";
            disciplina.Validate();
            Assert.Fail();
        }
    }
}