﻿using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Servicos
{
    public interface ITreinamentoServico
    {
        Retorno InserirTreinamento(Treinamento treinamento);
        Retorno AlterarTreinamento(Treinamento treinamento);
    }
}
