
namespace SGCFT.Dominio.Entidades
{
    public class ResultadoResposta
    {
        public ResultadoResposta(int idPergunta, int idAlternativaEscolhida, int idAlternativaCorreta)
        {
            IdPergunta = idPergunta;
            IdAlternativaEscolhida = idAlternativaEscolhida;
            IdAlternativaCorreta = idAlternativaCorreta;
            Acertou = idAlternativaEscolhida == idAlternativaCorreta;
        }

        public int IdPergunta { get; set; }
        public int IdAlternativaEscolhida { get; set; }
        public int IdAlternativaCorreta { get; set; }
        public bool Acertou { get; set; }
    }
}
