using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SGCFT.Dados.Repositorios
{
    public class ModuloRepositorio : IModuloRepositorio
    {
        private readonly Contexto _contexto;

        public ModuloRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Alterar(Modulo modulo)
        {
            _contexto.Entry<Modulo>(modulo).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Modulo modulo)
        {
            _contexto.Modulo.Add(modulo);
            _contexto.SaveChanges();
        }

        public List<Modulo> SelecionarPorIdTreinamento(int idTreinamento)
        {
            var query = _contexto.Modulo.Where(x => x.IdTreinamento == idTreinamento);
            return query.ToList();
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
        }
    }
}
