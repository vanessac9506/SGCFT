using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface IAlternativaRepositorio
    {
        void Inserir(Alternativa alternativa);
        void Alterar(Alternativa alternativa);
    }
}
