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
        private int Turno;
        private Cor JogadorAtual;
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

        private void ColocarPecas()
        {
            Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
        }

    }
}
