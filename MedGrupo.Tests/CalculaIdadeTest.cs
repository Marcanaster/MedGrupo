using MedGrupo.CrossCutting.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedGrupo.Tests
{
    [TestClass]
    public class CalculaIdadeTest
    {
        [TestMethod]
        public void MaiorDeIdade()
        {
            var dataNascimento = new DateTime(2004,01,24);
            var idade = Util.CalculaIdade(dataNascimento);
            Assert.IsTrue(idade >= 18);
        }

        [TestMethod]
        public void MenorDeIdade()
        {
            var dataNascimento = new DateTime(2010, 12, 5);
            var idade = Util.CalculaIdade(dataNascimento);
            Assert.IsTrue(idade < 18);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentEmpty()
        {
            var dataNascimento = (DateTime?)null;
             Util.CalculaIdade(dataNascimento);
        }
    }
}
