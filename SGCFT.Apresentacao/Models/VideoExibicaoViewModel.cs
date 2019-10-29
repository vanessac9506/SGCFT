namespace SGCFT.Apresentacao.Models
{
    public class VideoExibicaoViewModel
    {
        public VideoExibicaoViewModel(int id, string nomeTreinamento, string nomeModulo, string tituloVideo, int idModulo)
        {
            Id = id;
            NomeTreinamento = nomeTreinamento;
            NomeModulo = nomeModulo;
            TituloVideo = tituloVideo;
            IdModulo = idModulo;
        }

        public int Id { get; set; }
        public string NomeTreinamento { get; set; }
        public string NomeModulo { get; set; }
        public string TituloVideo { get; set; }
        public int IdModulo { get; set; }
    }
}