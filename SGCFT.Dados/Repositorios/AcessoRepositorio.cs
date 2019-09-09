using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Repositorios
{
    public class AcessoRepositorio : IAcessoRepositorio
    {
        private readonly Contexto _contexto;

        public AcessoRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Inserir(Acesso acesso)
        {
            _contexto.Acesso.Add(acesso);
            _contexto.SaveChanges();
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
