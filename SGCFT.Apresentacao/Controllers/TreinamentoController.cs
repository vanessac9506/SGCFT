using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class TreinamentoController
    {
        private TreinamentoRepositorio _repositorioTreinamentos;
        public TreinamentoController()
        {
            _repositorioTreinamentos = new TreinamentoRepositorio();
        }

        public bool CadastrarTreinamento(Treinamento treinamento)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioTreinamentos.Inserir(treinamento);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}