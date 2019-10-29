using SGCFT.Dominio.Entidades;
using System.Collections.Generic;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface IVideoRepositorio
    {
        void Inserir(Video video);
        void Alterar(Video video);
        List<Video> SelecionarVideosParaExibicao();
        Video ObterVideoPorIdModulo(int idModulo);
        byte[] ObterConteudoVideoPorId(int id);
    }
}
