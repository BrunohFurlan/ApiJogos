namespace ApiJogos.Model
{
    public class Jogo
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = String.Empty;

        public string Genero { get; set; } = String.Empty;

        public string Plataforma { get; set; } = String.Empty;

        public int AnoLancamento { get; set; }

        public bool Zerado { get; set; }
    }
}
