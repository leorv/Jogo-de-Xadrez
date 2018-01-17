using System;
using Tabuleiro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro.Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            terminada = false;
            JogadorAtual = Cor.Branco;
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao inicial, Posicao final)
        {
            Peca p = Tab.RetirarPeca(inicial);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(final);
            Tab.ColocarPecas(p, final);
        }

        public void RealizarJogada (Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Preto)
            {
                JogadorAtual = Cor.Branco;
            }
            else
            {
                JogadorAtual = Cor.Preto;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("Esta peça não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino (Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {//Se for FALSE, ocorre a exceção.
                throw new TabuleiroException("Posição inválida!");
            }
        }

        private void ColocarPecas()
        {
            Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPecas(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
        }

    }
}
