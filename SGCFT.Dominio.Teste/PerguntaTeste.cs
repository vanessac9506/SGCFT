using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System.Linq;

namespace SGCFT.Dominio.Teste
{
    [TestClass]
    public class PerguntaTeste
    {
        [TestMethod]
        public void CriarNovaPerguntaComTextoValido()
        {
            string texto = "Qual seu nome?";
            int idAutor = 3;
            int idModulo = 2;
            Pergunta pergunta = new Pergunta(texto,idAutor, idModulo);
            Retorno perguntaValida = pergunta.ValidarDominio();

            Assert.AreEqual(true, perguntaValida.Sucesso);
            Assert.AreEqual(false, perguntaValida.Mensagens.Any());
        }

        [TestMethod]
        public void CriarNovaPerguntaComTextoInvalido()
        {
            string texto = null;
            int autor = 3;
            int idModulo = 2;
            Pergunta pergunta = new Pergunta(texto,autor, idModulo);
            Retorno perguntaValida = pergunta.ValidarDominio();

            Assert.AreEqual(false, perguntaValida.Sucesso);
            Assert.AreEqual("Pergunta inválida!", perguntaValida.Mensagens.First());
        }

        [TestMethod]
        public void CriarNovaPerguntaComAutorInvalido()
        {
            string texto = null;
            int autor = ' ';
            int idModulo = 2;
            Pergunta pergunta = new Pergunta(texto, autor, idModulo);
            Retorno perguntaValida = pergunta.ValidarDominio();

            Assert.AreEqual(false, perguntaValida.Sucesso);
            Assert.AreEqual("Pergunta inválida!", perguntaValida.Mensagens.First());
        }
    }
}
