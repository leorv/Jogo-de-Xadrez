using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Posicao Posicao, Tabuleiro Tab, Cor Cor)
        {
            this.Posicao = Posicao;
            this.Tab = Tab;
            this.Cor = Cor;
            QtdMovimentos = 0;
        }
    }
}
