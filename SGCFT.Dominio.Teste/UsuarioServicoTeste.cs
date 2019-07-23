using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Teste
{
    [TestClass]
    public class UsuarioServicoTeste
    {
        
        [TestMethod]
        public void CriarNovoUsuarioComEmailJaExistente()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long cpf = 12904202625;
            Usuario usuario = new Usuario(nome, senha, email, cpf, true);

            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorioMock(true,false);

            IUsuarioServico usuarioServico = new UsuarioServico(usuarioRepositorio);
            Retorno retorno = usuarioServico.InserirUsuario(usuario);

            Assert.AreEqual(false, retorno.Sucesso);
            Assert.AreEqual("Email já cadastrado", retorno.Mensagens.First());
        }

        [TestMethod]
        public void CriarNovoUsuarioComCpfJaExistente()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long cpf = 12904202625;

            Usuario usuario = new Usuario(nome, senha, email, cpf, true);

            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorioMock(false, true);

            IUsuarioServico usuarioServico = new UsuarioServico(usuarioRepositorio);
            Retorno retorno = usuarioServico.InserirUsuario(usuario);

            Assert.AreEqual(false, retorno.Sucesso);
            Assert.AreEqual("Cpf já cadastrado", retorno.Mensagens.First());
        }

        [TestMethod]
        public void CriarNovoUsuarioValido()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long cpf = 12904202625;

            Usuario usuario = new Usuario(nome, senha, email, cpf, true);

            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorioMock(false, false);

            IUsuarioServico usuarioServico = new UsuarioServico(usuarioRepositorio);
            Retorno retorno = usuarioServico.InserirUsuario(usuario);

            Assert.AreEqual(true, retorno.Sucesso);
            Assert.AreEqual(false, retorno.Mensagens.Any());
        }
    }

    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {
        private bool resultadoEsperadoEmailCadastrado;
        private bool resultadoEsperadoDocumentoCadastrado;

        public UsuarioRepositorioMock(bool resultadoEsperadoEmailCadastrado, bool resultadoEsperadoDocumentoCadastrado)
        {
            this.resultadoEsperadoEmailCadastrado = resultadoEsperadoEmailCadastrado;
            this.resultadoEsperadoDocumentoCadastrado = resultadoEsperadoDocumentoCadastrado;
        }

        public void Inserir(Usuario usuario)
        {
            //FALTA FAZER*********  
        }

        public bool ValidarDocumentoCadastrado(long documento, bool isCpf)
        {
            return this.resultadoEsperadoDocumentoCadastrado;
        }

        public bool ValidarEmailCadastrado(string email)
        {
            return this.resultadoEsperadoEmailCadastrado;
        }
    }
}
