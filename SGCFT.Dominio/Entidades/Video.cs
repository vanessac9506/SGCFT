using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Video
    {
        public Video()
        {

        }

        public Video(int idModulo, string titulo, string url, byte[] conteudo)
        {
            this.IdModulo = idModulo;
            this.Titulo = titulo;
            this.Url = url;
            this.VideoConteudo = new VideoConteudo(conteudo);
        }

        public int Id { get; set; }
        public int IdModulo { get; set; }
        public Modulo Modulo { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public VideoConteudo VideoConteudo { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (this.IdModulo <= 0)
                retorno.AdicionarErro("Módulo inválido!");

            if(string.IsNullOrEmpty(this.Titulo) || string.IsNullOrWhiteSpace(this.Titulo))
                retorno.AdicionarErro("Título inválido!");

            if(string.IsNullOrEmpty(this.Url) || string.IsNullOrWhiteSpace(this.Url))
                retorno.AdicionarErro("Url inválida!");

            return retorno;
        }

    }
}
