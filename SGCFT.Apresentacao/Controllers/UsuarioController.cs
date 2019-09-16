using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class UsuarioController
    {
        private UsuarioRepositorio _repositorioUsuarios;
        public UsuarioController()
        {
            _repositorioUsuarios = new UsuarioRepositorio();          
        }

        public bool CadastrarUsuario(Usuario usuario)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioUsuarios.Inserir(usuario);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}