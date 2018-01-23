using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca( Tabuleiro Tab, Cor Cor)
        {
            Posicao = null;
            this.Tab = Tab;
            this.Cor = Cor;
            QtdMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QtdMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            QtdMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] MovimentosPossiveis();
        /* Poderíamos usar virtual ao invés de abstract, pois o virtual
         * diz que o método pode ser sobreescrito pelas classes filhas
         * e se nenhuma classe filha o sobrescreve, quando chamada ele
         * iria executar o da classe pai, e não é isso que queremos.
         * Para obrigar as classes filhas a terem um método que sobrescreva
         * (override) este da classe pai devemos usar o abstract no
         * método. Pois não queremos que nenhuma classe filha chame a 
         * Classe pai.*/      
         
        public bool PodeMoverPara(Posicao destino)
        {
            return MovimentosPossiveis()[destino.Linha, destino.Coluna];
            //Caso TRUE, pode mover para o destino.
        }
    }
}
