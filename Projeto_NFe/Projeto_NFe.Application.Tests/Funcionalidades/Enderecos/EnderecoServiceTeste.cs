using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Enderecos
{
    [TestFixture]
    public class EnderecoServiceTeste
    {
        private IEnderecoService _enderecoService;
        [SetUp]
        public void Inicializa()
        {
            _enderecoService = new EnderecoService();
        }

    }
}
