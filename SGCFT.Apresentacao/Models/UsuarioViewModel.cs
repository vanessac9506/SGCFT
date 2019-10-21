using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        [Required(ErrorMessage ="Informe o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(6, ErrorMessage = "A senha tem que ter no minimo 6 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public Usuario ConverterParaDominio()
        {
            Usuario usuario = new Usuario(this.Nome,this.Senha,this.Email,long.Parse(this.Cpf),true);
            return usuario;

        }
    }
}