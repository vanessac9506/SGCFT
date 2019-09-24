﻿using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Servicos
{
    public interface IAlternativaServico
    {
        Retorno InserirAlternativa(Alternativa alternativa);
        Retorno AlterarAlternativa(Alternativa alternativa);
    }
}
