using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public int IdModulo { get; set; }
        [Required(ErrorMessage = "Informe o título")]
        public string Titulo { get; set; }
        public string Url { get; set; }
        [Required(ErrorMessage = "Informe o vídeo")]
        public HttpPostedFileBase ConteudoVideo { get; set; }
        public List<TreinamentoViewModel> Treinamentos { get; set; }
        public Video ConverterParaDominio()
        {
            byte[] conteudo;
            using (Stream inputStream = this.ConteudoVideo.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    try
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    finally
                    {
                        memoryStream?.Dispose();
                    }

                }
                conteudo = memoryStream.ToArray();
            }
            Video video = new Video(this.IdModulo, this.Titulo, this.Url, conteudo);
            return video;
        }


    }
}