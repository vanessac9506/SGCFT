using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGCFT.Apresentacao.Models
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a pergunta")]
        public string Texto { get; set; }
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Informe o módulo")]
        public int IdModulo { get; set; }
        public List<TreinamentoViewModel> Treinamentos { get; set; }

        public string[] Alternativas { get; set; }
        public bool[] Corretos { get; set; }

        public Pergunta ConverterParaDominio()
        {
            Pergunta pergunta = new Pergunta(this.Texto, this.IdAutor,this.IdModulo);
            return pergunta;
        }
    }
}