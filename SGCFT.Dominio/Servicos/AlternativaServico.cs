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
    public class AlternativaServico : IAlternativaServico
    {
        private IAlternativaRepositorio _alternativaRepositorio;
        public AlternativaServico(IAlternativaRepositorio alternativaRepositorio)
        {
            this._alternativaRepositorio = alternativaRepositorio;
        }

        public Retorno InserirAlternativa(Alternativa alternativa)
        {
            Retorno retorno = new Retorno();

            if (alternativa == null)
            {
                retorno.AdicionarErro("Alternativa não informada");
                return retorno;
            }

            retorno = alternativa.ValidarDominio();
            if (retorno.Sucesso)
                _alternativaRepositorio.Inserir(alternativa);
            return retorno;
        }

        public Retorno AlterarAlternativa(Alternativa alternativa)
        {
            Retorno retorno = new Retorno();
            if (alternativa == null)
            {
                retorno.AdicionarErro("Alternativa não informada");
                return retorno;
            }
            retorno = alternativa.ValidarDominio();
            if (retorno.Sucesso)
                _alternativaRepositorio.Alterar(alternativa);

            return retorno;
        }
    }
}
