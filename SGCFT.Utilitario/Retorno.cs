using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Utilitario
{
    public class Retorno
    {
        public Retorno()
        {
            this.Sucesso = true;
            this.Mensagens = new List<string>();
        }
               
        public bool Sucesso { get; private set; }
        public List<string> Mensagens { get; private set; }


        public void AdicionarErro(params string[] erro)
        {
            this.Mensagens.AddRange(erro);
            this.Sucesso = false;
        }


    }
}
