using SGCFT.Dominio.Entidades;

namespace SGCFT.Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio
    {
        bool ValidarEmailCadastrado(string email);
        bool ValidarDocumentoCadastrado(long documento, bool isCpf);
        void Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        int ObterIdUsuarioPorEmail(string email);
    }
}
