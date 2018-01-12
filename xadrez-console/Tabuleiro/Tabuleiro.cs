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

        //Aqui faremos uma sobrecarga no método Peca.
        public Peca Peca (Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);//saber se está dentro dos limites do tabuleiro.
            return Peca(pos) != null;/* Se a matriz peça já tem uma peça em determinada
            posição, ela vai verificar o seguinte:
            - se a peca(pos) é diferente de nulo, ou seja, se não tem nada (nenhuma peça)
            nesta posição, a condição é satisfeita e me retorna TRUE.
            - se a peca(pos) é nulo, a condição de ser diferente não é satisfeita e me
            retornará FALSE.*/
        }

        public void ColocarPecas(Peca P, Posicao Posicao)
        {
            if (ExistePeca(Posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição.");
            }
            Pecas[Posicao.Linha, Posicao.Coluna] = P;
            P.Posicao = Posicao;
        }

        public bool VerificarPosicao(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            /*retornamos "true" sem fazer o else, pois o return já corta o método*/
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!VerificarPosicao(pos))
            {
                // ! significa "não", ou seja, se retornou falso lá. Lança a exceção.
                throw new TabuleiroException("Posição Inválida!");
            }
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }
            Peca aux = Peca(pos);/*Criando uma peça auxiliar e recebendo o peça na
            posição "pos". Logo dando o valor nulo para sua posição e fazendo com
            que a varíavel aux fique nula também.*/
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }
    }
}
