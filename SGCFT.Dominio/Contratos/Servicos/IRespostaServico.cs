using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System.Collections.Generic;

namespace SGCFT.Dominio.Contratos.Servicos
{
    public interface IRespostaServico
    {
        Retorno InserirResposta(Resposta resposta);
        List<ResultadoResposta> SelecionarResultadoQuestionario(List<int> idsRespostas);
    }
}
