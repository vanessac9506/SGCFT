using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class AlternativaController
    {
        private AlternativaRepositorio _repositorioAlternativas;
        public AlternativaController()
        {
            _repositorioAlternativas = new AlternativaRepositorio();
        }

        public bool CadastrarAlternativa(Alternativa alternativa)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioAlternativas.Inserir(alternativa);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}