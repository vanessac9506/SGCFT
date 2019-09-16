using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class ModuloController
    {
        private ModuloRepositorio _repositorioModulos;
        public ModuloController()
        {
            _repositorioModulos = new ModuloRepositorio();
        }

        public bool CadastrarModulo(Modulo modulo)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioModulos.Inserir(modulo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}