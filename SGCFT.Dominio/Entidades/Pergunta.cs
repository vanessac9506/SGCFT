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

        public Pergunta(string texto, int idAutor, int idModulo)
        {
            this.Texto = texto;
            this.IdAutor = idAutor;
            this.IdModulo = idModulo;
        }

        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdAutor { get; set; }
        public Usuario Autor { get; set; }
        public int IdModulo { get; set; }
        public Modulo Modulo { get; set; }
        public List<Alternativa> Alternativas { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Texto) || string.IsNullOrWhiteSpace(this.Texto))
                retorno.AdicionarErro("Pergunta inválida!");

            if (this.IdAutor <= 0)
                retorno.AdicionarErro("Autor da pergunta inválido");

            return retorno;
        }

        public Pergunta AdicionarAlternativa(string alternativa, bool correto)
        {
            if (this.Alternativas == null)
                this.Alternativas = new List<Alternativa>();

            Alternativa alternativaAdicionar = new Alternativa(this.Id, alternativa, correto);
            this.Alternativas.Add(alternativaAdicionar);

            return this;
        }
    }
}
