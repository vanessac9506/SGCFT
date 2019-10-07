using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class TreinamentoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o tema")]
        public string Tema { get; set; }
        public Usuario Autor { get; set; } //preciso manter aqui??
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Informe o tipo do treinamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um tipo correto")]
        public EnumTipoTreinamento TipoTreinamento { get; set; }
        public string Senha { get; set; }

        public Treinamento ConverterParaDominio()
        {
            Treinamento treinamento = new Treinamento(this.Tema, this.IdAutor, this.TipoTreinamento, this.Senha);
            return treinamento;
        }
    }
}