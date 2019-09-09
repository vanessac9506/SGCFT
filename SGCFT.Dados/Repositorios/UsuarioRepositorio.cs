using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Inserir(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public bool ValidarDocumentoCadastrado(long documento, bool isCpf)
        {
            if(isCpf)
                return _contexto.Usuario.Any(x => x.Cpf == documento);
            else
                return _contexto.Usuario.Any(x => x.Cnpj == documento);
        }

        public bool ValidarEmailCadastrado(string email)
        {
            return _contexto.Usuario.Any(x => x.Email == email);
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
        }
    }
}
