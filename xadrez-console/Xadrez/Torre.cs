using System;
using Tabuleiro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro.Tabuleiro Tab, Cor Cor) : base(Tab, Cor)
        {

        }

        public override string ToString()
        {
            return "T ";
        }
    }
}
