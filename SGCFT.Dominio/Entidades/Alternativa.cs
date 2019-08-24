using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Alternativa
    {
        protected Alternativa()
        {

        }

        private Alternativa(int idPergunta, string texto, bool certoErrado)
        {
            this.IdPergunta = idPergunta;
            this.Texto = texto;
            this.CertoErrado = certoErrado;
        }

        public int Id { get; set; }
        public int IdPergunta { get; set; }
        public string Texto { get; set; }
        public bool? CertoErrado { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if(this.IdPergunta <=0)
                retorno.AdicionarErro("Pergunta inválida!");

            if (string.IsNullOrEmpty(this.Texto) || string.IsNullOrWhiteSpace(this.Texto))
                retorno.AdicionarErro("Texto inválido!");

            return retorno;
        }

    }
}
