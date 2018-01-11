using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro (int Linhas, int Colunas)
        {
            this.Linhas = Linhas;
            this.Colunas = Colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca (int Linhas, int Colunas)
        {
            return Pecas[Linhas, Colunas];
        }

        public void ColocarPecas(Peca P, Posicao Posicao)
        {
            Pecas[Posicao.Linha, Posicao.Coluna] = P;
            P.Posicao = Posicao;
        }
    }
}
