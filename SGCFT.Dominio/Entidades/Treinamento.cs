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
        protected Treinamento()
        {

        }

        public Treinamento(string tema, int autor, EnumTipoTreinamento tipoTreinamento, string senha)
        {
            this.Tema = tema;
            this.IdAutor = autor;
            this.TipoTreinamento = tipoTreinamento;
            this.Senha = senha;
        }

        public int Id { get; set; }
        public string Tema { get; set; }
        public Usuario Autor { get; set; }
        public int IdAutor { get; set; }
        public List<Modulo> Modulos { get; set; }
        public EnumTipoTreinamento TipoTreinamento { get; set; }
        public string Senha { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string Duracao { get; set; }
        public Treinamento AdicionarModulo(string modulo)
        {
            if (this.Modulos == null)
                this.Modulos = new List<Modulo>();

            Modulo moduloAdicionar = new Modulo(this.Id, modulo);
            this.Modulos.Add(moduloAdicionar);

            return this;
        }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Tema) || string.IsNullOrWhiteSpace(this.Tema))
                retorno.AdicionarErro("Tema inválido!");

            if(this.IdAutor <= 0)
                retorno.AdicionarErro("Autor inválido!");

            if (this.TipoTreinamento <= 0)
                retorno.AdicionarErro("Tipo de treinamento inválido!");
            // não tem necessidade de validar a lista de módulo porque pode ser nula

            if (this.TipoTreinamento == EnumTipoTreinamento.Privado && (string.IsNullOrEmpty(this.Senha) || string.IsNullOrWhiteSpace(this.Senha)))
                retorno.AdicionarErro("Senha inválida!");
            return retorno;
        }


    }
}
