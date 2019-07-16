using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Treinamento
    {
        public Treinamento()
        {

        }

        public Treinamento(string tema, Usuario autor)
        {
            this.Tema = tema;
            this.Autor = autor;
            this.IdAutor = autor.Id;
        }

        public int Id { get; set; }
        public string Tema { get; set; }
        public Usuario Autor { get; set; }
        public int IdAutor { get; set; }
        public List<Modulo> Modulos { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Tema) || string.IsNullOrWhiteSpace(this.Tema))
                retorno.AdicionarErro("Tema inválido!");

            if (this.Autor == null)
                retorno.AdicionarErro("Autor inválida!");

            //falta ID AUTOR (PUXAR PELO AUTOR???)
            // PRECISA FAZER DO MÓDULO? PQ TENHO QUE CRIAR O TREINAMENTO ANTES.

            return retorno;
        }
    }
}
