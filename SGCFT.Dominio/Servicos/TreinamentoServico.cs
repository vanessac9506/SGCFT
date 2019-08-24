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
    public class TreinamentoServico : ITreinamentoServico
    {

        private ITreinamentoRepositorio _treinamentoRepositorio;
        public TreinamentoServico(ITreinamentoRepositorio treinamentoRepositorio)
        {
            this._treinamentoRepositorio = treinamentoRepositorio;
        }

        public Retorno InserirTreinamento(Treinamento treinamento)
        {
            Retorno retorno = new Retorno();

            if (treinamento == null)
            {
                retorno.AdicionarErro("Treinamento não informado");
                return retorno;
            }

            retorno = treinamento.ValidarDominio();
            if (retorno.Sucesso)
            {
                if (treinamento.TipoTreinamento == 2)
                {
                    if (treinamento.Senha == null)
                        retorno.AdicionarErro("Senha obrigatória");
                }

                if(retorno.Sucesso)
                    _treinamentoRepositorio.Inserir(treinamento);
            }
            return retorno;
        }
    }
}
