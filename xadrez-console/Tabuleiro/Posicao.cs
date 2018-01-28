
namespace Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao (int Linha, int Coluna)
        {
            this.Linha = Linha;
            this.Coluna = Coluna;
        }

        public override string ToString()
        {
            return "(" + Linha + ", " + Coluna + ")";
        }

        public void DefinirValores(int Linha, int Coluna)
        {
            /* Auxilia na verificação dos movimentos possíveis de
             * cada peça*/
            this.Linha = Linha;
            this.Coluna = Coluna;
        }

    }
}
