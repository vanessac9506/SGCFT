﻿using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Servicos
{
    public interface IVideoServico
    {
        Retorno InserirVideo(Video video);
    }
}
