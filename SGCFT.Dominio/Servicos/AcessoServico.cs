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
    public class AcessoServico : IAcessoServico
    {
        private IAcessoRepositorio _acessoRepositorio;
        public AcessoServico(IAcessoRepositorio acessoRepositorio)
        {
            this._acessoRepositorio = acessoRepositorio;
        }

        public Retorno InserirAcesso(Acesso acesso)
        {
            Retorno retorno = new Retorno();
            if (acesso == null)
            {
                retorno.AdicionarErro("Acesso não informado");
                return retorno;
            }

            retorno = acesso.ValidarDominio();
            if (retorno.Sucesso)
                _acessoRepositorio.Inserir(acesso);


            return retorno;
        }

        public Retorno AlterarAcesso(Acesso acesso)
        {
            Retorno retorno = new Retorno();
            if (acesso == null)
            {
                retorno.AdicionarErro("Acesso não informado");
                return retorno;
            }
            retorno = acesso.ValidarDominio();
            if (retorno.Sucesso)
                _acessoRepositorio.Alterar(acesso);

            return retorno;
        }
    }
}