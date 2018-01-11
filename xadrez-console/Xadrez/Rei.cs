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
        public Rei(Tabuleiro.Tabuleiro Tab, Cor Cor) : base(Tab, Cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
