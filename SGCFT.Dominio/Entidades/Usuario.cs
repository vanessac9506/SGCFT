using SGCFT.Utilitario;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SGCFT.Dominio.Entidades
{
    public class Usuario
    {
        protected Usuario()
        {

        }

        private Usuario(string nome, string senha, string email)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
        }

        public Usuario(string nome, string senha, string email, long documento, bool isCpf):this(nome,senha,email)
        {
            if (isCpf)
                this.Cpf = documento;
            else
                this.Cnpj = documento;
        }
    
        public int Id { get; set; }
        public long? Cpf { get; private set; }
        public long? Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }

        public Retorno ValidarDominio()
        {
            Retorno retorno = new Retorno();

            if (string.IsNullOrEmpty(this.Nome) || string.IsNullOrWhiteSpace(this.Nome))
                retorno.AdicionarErro("Nome inválido!");

            if (string.IsNullOrEmpty(this.Senha) || string.IsNullOrWhiteSpace(this.Senha))
                retorno.AdicionarErro("Senha inválida!");

            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match matchEmail = regexEmail.Match(this.Email);
            if (!matchEmail.Success)
                retorno.AdicionarErro("Email inválido!");

            if (this.Cpf != null && this.Cpf.ToString().Length != 11)
                retorno.AdicionarErro("Cpf inválido!");

            if (this.Cnpj != null && this.Cnpj.ToString().Length != 14)
                retorno.AdicionarErro("Cnpj inválido!");

            return retorno;
        }


    }
}
