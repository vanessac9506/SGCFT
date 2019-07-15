using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Entidades
{
    public class Treinamento
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public Usuario Autor { get; set; }
        public int IdAutor { get; set; }
        public List<Modulo> Modulos { get; set; }
    }
}
