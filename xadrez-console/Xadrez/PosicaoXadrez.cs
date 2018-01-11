using System;
using Tabuleiro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char Coluna, int Linha)
        {
            this.Coluna = Coluna;
            this.Linha = Linha;
        }

        public Posicao ToPosicao()
        {
            /*Macete para a conversão das linhas e colunas de um
             * tabuleiro real para a matriz do C#. */
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
