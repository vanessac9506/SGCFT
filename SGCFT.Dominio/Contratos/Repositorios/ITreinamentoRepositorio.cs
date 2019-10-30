using SGCFT.Dominio.Entidades;
using System.Collections.Generic;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface ITreinamentoRepositorio
    {
        void Inserir(Treinamento treinamento);
        void Alterar(Treinamento treinamento);
        List<Treinamento> selecionarTreinamentosPorUsuario(int idAutor);
        Treinamento ObterPorId(int id);
        List<Treinamento> SelecionarPrincipaisVideos();
        Treinamento ObterParaExibicao(int id);
    }
}
