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
        public Resposta()
        {

        }

        public Resposta(int idUsuario, int idPergunta, string resposta)
        {
            this.IdUsuario = idUsuario;
            this.IdPergunta = idPergunta;
            this.Solucao = resposta;

        }

        private int Id { get; set; }
        private int IdUsuario { get; set; }
        private int IdPergunta { get; set; }
        private string Solucao { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (this.IdUsuario.ToString() == null) //tava dando um erro para comparar int 
                retorno.AdicionarErro("Usuario inválido!");

            if (this.IdPergunta.ToString() == null)
                retorno.AdicionarErro("Pergunta inválido!");

            if (string.IsNullOrEmpty(this.Solucao) || string.IsNullOrWhiteSpace(this.Solucao))
                retorno.AdicionarErro("Resposta inválida!");

            return retorno;
        }

    }
}
