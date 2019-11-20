using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SGCFT.Dados.Repositorios
{
    public class RespostaRepositorio : IRespostaRepositorio
    {
        private readonly Contexto _contexto;

        public RespostaRepositorio()
        {
            _contexto = new Contexto();
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

        public List<Resposta> SelecionarRespostasPorIds(List<int> ids)
        {
            var respostas = _contexto.Resposta.Where(x => ids.Contains(x.Id)).ToList();
            return respostas;
        }
    }
}
