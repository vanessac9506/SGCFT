using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class ModuloViewModel
    {
        public ModuloViewModel()
        {

        }

        public ModuloViewModel(int id, string titulo)
        {
            this.Id = id;
            this.Titulo = titulo;
        }

        public int Id { get; set; }
        public int IdTreinamento { get; set; }
        [Required(ErrorMessage = "Informe o título")]
        public string Titulo { get; set; }
        public List<TreinamentoViewModel> ListaTreinamentos { get; set; }

        public Modulo ConverterParaDominio()
        {
            Modulo modulo = new Modulo(this.IdTreinamento, this.Titulo);
            return modulo;
        }


    }
}