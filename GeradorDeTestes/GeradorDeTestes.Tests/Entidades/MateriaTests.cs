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
    public class MateriaTests
    {
        Materia materia = new Materia();

        [TestInitialize()]
        public void Initialize()
        {
            materia = new Materia();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "O nome deve ter no máximo 40 caracteres.")]
        public void ValidarNomeMaiorQueQuarentaCaractersErrado()
        {
            materia.Nome = "plaskdçlçlasdkçladsçkldsaçkldsçklsdaçkldsalçkdsaçklçkladsçkladsklçadsçklçklads";
            materia.Validate();
            Assert.Fail();
        }

        [TestMethod()]
        public void ValidarNomeMaiorQueQuarentaCaractersCorreto()
        {

        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}