using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class AlternativaViewModel
    {
        public int Id { get; set; }
        public int IdPergunta { get; set; }
        public Pergunta Pergunta { get; set; }
        [Required(ErrorMessage = "Informe o texto")]
        public string Texto { get; set; }
        public bool CertoErrado { get; set; }

        public Alternativa ConverterParaDominio()
        {
            Alternativa alternativa = new Alternativa(this.IdPergunta, this.Texto, this.CertoErrado);
            return alternativa;

        }
    }
}