using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class VideoConteudo
    {
        public VideoConteudo(byte[] conteudo)
        {
            Conteudo = conteudo;
        }

        protected VideoConteudo()
        {

        }

        public int Id { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
