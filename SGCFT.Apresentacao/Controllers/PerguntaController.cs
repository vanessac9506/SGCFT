using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class PerguntaController
    {
        private PerguntaRepositorio _repositorioPerguntas;
        public PerguntaController()
        {
            _repositorioPerguntas = new PerguntaRepositorio();
        }

        public bool CadastrarPergunta(Pergunta pergunta)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioPerguntas.Inserir(pergunta);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}