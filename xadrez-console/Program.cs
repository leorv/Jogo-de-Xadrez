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
            try
            {
                Tabuleiro.Tabuleiro Tab = new Tabuleiro.Tabuleiro(8, 8);

                Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new Posicao(2, 3));
                Tab.ColocarPecas(new Torre(Tab, Cor.Branco), new Posicao(5, 2));
                Tab.ColocarPecas(new Torre(Tab, Cor.Preto), new Posicao(0, 3));
                Tab.ColocarPecas(new Torre(Tab, Cor.Preto), new Posicao(6, 3));

                Tela.ImprimirTabuleiro(Tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
