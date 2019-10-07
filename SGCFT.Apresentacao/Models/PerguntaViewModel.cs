using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a pergunta")]
        public string Texto { get; set; }
        public int IdAutor { get; set; }
        public Usuario Autor { get; set; }

        public Pergunta ConverterParaDominio()
        {
            Pergunta pergunta = new Pergunta(this.Texto, this.IdAutor);
            return pergunta;
        }
    }
}