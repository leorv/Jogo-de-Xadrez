using System;
using Tabuleiro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class Rei : Peca
    {
        /*Aqui o Rei recebe o tabuleiro e a cor, passando para a classe Pai
         * Pois quando formos colocar o tabuleiro, é chamado Tab.Peca(i,j)
         * E não dá pra fazer por exemplo, um sistema de if pra cada peça
         * se vai ser Rei ou Torre, etc. E sim fazer isso, apenas uma Classe Peça
         * (classe pai) que vai chamar o método ToString do Rei, por exemplo.
         * Isso foi o que entendi.
         */
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro.Tabuleiro Tab, Cor Cor, PartidaDeXadrez partida) : base(Tab, Cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            //Serão descritos os movimentos do Rei.
            //Norte
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;                
            }
            //Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sul
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Oeste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.VerificarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #JogadaEspecial Roque

            if (QtdMovimentos == 0 && !partida.Xeque)
            {
                // #JogadaEspecial Roque Pequeno
                Posicao PosTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (TesteTorreParaRoque(PosTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // #JogadaEspecial Roque Grande
                Posicao PosTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (TesteTorreParaRoque(PosTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }

            }

            return mat;
        }

        private bool TesteTorreParaRoque (Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);/*criamos uma peça auxiliar para capturar
            * o que existe na posição e dizer se é nulo (não tem nada, pode mover)
            * ou se existe uma peça de cor diferente, então pode mover tbm
            * para capturá-la.*/
            return p == null || p.Cor != Cor;
            /*não é necessário colocar this.Cor, pois está sendo comparado
             * a cor da peça na posição "tal" com a cor do rei.
             * Retorna TRUE se for possível mover. */
        }


    }
}
