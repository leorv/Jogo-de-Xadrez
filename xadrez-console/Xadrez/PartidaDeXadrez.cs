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
        private HashSet<Peca> Pecas;//Coleção que obedece regras de conjunto.
        private HashSet<Peca> PecasCapturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            terminada = false;
            JogadorAtual = Cor.Branco;
            //Antes de colocar peças, instanciar conjuntos.
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao inicial, Posicao final)
        {
            Peca p = Tab.RetirarPeca(inicial);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(final);
            Tab.ColocarPecas(p, final);
            if (PecaCapturada != null)
            {
                PecasCapturadas.Add(PecaCapturada);
            }
        }

        public void RealizarJogada (Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public HashSet<Peca> Capturadas(Cor cor)
        {
            HashSet<Peca> Aux = new HashSet<Peca>();
            foreach (Peca x in PecasCapturadas)
            {
                if (x.Cor == cor)
                {
                    Aux.Add(x);
                }
            }
            return Aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> Aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    Aux.Add(x);
                }
            }
            Aux.ExceptWith(Capturadas(cor));
            return Aux;
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

        public void ColocarNovaPeca(char Coluna, int Linha, Peca Peca)
        {
            Tab.ColocarPecas(Peca, new PosicaoXadrez(Coluna, Linha).ToPosicao());
            Pecas.Add(Peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branco));

            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preto));

        }

    }
}
