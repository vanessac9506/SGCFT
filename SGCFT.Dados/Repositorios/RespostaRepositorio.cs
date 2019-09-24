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
    public class RespostaRepositorio : IRespostaRepositorio
    {
        private readonly Contexto _contexto;

        public RespostaRepositorio()
        {
            _contexto = new Contexto();
        }
        public void Alterar(Resposta resposta)
        {
            _contexto.Entry<Resposta>(resposta).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Resposta resposta)
        {
            _contexto.Resposta.Add(resposta);
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
