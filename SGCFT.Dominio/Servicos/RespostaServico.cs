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
        public RespostaServico(IRespostaRepositorio respostaRepositorio)
        {
            this._respostaRepositorio = respostaRepositorio;
        }

        Retorno IRespostaServico.InserirResposta(Resposta resposta)
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
        public Retorno AlterarResposta(Resposta resposta)
        {
            Retorno retorno = new Retorno();
            if (resposta == null)
            {
                retorno.AdicionarErro("Resposta não informada");
                return retorno;
            }
            retorno = resposta.ValidarDominio();
            if (retorno.Sucesso)
                _respostaRepositorio.Alterar(resposta);

            return retorno;
        }
    }
}
