using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Servicos
{
    public class ModuloServico : IModuloServico
    {
        private IModuloRepositorio _moduloRepositorio;
        public ModuloServico(IModuloRepositorio moduloRepositorio)
        {
            this._moduloRepositorio = moduloRepositorio;
        }
               
        public Retorno InserirModulo(Modulo modulo)
        {
            Retorno retorno = new Retorno();

            if (modulo == null)
            {
                retorno.AdicionarErro("Módulo não informado");
                return retorno;
            }

            retorno = modulo.ValidarDominio();
            if (retorno.Sucesso)
                _moduloRepositorio.Inserir(modulo);
                       
            return retorno;
        }

        public Retorno AlterarModulo(Modulo modulo)
        {
            Retorno retorno = new Retorno();
            if (modulo == null)
            {
                retorno.AdicionarErro("Módulo não informado");
                return retorno;
            }
            retorno = modulo.ValidarDominio();
            if (retorno.Sucesso)
                _moduloRepositorio.Alterar(modulo);

            return retorno;
        }
    }
}
