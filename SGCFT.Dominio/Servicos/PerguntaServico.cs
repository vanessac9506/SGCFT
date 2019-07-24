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
    public class PerguntaServico: IPerguntaServico
    {
        private IPerguntaRepositorio _perguntaRepositorio;
        public PerguntaServico(IPerguntaRepositorio perguntaRepositorio)
        {
            this._perguntaRepositorio = perguntaRepositorio;
        }

        public Retorno InserirPergunta(Pergunta pergunta)
        {
            Retorno retorno = new Retorno();

            if (pergunta == null)
            {
                retorno.AdicionarErro("Pergunta não informada");
                return retorno;
            }

            retorno = pergunta.ValidarDominio();
            if (retorno.Sucesso)
                _perguntaRepositorio.Inserir(pergunta);

            return retorno;
        }
    }
}
