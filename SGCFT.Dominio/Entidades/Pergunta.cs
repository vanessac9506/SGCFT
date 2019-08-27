using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Pergunta
    {
        protected Pergunta()
        {

        }

        public Pergunta(string texto)
        {
            this.Texto = texto;        
        }

        private int Id { get; set; }
        private string Texto { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Texto) || string.IsNullOrWhiteSpace(this.Texto))
                retorno.AdicionarErro("Pergunta inválida!");

            return retorno;
        }
    }
}
