using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class AcessoController
    {
        private AcessoRepositorio _repositorioAcessos;
        public AcessoController()
        {
            _repositorioAcessos = new AcessoRepositorio();
        }

        public bool CadastrarAcesso(Acesso acesso)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioAcessos.Inserir(acesso);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}