using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    public class RespostaController: BaseController
    {
        private readonly IRespostaServico _servicoRespostas;

        public RespostaController()
        {
            _servicoRespostas = new RespostaServico(new RespostaRepositorio(), new AlternativaRepositorio());
        }

        [HttpPost]
        public ActionResult EnvioAlternativa(RespostaViewModel respostaViewModel)
        {
            var respostas = respostaViewModel.ConverterParaRespostas(base.IdUsuarioAutenticado);
            var retornosRespostas = new List<Retorno>();
            foreach (var resposta in respostas)
            {
                var retorno = _servicoRespostas.InserirResposta(resposta);
                retornosRespostas.Add(retorno);
            }

            var resultadoRespostas = _servicoRespostas.SelecionarResultadoQuestionario(respostas.Select(x => x.Id).ToList());

            return Json(new { Erro = retornosRespostas.Any(x => !x.Sucesso), Resultado = resultadoRespostas });
        }
    }
}