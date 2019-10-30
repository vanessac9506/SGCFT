using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SGCFT.Apresentacao.Models
{
    public class ModuloExibicaoViewModel
    {
        public ModuloExibicaoViewModel()
        {

        }

        public ModuloExibicaoViewModel(int id, string titulo, List<Video> videos)
        {
            Id = id;
            Titulo = titulo;
            Videos = videos?.Select(x => new VideoViewModel(x.Id, x.Titulo)).ToList() ?? new List<VideoViewModel>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<VideoViewModel> Videos { get; set; }
    }
}