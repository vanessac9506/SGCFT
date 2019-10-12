using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Resposta
    {
        protected Resposta()
        {

        }

        public Resposta(int idUsuario, int idPergunta, int resposta)
        {
            this.IdUsuario = idUsuario;
            this.IdPergunta = idPergunta;
            this.IdAlternativaEscolhida = resposta;

        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdPergunta { get; set; }
        public Pergunta Pergunta { get; set; }
        public int IdAlternativaEscolhida { get; set; }
        public Alternativa Alternativa { get; set; }//alternativa escolhida guarda o ID da alternativa escolhida para saber qual foi a resposta

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (this.IdUsuario<= 0 ) 
                retorno.AdicionarErro("Usuario inválido!");

            if (this.IdPergunta <= 0)
                retorno.AdicionarErro("Pergunta inválida!");

            if (this.IdAlternativaEscolhida <= 0)
                retorno.AdicionarErro("Resposta inválida!");

            return retorno;
        }

    }
}
