﻿using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SGCFT.Apresentacao.Models
{
    public class QuestionarioViewModel
    {
        public QuestionarioViewModel(Pergunta pergunta)
        {
            this.IdPergunta = pergunta.Id;
            this.Pergunta = pergunta.Texto;
            this.Alternativas = pergunta.Alternativas.Select(x => new AlternativaViewModel(x.Id,x.Texto)).ToList();
        }

        public int IdPergunta { get; set; }
        public string Pergunta { get; set; }
        public List<AlternativaViewModel> Alternativas { get; set; }
    }
}