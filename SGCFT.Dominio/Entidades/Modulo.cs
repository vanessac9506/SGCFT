using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Modulo
    {
        protected Modulo()
        {

        }

        private Modulo(int idTreinamento, string titulo) 
        {
            this.IdTreinamento = idTreinamento;
            this.Titulo = titulo;
        }
        public int Id { get; set; }
        public int IdTreinamento { get; set; }
        public Treinamento Treinamento { get; set; }
        public string Titulo { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (this.IdTreinamento <= 0)
                retorno.AdicionarErro("Treinamento inválido!");

            if (string.IsNullOrEmpty(this.Titulo) || string.IsNullOrWhiteSpace(this.Titulo))
                retorno.AdicionarErro("Titulo inválido!");

            return retorno;
        }
    }
}
