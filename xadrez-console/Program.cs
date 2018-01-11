using System;
using Tabuleiro;
using Xadrez;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro.Tabuleiro Tab = new Tabuleiro.Tabuleiro(8, 8);

            Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new Posicao(0, 0));
            Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new Posicao(1, 3));
            Tab.ColocarPecas(new Rei(Tab, Cor.Branco), new Posicao(2, 4));


            Tela.ImprimirTabuleiro(Tab);

            Console.ReadLine();
        }
    }
}
