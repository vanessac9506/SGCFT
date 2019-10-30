using SGCFT.Dominio.Entidades;
using System.Collections.Generic;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface IModuloRepositorio
    {
        void Inserir(Modulo modulo);
        void Alterar(Modulo modulo);
        List<Modulo> SelecionarPorIdTreinamento(int idTreinamento);
        Modulo ObterModuloPorId(int id);
    }
}
