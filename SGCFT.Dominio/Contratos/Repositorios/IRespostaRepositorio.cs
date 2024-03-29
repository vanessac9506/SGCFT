﻿using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface IRespostaRepositorio
    {
        void Inserir(Resposta resposta);
        List<Resposta> SelecionarRespostasPorIds(List<int> ids);
    }
}
