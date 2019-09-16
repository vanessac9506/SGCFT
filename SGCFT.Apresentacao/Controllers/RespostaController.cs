using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class RespostaController
    {
        private RespostaRepositorio _repositorioRespostas;
        public RespostaController()
        {
            _repositorioRespostas = new RespostaRepositorio();
        }

        public bool CadastrarResposta(Resposta resposta)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioRespostas.Inserir(resposta);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}