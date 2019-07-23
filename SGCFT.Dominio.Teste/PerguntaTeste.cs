using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Teste
{
    [TestClass]
    public class PerguntaTeste
    {
        [TestMethod]
        public void CriarNovaPerguntaComTextoValido()
        {
            string texto = "Qual seu nome?";

            Pergunta pergunta = new Pergunta(texto);
            Retorno perguntaValida = pergunta.ValidarDominio();

            Assert.AreEqual(true, perguntaValida.Sucesso);
            Assert.AreEqual(false, perguntaValida.Mensagens.Any());
        }

        [TestMethod]
        public void CriarNovaPerguntaComTextoInvalido()
        {
            string texto = null;

            Pergunta pergunta = new Pergunta(texto);
            Retorno perguntaValida = pergunta.ValidarDominio();

            Assert.AreEqual(false, perguntaValida.Sucesso);
            Assert.AreEqual("Pergunta inválida!", perguntaValida.Mensagens.First());
        }
    }
}
