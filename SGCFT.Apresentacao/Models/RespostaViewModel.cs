using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class RespostaViewModel
    {
        public int IdUsuarioAutenticado { get; set; }
        public List<int> IdsPergunta { get; set; }
        public List<int> IdsAlternativasEscolhida { get; set; }

        public List<Resposta> ConverterParaRespostas(int idUsuarioAutenticado)
        {
            List<Resposta> retorno = new List<Resposta>();

            for (int i = 0; i < this.IdsPergunta.Count; i++)
            {
                var resposta = new Resposta(idUsuarioAutenticado, this.IdsPergunta[i], this.IdsAlternativasEscolhida[i]);
                retorno.Add(resposta);
            }

            return retorno;
        }
    }
}