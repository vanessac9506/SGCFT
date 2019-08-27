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

        public Pergunta(string texto, int idAutor)
        {
            this.Texto = texto;
            this.IdAutor = idAutor;
        }

        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdAutor { get; set; }
        public Usuario Autor { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Texto) || string.IsNullOrWhiteSpace(this.Texto))
                retorno.AdicionarErro("Pergunta inválida!");

            if (this.IdAutor <= 0)
                retorno.AdicionarErro("Autor da pergunta inválido");

            return retorno;
        }
    }
}
