﻿using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface ITreinamentoRepositorio
    {
        void Inserir(Treinamento treinamento);
        void Alterar(Treinamento treinamento);
        List<Treinamento> selecionarTreinamentosPorUsuario(int idAutor);
        Treinamento ObterPorId(int id);
    }
}
