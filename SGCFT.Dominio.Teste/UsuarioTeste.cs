using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;

namespace SGCFT.Dominio.Teste
{
    [TestClass]
    public class UsuarioTeste
    {
        [TestMethod]
        public void CriarNovoUsuarioComCpf()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long cpf = 122131232;

            Usuario usuario = new Usuario(nome, senha, email, cpf, true);

            Assert.AreEqual(usuario.Nome, nome);
            Assert.AreEqual(usuario.Senha, senha);
            Assert.AreEqual(usuario.Email, email);
            Assert.AreEqual(usuario.Cpf, cpf);
        }

        [TestMethod]
        public void CriarNovoUsuarioComCnpj()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long cnpj = 1221312000154;

            Usuario usuario = new Usuario(nome, senha, email, cnpj, false);

            Assert.AreEqual(usuario.Nome, nome);
            Assert.AreEqual(usuario.Senha, senha);
            Assert.AreEqual(usuario.Email, email);
            Assert.AreEqual(usuario.Cnpj, cnpj);
        }

        [TestMethod]
        public void CriarUsuarioComEmailInvalido()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "testeteste.com";
            long documento = 68723674000158;
            Usuario usuario = new Usuario(nome, senha, email, documento, false);
            Retorno usuarioValido = usuario.ValidarDominio();
            Assert.AreEqual(false,usuarioValido.Sucesso);
            Assert.AreEqual("Email inválido!",usuarioValido.Mensagens.First());
        }

        [TestMethod]
        public void CriarUsuarioComEmailValido()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long documento = 68723674000158;

            Usuario usuario = new Usuario(nome, senha, email, documento, false);
            Retorno usuarioValido = usuario.ValidarDominio();

            Assert.AreEqual(true, usuarioValido.Sucesso);
            Assert.AreEqual(false, usuarioValido.Mensagens.Any());
        }

        [TestMethod]
        public void CriarUsuarioComNomeInvalido()
        {
            string nome = null;
            string senha = "valuneca";
            string email = "teste@teste.com";
            long documento = 68723674000158;
            Usuario usuario = new Usuario(nome, senha, email, documento, false);
            Retorno usuarioValido = usuario.ValidarDominio();
            Assert.AreEqual(false, usuarioValido.Sucesso);
            Assert.AreEqual("Nome inválido!", usuarioValido.Mensagens.First());
        }

        [TestMethod]
        public void CriarUsuarioComNomeValido()
        {
            string nome = "Vanessa";
            string senha = "valuneca";
            string email = "teste@teste.com";
            long documento = 68723674000158;

            Usuario usuario = new Usuario(nome, senha, email, documento, false);
            Retorno usuarioValido = usuario.ValidarDominio();

            Assert.AreEqual(true, usuarioValido.Sucesso);
            Assert.AreEqual(false, usuarioValido.Mensagens.Any());
        }
    }
}
