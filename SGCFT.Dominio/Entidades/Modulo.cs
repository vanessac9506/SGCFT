using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Modulo
    {
        public int Id { get; set; }
        public int IdTreinamento { get; set; }
        public Treinamento Treinamento { get; set; }
        public string Titulo { get; set; }
    }
}
