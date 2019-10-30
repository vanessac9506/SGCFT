using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SGCFT.Apresentacao.Models
{
    public class TreinamentoExibicaoViewModel
    {
        public TreinamentoExibicaoViewModel()
        {

        }
        public TreinamentoExibicaoViewModel(int id, string tema, string descricao, string duracao, string nomeAutor, List<Modulo> modulos)
        {
            this.Id = id;
            this.Tema = tema;
            this.Duracao = duracao;
            this.NomeAutor = nomeAutor;
            this.DescricaoTreinamento = descricao;
            this.Modulos = modulos?.Select(x => new ModuloViewModel(x.Id, x.Titulo)).ToList() ?? new List<ModuloViewModel>();
            if(this.Modulos != null)
            {
                this.IdModuloInicial = this.Modulos.FirstOrDefault()?.Id ?? 0;
                this.TituloModuloInicial = this.Modulos.FirstOrDefault()?.Titulo ?? string.Empty;
            }
        }

        public TreinamentoExibicaoViewModel(int id, string tema, string nomeAutor)
        {
            Id = id;
            Tema = tema;
            NomeAutor = nomeAutor;
        }

        public int Id { get; set; }
        public string Tema { get; set; }
        public string Duracao { get; set; }
        public string NomeAutor { get; set; }
        public string DescricaoTreinamento { get; set; }
        public List<ModuloViewModel> Modulos { get; set; }
        public int IdModuloInicial { get; set; }
        public string TituloModuloInicial { get; set; }
    }
}