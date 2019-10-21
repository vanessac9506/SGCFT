using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Seguranca.Contexto;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private IUsuarioRepositorio _usuarioRepositorio;
        private readonly UserManager<IdentityUser> _userManager;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
            this._userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new AspNetContext()));
        }

        public Retorno InserirUsuario(Usuario usuario)
        {
            Retorno retorno = new Retorno();
            if (usuario == null)
            {
                retorno.AdicionarErro("Usuário não informado");
                return retorno;
            }

            retorno = usuario.ValidarDominio();
            if(retorno.Sucesso)
            {
                bool emailExistente = _usuarioRepositorio.ValidarEmailCadastrado(usuario.Email);
                if (emailExistente)
                    retorno.AdicionarErro("Email já cadastrado");
                bool documentoExistente;
                if (usuario.Cpf != null)
                    documentoExistente = _usuarioRepositorio.ValidarDocumentoCadastrado(usuario.Cpf.Value, true);
                else
                    documentoExistente = _usuarioRepositorio.ValidarDocumentoCadastrado(usuario.Cnpj.Value, false);

                if (documentoExistente)
                    retorno.AdicionarErro($"{(usuario.Cpf != null ? "Cpf" : "Cnpj") } já cadastrado");

                if (retorno.Sucesso)
                {
                    _usuarioRepositorio.Inserir(usuario);
                    IdentityUser identityUser = new IdentityUser();
                    identityUser.Email = usuario.Email;
                    identityUser.EmailConfirmed = true;
                    identityUser.UserName = usuario.Email;
                    _userManager.Create(identityUser, usuario.Senha);
                }
            }

            return retorno;
        }

        public Retorno AlterarUsuario(Usuario usuario)
        {
            Retorno retorno = new Retorno();
            if (usuario == null)
            {
                retorno.AdicionarErro("Usuário não informado");
                return retorno;
            }
            retorno = usuario.ValidarDominio();
            if (retorno.Sucesso)
                _usuarioRepositorio.Alterar(usuario);

            return retorno;
        }
    }
}
