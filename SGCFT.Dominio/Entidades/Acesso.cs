using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Acesso
    {
        protected Acesso()
        {

        }

        public Acesso(int usuario, int modulo, int video, DateTime dataAcesso, string pontoParada, string visualizacao)
        { 
            this.IdUsuario = usuario;
            this.IdModulo = modulo;
            this.IdVideo = video;
            this.DataAcesso = dataAcesso;
            this.PontoParada = pontoParada;
            this.Visualizacao = visualizacao;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        //public Usuario Usuario { get; set; }
        public int IdModulo { get; set; }
        public Modulo Modulo { get; set; }
        public int IdVideo { get; set; }
        public Video Video { get; set; }
        public DateTime DataAcesso { get; set; }
        public string PontoParada { get; set; }
        public string Visualizacao { get; set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if(this.IdModulo == 0)
               retorno.AdicionarErro("Módulo não especificado");

            if (this.IdUsuario == 0)
                retorno.AdicionarErro("Usuário não especificado");

            if (this.IdVideo == 0)
                retorno.AdicionarErro("Vídeo não especificado");

            if (this.DataAcesso == null)
                retorno.AdicionarErro("Data não especificada");
            return retorno;
        }
    }
}
