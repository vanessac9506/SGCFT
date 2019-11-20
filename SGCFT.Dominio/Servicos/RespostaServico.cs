using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Servicos
{
    public class RespostaServico : IRespostaServico
    {
        private IRespostaRepositorio _respostaRepositorio;
        private readonly IAlternativaRepositorio _alternativaRepositorio;

        public RespostaServico(IRespostaRepositorio respostaRepositorio, IAlternativaRepositorio alternativaRepositorio)
        {
            this._respostaRepositorio = respostaRepositorio;
            this._alternativaRepositorio = alternativaRepositorio;
        }

        public Retorno InserirResposta(Resposta resposta)
        {
            Retorno retorno = new Retorno();
            if (resposta == null)
            {
                retorno.AdicionarErro("Resposta não informada");
                return retorno;
            }

            retorno = resposta.ValidarDominio();
            if (retorno.Sucesso)
                _respostaRepositorio.Inserir(resposta);
            return retorno;
        }

        public List<ResultadoResposta> SelecionarResultadoQuestionario(List<int> idsRespostas)
        {
            List<ResultadoResposta> resultado = new List<ResultadoResposta>();
            var respostas = _respostaRepositorio.SelecionarRespostasPorIds(idsRespostas);
            foreach (var resposta in respostas)
            {
                var alternativaCorreta = _alternativaRepositorio.AlternativaCorreta(resposta.IdPergunta);
                resultado.Add(new ResultadoResposta(resposta.IdPergunta, resposta.IdAlternativaEscolhida, alternativaCorreta.Id));
            }
            return resultado;
        }
    }
}
